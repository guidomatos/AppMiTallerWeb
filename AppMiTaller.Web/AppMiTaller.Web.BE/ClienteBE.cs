using System;
using System.Collections.Generic;

namespace AppMiTaller.Web.BE
{
    [Serializable()]
    public class ClienteBE
    {
        public Int32 nid_cliente { get; set; }
        public Int32 nid_contacto { get; set; }
        public Int32 nid_vehiculo { get; set; }
        public string no_nombre { get; set; }
        public string no_ape_paterno { get; set; }
        public string no_ape_materno { get; set; }
        public string co_tipo_documento { get; set; }
        public string nu_documento { get; set; }
        public string no_email { get; set; }
        public string no_email_trabajo { get; set; }
        public string no_email_alter { get; set; }
        public string nu_tel_fijo { get; set; }
        public string nu_tel_movil { get; set; }
        public string cod_tipo_persona { get; set; }
        public string cod_tipo_documento { get; set; }
        public string des_tipo_documento { get; set; }
        public string tx_direccion { get; set; }
        public string no_clave_web { get; set; }
        public string nu_placa { get; set; }
        public Int32 nid_marca { get; set; }
        public Int32 nid_modelo { get; set; }
    }
    [Serializable]
    public class ClienteBEList : List<ClienteBE> { }
}