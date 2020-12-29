using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.structure
{
    public class PowerSupplyCreatorList: IEnumerable
    {
        public string PcCreatorId { get; set; }

        public string Producer { get; set; }

        public string ProducerCode { get; set; }

        public string Standard { get; set; }

        public int Power { get; set; }

        public string EfficiencyCertificate { get; set; }

        public bool PFCSystem { get; set; }

        public int Efficiency { get; set; }

        public string CoolingType { get; set; }

        public int Diameter { get; set; }

        public string Security { get; set; }

        public string ModularCabling { get; set; }

        public int ATX24pin204 { get; set; }

        public int PCIE8pin62 { get; set; }

        public int PCIE8pin { get; set; }

        public int PCIE6pin { get; set; }

        public int CPU44pin8 { get; set; }

        public int CPU8pin { get; set; }

        public int CPU4pin { get; set; }

        public int SATA { get; set; }

        public int Molex { get; set; }

        public int Height { get; set; }

        public int Width { get; set; }

        public int Depth { get; set; }

        public bool Backlight { get; set; }

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
