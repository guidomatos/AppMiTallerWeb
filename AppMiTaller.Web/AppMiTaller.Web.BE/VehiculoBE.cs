using System;
using System.Collections.Generic;

namespace AppMiTaller.Web.BE
{
    [Serializable]
    public class VehiculoBE
    {
        public Int32 nid_vehiculo;
        public Int32 nid_contacto_src;
        public Int32 nid_cliente;
        public Int32 nid_propietario;
        public string nu_placa;
        public string nu_vin;
        public Int32 nid_marca;
        public Int32 nid_modelo;
        public Int32 qt_km_actual;
        public string fl_reg_manual;
        public string co_tipo;
        public Int32 nu_anio;
        public string co_marca;
        public Int32 nid_empresa;
        public string no_marca;
        public string co_modelo;
        public string no_modelo;
        public Int32 nid_negocio_linea;
    }
    [Serializable]
    public class VehiculoBEList : List<VehiculoBE> { }
}