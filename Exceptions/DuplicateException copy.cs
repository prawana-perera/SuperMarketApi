using System;

namespace Supermarket.API.Exceptions
{
  public class DuplicateException : Exception
  {
    public DuplicateException(string message) : base(message)
    { }
  }
}