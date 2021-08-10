using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Entities.Concrete;
using Entities.DTOs;

namespace Business.Abstract
{
    public interface IOrderService
    {
        IDataResult<List<Order>> GetAll();
        IDataResult<List<Order>> GetByCustomerId(int id);
        IDataResult<List<OrderDetailDto>> GetOrderDetails();
        IDataResult<Order> GetById(int id);
        IResult Add(Order order);
        IResult Update(Order order);
        IResult Delete(Order order);
    }
}
