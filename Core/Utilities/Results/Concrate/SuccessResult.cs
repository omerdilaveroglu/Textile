using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;
using Core.Utilities.Results.Concrete;

namespace Core.Utilities.Results.Concrate
{
    public class SuccessResult : Result
    {
        //Constructor
        public SuccessResult(string message) : base(true, message) //Base = Result demek 
        {
            // Sana bir mesaj gelicek, mesaj gelirse aşağıdaki bloguda çalıştır çünkü işlem doğru demektir.
        }

        public SuccessResult() : base(true) // Mesaj vemedim. 
        {
            // Mesaj gelmez ise bunu çalıştır.
        }


    }
}
