using E_commerce_System_currency.Models;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace E_commerce_System_currency.Repository.EntitiesRepository.Interface
{
    public interface IitemRepository 
    {
        Task<IEnumerable<Item>> GetAllItemsAsync(bool trackChanges);
        Task<Item>GetItemByIdAsync(int id, bool trackchanges);

        Task<Item> GetItemByName(string name, bool trackChanges);

        void CreateItem(Item item);
        void DeleteItem(Item Item);
    }
}
