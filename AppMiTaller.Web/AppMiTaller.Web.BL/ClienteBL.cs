using System;
using AppMiTaller.Web.BE;
using AppMiTaller.Web.DA;

namespace AppMiTaller.Web.BL
{
	public class ClienteBL
	{		
        public ClienteBEList ListarDatosContactoPorDoc(ClienteBE ent)
        {
            return new ClienteDA().ListarDatosContactoPorDoc(ent);
        }        		
        public ClienteBEList ListarTipoDocumentos()
        {
            return new ClienteDA().ListarTipoDocumentos();
        }		
        public Int32 ActualizarDatosCliente(ClienteBE ent)
        {
            return new ClienteDA().ActualizarDatosCliente(ent);
        }
	}	
}