using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using navapp.Models;
using SQLite;
namespace navapp
{
    public class LocalDBService
    {
        private const string DB_NAME = "demo_local_db.db1";
        private readonly SQLiteAsyncConnection _connection;

        public LocalDBService()
        {
            _connection = new SQLiteAsyncConnection(Path.Combine(FileSystem.AppDataDirectory, DB_NAME));
            _connection.CreateTableAsync<Book>().Wait();
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _connection.Table<Book>().ToListAsync();
        }

        public async Task<Book> GetById(int id)
        {
            return await _connection.Table<Book>().Where(x => x.Id == id).FirstOrDefaultAsync();
        }

        public async Task Create(Book book)
        {
            await _connection.InsertAsync(book);
        }

        public async Task Update(Book book)
        {
            await _connection.UpdateAsync(book);
        }

        public async Task Delete(Book book)
        {
            await _connection.DeleteAsync(book);
        }
    }
}




