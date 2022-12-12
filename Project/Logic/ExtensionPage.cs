using Project.Models;
using System.Collections.Generic;
using System.Linq;

namespace Project.Logic
{
    public class ExtensionPage
    {
        public static List<News> PagingNews(List<News> NewsList, int Pageindex, int Pagesize)
        {
            if (Pageindex==0||Pageindex==null) { Pageindex = 1; }
            using (var context = new Bds_CShapContext())
            {   // skip bỏ qua bn take lấy ra bn tiếp theo
                var queryResultPage = NewsList
                  .Skip(Pagesize * (Pageindex - 1))
                  .Take(Pagesize);
                List<News> NewsList2 = queryResultPage.ToList();
                return NewsList2;
            }
        }
        public static int PageEnd(List<News> NewsList, int Pagesize)
        {
            if (NewsList.Count==0)
            {
                return 0;
            }
            int allpage = NewsList.Count / Pagesize;
            int du = NewsList.Count % Pagesize;
            if (du > 0) { allpage = allpage+ 1; }
            return allpage;
        }
        public static List<Product> PagingProduct(List<Product> ProductList, int Pageindex, int Pagesize)
        {
            if (Pageindex == 0 || Pageindex == null) { Pageindex = 1; }
            using (var context = new Bds_CShapContext())
            {   // skip bỏ qua bn take lấy ra bn tiếp theo
                var queryResultPage = ProductList
                  .Skip(Pagesize * (Pageindex - 1))
                  .Take(Pagesize);
                List<Product> NewsList2 = queryResultPage.ToList();
                return NewsList2;
            }
        }
        public static int PageEndProduct(List<Product> ProductList, int Pagesize)
        {
            if (ProductList.Count == 0)
            {
                return 0;
            }
            int allpage = ProductList.Count / Pagesize;
            int du = ProductList.Count % Pagesize;
            if (du > 0) { allpage = allpage + 1; }
            return allpage;
        }

        public static List<User> PagingUser(List<User> ProductList, int Pageindex, int Pagesize)
        {
            if (Pageindex == 0) { Pageindex = 1; }
            using (var context = new Bds_CShapContext())
            {   // skip bỏ qua bn take lấy ra bn tiếp theo
                var queryResultPage = ProductList
                  .Skip(Pagesize * (Pageindex - 1))
                  .Take(Pagesize);
                List<User> NewsList2 = queryResultPage.ToList();
                return NewsList2;
            }
        }
        public static int PageEndUser(List<User> ProductList, int Pagesize)
        {
            if (ProductList.Count == 0)
            {
                return 0;
            }
            int allpage = ProductList.Count / Pagesize;
            int du = ProductList.Count % Pagesize;
            if (du > 0) { allpage = allpage + 1; }
            return allpage;
        }
    }
}
