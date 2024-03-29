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
            SqlCommand cmd = new SqlCommand("SRC_SPU_DATOS_CONTACTO_FO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_id_contacto", ent.nid_contacto);
            cmd.Parameters.AddWithValue("@vi_no_nombre", ent.no_nombre);
            cmd.Parameters.AddWithValue("@vi_no_ape_paterno", ent.no_ape_paterno);
            cmd.Parameters.AddWithValue("@vi_no_ape_materno", ent.no_ape_materno);
            cmd.Parameters.AddWithValue("@vi_nu_documento", ent.nu_documento);
            cmd.Parameters.AddWithValue("@vi_no_email", ent.no_email);
            cmd.Parameters.AddWithValue("@vi_nu_tel_movil", ent.nu_tel_movil);

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
        public ClienteBE Login(ClienteBE param)
        {
            ClienteBE retorno = null;

            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("src_sps_login_cliente_web", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_usuario", param.nu_documento);
            cmd.Parameters.AddWithValue("@vi_clave", param.no_clave_web);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    retorno = Entidad_Login(reader);
                reader.Close();
            }
            catch
            {
                if (reader != null && !reader.IsClosed) reader.Close();
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return retorno;
        }
        public ClienteBE ListarClientePorId(ClienteBE param)
        {
            ClienteBE retorno = null;

            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("src_sps_cliente_por_id", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_cliente", param.nid_cliente);

            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    retorno = Entidad_ListarClientePorId(reader);
                reader.Close();
            }
            catch
            {
                if (reader != null && !reader.IsClosed) reader.Close();
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return retorno;
        }

        public Int32 ActualizarClienteWeb(ClienteBE ent)
        {
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("src_spu_cliente_web", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_cliente", ent.nid_contacto);
            cmd.Parameters.AddWithValue("@vi_co_tipo_documento", ent.co_tipo_documento);
            cmd.Parameters.AddWithValue("@vi_nu_documento", ent.nu_documento);
            cmd.Parameters.AddWithValue("@vi_no_nombre", ent.no_nombre);
            cmd.Parameters.AddWithValue("@vi_no_ape_paterno", ent.no_ape_paterno);
            cmd.Parameters.AddWithValue("@vi_no_ape_materno", ent.no_ape_materno);
            cmd.Parameters.AddWithValue("@vi_nu_tel_movil", ent.nu_tel_movil);
            cmd.Parameters.AddWithValue("@vi_no_email", ent.no_email);
            cmd.Parameters.AddWithValue("@vi_tx_direccion", ent.tx_direccion);
            cmd.Parameters.AddWithValue("@vi_nu_placa", ent.nu_placa);
            cmd.Parameters.AddWithValue("@vi_nid_marca", ent.nid_marca);
            cmd.Parameters.AddWithValue("@vi_nid_modelo", ent.nid_modelo);
            cmd.Parameters.AddWithValue("@vi_no_clave_web", ent.no_clave_web);

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
        #region "Llenado de Entidades"
        private ClienteBE Entidad_ListarDatosContactoPorDoc(IDataRecord DReader)
        {
            ClienteBE Entidad = new ClienteBE();
            Int32 indice = 0;
            indice = DReader.GetOrdinal("nid_cliente");
            Entidad.nid_cliente = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("nid_vehiculo");
            Entidad.nid_vehiculo = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_cliente");
            Entidad.no_nombre = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
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
        private ClienteBE Entidad_Login(IDataRecord DReader)
        {
            ClienteBE Entidad = new ClienteBE();
            Int32 indice;
            indice = DReader.GetOrdinal("nid_cliente");
            Entidad.nid_cliente = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            return Entidad;
        }
        private ClienteBE Entidad_ListarClientePorId(IDataRecord DReader)
        {
            ClienteBE Entidad = new ClienteBE();
            Int32 indice = 0;
            //Datos del cliente
            indice = DReader.GetOrdinal("nid_cliente");
            Entidad.nid_cliente = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("co_tipo_cliente");
            Entidad.cod_tipo_persona = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("co_tipo_documento");
            Entidad.co_tipo_documento = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nu_documento");
            Entidad.nu_documento = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_cliente");
            Entidad.no_nombre = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_ape_pat");
            Entidad.no_ape_paterno = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_ape_mat");
            Entidad.no_ape_materno = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nu_celular");
            Entidad.nu_tel_movil = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_correo");
            Entidad.no_email = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("tx_direccion");
            Entidad.tx_direccion = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            //Datos del Vehiculo
            indice = DReader.GetOrdinal("nid_vehiculo");
            Entidad.nid_vehiculo = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("nu_placa");
            Entidad.nu_placa = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nid_marca");
            Entidad.nid_marca = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("nid_modelo");
            Entidad.nid_modelo = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            return Entidad;
        }
        #endregion
    }
}