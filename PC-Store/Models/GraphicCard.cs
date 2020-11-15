using PC_Store.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Models.ViewModels
{
    public class GraphicCard: IProducts
    {
        public int Id { get; set; }

        public string Producer { get; set; }

        public string ProducerCode { get; set; }

        public string ProducerChipset { get; set; }

        public int CoreClock { get; set; }

        public int CoreClockBoost { get; set; }

        public string ConnectorType { get; set; }

        public string Resolution { get; set; }

        public string RecommendedPSUPower { get; set; }

        public int AmountOfRAM { get; set; }

        public string TypeOfRAM { get; set; }

        public int DataBus { get; set; } //bit

        public int MemoryClock { get; set; }

        public int CoolingType { get; set; }

        public int NumberOfFans { get; set; }

        public int DSub { get; set;}

        public int DisplayPort { get; set; }

        public int HDMI { get; set; }

        public int DVI { get; set; }

        public int GetId()
        {
            throw new NotImplementedException();
        }

        public decimal GetPrice()
        {
            throw new NotImplementedException();
        }
    }
}
