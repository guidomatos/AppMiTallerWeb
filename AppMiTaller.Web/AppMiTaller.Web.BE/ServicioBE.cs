using System;
using System.Collections.Generic;

namespace AppMiTaller.Web.BE
{
    [Serializable()]
    public class ServicioBE
    {
        public Int32 nid_servicio { get; set; }
        public string co_servicio { get; set; }
        public string no_servicio { get; set; }
        public Int32 nid_tipo_servicio { get; set; }
        public Int32 qt_tiempo_prom { get; set; }
        public string fl_quick_service { get; set; }
        public string no_dias_validos { get; set; }
        public string co_tipo_servicio { get; set; }
        public string no_tipo_servicio { get; set; }
        public Int32 nid_modelo { get; set; }
        public Int32 nid_Pais { get; set; }
        public string coddpto { get; set; }
        public string codprov { get; set; }
        public string coddist { get; set; }
        public string nu_placa { get; set; }
        public string fl_campania_veh { get; set; }
        public string co_modeloservicio_ax_veh { get; set; }
        public string fl_visible_obs { get; set; }
        public string fl_visible_tx_informativo { get; set; }
        public string tx_informativo { get; set; }
    }
    [Serializable]
    public class ServicioBEList : List<ServicioBE> { }
}