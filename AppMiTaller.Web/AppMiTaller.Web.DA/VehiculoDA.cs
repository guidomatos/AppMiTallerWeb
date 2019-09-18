using System;
using System.Data;
using System.Data.SqlClient;
using AppMiTaller.Web.BE;

namespace AppMiTaller.Web.DA
{
    public class VehiculoDA
    {
        public VehiculoBEList ListarDatosPorPlaca(VehiculoBE ent)
        {
            VehiculoBEList lista = new VehiculoBEList();
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPS_DATOSVEHICULO_POR_PLACA_FO]", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nu_placa", ent.nu_placa);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(Entidad_ListarDatosPorPlaca(reader));
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
        public VehiculoBEList ListarMarcas(VehiculoBE ent)
        {
            VehiculoBEList lista = new VehiculoBEList();
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPS_MARCAS_FO]", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_empresa", ent.nid_empresa);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(Entidad_ListarMarcas(reader));
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
        public VehiculoBEList ListarModelosPorMarca(VehiculoBE ent)
        {
            VehiculoBEList lista = new VehiculoBEList();
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPS_MODELOS_POR_MARCA_FO]", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_marca", ent.nid_marca);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(Entidad_ListarModelosPorMarca(reader));
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
        public String MinimoDiasReservaPorModelo(VehiculoBE ent)
        {
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("SRC_SPS_MIN_DIASRESERVA_MODELO_FO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_modelo", ent.nid_modelo);
            string res = string.Empty;
            try
            {
                conn.Open();
                res = cmd.ExecuteScalar().ToString();
            }
            catch (Exception)
            {
                res = string.Empty;
                throw;
            }
            finally
            {
                conn.Close();
                conn.Dispose();
            }
            return res;
        }
        private VehiculoBE Entidad_ListarDatosPorPlaca(IDataRecord DReader)
        {
            VehiculoBE Entidad = new VehiculoBE();
            Int32 indice = 0;
            indice = DReader.GetOrdinal("nid_vehiculo");
            Entidad.nid_vehiculo = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("nid_marca");
            Entidad.nid_marca = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_marca");
            Entidad.no_marca = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nid_modelo");
            Entidad.nid_modelo = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_modelo");
            Entidad.no_modelo = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("qt_km_actual");
            Entidad.qt_km_actual = (DReader.IsDBNull(indice) ? 0 : Convert.ToInt32(DReader.GetInt64(indice)));
            indice = DReader.GetOrdinal("co_tipo");
            Entidad.co_tipo = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nu_anio");
            Entidad.nu_anio =(DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            return Entidad;
        }
        private VehiculoBE Entidad_ListarMarcas(IDataRecord DReader)
        {
            VehiculoBE Entidad = new VehiculoBE();
            Int32 indice = 0;
            indice = DReader.GetOrdinal("nid_marca");
            Entidad.nid_marca = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("co_marca");
            Entidad.co_marca =  (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_marca");
            Entidad.no_marca = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));                        
            return Entidad;
        }
        private VehiculoBE Entidad_ListarModelosPorMarca(IDataRecord DReader)
        {
            VehiculoBE Entidad = new VehiculoBE();
            Int32 indice = 0;            
            indice = DReader.GetOrdinal("nid_modelo");
            Entidad.nid_modelo = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("nid_marca");
            Entidad.nid_marca = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("co_modelo");
            Entidad.co_modelo = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_modelo");
            Entidad.no_modelo = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            return Entidad;
        }    
    }	
}