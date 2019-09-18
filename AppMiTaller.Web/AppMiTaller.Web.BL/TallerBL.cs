using AppMiTaller.Web.BE;
using AppMiTaller.Web.DA;
using System.Collections;

namespace AppMiTaller.Web.BL
{
    public class TallerBL
    {
        public ArrayList ListarContenidoInformativoTaller(int nid_taller)
        {
            ArrayList oContenidoInfo = new ArrayList();

            TallerBE ent = new TallerDA().ListarContenidoInformativoTaller(nid_taller);
            if (ent != null)
            {
                oContenidoInfo.Add(ent.no_taller.ToString().Trim());
                oContenidoInfo.Add(ent.tx_promociones.ToString().Trim());
                oContenidoInfo.Add(ent.tx_noticias.ToString().Trim());
                oContenidoInfo.Add(ent.tx_datos.ToString().Trim());
                oContenidoInfo.Add(ent.tx_fotos.ToString().Trim());
            }
            return oContenidoInfo;
        }
        public TallerBEList Listar_PuntosRed(TallerBE ent)
        {
            return new TallerDA().Listar_PuntosRed(ent);
        }
        public TallerBEList Listar_Talleres(TallerBE ent)
        {
            return new TallerDA().Listar_Talleres(ent);
        }
    }
}