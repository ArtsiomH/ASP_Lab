using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;

namespace _60331_Glotov.DAL
{
    public class EFBookRepository : IRepository<Book>
    {
        private ApplicationDbContext context;
        private DbSet<Book> table;

        public EFBookRepository(ApplicationDbContext context)
        {
            this.context = context;
            table = context.Books; 
        }

        public void Create(Book t)
        {
            table.Add(t);
            context.SaveChanges();
        }

        public void Delete(int id)
        {
            context.Entry(new Book { BookId = id }).State = EntityState.Deleted;
            context.SaveChanges();
        }

        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            return table.Where(predicate).ToList();
        }

        public Book Get(int id)
        {
            return table.Find(id);
        }

        public IEnumerable<Book> GetAll()
        {
            return table;
        }

        public Task<Book> GetAsync(int id)
        {
            return context.Books.FindAsync(id);
        }

        public void Update(Book t)
        {
            if (t.Image == null)
            {
                Book book = context.Books.AsNoTracking()
                                         .Where(x => x.BookId == t.BookId)
                                         .FirstOrDefault();
                t.Image = book.Image;
                t.MimeType = book.MimeType;
            }
            context.Entry(t).State = EntityState.Modified;
            context.SaveChanges();
        }
    }
}
