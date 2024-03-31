using E_commerce_System_currency.Repository.EntitiesRepository.Interface;

namespace E_commerce_System_currency.Repository.RepositoryManager
{
    public interface IRepositoryManager
    {
        IitemRepository Item { get; }
        IOrderRepository Order { get; }
        IOrderDetailsRepo OrderDetails { get; }
        Task SaveAsync();

    }
}
