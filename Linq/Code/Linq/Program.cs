using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinQDemo
{
    class Program
    {

        static void Main(string[] args)
        {
            #region Mock Data

            List<User> users = new List<User>()
            {
                
                new User()
                {
                    Name="zhang",
                    Age = 20,
                    Contacts = new List<Contact>()
                    {
                        new Contact() {Title="QQ",Content="123456" },
                        new Contact() {Title="Phone",Content="12312341234" },
                        new Contact() {Title="Addr",Content="shanghai" },
                    }
                },
                new User()
                {
                    Name="wang",
                    Age = 22,
                    Contacts = new List<Contact>()
                    {
                        new Contact() {Title="QQ",Content="999999" },
                        new Contact() {Title="Phone",Content="12345" },
                    }
                },
                new User()
                {
                    Name="li",
                    Age = 20,
                    Contacts = new List<Contact>()
                    {
                        new Contact() {Title="QQ",Content="111111" },
                    }
                },
                new User()
                {
                    Name="yue",
                    Age = 21,
                    Contacts = new List<Contact>()
                    {
                        new Contact() {Title="Phone",Content="222222" },
                    }
                },
                new User()
                {
                    Name="zhao",
                    Age = 5,
                    Contacts = new List<Contact>()
                    {
                        new Contact() {Title="Addr",Content="shanghai" },
                    }
                },
            };


            #endregion

            #region 
            //筛选
            //where子句合并多个表达式。 
            var user11 = (from u in users
                         where u.Age==20 && u.Name=="zhang"
                         select u);

            //var user12 = users.Where(u => u.Age == 20 && u.Name == "zhang").Select(u => u).ToList();
            var user12 = users.Where((u) => u.Age == 20 && u.Name == "zhang").ToList();

            //索引器筛选
            //索引是筛选器返回的每个结果的计数器。
            var user13 = users.Where((u, index) => u.Age == 20).ToList();
            var user14 = users.Where((u, index) => u.Age==20 && index % 2 == 0).ToList();
            //var user15 = users.Where((u, index) => u.Age == 20 && index == 2).ToList();

            int[] numbers = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
            var numsInPlace = numbers.Where((num, index) => (num == index));
            //类型筛选
            //基于类型筛选，使用 OfType 扩展方法。
            object[] data = { "one", 1, 2, "li" };
            var filterByType = data.OfType<int>();


            #endregion

            #region 
            //排序
            var user21 = from u in users
                         where u.Age > 10
                         orderby u.Age descending
                         select u;

            var user22 = users.Where(u => u.Age>10).OrderByDescending(u => u.Age).ToList();

            var user23 = from u in users
                         where u.Age > 10
                         orderby u.Age descending, u.Name ascending
                         select u;

            var user24 = users.Where(u => u.Age > 10).OrderByDescending(u => u.Age).ThenBy(u => u.Name).ToList();

            #endregion

            #region 
            //
            var group = from u in users
                            group u by u.Age into g
                            orderby g.Count() descending, g.Key
                            where g.Count() >= 2
                            select new
                            {
                                Country = g.Key,
                                Count = g.Count()
                            };
            
            var group2 = users.GroupBy(u => u.Age)
                                 .OrderByDescending(g => g.Count())
                                 .ThenBy(g => g.Key)
                                 .Where(g => g.Count() >= 2)
                                 .Select(g => new {
                                     Country = g.Key,
                                     Count = g.Count()
                                 });

            #endregion

            #region Take 和Skip
            var user31 = (from u in users
                          select u).Take(3).ToList();
                
            var user32 = (from u in users
                          select u).Skip(1).Take(3).ToList();

            var user33 = users.Take(3).ToList();
            var user34 = users.Skip(1).Take(3).ToList();

            #endregion

            #region Range、 Empty、Repeat
            var values = Enumerable.Range(1, 20);
            var s = Enumerable.Empty<string>();
            var strings = Enumerable.Repeat("A.", 3).ToList();
            #endregion

            #region Count()、Sum()、Min()、Max()、Average()
            List<int> list = new List<int>() { 1, 2, 4, 5 };

            var count = list.Count();
            var sum = list.Sum();
            var min = list.Min();
            var max = list.Max();
            var average = list.Average();

            list.FirstOrDefault();
            
            User qq = default(User);

            #endregion

            Console.ReadLine();
        }

        public static List<Product> GetList()
        {
            var products = new List<Product>
                        {
                            new Product {Id = 1, Category = "Electronics", Value = 15.0},
                            new Product {Id = 2, Category = "Groceries", Value = 40.0},
                            new Product {Id = 3, Category = "Garden", Value = 210.3},
                            new Product {Id = 4, Category = "Pets", Value = 2.1},
                            new Product {Id = 5, Category = "Electronics", Value = 19.95},
                            new Product {Id = 6, Category = "Pets", Value = 21.25},
                            new Product {Id = 7, Category = "Pets", Value = 5.50},
                            new Product {Id = 8, Category = "Garden", Value = 13.0},
                            new Product {Id = 9, Category = "Automotive", Value = 10.0},
                            new Product {Id = 10, Category = "Electronics", Value = 250.0},
                        };
            return products;
        }
    }
}
