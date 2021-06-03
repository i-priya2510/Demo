using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace CodeFirstEg
{
    class Program
    {
        public static EFContext db = new EFContext();
        public static Product p = new Product();
        static void Main(string[] args)
        {
            //p = AcceptDetails();
            //AddProduct(p);
            Console.WriteLine("Enter id to be updated");
            int id = Convert.ToInt32(Console.ReadLine());
            UpdateProduct(id);
            DisplayProducts();          
            //DeleteData(id);
            ////Console.WriteLine("Hello World!");
        }
        private static void DisplayProducts()
        {
            //var result = db.Products.ToList();
            foreach (var item in db.Products)
            {
                Console.WriteLine("Id: "+item.PId);
                Console.WriteLine("Name: " + item.PName);
                Console.WriteLine("Price: " + item.Price);
                Console.WriteLine("Quantity: " + item.Qty);
                Console.WriteLine("-----------------------------");
            }
        }
        private static void AddProduct(Product p1)
        {
            db.Products.Add(p1);
            db.SaveChanges();
            Console.WriteLine("Record added successfully");
        }
        private static Product AcceptDetails()
        {
            Console.WriteLine("Enter Product Name, Price, quantity");
            //Product p = new Product();
            //m.Id = Convert.ToInt32(Console.ReadLine());
            p.PName = Console.ReadLine();
            p.Price = Convert.ToInt32(Console.ReadLine());
            p.Qty= Convert.ToInt32(Console.ReadLine());
            return p;
        }
        private static Product GetProductByID(int id)
        {
            using(var db=new EFContext())
            {
                p = db.Products.Find(id);
            }
            return p;
        }
        private static void UpdateProduct(int id)
        {
            using (var db=new EFContext())
            {
                p = GetProductByID(id);
                Console.WriteLine(p.ToString());
                p = AcceptDetails();
                db.Entry(p).State = EntityState.Modified;
                db.SaveChanges();
                Console.WriteLine("Record has been Updated!!");
            }
        }
        private static void DeleteData(int id)
        {
            p = db.Products.Find(id);
            if (p == null)
            {
                Console.WriteLine("No such id");
            }
            else
            {
                db.Products.Remove(p);
                db.SaveChanges();
                Console.WriteLine("The product is deleted successfully");
            }
        }
    }
}
