using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _60331_Glotov.DAL
{
    public class FakeRepository : IRepository<Book>
    {
        public void Create(Book t)
        {
            throw new NotImplementedException();
        }

        public void Delete(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> Find(Func<Book, bool> predicate)
        {
            throw new NotImplementedException();
        }

        public Book Get(int id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Book> GetAll()
        {
            return new List<Book>
            {
                new Book { BookId = 1, BookName = "Цветы для Элджернона", Description ="Из дебилов - в гении, из гениев - в...", CategoryName = "Художественная литература", Price = 14},
                new Book { BookId = 2, BookName = "Мятная сказка", Description ="Прочитай. Забудь.", CategoryName = "Художественная литература", Price = 16},
                new Book { BookId = 3, BookName = "Метро 2033", Description ="Конец света. Начало истории.", CategoryName = "Фэнтези и фантастика", Price = 26},
                new Book { BookId = 4, BookName = "Ведьмак", Description ="Ведьмак - это мир на острие меча", CategoryName = "Фэнтези и фантастика", Price = 16},
                new Book { BookId = 5, BookName = "Совершенный код. Мастер-класс", Description ="Руководство по стилю программирования и конструированию ПО", CategoryName = "Компьютеры и Интернет", Price = 46}
            };
        }

        public Task<Book> GetAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Book t)
        {
            throw new NotImplementedException();
        }
    }
}
