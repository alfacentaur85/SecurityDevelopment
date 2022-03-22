using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SecurityDevelopment.Models
{
    public class DebetCard
    {
        public int Id { get; set; }

        public string Number { get; set; }

        public string CVC { get; set; }

        public decimal Balance { get; set; }

        public DateTime DateFrom { get; set; }

        public DateTime DateTo { get; set; }

        public Person Owner { get; set; }
    }
}
