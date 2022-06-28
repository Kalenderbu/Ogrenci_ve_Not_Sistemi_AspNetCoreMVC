using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ogrenci_ve_Not_Sistemi_AspNetCoreMVC.Models
{
    [Table("Derslers")]
    public class Dersler
    {
        [Key]
        public int DersID { get; set; }
        public string DersAd { get; set; }
    }
}
