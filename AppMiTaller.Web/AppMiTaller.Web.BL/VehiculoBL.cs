using AppMiTaller.Web.BE;
using AppMiTaller.Web.DA;

namespace AppMiTaller.Web.BL
{
    public class VehiculoBL
    {
        public VehiculoBEList ListarDatosPorPlaca(VehiculoBE ent)
        {
            return new VehiculoDA().ListarDatosPorPlaca(ent);
        }
        public VehiculoBEList ListarMarcas(VehiculoBE ent)
        {
            return new VehiculoDA().ListarMarcas(ent);
        }
        public VehiculoBEList ListarModelosPorMarca(VehiculoBE ent)
        {
            return new VehiculoDA().ListarModelosPorMarca(ent);
        }
        public string MinimoDiasReservaPorModelo(VehiculoBE ent)
        {
            return new VehiculoDA().MinimoDiasReservaPorModelo(ent);
        }
    }
}