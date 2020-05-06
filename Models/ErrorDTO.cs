using System.Collections.Generic;

namespace Supermarket.API.Models
{
    public class ErrorDTO
    {
        public string Field { get; set; }
        public IList<string> Errors { get; set; }
    }
}