using System.Security.Claims;
using AutoMapper;
using E_commerce_System_currency.CachingServices;
using E_commerce_System_currency.Models;
using E_commerce_System_currency.Repository.RepositoryManager;
using E_commerce_System_currency.Services.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace E_commerce_System_currency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IRedisCacheService _redisCacheService;
        private readonly IConfiguration _configuration;
        public OrdersController(IRepositoryManager repository,IMapper mapper,UserManager<ApplicationUser> userManager
            ,IRedisCacheService redisCacheService,IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _userManager = userManager;
            _redisCacheService = redisCacheService;
            _configuration = configuration;
        }


        #region Get All Orders
        [Authorize(Roles = "Admin")]
        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders()
        {

            var Orders =await _repository.Order.GetAllOrdersAsync(false);
    
            var Results = _mapper.Map<IEnumerable<OutPutOrderDto>>(Orders);

            return Ok(Results);
        }
        #endregion

        #region GetOrder by CustomerID
        [Authorize(Roles = "User , Admin")]
        [HttpGet("GetOrderByCustomerID")]
        public async Task<IActionResult> GetOrdersbyCustomerId()
        {
            string? Username = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            if (Username == null)
                return BadRequest("Register Or Login Please!");
            var user = await _userManager.FindByNameAsync(Username);

            var Orders = await _repository.Order.GetOrdersByCustomerId(user.Id,false);

            var Results = _mapper.Map<IEnumerable<OutPutOrderDto>>(Orders);

            return Ok(Results);
        }
        #endregion

        #region Create Order EndPoint
        [Authorize(Roles = "User , Admin")]
        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder(string CurrencyCode, string DiscountPromoCode, [FromBody] List<CreateOrderItems> products)
        {
            string? Username = User.FindFirstValue(ClaimTypes.NameIdentifier); // will give the user's userId
            if (Username == null)
                return BadRequest("Register Or Login Please!");
            var user = await _userManager.FindByNameAsync(Username);
            
            decimal totalPrice = 0;
            foreach (var Pro in products)
            {
                totalPrice += (Pro.Quantity * Pro.Price);
            }

            if (DiscountPromoCode == _configuration.GetSection("Discount")["PromoCode"])
            {
                totalPrice -= _configuration.GetValue<int>("Discount:Value");  
            }

            decimal exchangeRate= 0 ;
            if (CurrencyCode == _configuration.GetSection("BasicCurrency")["CurrencyCode"])
            {
                exchangeRate = 1;
            }
            else
            { 
                exchangeRate = _redisCacheService.GetExchangeRate(CurrencyCode);
            }
            decimal forignPrice = totalPrice * exchangeRate;

            var Order = new Order
            {
                TotalPrice = totalPrice,
                ExchangeRate = exchangeRate,
                ForignPrice = forignPrice,
                RequestDate = DateTime.Now,
                status = "open",
                CustomerId = user.Id,
                CurrencyCode = CurrencyCode,
                DiscountPromoCode = DiscountPromoCode,
                DiscountValue = _configuration.GetValue<int>("Discount:Value")
            };

            if (DiscountPromoCode != _configuration.GetSection("Discount")["PromoCode"])
            {
                Order.DiscountPromoCode = null;
                Order.DiscountValue =0;
            }

            _repository.Order.CreateOrder(Order);
            await _repository.SaveAsync();

            //var Ordersdetails = new List<Order_details>();
            foreach (var Pro in products)
            {
                var Orderdetails = new Order_details
                {
                    OrderId = Order.Id,
                    ItemId = Pro.Id,
                    ItemPrice = Pro.Price,
                    Quanitity = Pro.Quantity,
                    TotalPrice = Pro.Price * Pro.Quantity
                };

                _repository.OrderDetails.CreateOrderDetails(Orderdetails);
                await _repository.SaveAsync();
            }

            var Result=_mapper.Map<OutPutOrderDto>(Order);

            return Ok(Result);
        }
        #endregion

        #region Delete Order
        [Authorize(Roles = "Admin")]
        [HttpDelete("Delete/{Id}")]
        public async Task<IActionResult> DeleteOrder(int Id)
        {
            var OrderToDelete =await _repository.Order.GetOrderByIdAsync(Id, true);

            _repository.Order.DeleteOrder(OrderToDelete);

            await _repository.SaveAsync();
            return NoContent();
        }
        #endregion

        #region Close Order By Admin
        [Authorize(Roles = "Admin")]
        [HttpPut("CloseOrder/{Id}")]
        public async Task<IActionResult> CloseOrder(int Id)
        {
            var OrderToClose = await _repository.Order.GetOrderByIdAsync(Id, true);
            
            OrderToClose.ClosedOn=DateTime.Now;
            OrderToClose.status = "Close";

            await _repository.SaveAsync();

            return NoContent();
        }
        #endregion

    }
}
