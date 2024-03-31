using E_commerce_System_currency.Models;

namespace E_commerce_System_currency.Repository.EntitiesRepository.Interface
{
    public interface IOrderRepository
    {
        Task<IEnumerable<Order>>GetAllOrdersAsync(bool trackChanges);

        Task<Order> GetOrderByIdAsync(int id, bool trackChanges);
        Task<IEnumerable<Order>> GetOrdersByCustomerId(string id, bool trackChanges);
        void CreateOrder(Order order);
        void DeleteOrder(Order order);

    }
}
