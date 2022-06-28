namespace Ogrenci_ve_Not_Sistemi_AspNetCoreMVC.Models
{
    public class Grafik_Cinsiyet
    {
        public string VeriBaslik { get; set; }
        public int Veri { get; set; }

        public Grafik_Cinsiyet()
        {

        }

        public Grafik_Cinsiyet(string a, int b)
        {
            VeriBaslik = a;
            Veri = b;
        }
    }
}
