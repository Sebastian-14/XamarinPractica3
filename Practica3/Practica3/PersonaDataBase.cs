using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Practica3
{
    public class PersonaDatabase
    {
        readonly SQLiteAsyncConnection database;

        public PersonaDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Persona>().Wait();
        }

        public Task<List<Persona>> GetItemsAsync()
        {
            return database.Table<Persona>().ToListAsync();
        }

        public Task<List<Persona>> GetItemsNotDoneAsync()
        {
            return database.QueryAsync<Persona>("SELECT * FROM [Persona]");
        }

        public Task<Persona> GetItemAsync(int id)
        {
            return database.Table<Persona>().Where(i => i.ID == id).FirstOrDefaultAsync();
        }

        public Task<int> SaveItemAsync(Persona item)
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

        public Task<int> DeleteItemAsync(Persona item)
        {
            return database.DeleteAsync(item);
        }
    }
}
