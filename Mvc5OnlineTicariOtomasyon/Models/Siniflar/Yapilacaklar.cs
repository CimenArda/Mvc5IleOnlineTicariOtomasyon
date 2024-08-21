using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace Mvc5OnlineTicariOtomasyon.Models.Siniflar
{
    public class Yapilacaklar
    {

        [Key]
        public int YapilacaklarID { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string Baslik { get; set; }



        [Column(TypeName = "bit")]
        public bool Durum { get; set; }
    }
}