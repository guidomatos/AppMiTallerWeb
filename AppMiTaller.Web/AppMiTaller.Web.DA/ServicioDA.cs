using System;
using System.Data;
using System.Data.SqlClient;
using AppMiTaller.Web.BE;

namespace AppMiTaller.Web.DA
{
	public class ServicioDA
	{
        public ServicioBEList Listar_Datos_Servicio(ServicioBE ent)
        {
            ServicioBEList lista = new ServicioBEList();
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPS_LISTAR_DATOS_SERVICIOS_FO]", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_servicio", ent.nid_servicio);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(Entidad_Listar_Datos_Servicio(reader));
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
        public ServicioBEList Listar_Servicios_PorTipo(ServicioBE ent)
        {
            ServicioBEList lista = new ServicioBEList();
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPS_LISTAR_SERVICIOS_POR_TIPO_FO]", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_tipo_servicio", ent.nid_tipo_servicio);
            cmd.Parameters.AddWithValue("@vi_nid_modelo", ent.nid_modelo == 0 ? (object)DBNull.Value : ent.nid_modelo);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(Entidad_Listar_Servicios_PorTipo(reader));
                reader.Close();
            }
            catch //(Exception)
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
        public ServicioBE ObtenerTextoInformativo(int nid_tipo_servicio,int nid_marca)
        {
            ServicioBE oTextoInformativoBE = null;
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPS_OBTENER_TEXTO_INFORMATIVO]", conn);
            cmd.Parameters.AddWithValue("@vi_nid_tipo_servicio", nid_tipo_servicio);
            cmd.Parameters.AddWithValue("@vi_nid_marca", nid_marca == 0 ? (object)DBNull.Value : nid_marca);
            cmd.CommandType = CommandType.StoredProcedure;
            SqlDataReader reader = null;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                Int32 indice;
                while (reader.Read())
                {
                    oTextoInformativoBE = new ServicioBE();

                    indice = reader.GetOrdinal("fl_visible");
                    oTextoInformativoBE.fl_visible_tx_informativo = (reader.IsDBNull(indice) ? "" : reader.GetString(indice));

                    indice = reader.GetOrdinal("tx_informativo");
                    oTextoInformativoBE.tx_informativo = (reader.IsDBNull(indice) ? "" : reader.GetString(indice));
                }
                reader.Close();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return oTextoInformativoBE;
        }
        public ServicioBEList Listar_Tipos_Servicios(int nid_modelo)
        {
            ServicioBEList lista = new ServicioBEList();
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPS_LISTAR_TIPO_SERVICIO_FO]", conn);
            cmd.Parameters.AddWithValue("@vi_nid_modelo", nid_modelo == 0 ? (object)DBNull.Value : nid_modelo);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(Entidad_Listar_Tipos_Servicios(reader));
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
        private ServicioBE Entidad_Listar_Datos_Servicio(IDataRecord DReader)
        {
            ServicioBE Entidad = new ServicioBE();
            Int32 indice = 0;
            indice = DReader.GetOrdinal("nid_servicio");
            Entidad.nid_servicio = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_servicio");
            Entidad.no_servicio = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("qt_tiempo_prom");
            Entidad.qt_tiempo_prom = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("fl_quick_service");
            Entidad.fl_quick_service = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_dias_validos");
            Entidad.no_dias_validos = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            return Entidad;
        }        	
        private ServicioBE Entidad_Listar_Servicios_PorTipo(IDataRecord DReader)
        {
            ServicioBE Entidad = new ServicioBE();
            Int32 indice = 0;
            indice = DReader.GetOrdinal("nid_servicio");
            Entidad.nid_servicio = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_servicio");
            Entidad.no_servicio = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            return Entidad;
        }        
        private ServicioBE Entidad_Listar_Tipos_Servicios(IDataRecord DReader)
        {
            ServicioBE Entidad = new ServicioBE();
            Int32 indice = 0;
            indice = DReader.GetOrdinal("nid_tipo_servicio");
            Entidad.nid_tipo_servicio = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_tipo_servicio");
            Entidad.no_tipo_servicio = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("fl_visible_obs");
            Entidad.fl_visible_obs = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            return Entidad;
        }
	}	
}