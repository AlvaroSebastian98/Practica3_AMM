using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practica3
{
    public class PersonaItemDatabase
    {
        readonly SQLiteAsyncConnection database;

        public PersonaItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<PersonaItem>().Wait();
        }

        public Task<List<PersonaItem>> GetItemsAsync()
        {
            return database.Table<PersonaItem>().ToListAsync();
        }

        public Task<List<PersonaItem>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<PersonaItem>("SELECT * FROM [PersonaItem]");
        }

        public Task<PersonaItem> GetItemAsync(int id)
        {
            return database.Table<PersonaItem>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(PersonaItem item)
        {
            if (item.ID != 0)
            {
                return database.UpdateAsync(item);
            }
            else
            {
                return database.InsertAsync(item);
            }
        }

        public Task<int> DeleteItemAsync(PersonaItem item)
        {
            return database.DeleteAsync(item);
        }
    }
}