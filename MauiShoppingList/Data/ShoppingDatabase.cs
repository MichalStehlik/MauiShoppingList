using MauiShoppingList.Models;
using SQLite;

namespace MauiShoppingList.Data
{
    internal class ShoppingDatabase
    {
        SQLiteAsyncConnection _database;

        async Task Init()
        {
            if (_database is not null)
                return;

            _database = new SQLiteAsyncConnection(Constants.DatabasePath, Constants.Flags);
            var result = await _database.CreateTableAsync<ShoppingItem>();
        }

        public async Task<List<ShoppingItem>> GetItemsAsync()
        {
            await Init();
            return await _database.Table<ShoppingItem>().ToListAsync();
        }

        public async Task<ShoppingItem> GetItemAsync(int id)
        {
            await Init();
            return await _database.Table<ShoppingItem>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public async Task<int> StoreItemAsync(ShoppingItem item)
        {
            await Init();
            if (item.Id != 0)
                return await _database.UpdateAsync(item);
            else
                return await _database.InsertAsync(item);
        }

        public async Task<int> DeleteItemAsync(ShoppingItem item)
        {
            await Init();
            return await _database.DeleteAsync(item);
        }
    }
}
