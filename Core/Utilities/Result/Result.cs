using System;
using System.Collections.Generic;
using System.Text;

namespace Core.Utilities.Result
{
    //ıresultın somut sınıfı
    public class Result : IResult
    {
        //sen resulta ctr vasıtayla bir tane bool bir tane de string bir şey göndermen gerekiyor.
        public Result(bool success, string message) : this(success) //c#da this demek classın kendisi demek result demek 
            //resultın tek parametrekli ctr success yolla 
        {
            Message = message;
        }

        public Result(bool success) //istersem mesaj göndermem.
        {
            Success = success;

        }
        //getter readonly dir readlonlyler ctr set eedilebilir.

        public bool Success { get; }

        public string Message { get; }
    }
}
