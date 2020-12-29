using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Models
{
    public class UserPCCreator
    {
        [Key]
        public string Name { get; set; }

        public int ComputerCaseProduct { get; set; }

        public int ProcessorProduct { get; set; }

        public int RamProduct { get; set; }

        public int GraphicCardProduct { get; set; }

        public int MotherboardProduct { get; set; }

        public int PowerSupplyProduct { get; set; }

        public DateTime ModifyDate { get; set; }

        public string User { get; set; }
    }
}
