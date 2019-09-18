using System;
using System.Data;
using System.Data.SqlClient;
using AppMiTaller.Web.BE;

namespace AppMiTaller.Web.DA
{
	public class ClienteDA
	{		
        public ClienteBEList ListarDatosContactoPorDoc(ClienteBE ent)
        {
            ClienteBEList lista = new ClienteBEList();
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPS_LISTAR_DATOSCONTACTO_POR_DOC_FO]", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_cod_tipodoc", ent.co_tipo_documento);
            cmd.Parameters.AddWithValue("@vi_nu_documento", ent.nu_documento);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(Entidad_ListarDatosContactoPorDoc(reader));                
                reader.Close();
            }
            catch (Exception)
            {
                if (reader != null && !reader.IsClosed) reader.Close();
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return lista;         
        }        		
        public ClienteBEList ListarTipoDocumentos()
        {
            ClienteBEList lista = new ClienteBEList();
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPS_TIPOS_DOCUMENTOS_FO]", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(Entidad_ListarTipoDocumentos(reader));
                reader.Close();
            }
            catch (Exception)
            {
                if (reader != null && !reader.IsClosed) reader.Close();
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return lista;
        }		
        public Int32 ActualizarDatosCliente(ClienteBE ent)
        {
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPU_DATOS_CONTACTO_FO]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_id_contacto", ent.nid_contacto);
            cmd.Parameters.AddWithValue("@vi_no_nombre",  ent.no_nombre);
            cmd.Parameters.AddWithValue("@vi_no_ape_paterno",  ent.no_ape_paterno);
            cmd.Parameters.AddWithValue("@vi_no_ape_materno",  ent.no_ape_materno);
            cmd.Parameters.AddWithValue("@vi_nu_documento", ent.nu_documento);
            cmd.Parameters.AddWithValue("@vi_no_email", ent.no_email);
            cmd.Parameters.AddWithValue("@vi_no_email_trab", ent.no_email_trabajo);
            cmd.Parameters.AddWithValue("@vi_no_email_alter",  ent.no_email_alter);
            cmd.Parameters.AddWithValue("@vi_nu_tel_fijo",  ent.nu_tel_fijo);
            cmd.Parameters.AddWithValue("@vi_nu_tel_movil",  ent.nu_tel_movil);
            Int32 res = 0;
            try
            {
                conn.Open();
                res = Int32.Parse(cmd.ExecuteScalar().ToString());
            }
            catch
            {
                res = 0;
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return res;
        }
        
        private ClienteBE Entidad_ListarDatosContactoPorDoc(IDataRecord DReader)
        {
            ClienteBE Entidad = new ClienteBE();
            Int32 indice = 0;
            indice = DReader.GetOrdinal("nid_cliente");
            Entidad.nid_cliente = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("nid_vehiculo");
            Entidad.nid_vehiculo = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_cliente");
            Entidad.no_nombre  = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_ape_pat");
            Entidad.no_ape_paterno = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_ape_mat");
            Entidad.no_ape_materno = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("co_tipo_documento");
            Entidad.co_tipo_documento = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nu_documento");
            Entidad.nu_documento = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_email");
            Entidad.no_email = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_email_trabajo");
            Entidad.no_email_trabajo = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_email_alter");
            Entidad.no_email_alter = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nu_telefono");
            Entidad.nu_tel_fijo = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nu_celular");
            Entidad.nu_tel_movil = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));            
            return Entidad;
        }
        private ClienteBE Entidad_ListarTipoDocumentos(IDataRecord DReader)
        {
            ClienteBE Entidad = new ClienteBE();
            Int32 indice = 0;
            indice = DReader.GetOrdinal("cod_tipo_documento");
            Entidad.cod_tipo_documento = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("des_tipo_documento");
            Entidad.des_tipo_documento = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            return Entidad;
        }		
	}	
}