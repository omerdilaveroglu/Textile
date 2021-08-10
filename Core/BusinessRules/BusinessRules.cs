using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Abstract;

namespace Core.BusinessRules
{
    public class BusinessRules
    {
        // birden fazla IResult türünde parametre yollanabilir. List<IResult> da döndürülebilir. 
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
