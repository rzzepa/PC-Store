﻿using PC_Store.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Models
{
    public class GraphicCard
    {
        public int Id { get; set; }

        public string Producer { get; set; }

        public string ProducerCode { get; set; }

        public string ProducerChipset { get; set; }

        public string ChipsetType { get; set; }

        public int CoreClock { get; set; }

        public int CoreClockBoost { get; set; }
        
        public int CardLength { get; set; }

        public string ConnectorType { get; set; }

        public string VerConnectorType { get; set; }

        public string Resolution { get; set; }

        public string RecommendedPSUPower { get; set; }

        public bool Led { get; set; }

        public int AmountOfRAM { get; set; }

        public string TypeOfRAM { get; set; }

        public int DataBus { get; set; }

        public int MemoryClock { get; set; }

        public string CoolingType { get; set; }

        public int NumberOfFans { get; set; }

        public int DSub { get; set;}

        public int DisplayPort { get; set; }

        public int HDMI { get; set; }

        public int DVI { get; set; }

        public int ProductId { get; set; }

    }
}
