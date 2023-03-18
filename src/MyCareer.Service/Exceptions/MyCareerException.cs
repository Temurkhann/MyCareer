using System;
namespace MyCareer.Service.Exceptions;

public class MyCareerException : Exception
{
    public int Code { get; set; }

    public MyCareerException(int code, string message) : base(message)
    {
        Code = code;
    }
}