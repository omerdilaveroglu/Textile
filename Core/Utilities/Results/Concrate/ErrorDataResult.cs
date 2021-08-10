using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Concrate
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T date, string message) : base(date, false, message)
        {

        }

        public ErrorDataResult(T date) : base(date, false)
        {

        }

        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
