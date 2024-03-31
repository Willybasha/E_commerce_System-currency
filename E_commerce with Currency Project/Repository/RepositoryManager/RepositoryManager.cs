using E_commerce_System_currency.Context;
using E_commerce_System_currency.Repository.EntitiesRepository;
using E_commerce_System_currency.Repository.EntitiesRepository.Interface;

namespace E_commerce_System_currency.Repository.RepositoryManager
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly ApplicationDbContext _context;
        private readonly Lazy<IitemRepository> _itemRepository;
        private readonly Lazy<IOrderRepository> _OrderRepository;
        private readonly Lazy<IOrderDetailsRepo> _OrderDetailsRepo;

        public RepositoryManager(ApplicationDbContext context)
        {
            _context = context;
            _itemRepository = new Lazy<IitemRepository>(() => new
           ItemRepository(context));
            _OrderRepository = new Lazy<IOrderRepository>(() => new
           OrderRepository(context));
            _OrderDetailsRepo = new Lazy<IOrderDetailsRepo>(() => new
           OrderDetailsRepo(context));
        }
        public IitemRepository Item =>_itemRepository.Value;

        public IOrderRepository Order => _OrderRepository.Value;

        public IOrderDetailsRepo OrderDetails=>_OrderDetailsRepo.Value;

        public async Task SaveAsync() => await _context.SaveChangesAsync();
    }
}
