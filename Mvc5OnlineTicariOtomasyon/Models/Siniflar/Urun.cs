﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc5OnlineTicariOtomasyon.Models.Siniflar
{
    public class Urun
    {

        [Key]
        public int UrunID { get; set; }

        [Column(TypeName ="Varchar")]
        [StringLength(30)]
        public string UrunAd { get; set; }
        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string Marka { get; set; }
        public short Stok { get; set; }

        public decimal AlisFiyat { get; set; }
        public decimal SatisFiyat { get; set; }

        public bool Durum {  get; set; }



        [Column(TypeName = "Varchar")]
        [StringLength(250)]
        public string UrunGorsel { get; set; }


        public Kategori Kategoris { get; set; }


        public ICollection<SatisHareket> SatisHarekets { get; set; }





    }
}