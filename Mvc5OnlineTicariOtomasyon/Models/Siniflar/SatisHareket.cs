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

         public Urun Uruns { get; set; }  
         public Cari Caris { get; set; }  
         public Personel Personels { get; set; }  




        public DateTime Tarih { get; set; }

        public int Adet {  get; set; }
        public decimal Fiyat {  get; set; }
        public decimal ToplamTutar {  get; set; }

    }
}