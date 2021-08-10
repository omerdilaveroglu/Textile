using Business.Abstract;
using System;
using System.Net.Http.Headers;
using Business.Concrete;
using Business.Constants;
using DataAccess.Concrete.EntityFramework;

namespace ConsoleUI
{
    class Program
    {
        static void Main(string[] args)
        {
            ProductTest();
            //CategoryTest();
            //CustomerTest();
            //OrderTest();
        }

        private static void OrderTest()
        {
            OrderManager orderManager = new OrderManager(new EfOrderDal());
            foreach (var x in orderManager.GetOrderDetails().Data)
            {
                Console.WriteLine("Sipariş Id = "+ x.OrderId+ Environment.NewLine +"Müşteri Id = "+
                                  x.CustomerName+ Environment.NewLine +"Adres = "+
                                  x.Address+ Environment.NewLine +"Sipariş tarihi = "+ x.OrderDate);
            }
        }

        private static void CategoryTest()
        {
            ICategoryService categoryManager = new CategoryManager(new EfCategoryDal());
            foreach (var category in categoryManager.GetAll().Data)
            {
                Console.WriteLine(category.CategoryName);
            }
        }

        private static void CustomerTest()
        {
            ICustomerService customerManager = new CustomerManager(new EfCustomerDal());
            foreach (var customer in customerManager.GetById(1).Data)
            {
                Console.WriteLine(customer.CustomerName + " : " + customer.Phone);
            }
        }

        private static void ProductTest()
        {
            IProductService productManager = new ProductManager(new EfProductDal());
            var result = productManager.GetAllByCategoryId(1);

            if (result.Success == true)
            {
                foreach (var product in result.Data)
                {
                    Console.WriteLine(product.ProductName + " / " + product.CategoryId +" / "+product.Description);
                }
            }
            else
            {
                Console.WriteLine(result.Message);
            }
        }
    }
}
