using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using AppMiTaller.Web.BE;
using AppMiTaller.Web.BL;

public partial class SRC_ConsultarCita : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {

    }

    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    [WebMethod]
    public static object Get_Inicial(String nid_cliente)
    {
        #region "- Carga Placa por Cliente"
        ArrayList oDatosVehiculo = new ArrayList();
        List<object> oComboPlaca = new List<object>();

        VehiculoBL oVehiculoBL = new VehiculoBL();
        ClienteBE param = new ClienteBE();
        param.nid_cliente = Convert.ToInt32(nid_cliente);
        VehiculoBEList listaVehiculo = oVehiculoBL.ListarVehiculoPorCliente(param);
        if (listaVehiculo != null && listaVehiculo.Count > 0)
        {
            foreach (VehiculoBE item in listaVehiculo)
            {
                oComboPlaca.Add(new
                {
                    value = item.nu_placa,
                    nombre = item.nu_placa

                });
            }
        }

        #endregion

        object response = new
        {
            oComboPlaca = oComboPlaca
        };
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return serializer.Serialize(response);
    }

    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    [WebMethod]
    public static object Get_Bandeja(String[] strFiltros)
    {
        CitasBE oCitasBE = new CitasBE();
        CitasBL oCitasBL = new CitasBL();
        oCitasBE.nid_cita = 0;
        oCitasBE.nu_placa = strFiltros[0];
        oCitasBE.nid_cliente = Convert.ToInt32(strFiltros[1]);
        CitasBEList oCitasBEList = oCitasBL.Listar_Datos_Cita(oCitasBE);

        List<object> oCitas = new List<object>();
        object oCita;

        String id_img = String.Empty;
        if (oCitasBEList.Count == 1) { id_img = "id='ImgSeleccionar'"; }
        String imgSeleccionar = "<img " + id_img + " title='Seleccionar' alt='Seleccionar' src='img/disponible.png' style='width: 18px; height: 18px;' onclick='javascript: fn_SeleccionaCita(&#39;{0}&#39;);' />";
        foreach (CitasBE obj in oCitasBEList)
        {
            oCita = new
            {
                no_taller = obj.no_taller,
                fe_inicio = obj.fecha_prog + " - " + obj.ho_inicio_c,
                nu_servicio = obj.no_servicio,
                no_asesor = obj.no_asesor,
                co_estado = obj.no_estado,
                seleccionar = String.Format(imgSeleccionar, obj.nid_cita.ToString())
            };
            oCitas.Add(oCita);
        }
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return serializer.Serialize(oCitas);
    }

    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    [WebMethod]
    public static object Get_DetalleCita(String[] strParametros)
    {
        CitasBE oCitasBE = new CitasBE();
        CitasBL oCitasBL = new CitasBL();
        CitasBEList oCitasBEList = new CitasBEList();

        Int32 nid_cita; Int32.TryParse(strParametros[0], out nid_cita);

        oCitasBE.nid_cita = nid_cita;
        oCitasBE.cod_reserva_cita = "";
        oCitasBEList = oCitasBL.Listar_Datos_Cita(oCitasBE);

        Int32 flg_estado_botones = 1;
        Int32 _EstadoCita = Convert.ToInt32(oCitasBEList[0].nu_estado);
        if (_EstadoCita == (Int32)Parametros.EstadoCita.ANULADA)
            flg_estado_botones = 0;
        else if (_EstadoCita == (Int32)Parametros.EstadoCita.VENCIDA)
            flg_estado_botones = 0;
        else if (_EstadoCita == (Int32)Parametros.EstadoCita.ATENDIDA)
            flg_estado_botones = 0;
        else if (_EstadoCita == (Int32)Parametros.EstadoCita.REPROGRAMADA)
            flg_estado_botones = 1;

        object filas = new
        {
            nid_cita = oCitasBEList[0].nid_cita,
            cod_reserva_cita= oCitasBEList[0].cod_reserva_cita,
            fecha_prog=  oCitasBEList[0].fecha_prog,
            fecha_prog_format = GetFechaLarga(Convert.ToDateTime(oCitasBEList[0].fecha_prog)) + ", a las " + FormatoHora(oCitasBEList[0].ho_inicio_c),
            ho_inicio_c = oCitasBEList[0].ho_inicio_c,
            ho_fin_c = oCitasBEList[0].ho_fin_c,
            fl_origen = oCitasBEList[0].fl_origen,
            nid_estado = oCitasBEList[0].nid_estado, 
            fl_datos_pend = oCitasBEList[0].fl_datos_pend ,
            tx_observacion = oCitasBEList[0].tx_observacion,
            qt_km_inicial = oCitasBEList[0].qt_km_inicial ,
            fecha_atencion = oCitasBEList[0].fecha_atencion,
            tx_glosa_atencion = oCitasBEList[0].tx_glosa_atencion ,
            co_estado = oCitasBEList[0].co_estado ,
            no_estado= oCitasBEList[0].no_estado,
            nu_estado = oCitasBEList[0].nu_estado, 
            flg_estado_botones = flg_estado_botones,
            nid_cliente= oCitasBEList[0].nid_cliente,
            no_cliente = oCitasBEList[0].no_cliente,
            no_ape_paterno= oCitasBEList[0].no_ape_paterno,
            no_ape_materno = oCitasBEList[0].no_ape_materno, 
            co_tipo_documento= oCitasBEList[0].co_tipo_documento,
            nu_documento = oCitasBEList[0].nu_documento,
            no_correo= oCitasBEList[0].no_correo,
            no_correo_trabajo = oCitasBEList[0].no_correo_trabajo ,
            no_correo_alter= oCitasBEList[0].no_correo_alter,
            nu_telefono_c = oCitasBEList[0].nu_telefono_c,
            nu_celular_c = oCitasBEList[0].nu_celular_c,
            nid_servicio= oCitasBEList[0].nid_servicio,
            no_servicio = oCitasBEList[0].no_servicio,
            fl_quick_service= oCitasBEList[0].fl_quick_service,
            nid_tipo_servicio = oCitasBEList[0].nid_tipo_servicio, 
            no_tipo_servicio= oCitasBEList[0].no_tipo_servicio,
            nid_taller = oCitasBEList[0].nid_taller,
            no_taller= oCitasBEList[0].no_taller,
            co_intervalo= oCitasBEList[0].co_intervalo,
            nu_intervalo= oCitasBEList[0].nu_intervalo,
            no_direccion_t= oCitasBEList[0].no_direccion_t,
            nu_telefono_t= oCitasBEList[0].nu_telefono_t,
            tx_mapa_taller= oCitasBEList[0].tx_mapa_taller,
            tx_url_taller= oCitasBEList[0].tx_url_taller,
            dd_atencion= oCitasBEList[0].dd_atencion,
            ho_inicio_t= oCitasBEList[0].ho_inicio_t,
            ho_fin_t= oCitasBEList[0].ho_fin_t,
            nid_ubica= oCitasBEList[0].nid_ubica,
            no_ubica= oCitasBEList[0].no_ubica,
            coddpto= oCitasBEList[0].coddpto,
            codprov= oCitasBEList[0].codprov,
            coddist= oCitasBEList[0].coddist,
            no_distrito= oCitasBEList[0].no_distrito,
            nid_vehiculo= oCitasBEList[0].nid_vehiculo,
            nu_placa= oCitasBEList[0].nu_placa,
            nid_modelo= oCitasBEList[0].nid_modelo,
            no_modelo= oCitasBEList[0].no_modelo,
            nid_marca= oCitasBEList[0].nid_marca,
            no_marca= oCitasBEList[0].no_marca,
            nid_asesor= oCitasBEList[0].nid_asesor,
            no_asesor= oCitasBEList[0].no_asesor,
            nu_telefono_a= oCitasBEList[0].nu_telefono_a,
            no_correo_asesor= oCitasBEList[0].no_correo_asesor,
            nid_taller_empresa = oCitasBEList[0].nid_taller_empresa,
            no_banco = oCitasBEList[0].no_banco,
            nu_cuenta = oCitasBEList[0].nu_cuenta,
            no_correo_callcenter = oCitasBEList[0].no_correo_callcenter,
            nu_callcenter = oCitasBEList[0].nu_callcenter,
            fl_nota = oCitasBEList[0].fl_nota
        };

        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return serializer.Serialize(filas);
    }

    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    [WebMethod]
    public static int ActualizarDatosCliente(String[] strParametros)
    {
        ClienteBE oClienteBE = new ClienteBE();
        ClienteBL oClienteBL = new ClienteBL();
        ClienteBEList oClienteBEList = new ClienteBEList();

        int nid_contacto;
        Int32.TryParse(strParametros[0], out nid_contacto);
        oClienteBE.nid_contacto = nid_contacto;
        oClienteBE.no_nombre = strParametros[1];
        oClienteBE.no_ape_paterno = strParametros[2];
        oClienteBE.no_ape_materno = strParametros[3];
        oClienteBE.nu_documento = strParametros[4];
        oClienteBE.no_email = strParametros[5];
        oClienteBE.nu_tel_movil = strParametros[6];

        int resultado = oClienteBL.ActualizarDatosCliente(oClienteBE);
        return resultado;
    }

    private static string GetFechaLarga(DateTime dt)
    {
        return dt.ToString("D", System.Globalization.CultureInfo.CurrentCulture);
    }

    private static string FormatoHora(string strHora)
    {
        string strHF = strHora;
        try
        {
            string strHoraF = Convert.ToDateTime(strHora).ToString("hh:mm");
            Int32 strHoraF1 = Convert.ToInt32(strHora.Replace(":", ""));
            strHF = strHoraF + (((strHoraF1 < 1200)) ? " a.m." : " p.m.");
        }
        catch (Exception)
        {
            strHF = strHora;
        }
        return strHF;
    }
}