using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.DataAccess.EntityFramawork;
using DataAccess.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfOrderDal : EfEntityRepositoryBase<Order, TextileContext>, IOrderDal
    {
        public List<OrderDetailDto> GetAllOrderDetails()
        {
            using (TextileContext context = new TextileContext())
            {
                var result = from o in context.Orders
                    join c in context.Customers on o.CustomerId equals c.CustomerId
                    select new OrderDetailDto
                    {
                        OrderId = o.OrderId,
                        OrderDate = o.OrderDate,
                        Address = c.Address,
                        CustomerName = c.CustomerName
                    };
                return result.ToList();
            }
        }
    }
}
