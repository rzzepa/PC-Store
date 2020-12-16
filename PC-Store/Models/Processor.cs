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
        [StringLength(20)]
        [Required]
        public string Producer { get; set; }
        [Required]
        public string Line { get; set; }

        public bool Cooling { get; set; }
        [Required]
        public string SocketType { get; set; }
        [Required]
        public int NumberOfCores { get; set; }
        [Required]
        public int NumberOfThreads { get; set; }

        public float ProcessorClockFrequency { get; set; }

        public float TurboMaximumFrequency { get; set; }

        public string IntegratedGraphics { get; set; }

        public bool UnlockedMultiplier { get; set; }

        public int Architecture { get; set; }

        public string TypesOfSupportedMemory { get; set; }

        public int ProductId { get; set; }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

    }
}
