using AutoMapper;
using E_commerce_System_currency.Models;
using E_commerce_System_currency.Repository.RepositoryManager;
using E_commerce_System_currency.Services.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace E_commerce_System_currency.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ItemsController : ControllerBase
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public ItemsController(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        #region Get All Items endpoint
        [Authorize(Roles = "User , Admin")]
        [HttpGet("GetAllProducts")]
        public async Task<IActionResult> GetAllItems()
        {
            var items = await _repository.Item.GetAllItemsAsync(false);
            var returnItems = _mapper.Map<IEnumerable<OutPutItemDto>>(items);
            return Ok(returnItems);
        }
        #endregion

        #region get item by id
        [Authorize(Roles = "User , Admin")]
        [HttpGet("GetProduct/{Id}")]
        public async Task<IActionResult> GetProduct(int Id)
        {
            var item = await _repository.Item.GetItemByIdAsync(Id, false);
            if (item == null)
                return BadRequest($"The Product With Id {Id} Doesn't Exists!");

            var itemreturn = _mapper.Map<OutPutItemDto>(item);
            return Ok(itemreturn);
        }

        #endregion

        #region Add Items endpoint
        [Authorize(Roles = "Admin")]
        [HttpPost("AddProduct")]
        public async Task<IActionResult> CreateItem([FromBody] AddItemDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var item = await _repository.Item.GetItemByName(model.ItemName, false);
            if (item != null)
                return BadRequest($"The Product With Name {model.ItemName} Already Exist!");

            item = _mapper.Map<Item>(model);

            _repository.Item.CreateItem(item);
            await _repository.SaveAsync();

            var Display = _mapper.Map<OutPutItemDto>(item);

            return Ok(Display);
        }
        #endregion

        #region update item
        [Authorize(Roles = "Admin")]
        //admin
        [HttpPut("updateProduct")]
        public async Task<IActionResult> UpdateItem([FromBody] UpdateItemDto model)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var itemforUpdate = await _repository.Item.GetItemByIdAsync(model.Id, true);
            if (itemforUpdate == null)
                return BadRequest($"TheProduct With Id {model.Id} Doesn't Exists!");

            var updateditem = _mapper.Map(model, itemforUpdate);

            await _repository.SaveAsync();
           
            var result = _mapper.Map<OutPutItemDto>(updateditem);
            return Ok(result);

        }
        #endregion

        #region Delete Item
        [Authorize(Roles = "Admin")]
        [HttpDelete("DeleteProduct/{Id}")]
        public async Task<IActionResult> DeleteProduct(int Id)
        {
            var Itemfordelete = await _repository.Item.GetItemByIdAsync(Id,true);
            if (Itemfordelete == null)
                return BadRequest($"TheProduct With Id {Id} Doesn't Exists!");

            _repository.Item.DeleteItem(Itemfordelete);

            _repository.SaveAsync();

            return Ok();
        }
        #endregion
    }
}
