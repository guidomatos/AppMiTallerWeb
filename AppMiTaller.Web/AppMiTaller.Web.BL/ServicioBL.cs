using AppMiTaller.Web.BE;
using AppMiTaller.Web.DA;

namespace AppMiTaller.Web.BL
{
    public class ServicioBL
    {
        public ServicioBEList Listar_Datos_Servicio(ServicioBE ent)
        {
            return new ServicioDA().Listar_Datos_Servicio(ent);
        }
        public ServicioBEList Listar_Servicios_PorTipo(ServicioBE ent)
        {
            return new ServicioDA().Listar_Servicios_PorTipo(ent);
        }
        public ServicioBEList Listar_Tipos_Servicios(int nid_modelo)
        {
            return new ServicioDA().Listar_Tipos_Servicios(nid_modelo);
        }
        public ServicioBE ObtenerTextoInformativo(int nid_tipo_servicio, int nid_marca)
        {
            return new ServicioDA().ObtenerTextoInformativo(nid_tipo_servicio, nid_marca);
        }
    }
}