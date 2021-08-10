using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Results.Concrete
{
    public class Result : IResult
    {
        public bool Success { get; }
        public string Message { get; }

        //Constructor
        public Result(bool success, string message) :this(success) //this = Result Class'ı demek. //Result success'i yolla
        {
            Message = message;
            //bu kısım çalıştığında Success set edilsin diye this(success) dedik. Yani aşağıdaki success'i de calıştırıp yuları yolladık.
         
        }

        public Result(bool success) // Mesaj göndermek istemiyorsak burası çalışır.
        {
            Success = success; // success i set et.
        }

        
    }
    
}
