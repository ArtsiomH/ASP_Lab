using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity;

namespace _60331_Glotov.DAL
{
    public partial class ApplicationDbContext
    {
        public DbSet<Book> Books { get; set; }

        
        public void Populate()
        {
            List<IdentityRole> d = Roles.ToList();
            //if (!Roles.Any())
            //{
            //    // Создаем менеджеры ролей и пользователей
            //    var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this));
            //    var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this));
            //    // Создаем роли "admin" и "user"
            //    roleManager.Create(new IdentityRole("admin"));
            //    roleManager.Create(new IdentityRole("user"));
            //    // Создаем пользователя
            //    var userAdmin = new ApplicationUser
            //    {
            //        Email = "admin@mail.ru",
            //        UserName = "admin@mail.ru",
            //        NickName = "SuperHero"
            //    };
            //    userManager.CreateAsync(userAdmin, "123456").Wait();
            //    // Добавляем созданного пользователя в администраторы
            //    userManager.AddToRole(userAdmin.Id, "admin");
            //}
            if(!Roles.Any())
            {
                //Создаем менеджеры ролей и пользователей
                RoleManager<IdentityRole> roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(this));
                UserManager<ApplicationUser> userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(this));

                //создаем роли "админ" и "user"
                roleManager.Create(new IdentityRole("admin"));
                roleManager.Create(new IdentityRole("user"));

                //создаем пользователя
                ApplicationUser userAdmin = new ApplicationUser
                {
                    Email = "admin@gmail.com",
                    UserName = "admin@gmail.com",
                    NickName = "mainUser"
                };
                userManager.CreateAsync(userAdmin, "123456").Wait();

                //Добавляем созданного пользователя в администраторы
                userManager.AddToRole(userAdmin.Id, "admin");
            }


            if (!Books.Any())
            {
                List<Book> books = new List<Book>
                {
                    new Book { BookId = 1, BookName = "Цветы для Элджернона", Description ="Из дебилов - в гении, из гениев - в...", CategoryName = "Художественная литература", Price = 14},
                    new Book { BookId = 2, BookName = "Мятная сказка", Description ="Прочитай. Забудь.", CategoryName = "Художественная литература", Price = 16},
                    new Book { BookId = 3, BookName = "Метро 2033", Description ="Конец света. Начало истории.", CategoryName = "Художественная литература", Price = 26},
                    new Book { BookId = 4, BookName = "Ведьмак", Description ="Ведьмак - это мир на острие меча", CategoryName = "Художественная литература", Price = 16},
                    new Book { BookId = 5, BookName = "Совершенный код. Мастер-класс", Description ="Руководство по стилю программирования и конструированию ПО", CategoryName = "Компьютеры и Интернет", Price = 46},
                    new Book { BookId = 6, BookName = "Изучаем Java", Description ="Нашим мозгам. За то, что всегда были с нами", CategoryName = "Компьютеры и Интернет", Price = 44},
                    new Book { BookId = 7, BookName = "Head First. Паттерны проектирования", Description ="Настрой свой мозг на дизайн паттернов", CategoryName = "Компьютеры и Интернет", Price = 46},
                    new Book { BookId = 8, BookName = "Как пасти котов", Description ="Наставление для программистов, руководящих другими программистами", CategoryName = "Компьютеры и Интернет", Price = 26},
                    new Book { BookId = 9, BookName = "Тонкое искусство пофигизма", Description ="Тонкое искусство наплевать", CategoryName = "Популярная психология", Price = 23},
                    new Book { BookId = 10, BookName = "Краткая история времени", Description ="От Большого взрыва до черных дыр", CategoryName = "Научно-популярная литература", Price = 23},
                    new Book { BookId = 11, BookName = "Sapiens. Краткая история человечества", Description ="О важнейших вопросах истории и современности - незабываемо ярко", CategoryName = "Научно-популярная литература", Price = 46},
                    new Book { BookId = 12, BookName = "Чизкейк внутри", Description ="Сложные и необычные торты - легко!", CategoryName = "Кулинария", Price = 20},
                    new Book { BookId = 13, BookName = "Происхождение", Description ="Весьма достойный детектив", CategoryName = "Художественная литература", Price = 28},
                    new Book { BookId = 14, BookName = "Уникальный экземпляр", Description ="Истории о том о сём", CategoryName = "Художественная литература", Price = 19},
                    new Book { BookId = 15, BookName = "Омерзительное искусство", Description ="Юмор и хоррор шедевров живописи", CategoryName = "Искусство", Price = 27},
                    new Book { BookId = 16, BookName = "Искусство рисунка", Description ="Множество технических приемов рисования", CategoryName = "Искусство", Price = 22},
                    new Book { BookId = 17, BookName = "Как устроено кино", Description ="Теория и история кинематографа", CategoryName = "Искусство", Price = 38}
                };
                Books.AddRange(books);
                SaveChanges();
            }
        }
    }
}
