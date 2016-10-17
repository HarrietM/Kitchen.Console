using System;

namespace Kitchen.Console.Models
{
    public class Omelette
    {
        public int OmeletteId { get; set; }
        public DateTime DateCooked { get; set; }

        public virtual Recipe Recipe { get; set; }
    }
}
