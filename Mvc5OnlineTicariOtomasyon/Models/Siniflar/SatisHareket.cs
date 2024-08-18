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

         public virtual Urun Uruns { get; set; }  
         public virtual Cari Caris { get; set; }  
         public virtual Personel Personels { get; set; }

        public int Urunid { get; set; }
        public int Cariid { get; set; }
        public int Personelid { get; set; }


        public DateTime Tarih { get; set; }

        public int Adet {  get; set; }
        public decimal Fiyat {  get; set; }
        public decimal ToplamTutar {  get; set; }

    }
}