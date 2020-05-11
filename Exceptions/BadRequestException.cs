using System;

namespace Supermarket.API.Exceptions
{
  public class BadRequestException : Exception
  {
    public BadRequestException(string message) : base(message)
    { }
  }
}