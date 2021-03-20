using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    //Temel  voidler için 
    //içerisinde bir tane işlem sonucu olsun bir tane de kullanıcıyı bilgilendirme amacıyla bir mesaj
    public interface IResult
    {
        bool Success { get; }

        string Message { get; }
    }
}
