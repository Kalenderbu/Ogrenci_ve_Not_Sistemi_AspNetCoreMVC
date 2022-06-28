using Ogrenci_ve_Not_Sistemi_AspNetCoreMVC.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Ogrenci_ve_Not_Sistemi_AspNetCoreMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly Context tVeritabani = new Context();
        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Ogrenciler()
        {
            var Ogrenciler = tVeritabani.ogrencilerTablosu.ToList();
            return View(Ogrenciler);
        }

        [HttpGet]
        public IActionResult Ogrenci_Kayit()
        {
            return View();
        }
        [HttpPost]
        public async Task <IActionResult> Ogrenci_Kayit([Bind ("OgrenciNo","OgrenciAd","OgrenciSoyad","TCK","Cinsiyet")] Ogrenciler tOgrenciKayit )
        {
            tVeritabani.ogrencilerTablosu.Add(tOgrenciKayit);
            await tVeritabani.SaveChangesAsync();
            return RedirectToAction("Ogrenciler","Home");
        }

        [HttpGet]
        public IActionResult Ogrenci_Duzelt(int? id)
        {
            Ogrenciler tOgrenciler = new Ogrenciler();
            if (id.HasValue)
            {
                tOgrenciler = tVeritabani.ogrencilerTablosu.Find(id);
            }

            return View(tOgrenciler);
        }

        [HttpPost]
        public async Task<IActionResult> Ogrenci_Duzelt( [Bind("OgrenciID","OgrenciNo","OgrenciAd","OgrenciSoyad","TCK","Cinsiyet")] Ogrenciler tOgrenciDuzelt)
        {

            Ogrenciler tOgrenciDuzeltNesne = tVeritabani.ogrencilerTablosu.Find(tOgrenciDuzelt.OgrenciID);
            tOgrenciDuzeltNesne.OgrenciNo = tOgrenciDuzelt.OgrenciNo;
            tOgrenciDuzeltNesne.OgrenciAd = tOgrenciDuzelt.OgrenciAd;
            tOgrenciDuzeltNesne.OgrenciSoyad = tOgrenciDuzelt.OgrenciSoyad;
            tOgrenciDuzeltNesne.TCK = tOgrenciDuzelt.TCK;
            tOgrenciDuzeltNesne.Cinsiyet = tOgrenciDuzelt.Cinsiyet;
            await tVeritabani.SaveChangesAsync();
            return RedirectToAction("Ogrenciler","Home");
        }

        [HttpGet]
        public async Task<IActionResult> Ogrenci_Sil(int? id)
        {
            Ogrenciler tOgrenciSil = new Ogrenciler();
            if (id.HasValue)
            {
                tOgrenciSil = tVeritabani.ogrencilerTablosu.Find(id);
                tVeritabani.ogrencilerTablosu.Remove(tOgrenciSil);
                await tVeritabani.SaveChangesAsync();
                return RedirectToAction("Ogrenciler", "Home");
            }

            return RedirectToAction("Ogrenciler", "Home");
        }

        [HttpGet]
        public IActionResult Dersler()
        {
            var Dersler = tVeritabani.derslerTablosu.ToList();
            return View(Dersler);
        }
        [HttpGet]
        public IActionResult Ders_Kayit()
        {
            return View();
        }             

        [HttpPost]
        public async Task<IActionResult> Ders_Kayit([Bind("DersID", "DersAd")] Dersler tDersKayit)
        {
            tVeritabani.derslerTablosu.Add(tDersKayit);
            await tVeritabani.SaveChangesAsync();
            return RedirectToAction("Dersler", "Home");
        }

        [HttpGet]
        public IActionResult Ders_Duzelt(int? id)
        {
            Dersler tDers = new Dersler();
            if (id.HasValue)
            {
                tDers = tVeritabani.derslerTablosu.Find(id);
            }
            return View(tDers);
        }

        [HttpPost]
        public async Task<IActionResult> Ders_Duzelt([Bind("DersID", "DersAd")] Dersler tDersKayit)
        {
            Dersler tNesne = tVeritabani.derslerTablosu.Find(tDersKayit.DersID);
            tNesne.DersAd = tDersKayit.DersAd;
            await tVeritabani.SaveChangesAsync();
            return RedirectToAction("Dersler", "Home");
        }

        [HttpGet]
        public async Task<IActionResult> Ders_Sil(int? id)
        {
            Dersler tDersSil = tVeritabani.derslerTablosu.Find(id);
            tVeritabani.derslerTablosu.Remove(tDersSil);
            await tVeritabani.SaveChangesAsync();
            return RedirectToAction("Dersler", "Home");
        }

        [HttpGet]
        public IActionResult Notlar()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Notlar(int? id)
        {
            
            if (id.HasValue)
            {
                return View(id);
            }
            return View();
        }

        [HttpGet]
        public IActionResult Not_Kayit()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Not_Kayit([Bind("OgrenciID", "DersID", "Vize", "Final")] Notlar tNotKayit)
        {
            bool degerVarMi = tVeritabani.notlarTablosu
                                                .Where(tbl => tbl.OgrenciID == tNotKayit.OgrenciID
                                                && tbl.DersID == tNotKayit.DersID)
                                                .Any();

            if (degerVarMi)
            {
                Notlar tDuzeltilecekNesne = tVeritabani.notlarTablosu
                                                .Where(tbl => tbl.OgrenciID == tNotKayit.OgrenciID
                                                && tbl.DersID == tNotKayit.DersID)
                                                .Single();
                tDuzeltilecekNesne.Vize = tNotKayit.Vize;
                tDuzeltilecekNesne.Final = tNotKayit.Final;
            }
            else
            {
                tVeritabani.notlarTablosu.Add(tNotKayit);
            }
            await tVeritabani.SaveChangesAsync();
            return RedirectToAction("Notlar", "Home");
        }

        [HttpGet]
        public IActionResult Not_Duzelt(int? id)
        {
            Notlar tNotlar = new Notlar();
            if (id.HasValue)
            {
                tNotlar = tVeritabani.notlarTablosu.Find(id);
            }

            return View(tNotlar);
        }

        [HttpPost]
        public async Task<IActionResult> Not_Duzelt([Bind("NotID", "OgrenciID", "DersID", "Vize", "Final")] Notlar tNotDuzelt)
        {

            Notlar tNotNesne = tVeritabani.notlarTablosu.Find(tNotDuzelt.NotID);

            if (tNotNesne.OgrenciID == tNotDuzelt.OgrenciID && tNotNesne.DersID == tNotDuzelt.DersID)
            {
                // 1 Senaryo Öğrenci değişmez Ders değişmez
                tNotNesne.Vize = tNotDuzelt.Vize;
                tNotNesne.Final = tNotDuzelt.Final;
            }
            else
            {

                bool degerVarMi = tVeritabani.notlarTablosu
                                                .Where(tbl => tbl.OgrenciID == tNotDuzelt.OgrenciID
                                                && tbl.DersID == tNotDuzelt.DersID)
                                                .Any();
                //2. Senaryo Öğrenci değişir Ders değişir
                //3. Senaryo Öğrenci değişir Ders değişmez
                //4. Senaryo Öğrenci değişmez Ders değişir

                if (degerVarMi)
                {
                    Notlar tDuzeltilecekNesne = tVeritabani.notlarTablosu
                                                    .Where(tbl => tbl.OgrenciID == tNotDuzelt.OgrenciID
                                                    && tbl.DersID == tNotDuzelt.DersID)
                                                    .Single();
                    tDuzeltilecekNesne.OgrenciID = tNotDuzelt.OgrenciID;
                    tDuzeltilecekNesne.DersID = tNotDuzelt.DersID;
                    tDuzeltilecekNesne.Vize = tNotDuzelt.Vize;
                    tDuzeltilecekNesne.Final = tNotDuzelt.Final;
                }
                else
                {
                    Notlar tKayitNesnesi = new Notlar();
                    tKayitNesnesi.OgrenciID = tNotDuzelt.OgrenciID;
                    tKayitNesnesi.DersID = tNotDuzelt.DersID;
                    tKayitNesnesi.Vize = tNotDuzelt.Vize;
                    tKayitNesnesi.Final = tNotDuzelt.Final;
                    tVeritabani.notlarTablosu.Add(tKayitNesnesi);
                }
                tVeritabani.notlarTablosu.Remove(tNotNesne);
            }
             await tVeritabani.SaveChangesAsync();
             return RedirectToAction("Notlar", "Home");
            }

        public IActionResult Grafik1()
        {
            int tErkekSayisi = tVeritabani.ogrencilerTablosu.Where(tablom => tablom.Cinsiyet== "Erkek").Count();
            int tKadinSayisi = tVeritabani.ogrencilerTablosu.Where(tablom => tablom.Cinsiyet=="Kadın").Count();
            int tBelirtilmediSayisi = tVeritabani.ogrencilerTablosu.Where(tablom => tablom.Cinsiyet=="Belirtilmedi").Count();
            List<Grafik_Cinsiyet> tModel = new List<Grafik_Cinsiyet>();
            tModel.Add(new Grafik_Cinsiyet() { VeriBaslik = "Erkek", Veri = tErkekSayisi });
            tModel.Add(new Grafik_Cinsiyet() { VeriBaslik = "Kadın", Veri = tKadinSayisi });
            tModel.Add(new Grafik_Cinsiyet("Belirtilmedi", tBelirtilmediSayisi));
            return View(tModel);
        }

        [HttpGet]
        public async Task<IActionResult> Not_Sil(int? id)
        {
            Notlar tNotSil = new Notlar();
            if (id.HasValue)
            {
                tNotSil = tVeritabani.notlarTablosu.Find(id);
                tVeritabani.notlarTablosu.Remove(tNotSil);
                await tVeritabani.SaveChangesAsync();
                return RedirectToAction("Notlar", "Home");
            }

            return RedirectToAction("Notlar", "Home");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}