using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject.Models
{
    public class PhysicalBook : Book
    {
        public Type PrintType { get; set; }

        public enum Type
        {
            Paperback = 0,
            Hardback = 1,
        }
    }
}
