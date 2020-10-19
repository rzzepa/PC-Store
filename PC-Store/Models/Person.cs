using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace PC_Store.Models
{

    public class Person
    {
        
        public int Id{ get; set; }

        public string Name {get; set; }

        public string Surname { get; set; }

        public string Type { get; set; }

    }
}
