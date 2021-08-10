using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;

namespace Core.Utilities.Business
{
    public class BusinessRules
    {
        //params verdiğimizde Run içerisine istediğimiz kadar IResult verebiliriz parametre olarak.
        //C# arka planda gönderdiğimiz bütün parametreleri Arry haline getirip logics'in içerisine atar.
        public static IResult Run(params IResult[] logics) 
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }

            return null;
        }
    }
}
