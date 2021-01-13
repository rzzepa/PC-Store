using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.ViewModels
{
    public class MotherboardCreatorViewModel : IEnumerable
    {
        public string PcCreatorId { get; set; }

        public string Producer { get; set; }

        public string ProducerCode { get; set; }

        public string Standard { get; set; }

        public string Chipset { get; set; }

        public string SocketType { get; set; }

        public string Technologies { get; set; }

        public string StandardMemory { get; set; }

        public string ConnectorType { get; set; }

        public int NumberOfMemorySlots { get; set; }

        public int MaximumAmountOfMemory { get; set; }

        public string MultiChannelArchitecture { get; set; }

        public bool IntegratedGraphicsCardSupport { get; set; }

        public string GraphicsChipset { get; set; }

        public string CombiningCards { get; set; }

        public string SoundChipset { get; set; }

        public string AudioChannels { get; set; }

        public string IntegratedNetworkCard { get; set; }

        public string NetworkCardChipset { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public int PCIExpressx1 { get; set; }

        public int PCIExpressx16 { get; set; }

        public int PCIExpressx4 { get; set; }

        public int Quantity { get; set; }

        public int Id { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
