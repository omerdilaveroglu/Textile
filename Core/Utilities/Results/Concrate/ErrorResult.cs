﻿using System;
using System.Collections.Generic;
using System.Text;
using Core.Utilities.Results.Concrete;

namespace Core.Utilities.Results.Concrate
{
    public class ErrorResult : Result
    {
        public ErrorResult(string message) : base(false, message)
        {

        }

        public ErrorResult() : base(false)
        {

        }
    }
}
