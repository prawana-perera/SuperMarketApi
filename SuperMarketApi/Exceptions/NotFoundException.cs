using System;

namespace Supermarket.API.Exceptions
{
  public class NotFoundException : Exception
  {
    public NotFoundException(string message) : base(message)
    { }
  }
}