using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using AppMiTaller.Web.BL;
using AppMiTaller.Web.BE;
using System.Web.Services;
using System.Configuration;

public partial class SRC_ResumenCita : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string Param_nid_cita = Request.Params["nid_cita"];
            if (Param_nid_cita != null)
            {
                if (Param_nid_cita != "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SeleccionaCita", "fn_GetResumen(" + Param_nid_cita + ");", true);
                }
            }
            else
            {
                String nid_marca = Request.Params["co_marca"].ToString();
                Response.Redirect("~/SRC_Home.aspx?co_marca=" + nid_marca);
            }
        }
    }

    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    [WebMethod]
    public static object Get_Resumen(Int32 codC)
    {
        String fl_seguir = "0";
        String msg_retorno = String.Empty;
        object strRetorno;
        object oDatosCita = null;
        try
        {
            Int32 nid_cita = codC;

            fl_seguir = "1";
            CitasBL oCitasBL = new CitasBL();
            CitasBE oCitasBE = new CitasBE();
            CitasBEList oCitasBEList = new CitasBEList();
            oCitasBE.nid_cita = nid_cita;
            oCitasBEList = oCitasBL.Listar_Datos_Cita(oCitasBE);
            oCitasBE = new CitasBE();
            oCitasBE = oCitasBEList[0];

            CorreoElectronico oEmail = new CorreoElectronico(HttpContext.Current.Server.MapPath("~/"));
            //>> Llenado para la Impresion
            string strImpresion = oEmail.CargarPlantilla_Imprimir(oCitasBE, Parametros.EstadoCita.REGISTRADA).ToString();
            Boolean fl_confirmar = !(oCitasBL.BuscarCitaPorCodigo(oCitasBE)[0].nu_estado.Equals(4));

            if (ConfigurationManager.AppSettings["MostrarMensajeRegistro"].Equals("1"))
                msg_retorno = (ConfigurationManager.AppSettings["msgCitaRegistrada"].ToString());

            //Set Datos Cita
            oDatosCita = new
            {
                template_impresion = strImpresion,
                fl_confirmar = fl_confirmar,
                //-------------------------
                nid_cita = oCitasBE.nid_cita,
                nu_estado = oCitasBE.nu_estado,
                co_reserva = " " + oCitasBE.cod_reserva_cita,
                no_taller = Parametros.N_Taller + ": " + oCitasBE.no_taller,
                no_asesor = Parametros.N_Asesor + ": " + oCitasBE.no_asesor,
                fe_programada = "Fecha: " + oCitasBE.fecha_prog,
                ho_programada = "Hora: " + FormatoHora(oCitasBE.ho_inicio_c),
                nu_telf_taller = Parametros.N_TelefonoTaller + ": " + oCitasBE.nu_telefono_t,
                nu_cel_asesor = Parametros.N_CellAsesor + ": " + oCitasBE.nu_telefono_a,
                nu_telf_callcenter = Parametros.N_TelefonoCall + ": "
                    + (oCitasBE.nid_taller_empresa.Equals(0) ? Parametros.N_TelefonoCallCenter : (string.IsNullOrEmpty(oCitasBE.nu_callcenter) ? Parametros.N_TelefonoCallCenter : oCitasBE.nu_callcenter))
            };

            strRetorno = new
            {
                fl_seguir = fl_seguir,
                msg_retorno = msg_retorno,
                oDatosCita = oDatosCita
            };
        }
        catch (Exception ex)
        {
            strRetorno = new
            {
                fl_seguir = "-1",
                msg_retorno = "Error: " + ex.Message,
                oDatosCita = oDatosCita
            };
        }

        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return serializer.Serialize(strRetorno);
    }

    private static string FormatoHora(string strHora)
    {
        string strHF = strHora;
        try
        {
            string strHoraF = Convert.ToDateTime(strHora).ToString("hh:mm");
            Int32 strHoraF1 = Convert.ToInt32(strHora.Replace(":", ""));
            strHF = strHoraF + ((strHoraF1 < 1200) ? " a.m." : " p.m.");
        }
        catch (Exception)
        {
            strHF = strHora;
        }
        return strHF;
    }
}