namespace ConnString
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DanyFizetes
    {
        public int ID { get; set; }

        public int? IDTartozas { get; set; }

        public int? BefizetesOsszege { get; set; }

        [Column(TypeName = "date")]
        public DateTime? BefizetesDatuma { get; set; }

        [StringLength(30)]
        public string BankiTranzakcioSzam { get; set; }

        [StringLength(250)]
        public string Megjegyzes { get; set; }
    }
}
