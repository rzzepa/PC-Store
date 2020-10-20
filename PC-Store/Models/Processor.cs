using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Models
{


    public class Processor
    {
        public int Id { get; set; }

        public string producer { get; set; }

        public string line { get; set; }

        public bool cooling { get; set; }

        public string sockerType { get; set; }

        public int numberOfCores { get; set; }

        public int numberOfThreads { get; set; }

        public float processorClockFrequency { get; set; }

        public float turboMaximumFrequency { get; set; }

        public string integratedGraphics { get; set; }

        public string unlockedMultiplier { get; set; }

        public int architecture { get; set; } //bit

        public string typesOfSupportedMemory { get; set; }

        
    }
}
