using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.ViewModels
{
    public class ProcessorCreatorViewModel : IEnumerable
    {
        public string PcCreatorId { get; set; }

        public string Producer { get; set; }

        public string Line { get; set; }

        public bool Cooling { get; set; }

        public string SocketType { get; set; }

        public int NumberOfCores { get; set; }

        public int NumberOfThreads { get; set; }

        public float ProcessorClockFrequency { get; set; }

        public float TurboMaximumFrequency { get; set; }

        public string IntegratedGraphics { get; set; }

        public bool UnlockedMultiplier { get; set; }

        public int Architecture { get; set; }

        public string TypesOfSupportedMemory { get; set; }

        public decimal Price { get; set; }

        public string Name { get; set; }

        public string Picture { get; set; }

        public int Quantity { get; set; }

        public int Id { get; set; }
        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }
    }
}
