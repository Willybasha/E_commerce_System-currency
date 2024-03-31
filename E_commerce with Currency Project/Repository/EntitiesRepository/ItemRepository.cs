using E_commerce_System_currency.Context;
using E_commerce_System_currency.Models;
using E_commerce_System_currency.Repository.EntitiesRepository.Interface;
using E_commerce_System_currency.Repository.GenericRepository;
using Microsoft.EntityFrameworkCore;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace E_commerce_System_currency.Repository.EntitiesRepository
{
    internal sealed class ItemRepository : GenericRepository<Item> , IitemRepository
    {
     public ItemRepository(ApplicationDbContext context) : base(context)
    { 
    }
        public async Task<IEnumerable<Item>> GetAllItemsAsync(bool trackChanges) 
            => await FindAll(trackChanges).OrderBy(c => c.ItemName).ToListAsync();

        public async Task<Item> GetItemByIdAsync(int id, bool trackchanges)
            => await FindByCondition(c => c.Id.Equals(id), trackchanges).SingleOrDefaultAsync();

        public async Task<Item> GetItemByName(string name, bool trackChanges)
            => await FindByCondition(n => n.ItemName.Equals(name), trackChanges).SingleOrDefaultAsync();


        public void CreateItem(Item item)=> Create(item);

        public void DeleteItem(Item Item)=> Delete(Item);

    }
}
