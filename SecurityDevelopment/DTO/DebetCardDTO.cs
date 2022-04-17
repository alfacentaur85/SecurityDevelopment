using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using SecurityDevelopment.Models;

namespace SecurityDevelopment.DTO
{
    public class DebetCardDTO
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
