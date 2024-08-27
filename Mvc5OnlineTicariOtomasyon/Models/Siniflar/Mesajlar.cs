using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mvc5OnlineTicariOtomasyon.Models.Siniflar
{
    public class Mesajlar
    {
        [Key]
        public int MesajID { get; set; }



        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string Gonderici { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string Alıcı { get; set; }

        [Column(TypeName = "Varchar")]
        [StringLength(60)]
        public string Konu { get; set; }



        [Column(TypeName = "Varchar")]
        [StringLength(3000)]
        public string Icerik { get; set; }


        [Column(TypeName = "Date")]
        public DateTime Tarih { get; set; }

    }
}