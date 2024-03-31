using System.Xml.Linq;
using E_commerce_System_currency.Context;
using E_commerce_System_currency.Models;
using E_commerce_System_currency.Repository.EntitiesRepository.Interface;
using E_commerce_System_currency.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;

namespace E_commerce_System_currency.Repository.EntitiesRepository
{
    internal sealed class OrderRepository : GenericRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Order>> GetAllOrdersAsync(bool trackChanges)=> 
            await FindAll(trackChanges).ToListAsync();

        public async Task<Order> GetOrderByIdAsync(int id, bool trackChanges)=>
            await FindByCondition(n => n.Id.Equals(id), trackChanges).SingleOrDefaultAsync();

        public async Task<IEnumerable<Order>> GetOrdersByCustomerId(string id,bool trackChanges)
            => await FindByCondition(n => n.CustomerId.Equals(id), trackChanges).ToListAsync();

        public void CreateOrder(Order order)=>Create(order);

        public void DeleteOrder(Order order)=> Delete(order);




    }
}
