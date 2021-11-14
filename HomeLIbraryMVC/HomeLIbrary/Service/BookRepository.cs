using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HomeLIbrary.Service
{
    public class BookRepository : IRepository
    {
        private readonly HomeLibraryDBContext _context;

        public BookRepository(HomeLibraryDBContext context)
        {
            _context = context;
        }

        public void Create(Book item)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                 new SqlParameter("@name", item.NameBook),
                 new SqlParameter("@birth", item.Datebirth),
                 new SqlParameter("@author", item.Author),
                 new SqlParameter("@contents", item.Contents)
            };
            _context.Database.ExecuteSqlRaw("AddBook @name, @birth, @author, @contents", parameters.ToArray());
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            _context.Database.ExecuteSqlRaw("DeleteBook @Id", new SqlParameter("@Id", id));
            _context.SaveChanges();
        }

        public Book GetBook(int id)
        {
            var book = _context.Books.FromSqlRaw("GetBook @Id", new SqlParameter("@Id", id)).ToList();
            return book.FirstOrDefault(); 
        }

        public IEnumerable<Book> GetBookList()
        {
            return _context.Books.FromSqlRaw("GetBooks").ToList();
        }

        public void Update(Book item)
        {
            List<SqlParameter> parameters = new List<SqlParameter>()
            {
                 new SqlParameter("@Id", item.Id),
                 new SqlParameter("@name", item.NameBook),
                 new SqlParameter("@birth", item.Datebirth),
                 new SqlParameter("@author", item.Author),
                 new SqlParameter("@contents", item.Contents)
            };
            _context.Database.ExecuteSqlRaw("UpdateBook @Id, @name, @birth, @author, @contents", parameters.ToArray());
            _context.SaveChanges();
        }
    }
}
