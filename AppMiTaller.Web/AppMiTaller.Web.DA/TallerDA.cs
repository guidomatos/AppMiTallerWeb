using System;
using System.Data;
using System.Data.SqlClient;
using AppMiTaller.Web.BE;

namespace AppMiTaller.Web.DA
{
	public class TallerDA
    {
        public TallerBE ListarContenidoInformativoTaller(int nid_taller)
        {
            TallerBE ent = null;
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("src_sps_contenido_total_taller_bo", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_taller", nid_taller);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ent = new TallerBE();
                    ent.no_taller = reader["no_taller"].ToString();
                    ent.tx_promociones = reader["tx_promociones"].ToString();
                    ent.tx_noticias = reader["tx_noticias"].ToString();
                    ent.tx_datos = reader["tx_datos"].ToString();
                    ent.tx_fotos = reader["tx_fotos"].ToString();
                }
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
            return ent;
        }
        public TallerBEList Listar_PuntosRed(TallerBE ent)
        {
            TallerBEList lista = new TallerBEList();
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPS_LISTAR_PUNTOS_RED_FO]", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_servicio", ent.nid_servicio);
            cmd.Parameters.AddWithValue("@vi_nid_modelo", ent.nid_modelo);
            cmd.Parameters.AddWithValue("@vi_coddpto", ent.coddpto);
            cmd.Parameters.AddWithValue("@vi_codprov", ent.codprov);
            cmd.Parameters.AddWithValue("@vi_coddist", ent.coddist);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(Entidad_Listar_PuntosRed(reader));
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
        public TallerBEList Listar_Talleres(TallerBE ent)
        {
            TallerBEList lista = new TallerBEList();
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPS_LISTAR_TALLERES_FO]", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_servicio", ent.nid_servicio);
            cmd.Parameters.AddWithValue("@vi_nid_modelo", ent.nid_modelo);
            cmd.Parameters.AddWithValue("@vi_nid_ubica", ent.nid_ubica);
            cmd.Parameters.AddWithValue("@vi_coddpto", ent.coddpto);
            cmd.Parameters.AddWithValue("@vi_codprov", ent.codprov);
            cmd.Parameters.AddWithValue("@vi_coddist", ent.coddist);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(Entidad_Listar_Talleres(reader));
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
        private TallerBE Entidad_Listar_PuntosRed(IDataRecord DReader)
        {
            TallerBE Entidad = new TallerBE();
            Int32 indice = 0;
            indice = DReader.GetOrdinal("nid_ubica");
            Entidad.nid_ubica = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_ubica");
            Entidad.no_ubica = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("coddpto");
            Entidad.coddpto = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("codprov");
            Entidad.codprov = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("coddist");
            Entidad.coddist = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            return Entidad;
        }
        private TallerBE Entidad_Listar_Talleres(IDataRecord DReader)
        {
            TallerBE Entidad = new TallerBE();
            Int32 indice = 0;
            indice = DReader.GetOrdinal("nid_taller");
            Entidad.nid_taller = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_taller");
            Entidad.no_taller = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("tx_mapa_taller");
            Entidad.tx_mapa_taller = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("fl_taxi");
            Entidad.fl_taxi = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nid_ubica");
            Entidad.nid_ubica = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("coddpto");
            Entidad.coddpto = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("codprov");
            Entidad.codprov = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("coddist");
            Entidad.coddist = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            return Entidad;
        }
	}	
}