using PC_Store.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Models
{
    public class Motherboard 
    {
        public int Id { get; set; }
        [Required]
        public string Producer { get; set; }
        [Required]
        public string ProducerCode { get; set; }
        [Required]
        public string Standard { get; set; }
        [Required]
        public string Chipset { get; set; }
        [Required]
        public string SocketType { get; set; }

        public string Technologies { get; set; }
        [Required]
        public string StandardMemory { get; set; }
        [Required]
        public string ConnectorType { get; set; }
        [Required]
        public int NumberOfMemorySlots { get; set; }
        [Required]
        public int MaximumAmountOfMemory { get; set; }

        public string MultiChannelArchitecture { get; set; }

        public bool IntegratedGraphicsCardSupport { get; set; }
        [Required]
        public string GraphicsChipset { get; set; }

        public string CombiningCards { get; set; }

        public string SoundChipset { get; set; }

        public string AudioChannels { get; set; }

        public string IntegratedNetworkCard { get; set; }

        public string NetworkCardChipset { get; set; }
        [Required]
        public int PCIExpressx1 { get; set; }
        [Required]
        public int PCIExpressx16 { get; set; }
        [Required]
        public int PCIExpressx4 { get; set; }

        public int ProductId { get; set; }

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
