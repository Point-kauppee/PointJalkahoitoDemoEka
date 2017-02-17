//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace PointJalkahoitoDemoEka.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Henkilokunta
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Henkilokunta()
        {
            this.Kayttaja1 = new HashSet<Kayttaja>();
            this.Osoite1 = new HashSet<Osoite>();
            this.Puhelin1 = new HashSet<Puhelin>();
            this.Varaus1 = new HashSet<Varaus>();
        }
    
        public int Henkilokunta_id { get; set; }
        public string Etunimi { get; set; }
        public string Sukunimi { get; set; }
        public string Henkilotunnus { get; set; }
        public string Huomiot { get; set; }
        public string Sahkoposti { get; set; }
        public Nullable<int> Käyttäjä_id { get; set; }
        public Nullable<int> Osoite_id { get; set; }
        public Nullable<int> Puhelin_id { get; set; }
        public Nullable<int> Asiakas_id { get; set; }
        public Nullable<int> Hoitaja_id { get; set; }
        public Nullable<int> Varaus_id { get; set; }
        public Nullable<int> Palvelu_id { get; set; }
        public Nullable<int> Kurssi_id { get; set; }
    
        public virtual Osoite Osoite { get; set; }
        public virtual Puhelin Puhelin { get; set; }
        public virtual Hoitaja Hoitaja { get; set; }
        public virtual Varaus Varaus { get; set; }
        public virtual Palvelu Palvelu { get; set; }
        public virtual Kayttaja Kayttaja { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Kayttaja> Kayttaja1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Osoite> Osoite1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Puhelin> Puhelin1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Varaus> Varaus1 { get; set; }
    }
}
