using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc5OnlineTicariOtomasyon.Models.Siniflar
{
    public class SatisHareket
    {
        [Key]
        public int SatisHareketID { get; set; }

        //ürün
        //cari
        //personel

        public ICollection<Urun> Urun { get; set; }
        public ICollection<Cari> Cari { get; set; }
        public ICollection<Personel> Personel { get; set; }





        public DateTime Tarih { get; set; }

        public int Adet {  get; set; }
        public decimal Fiyat {  get; set; }
        public decimal ToplamTutar {  get; set; }

    }
}