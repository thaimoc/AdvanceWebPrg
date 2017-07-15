using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BLL;

using System.Linq.Expressions;
using DAL.Sql;
using DAL.Sql.Modles;

namespace Test
{
    class Program
    {
        static void Main(string[] args)
        {
            using (GeneralRepository<Category> categories = new GeneralRepository<Category>())
            {
                List<Category> list = categories.All().ToList();
                foreach (Category i in list)
                    Console.WriteLine(i.Name);
                Console.ReadKey();
            }
        }
    }
}
