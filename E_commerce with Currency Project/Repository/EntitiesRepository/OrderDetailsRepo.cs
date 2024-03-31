using AutoMapper.Configuration;
using E_commerce_System_currency.Context;
using E_commerce_System_currency.Models;
using E_commerce_System_currency.Repository.EntitiesRepository.Interface;
using E_commerce_System_currency.Repository.GenericRepository;

namespace E_commerce_System_currency.Repository.EntitiesRepository
{
    internal sealed class OrderDetailsRepo : GenericRepository<Order_details>, IOrderDetailsRepo
    {
        public OrderDetailsRepo(ApplicationDbContext context) : base(context)
        {
        }

        public  void CreateOrderDetails(Order_details order_Details)=>
            Create(order_Details);
      
    }
}
