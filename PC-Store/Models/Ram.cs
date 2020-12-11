using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Models
{
    public class Ram
    {
        public int Id { get; set; }

        public string Producer { get; set; }

        public string ProducerCode { get; set; }

        public string Line { get; set; }

        public string ConnectorType { get; set; }

        public string MemoryType { get; set; }

        public string Cooling { get; set; }

        public bool LowProfile { get; set; }

        public int TotalCapacity { get; set; }

        public int NumberOfModules { get; set; }

        public int Frequency { get; set; }

        public string Delay { get; set; }

        public float Voltage { get; set; }

        public bool Backlight { get; set; }

        public int ProductId { get; set; }
    }
}
