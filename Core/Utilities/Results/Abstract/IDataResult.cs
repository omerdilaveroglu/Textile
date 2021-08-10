using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Abstract
{
    public interface IDataResult<T>:IResult
    {
        // Burada sadece data döndürecek kodu yazdık. IResult'dan zaten mesaj ve işlem sonucu geliyor. 
        T Data { get; }
    }
}