using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Ogrenci_ve_Not_Sistemi_AspNetCoreMVC.Models
{
    [Table("Ogrencilers")]
    public class Ogrenciler
    {
        [Key]
        public int OgrenciID { get; set; }
        public string OgrenciNo { get; set; }
        public string OgrenciAd { get; set; }
        public string OgrenciSoyad { get; set; }
        public string TCK { get; set; }
        public string Cinsiyet { get; set; }

    }
}
