using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace PC_Store.Models
{
    public class Dictionary
    {
        public int Id { get; set; }
        [Required]
        public string CodeItem { get; set; }
        [Required]
        public string CodeDict { get; set; }
        [Required]
        public string CodeValue { get; set; }

        public string Ext1 { get; set; }

        public string Ext2 { get; set; }

        public int ExtN1 { get; set; }

        public int ExtN2 { get; set; }
    }
}
