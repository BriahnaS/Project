using System;
using System.Collections.Generic;
using System.Text;

namespace MiniProject.Models
{
    internal class PhysicalBook : Book
    {
        public Type PrintType { get; set; }


        public enum Type
        {
            Paperback = 0,
            Hardback = 1,
        }
    }
}
