using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PointJalkahoitoDemoEka.Models
{
    public class RekisterointiViewModel
    {
        public int Käyttäjä_id { get; set; }
        public string Käyttäjätunnus { get; set; }
        public string Salasana { get; set; }
        public Nullable<int> Asiakas_id { get; set; }
        public Nullable<int> Hoitaja_Id { get; set; }
        public Nullable<int> Henkilokunta_id { get; set; }
        public Nullable<int> Rooli_id { get; set; }
    }
}