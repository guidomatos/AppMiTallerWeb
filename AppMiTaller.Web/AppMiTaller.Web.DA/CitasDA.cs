using System;
using System.Data;
using System.Data.SqlClient;
using AppMiTaller.Web.BE;

namespace AppMiTaller.Web.DA
{
    public class CitasDA
    {
        public CitasBE Obtiene_Texto_Legal(Int32 IdEmpresa, Int32 nid_marca)
        {
            CitasBE oCitasBE = null;
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("sgsnet_sps_texto_legal_by_id", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_empresa", IdEmpresa);
            cmd.Parameters.AddWithValue("@vi_nid_marca", nid_marca);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oCitasBE = new CitasBE();
                    oCitasBE = Entidad_Texto_Legal(reader);

                } reader.Close();
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
            return oCitasBE;
        }
        private CitasBE Entidad_Texto_Legal(IDataRecord DReader)
        {
            CitasBE Entidad = new CitasBE();
            Int32 indice = 0;
            indice = DReader.GetOrdinal("nid_tbl_texto_legales");
            Entidad.nid_tbl_texto_legales = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));

            indice = DReader.GetOrdinal("nid_empresa");
            Entidad.nid_empresa = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));

            indice = DReader.GetOrdinal("tx_legal");
            Entidad.tx_legal = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));

            indice = DReader.GetOrdinal("tx_alternativo_01");
            Entidad.tx_alternativo_01 = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));

            indice = DReader.GetOrdinal("tx_alternativo_02");
            Entidad.tx_alternativo_02 = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));

            return Entidad;
        }
        public CitasBE Obtiene_Validacion_Km(string patente, int nid_servicio, int nid_marca)
        {
            CitasBE oCitasBE = null;
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPS_OBTENER_KM_ULTIMAOT]", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_patente", patente);
            cmd.Parameters.AddWithValue("@vi_nid_servicio", nid_servicio);
            cmd.Parameters.AddWithValue("@vi_nid_marca", nid_marca);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    oCitasBE = new CitasBE();
                    oCitasBE = Entidad_Validacion_Km(reader);

                } reader.Close();
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
            return oCitasBE;
        }
        private CitasBE Entidad_Validacion_Km(IDataRecord DReader)
        {
            CitasBE Entidad = new CitasBE();
            Int32 indice = 0;

            indice = DReader.GetOrdinal("tx_alternativo_01");
            Entidad.tx_alternativo_01 = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));

            indice = DReader.GetOrdinal("tx_alternativo_02");
            Entidad.tx_alternativo_02 = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));

            return Entidad;
        }
        public Int32 Confirmar(CitasBE ent)
        {
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPI_CONFIRMAR_CITA_FO]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_cita", ent.nid_cita);
            cmd.Parameters.AddWithValue("@vi_nid_estado_ant", ent.nid_estado);
            Int32 res = 0;
            try
            {
                conn.Open();
                res = Int32.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception)
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
        public Int32 Anular(CitasBE ent)
        {
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPI_ANULAR_CITA_FO]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_cita", ent.nid_cita);
            cmd.Parameters.AddWithValue("@vi_nid_estado_ant", ent.nid_estado);
            Int32 res = 0;
            try
            {
                conn.Open();
                res = Int32.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception)
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
        public Int32 Reprogramar(CitasBE ent)
        {
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPI_REPROGRAMAR_CITA_FO]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_cita", ent.nid_cita);
            cmd.Parameters.AddWithValue("@vi_nid_estado_ant", ent.nid_estado);
            cmd.Parameters.AddWithValue("@vi_fe_reprogramacion", ent.fe_prog);
            cmd.Parameters.AddWithValue("@vi_ho_inicio", ent.ho_inicio);
            cmd.Parameters.AddWithValue("@vi_ho_fin", ent.ho_fin);
            cmd.Parameters.AddWithValue("@vi_nid_taller", ent.nid_taller);
            cmd.Parameters.AddWithValue("@vi_tx_observacion", ent.tx_observacion);
            cmd.Parameters.AddWithValue("@vi_nid_usuario", ent.nid_usuario);
            cmd.Parameters.AddWithValue("@vi_dd_atencion", ent.dd_atencion);
            cmd.Parameters.AddWithValue("@vi_no_nombreqr", ent.no_nombreqr);
            Int32 res = 0;
            try
            {
                conn.Open();
                res = Int32.Parse(cmd.ExecuteScalar().ToString());
            }
            catch (Exception)
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
        public String InsertarCita(CitasBE ent)
        {
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("SRC_SPI_RESERVAR_CITA_WEB_FO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_contacto", ent.nid_contacto);
            if (ent.nid_vehiculo != 0)
                cmd.Parameters.AddWithValue("@vi_nid_vehiculo", ent.nid_vehiculo);
            else
                cmd.Parameters.AddWithValue("@vi_nid_vehiculo", DBNull.Value);
            cmd.Parameters.AddWithValue("@vi_no_nombre", ent.no_nombre);
            cmd.Parameters.AddWithValue("@vi_no_ape_paterno", ent.no_ape_paterno);
            cmd.Parameters.AddWithValue("@vi_no_ape_materno", ent.no_ape_materno);
            cmd.Parameters.AddWithValue("@vi_co_tipo_doc", ent.co_tipo_documento);
            cmd.Parameters.AddWithValue("@vi_nu_documento", ent.nu_documento);
            cmd.Parameters.AddWithValue("@vi_no_email", ent.no_email);
            cmd.Parameters.AddWithValue("@vi_no_email_trab", ent.no_email_trabajo);
            cmd.Parameters.AddWithValue("@vi_no_email_alter", ent.no_email_alter);
            cmd.Parameters.AddWithValue("@vi_nu_tel_fijo", ent.nu_tel_fijo);
            cmd.Parameters.AddWithValue("@vi_nu_tel_movil", ent.nu_tel_movil);
            cmd.Parameters.AddWithValue("@vi_nid_taller", ent.nid_taller);
            cmd.Parameters.AddWithValue("@vi_nid_usuario", ent.nid_usuario);
            cmd.Parameters.AddWithValue("@vi_nid_servicio", ent.nid_servicio);
            cmd.Parameters.AddWithValue("@vi_nu_placa", ent.nu_placa);
            if (ent.nu_anio_vehiculo == -1)
            {
                cmd.Parameters.AddWithValue("@vi_nu_anio_veh", DBNull.Value);
                cmd.Parameters.AddWithValue("@vi_co_tipo_veh", DBNull.Value);
            }
            else
            {
                cmd.Parameters.AddWithValue("@vi_nu_anio_veh", ent.nu_anio_vehiculo);
                cmd.Parameters.AddWithValue("@vi_co_tipo_veh", ent.co_tipo_vehiculo);
            }
            cmd.Parameters.AddWithValue("@vi_nid_marca", ent.nid_marca);
            cmd.Parameters.AddWithValue("@vi_nid_modelo", ent.nid_modelo);
            cmd.Parameters.AddWithValue("@vi_fe_programada", ent.fe_prog);
            cmd.Parameters.AddWithValue("@vi_fl_origen", ent.fl_origen);
            cmd.Parameters.AddWithValue("@vi_ho_inicio", ent.ho_inicio);
            cmd.Parameters.AddWithValue("@vi_ho_fin", ent.ho_fin);
            cmd.Parameters.AddWithValue("@vi_fl_datos_pend", ent.fl_datos_pend);
            if (string.IsNullOrEmpty(ent.tx_observacion))
                cmd.Parameters.AddWithValue("@vi_tx_observacion", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@vi_tx_observacion", ent.tx_observacion);
            cmd.Parameters.AddWithValue("@vi_no_pais", ent.no_pais);
            cmd.Parameters.AddWithValue("@VI_DD_ATENCION", ent.dd_atencion);
            if (string.IsNullOrEmpty(ent.fl_taxi))
                cmd.Parameters.AddWithValue("@vi_fl_taxi", DBNull.Value);
            else
                cmd.Parameters.AddWithValue("@vi_fl_taxi", ent.fl_taxi);
            cmd.Parameters.AddWithValue("@vi_nid_empresa", ent.nid_empresa);
            cmd.Parameters.AddWithValue("@vi_fl_tipo_texto_legal", ent.fl_tipo_texto_legal);
            cmd.Parameters.AddWithValue("@co_origencita", ent.co_origencita);
            cmd.Parameters.AddWithValue("@vi_no_nombreqr", ent.no_nombreqr);
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
        public String AsignarClienteColaEspera(CitasBE ent)
        {
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPU_ASIGNAR_CLIENTE_CITA_COLAESPERA_FO]", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_cita", ent.nid_cita);
            cmd.Parameters.AddWithValue("@vi_nid_asesor", ent.nid_asesor);
            cmd.Parameters.AddWithValue("@vi_no_pais", ent.no_pais);
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
        
        public String GetCitaColaEspera(CitasBE ent)
        {
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("SRC_SPS_CLIENTES_COLAESPERA_FO", conn);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_cita", ent.nid_cita);
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
        public CitasBEList Listar_Datos_Cita(CitasBE ent)
        {
            CitasBEList lista = new CitasBEList();
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPS_LISTAR_CITA_POR_DATOS_FO]", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_cita", ent.nid_cita);
            cmd.Parameters.AddWithValue("@vi_cod_resverva_cita", ent.cod_reserva_cita);
            cmd.Parameters.AddWithValue("@vi_nu_documento", ent.nu_documento);
            cmd.Parameters.AddWithValue("@vi_nu_placa", ent.nu_placa);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(Entidad_Listar_Datos_Cita(reader));
                reader.Close();
            }
            catch //(Exception ex)
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
        public CitasBEList VerificarCitasPedientesPlaca(CitasBE ent)
        {
            CitasBEList lista = new CitasBEList();
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPS_VERIFICAR_CITAS_PENDIENTES_PLACA_FO]", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nu_placa", ent.nu_placa);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(Entidad_Listar_Citas_Pendiente(reader));
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
        public CitasBEList BuscarCitaPorCodigo(CitasBE ent)
        {
            CitasBEList lista = new CitasBEList();
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPS_CITA_POR_COD_FO]", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_cod_reserva", ent.cod_reserva_cita);
            cmd.Parameters.AddWithValue("@vi_nu_documento", ent.nu_documento);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(Entidad_BuscarCitaPorCodigo(reader));
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
        public CitasBEList ListarHorarioRecord()
        {
            CitasBEList lista = new CitasBEList();
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPS_HORARIO_RECORDATORIO_FO]", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(Entidad_ListarHorarioRecord(reader));
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
        public CitasBEList Listar_Ubigeos_Disponibles(CitasBE ent)
        {
            CitasBEList lista = new CitasBEList();
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("[SRC_SPS_LISTAR_UBIGEOS_FO]", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_servicio", ent.nid_servicio);
            cmd.Parameters.AddWithValue("@vi_nid_modelo", ent.nid_modelo);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(Entidad_Listar_Ubigeos_Disponibles(reader));
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
        private CitasBE Entidad_Listar_Datos_Cita(IDataRecord DReader)
        {
            CitasBE Entidad = new CitasBE();
            Int32 indice = 0;
            indice = DReader.GetOrdinal("nid_cita");
            Entidad.nid_cita = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("cod_reserva_cita");
            Entidad.cod_reserva_cita = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("fe_programada");
            Entidad.fecha_prog = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("ho_inicio_c");
            Entidad.ho_inicio_c = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("ho_fin_c");
            Entidad.ho_fin_c = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("fl_origen");
            Entidad.fl_origen = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("nid_estado");
            Entidad.nid_estado = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("fl_origen");
            Entidad.fl_origen = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("fl_datos_pendientes");
            Entidad.fl_datos_pend = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("tx_observacion");
            Entidad.tx_observacion = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("qt_km_inicial");
            Entidad.qt_km_inicial = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("fe_atencion");
            Entidad.fecha_atencion = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("tx_glosa_atencion");
            Entidad.tx_glosa_atencion = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("nid_estado");
            Entidad.nid_estado = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("co_estado");
            Entidad.co_estado = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("no_estado");
            Entidad.no_estado = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("nu_estado");
            Entidad.nu_estado = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("nid_cliente");
            Entidad.nid_cliente = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_cliente");
            Entidad.no_cliente = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("no_ape_pat");
            Entidad.no_ape_paterno = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("no_ape_mat");
            Entidad.no_ape_materno = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("co_tipo_documento");
            Entidad.co_tipo_documento = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("nu_documento");
            Entidad.nu_documento = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("no_correo");
            Entidad.no_correo = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("no_correo_trabajo");
            Entidad.no_correo_trabajo = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("no_correo_alter");
            Entidad.no_correo_alter = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("nu_telefono_c");
            Entidad.nu_telefono_c = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("nu_celular_c");
            Entidad.nu_celular_c = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("nid_servicio");
            Entidad.nid_servicio = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_servicio");
            Entidad.no_servicio = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("fl_quick_service");
            Entidad.fl_quick_service = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("nid_tipo_servicio");
            Entidad.nid_tipo_servicio = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_tipo_servicio");
            Entidad.no_tipo_servicio = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("nid_taller");
            Entidad.nid_taller = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_taller");
            Entidad.no_taller = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("co_intervalo");
            Entidad.co_intervalo = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("nu_intervalo");
            Entidad.nu_intervalo = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_direccion_t");
            Entidad.no_direccion_t = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("nu_telefono_t");
            Entidad.nu_telefono_t = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("tx_mapa_taller");
            Entidad.tx_mapa_taller = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("tx_url_taller");
            Entidad.tx_url_taller = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("dd_atencion_t");
            Entidad.dd_atencion = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("ho_inicio_t");
            Entidad.ho_inicio_t = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("ho_fin_t");
            Entidad.ho_fin_t = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("nid_ubica");
            Entidad.nid_ubica = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_ubica_corto");
            Entidad.no_ubica = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("coddpto");
            Entidad.coddpto = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("codprov");
            Entidad.codprov = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("coddist");
            Entidad.coddist = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("no_distrito");
            Entidad.no_distrito = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("nid_vehiculo");
            Entidad.nid_vehiculo = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("nu_placa");
            Entidad.nu_placa = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("nid_modelo");
            Entidad.nid_modelo = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_modelo");
            Entidad.no_modelo = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("nid_marca");
            Entidad.nid_marca = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_marca");
            Entidad.no_marca = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("nid_asesor");
            Entidad.nid_asesor = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_asesor");
            Entidad.no_asesor = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("nu_telefono_a");
            Entidad.nu_telefono_a = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("no_correo_asesor");
            Entidad.no_correo_asesor = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("nid_taller_empresa");
            Entidad.nid_taller_empresa = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_banco");
            Entidad.no_banco = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("nu_cuenta");
            Entidad.nu_cuenta = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("no_correo_callcenter");
            Entidad.no_correo_callcenter = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("nu_callcenter");
            Entidad.nu_callcenter = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("fl_nota");
            Entidad.fl_nota = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            indice = DReader.GetOrdinal("no_nombreqr");
            Entidad.no_nombreqr = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice).Trim());
            return Entidad;
        }
        private CitasBE Entidad_Listar_Citas_Pendiente(IDataRecord DReader)
        {
            CitasBE Entidad = new CitasBE();
            Int32 indice = 0;
            indice = DReader.GetOrdinal("nid_cita");
            Entidad.nid_cita = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_cliente");
            Entidad.no_cliente = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
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
            indice = DReader.GetOrdinal("nu_placa");
            Entidad.nu_placa = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_modelo");
            Entidad.no_modelo = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_marca");
            Entidad.no_marca = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("cod_reserva_cita");
            Entidad.cod_reserva_cita = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("fe_programada");
            Entidad.fecha_prog = (DReader.IsDBNull(indice) ? "" : DReader.GetDateTime(indice).ToShortDateString());
            indice = DReader.GetOrdinal("ho_inicio");
            Entidad.ho_inicio = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_servicio");
            Entidad.no_servicio = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_asesor");
            Entidad.no_asesor = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_taller");
            Entidad.no_taller = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_direccion");
            Entidad.no_direccion = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nu_telefono");
            Entidad.nu_telefono = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nu_callcenter");
            Entidad.nu_callcenter = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            return Entidad;
        }
        private CitasBE Entidad_BuscarCitaPorCodigo(IDataRecord DReader)
        {
            CitasBE Entidad = new CitasBE();
            Int32 indice = 0;
            indice = DReader.GetOrdinal("nid_cita");
            Entidad.nid_cita = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("nid_cliente");
            Entidad.nid_contacto = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("nid_usuario");
            Entidad.nid_usuario = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("ASESOR");
            Entidad.no_asesor = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nid_servicio");
            Entidad.nid_servicio = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_servicio");
            Entidad.no_servicio = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("fl_quick_service");
            Entidad.fl_quick_service = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nid_tipo_servicio");
            Entidad.nid_tipo_servicio = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("nid_taller");
            Entidad.nid_taller = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_taller");
            Entidad.no_taller = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("qt_intervalo_atenc");
            Entidad.qt_intervalo_atenc = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("NO_DIAS_VALIDOS");
            Entidad.no_dias_validos = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("DD_ATENCION");
            Entidad.dd_atencion = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("ho_taller_ini");
            Entidad.ho_taller_ini = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("ho_taller_fin");
            Entidad.ho_taller_fin = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nid_ubica");
            Entidad.nid_ubica = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_ubica");
            Entidad.no_ubica = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("CODDPTO");
            Entidad.coddpto = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("CODPROV");
            Entidad.codprov = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("CODDIST");
            Entidad.coddist = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("Distrito");
            Entidad.no_distrito = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("di_ubica");
            Entidad.di_ubica = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("tx_mapa_taller");
            Entidad.tx_mapa_taller = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nu_telefono");
            Entidad.nu_telefono = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nid_vehiculo");
            Entidad.nid_vehiculo = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("nu_placa");
            Entidad.nu_placa = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nid_marca");
            Entidad.nid_marca = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_marca");
            Entidad.no_marca = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nid_modelo");
            Entidad.nid_modelo = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_modelo");
            Entidad.no_modelo = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("fecha_prog");
            Entidad.fecha_prog = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("hora_ini");
            Entidad.ho_inicio = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("hora_fin");
            Entidad.ho_fin = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("tx_observacion");
            Entidad.tx_observacion = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("qt_km_inicial");
            Entidad.qt_km_inicial = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("fe_atencion");
            Entidad.fecha_atencion = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("tx_glosa_atencion");
            Entidad.tx_glos = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
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
            Entidad.nu_telefono = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nu_celular");
            Entidad.nu_celular = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nid_estado");
            Entidad.nid_estado = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("co_estado_cita");
            Entidad.co_estado_cita = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("NUM_ESTADO");
            Entidad.nu_estado = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("NOM_ESTADO");
            Entidad.no_estado_cita = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            return Entidad;
        }
        private CitasBE Entidad_ListarHorarioRecord(IDataRecord DReader)
        {
            CitasBE Entidad = new CitasBE();
            Int32 indice = 0;
            indice = DReader.GetOrdinal("NO_VALOR2");
            Entidad.ho_prog = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            return Entidad;
        }
        private CitasBE Entidad_Listar_Ubigeos_Disponibles(IDataRecord DReader)
        {
            CitasBE Entidad = new CitasBE();
            Int32 indice = 0;
            indice = DReader.GetOrdinal("coddpto");
            Entidad.coddpto = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("codprov");
            Entidad.codprov = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("coddist");
            Entidad.coddist = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nomdpto");
            Entidad.nomdpto = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nomprov");
            Entidad.nomprov = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nomdist");
            Entidad.nomdist = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            return Entidad;
        }
        public CitasBEList ListarTalleresDisponibles_PorFecha(CitasBE ent)
        {
            CitasBEList lista = new CitasBEList();
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("SRC_SPS_TALLERES_DISPONIBLES_FECHA_FO", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_servicio", ent.nid_servicio);
            cmd.Parameters.AddWithValue("@vi_nid_modelo", ent.nid_modelo);
            cmd.Parameters.AddWithValue("@VI_CODDPTO", ent.coddpto);
            cmd.Parameters.AddWithValue("@VI_CODPROV", ent.codprov);
            cmd.Parameters.AddWithValue("@VI_CODDIST", ent.coddist);
            cmd.Parameters.AddWithValue("@VI_NID_UBICA", ent.nid_ubica);
            cmd.Parameters.AddWithValue("@vi_nid_taller", ent.nid_taller);
            cmd.Parameters.AddWithValue("@VI_FECHA", ent.fe_atencion);
            cmd.Parameters.AddWithValue("@VI_DD_ATENCION", ent.dd_atencion);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(Entidad_ListarTalleresDisponibles_PorFecha(reader));
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
        public CitasBEList ListarHorarioExcepcional_Talleres(CitasBE ent)
        {
            CitasBEList lista = new CitasBEList();
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("SRC_SPS_HORARIO_EXCEPCIONAL_TALLERES_FO", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_taller", ent.nid_taller);
            cmd.Parameters.AddWithValue("@vi_fecha", ent.fe_atencion);
            cmd.Parameters.AddWithValue("@vi_dd_atencion", ent.dd_atencion);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(Entidad_ListarHorarioExcepcional_Talleres(reader));
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
        public CitasBEList ListarAsesoresDisponibles_PorFecha(CitasBE ent)
        {
            CitasBEList lista = new CitasBEList();
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("SRC_SPS_ASESORES_DISPONIBLES_FECHA_FO", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_Servicio", ent.nid_servicio);
            cmd.Parameters.AddWithValue("@vi_nid_modelo", ent.nid_modelo);
            cmd.Parameters.AddWithValue("@vi_nid_taller", ent.nid_taller);
            cmd.Parameters.AddWithValue("@vi_fecha", ent.fe_atencion);
            cmd.Parameters.AddWithValue("@vi_dd_atencion", ent.dd_atencion);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(Entidad_ListarAsesoresDisponibles_PorFecha(reader));
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
        public CitasBEList ListarCitasAsesores(CitasBE ent)
        {
            CitasBEList lista = new CitasBEList();
            SqlConnection conn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            SqlCommand cmd = new SqlCommand("SRC_SPS_CITAS_ASESORES_BO", conn);
            SqlDataReader reader = null;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@vi_nid_Servicio", ent.nid_servicio);
            cmd.Parameters.AddWithValue("@vi_nid_taller", ent.nid_taller);
            cmd.Parameters.AddWithValue("@vi_fecha", ent.fe_atencion);
            try
            {
                conn.Open();
                reader = cmd.ExecuteReader();
                while (reader.Read())
                    lista.Add(Entidad_ListarCitasAsesores(reader));
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
        private CitasBE Entidad_ListarTalleresDisponibles_PorFecha(IDataRecord DReader)
        {
            CitasBE Entidad = new CitasBE();
            Int32 indice = 0;
            indice = DReader.GetOrdinal("nid_taller");
            Entidad.nid_taller = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_taller");
            Entidad.no_taller = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("qt_intervalo");
            Entidad.qt_intervalo_atenc = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("qt_capacidad_t");
            Entidad.qt_capacidad_t = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("dd_atencion");
            Entidad.dd_atencion = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("ho_inicio_t");
            Entidad.ho_inicio_t = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("ho_fin_t");
            Entidad.ho_fin_t = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_direccion");
            Entidad.di_ubica = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_distrito");
            Entidad.no_distrito = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nu_telefono");
            Entidad.nu_telefono = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("tx_mapa_taller");
            Entidad.tx_mapa_taller = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("tx_url_taller");
            Entidad.tx_url_taller = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
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
            indice = DReader.GetOrdinal("fl_control");
            Entidad.fl_control = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("qt_citas_t");
            Entidad.qt_citas_t = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("qt_cantidad_t");
            Entidad.qt_cantidad_t = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("qt_capacidad_m");
            Entidad.qt_capacidad_m = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("qt_citas_m");
            Entidad.qt_citas_m = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("qt_cantidad_m");
            Entidad.qt_cantidad_m = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("nid_dia_exceptuado_t");
            Entidad.nid_dia_exceptuado_t = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("co_valoracion");
            Entidad.co_valoracion = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            return Entidad;
        }
        private CitasBE Entidad_ListarAsesoresDisponibles_PorFecha(IDataRecord DReader)
        {
            CitasBE Entidad = new CitasBE();
            Int32 indice = 0;
            indice = DReader.GetOrdinal("nid_taller");
            Entidad.nid_taller = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_taller");
            Entidad.no_taller = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nid_asesor");
            Entidad.nid_asesor = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("no_asesor");
            Entidad.no_asesor = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("ho_asesor");
            Entidad.horario_asesor = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("nu_telefono_a");
            Entidad.nu_telefono_a = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("no_correo");
            Entidad.no_correo_a = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("qt_capacidad_a");
            Entidad.qt_capacidad_a = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("qt_citas_a");
            Entidad.qt_citas_a = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("qt_cantidad_a");
            Entidad.qt_cantidad_a = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("nid_dia_exceptuado_a");
            Entidad.nid_dia_exceptuado_a = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            return Entidad;
        }
        private CitasBE Entidad_ListarHorarioExcepcional_Talleres(IDataRecord DReader)
        {
            CitasBE Entidad = new CitasBE();
            Int32 indice = 0;
            indice = DReader.GetOrdinal("nid_taller");
            Entidad.nid_taller = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("HO_RANGO1");
            Entidad.ho_rango1 = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("HO_RANGO2");
            Entidad.ho_rango2 = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("HO_RANGO3");
            Entidad.ho_rango3 = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            return Entidad;
        }
        private CitasBE Entidad_ListarCitasAsesores(IDataRecord DReader)
        {
            CitasBE Entidad = new CitasBE();
            Int32 indice = 0;
            indice = DReader.GetOrdinal("nid_taller");
            Entidad.nid_taller = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("nid_asesor");
            Entidad.nid_asesor = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            indice = DReader.GetOrdinal("ho_inicio_c");
            Entidad.ho_inicio_c = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("ho_fin_c");
            Entidad.ho_fin_c = (DReader.IsDBNull(indice) ? "" : DReader.GetString(indice));
            indice = DReader.GetOrdinal("qt_cola_espera");
            Entidad.qt_cola_espera = (DReader.IsDBNull(indice) ? 0 : DReader.GetInt32(indice));
            return Entidad;
        }
    }
}