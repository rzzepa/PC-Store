using PC_Store.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Models
{
    public class GraphicCard
    {
        public int Id { get; set; }

        [Required]
        public string Producer { get; set; }
        [Required]
        public string ProducerCode { get; set; }
        [Required]
        public string ProducerChipset { get; set; }
        [Required]
        public string ChipsetType { get; set; }
        [Required]
        public int CoreClock { get; set; }
        [Required]
        public int CoreClockBoost { get; set; }
        [Required]
        public int CardLength { get; set; }
        [Required]
        public string ConnectorType { get; set; }
        [Required]
        public string VerConnectorType { get; set; }
        [Required]
        public string Resolution { get; set; }
        [Required]
        public string RecommendedPSUPower { get; set; }

        public bool Led { get; set; }
        [Required]
        public int AmountOfRAM { get; set; }
        [Required]
        public string TypeOfRAM { get; set; }
        [Required]
        public int DataBus { get; set; }
        [Required]
        public int MemoryClock { get; set; }
        [Required]
        public string CoolingType { get; set; }
        [Required]
        public int NumberOfFans { get; set; }

        public int DSub { get; set;}

        public int DisplayPort { get; set; }

        public int HDMI { get; set; }

        public int DVI { get; set; }

        public int ProductId { get; set; }

    }
}
