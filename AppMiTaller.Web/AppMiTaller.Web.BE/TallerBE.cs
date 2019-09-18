using System;
using System.Collections.Generic;

namespace AppMiTaller.Web.BE
{
    [Serializable()]
    public class TallerBE
    {
        public Int32 nid_taller { get; set; }
        public Int32 nid_servicio { get; set; }
        public string co_taller { get; set; }
        public string no_taller { get; set; }
        public string nid_intervalo { get; set; }
        public Int32 qt_intervalo_atenc { get; set; }
        public string ho_inicio { get; set; }
        public string ho_fin { get; set; }
        public Int32 nid_ubica { get; set; }
        public string no_ubica { get; set; }
        public string di_ubica { get; set; }
        public string no_distrito { get; set; }
        public string nu_telefono { get; set; }
        public Int32 nid_dias_exceptuados { get; set; }
        public string tx_mapa_taller { get; set; }
        public string tx_url_taller { get; set; }
        public Int32 dd_atencion { get; set; }
        public DateTime fe_exceptuada { get; set; }
        public Int32 nid_pais { get; set; }
        public Int32 nid_modelo { get; set; }
        public string fl_tipo { get; set; }
        public string coddpto { get; set; }
        public string codprov { get; set; }
        public string coddist { get; set; }
        public string ho_rango1 { get; set; }
        public string ho_rango2 { get; set; }
        public string ho_rango3 { get; set; }
        public string fl_nota { get; set; }
        public string tx_promociones { get; set; }
        public string tx_noticias { get; set; }
        public string tx_datos { get; set; }
        public string tx_fotos { get; set; }
        public string fl_taxi { get; set; }
    }
    [Serializable]
    public class TallerBEList : List<TallerBE> { }
}