using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace PointJalkahoitoDemoEka.Models
{
    public class AsiakasPuhelinNakyma
    {
        public int Asiakas_id { get; set; }
        [Required(ErrorMessage = "Lisää Etunimi")]
        public string Etunimi { get; set; }
        [Required(ErrorMessage = "Lisää Sukunimi")]
        public string Sukunimi { get; set; }
        [Required(ErrorMessage = "Lisää Henkilötunnus")]
        public string Henkilotunnus { get; set; }
        public string Huomiot { get; set; }
        public int? Puhelin_id { get; set; }
        public string Puhelinnumero_1 { get; set; }

        //public virtual Puhelin Puhelin { get; set; }
    }
}