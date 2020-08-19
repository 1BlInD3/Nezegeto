namespace ConnString
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("DanyTartozasok")]
    public partial class DanyTartozasok
    {
        public int ID { get; set; }

        [StringLength(50)]
        public string Nev { get; set; }

        [StringLength(6)]
        public string Torzsszam { get; set; }

        [StringLength(10)]
        public string TartozasJellege { get; set; }

        public int? Osszeg { get; set; }

        public int? VegrehajtasiKTSG { get; set; }

        [Column(TypeName = "date")]
        public DateTime? RogzDatum { get; set; }

        [Column(TypeName = "date")]
        public DateTime? ElsoBefizetesDatum { get; set; }

        public int? Futamido { get; set; }

        public short? Statusz { get; set; }

        [Column(TypeName = "date")]
        public DateTime? FigyelmeztetesDatum { get; set; }

        [Column(TypeName = "date")]
        public DateTime? VegrehajtasDatum { get; set; }

        [StringLength(200)]
        public string Megjegyzes { get; set; }

        public int? figyelmeztetes { get; set; }
    }
}
