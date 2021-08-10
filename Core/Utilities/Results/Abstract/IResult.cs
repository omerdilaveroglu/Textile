using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Results.Abstract
{
    public interface IResult
    {
        bool Success { get; }       // Sonuc döndür doğrumu yanlışmı ?
        string Message { get; }     // mesaj vercek
    }
}
