using System;
using System.Collections.Generic;

#nullable disable

namespace HomeLIbrary
{
    public partial class Book
    {
        public int Id { get; set; }
        public string NameBook { get; set; }
        public DateTime Datebirth { get; set; }
        public string Author { get; set; }
        public string Contents { get; set; }
    }
}
