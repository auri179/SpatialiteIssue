using GeoAPI.Geometries;
using System;
using System.Collections.Generic;

namespace ConsoleApp1
{
    public partial class GeoParcelle
    {
        public string GeoParcelle1 { get; set; }
        public string Annee { get; set; }
        public string ObjectRid { get; set; }
        public string Idu { get; set; }
        public string GeoSection { get; set; }
        public string GeoSubdsect { get; set; }
        public decimal? Supf { get; set; }
        public string GeoIndp { get; set; }
        public string Coar { get; set; }
        public string Tex { get; set; }
        public string Tex2 { get; set; }
        public string Codm { get; set; }
        public DateTime? CreatDate { get; set; }
        public DateTime? UpdateDat { get; set; }
        public string Lot { get; set; }
        public long OgcFid { get; set; }
        public IMultiPolygon Geom { get; set; }
    }
}
