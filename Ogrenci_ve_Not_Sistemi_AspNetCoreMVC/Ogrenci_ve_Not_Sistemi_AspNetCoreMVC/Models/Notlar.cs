using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ogrenci_ve_Not_Sistemi_AspNetCoreMVC.Models
{
        [Table("Notlars")]
        public class Notlar
        {
            [Key]
            public int NotID { get; set; }
            public int OgrenciID { get; set; }
            public int DersID { get; set; }
            public int Vize { get; set; }
            public int Final { get; set; }

            [NotMapped]
            public double Ortalama { get { return (Vize * 0.4) + (Final * 0.6); } }
        }
}
