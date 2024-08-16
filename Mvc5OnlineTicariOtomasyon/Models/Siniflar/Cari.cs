using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc5OnlineTicariOtomasyon.Models.Siniflar
{
    public class Cari
    {
        [Key]
        public int CariID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariAd { get; set;}

        [Column(TypeName = "Varchar")]
        [StringLength(30)]
        public string CariSoyad { get; set;}

        [Column(TypeName = "Varchar")]
        [StringLength(20)]
        public string CariSehir { get; set;}

        [Column(TypeName = "Varchar")]
        [StringLength(50)]
        public string CariMail { get; set;}

        public ICollection<SatisHareket> SatisHarekets { get; set; }


    }
}