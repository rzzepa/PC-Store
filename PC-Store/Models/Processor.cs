using Microsoft.AspNetCore.Http.Features;
using PC_Store.Interfaces;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using System.Web;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations.Schema;

namespace PC_Store.Models
{


    public class Processor :IEnumerable
    {
        public int Id { get; set; }
        [Required]
        public string Producer { get; set; }
        [Required]
        public string Line { get; set; }
        [Required]
        public bool Cooling { get; set; }
        [Required]
        public string SocketType { get; set; }
        [Required]
        public int NumberOfCores { get; set; }
        [Required]
        public int NumberOfThreads { get; set; }
        [Required]
        public float ProcessorClockFrequency { get; set; }
        [Required]
        public float TurboMaximumFrequency { get; set; }
        [Required]
        public string IntegratedGraphics { get; set; }
        [Required]
        public bool UnlockedMultiplier { get; set; }
        [Required]
        public int Architecture { get; set; }
        [Required]
        public string TypesOfSupportedMemory { get; set; }

        public int ProductId { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}
