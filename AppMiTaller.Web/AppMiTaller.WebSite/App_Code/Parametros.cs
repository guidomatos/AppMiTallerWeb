using System;
using System.Configuration;

public class Parametros
{
	public Parametros()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    public const string OBJECTO_TODOS = "--Todos--";
    public const string OBJECTO_SELECCIONE = "--Seleccione--";
    public const string OBJECTO_NINGUNO = "--Ninguno--";

    public const string OBJECTO_ACTIVO = "Activo";
    public const string OBJECTO_INACTIVO = "Inactivo";

    public static class Combo
    {
        public static class SRC
        {
            public const string MARCAS = "MARCAS";
            public const string MODELOS = "MODELOS";
            public const string TIPO_SERVICIOS = "TIPO_SERVICIOS";
            public const string SERVICIOS = "SERVICIOS";
        }
    }

    //Configuración Principal
    public static Int32 SRC_CodEmpresaConfigurada()
    {
        Int32 nid_empresa_configurada = 0;
        String codEmpresas = ConfigurationManager.AppSettings["CodEmpresa"].ToString();
        Int32 nu_empresas_configuradas = codEmpresas.Split('$').Length;
        if (nu_empresas_configuradas == 1)
        {
            nid_empresa_configurada = Convert.ToInt32(codEmpresas.Split('$')[0].Split(':')[0]);
        }
        return nid_empresa_configurada;
    }
    
    public static string SRC_CodEmpresa(Int32 nid_marca_permitida)
    {
        String nid_empresa = "0";
        String strCodEmpresaMarca = ConfigurationManager.AppSettings["codEmpresa"].ToString();
        Boolean fl_marca_encontrada = false;
        foreach (string codEmpresaMarca in strCodEmpresaMarca.Split('$'))
        {
            String arrMarcas = codEmpresaMarca.Split(':')[1]; //Indice 1: marcas concatenadas
            foreach (string nid_marca in arrMarcas.Split('|'))
            {
                if (nid_marca == nid_marca_permitida.ToString())
                {
                    nid_empresa = codEmpresaMarca.Split(':')[0]; //Indice 0: empresa asociada
                    fl_marca_encontrada = true;
                    break;
                }
            }
            if (fl_marca_encontrada)
            {
                break;
            }
        }
        return nid_empresa;
    }
    public static Int32 SRC_Pais = Convert.ToInt32(ConfigurationManager.AppSettings["CodPais"]);
    public static PAIS SRC_Pais_actual = PAIS.PERU;
    public enum PAIS
    {
        PERU = 1,
        CHILE = 2
    }
    public static string SRC_PermitirObservaciones = ConfigurationManager.AppSettings["PermitirObservaciones"].ToString();
    public static string SRC_AniosVehiculo = ConfigurationManager.AppSettings["RangoAniosVehiculo"].ToString();
    public static string SRC_TiposVehiculo = ConfigurationManager.AppSettings["TiposVehiculo"].ToString();
    public static string SRC_MostrarAnioTipoVehiculo = ConfigurationManager.AppSettings["MostrarAnioTipoVehiculo"].ToString();
    public static string SRC_OrdenGrilla = ConfigurationManager.AppSettings["OrdenGrilla"].ToString();
    public static string SRC_CambiarTaller = ConfigurationManager.AppSettings["CambiarTaller"].ToString();

    #region - Nombres de los Controles
    public static string N_URLHome = nombreMensaje("nURLHome");
    public static string N_Asesor = nombreMensaje("nAsesor");
    public static string N_MaxLongitudTelfMovil = ConfigurationManager.AppSettings["MaxLongitudTelfMovil"].ToString();
    //Reservar Cita - Paso 2
    public static string N_VerificaDoc = nombreMensaje("nVerificaDoc");
    public static string N_TipoDocumento = ConfigurationManager.AppSettings["nTipoDoc"].ToString();
    public static string N_NumeroDoc = ConfigurationManager.AppSettings["nNumeroDoc"].ToString();
    public static string N_Nombres = ConfigurationManager.AppSettings["nNombres"].ToString();
    public static string N_ApellidoPat = ConfigurationManager.AppSettings["nApellidoPat"].ToString();
    public static string N_ApellidoMat = ConfigurationManager.AppSettings["nApellidoMat"].ToString();
    public static string N_EmailPersonal = ConfigurationManager.AppSettings["nEmailPers"].ToString();
    public static string N_EmailTrabajo = ConfigurationManager.AppSettings["nEmailTrab"].ToString();
    public static string N_EmailAlternativo = ConfigurationManager.AppSettings["nEmailAlter"].ToString();
    public static string N_TelefonoFijo = ConfigurationManager.AppSettings["nTelfFijo"].ToString();
    public static string N_TelefonoMovil = ConfigurationManager.AppSettings["nTelfMovil"].ToString();
    public static string N_EnviarRecord = ConfigurationManager.AppSettings["nEnviarRecord"].ToString();
    public static string N_TelefonoTaller = ConfigurationManager.AppSettings["nTelfTaller"].ToString();
    public static string N_CellAsesor = ConfigurationManager.AppSettings["nCellAsesor"].ToString();
    public static string N_TelefonoCall = ConfigurationManager.AppSettings["nTelfCallCenter"].ToString();
    public static string N_TextoPieCorreo = nombreMensaje("nTextoPieCorreo");
    public static string SRC_MostrarLogo = ConfigurationManager.AppSettings["MostrarLogo"].ToString();
    public static string SRC_MostrarTextoPie = ConfigurationManager.AppSettings["MostrarTextoPie"].ToString();    
    //Reservar Cita - Paso 1
    public static string N_Placa = nombreMensaje("nPlaca");
    public static string N_VerificaNum = nombreMensaje("nVerificaNum");
    public static string N_AnioVehiculo = ConfigurationManager.AppSettings["nAnioVehiculo"].ToString();
    public static string N_TipoVehiculo = ConfigurationManager.AppSettings["nTipoVehiculo"].ToString();
    public static string N_Departamento = nombreMensaje("nDepartamento");
    public static string N_Provincia = nombreMensaje("nProvincia");
    public static string N_Distrito = nombreMensaje("nDistrito");
    public static string N_Local = nombreMensaje("nLocal");
    public static string N_Taller = nombreMensaje("nTaller");
    public static string N_DatosRecord = nombreMensaje("nDatosRecord");

    public static string N_FormatoDoc = Convert.ToString(nombreMensaje("nFormatoDoc"));
    public static string N_SeleccionarCita = nombreMensaje("nSeleccionarCita");
    public static string N_DatoConsulta1 = nombreMensaje("nDatoConsulta1");
    public static string N_DatoConsulta2 = nombreMensaje("nDatoConsulta2");
    public static string N_DatoConsulta3 = nombreMensaje("nDatoConsulta3");
    public static string N_EtiquetaHome = nombreMensaje("nEtiquetaHome");
    public static string N_DatosObligatorio()
    {
        String indDatoObligatorio = Parametros.GetValor(PARM._15);
        String DatoObligatorio = String.Empty;
        switch(indDatoObligatorio){
            case "1": DatoObligatorio = Parametros.N_DatoConsulta1; break;
            case "2": DatoObligatorio = Parametros.N_DatoConsulta2; break;
            case "3": DatoObligatorio = Parametros.N_DatoConsulta3; break;
        };
        return nombreMensaje("nDatosObligatorio").Replace("{DatoObligatorio}", DatoObligatorio);
    }
    public static string N_TextoPieConsulta()
    {
        return ConfigurationManager.AppSettings["TextoPieConsulta"].ToString() + " " + Parametros.N_TelefonoCallCenter;
    }
    public static string N_TelefonoCallCenter = ConfigurationManager.AppSettings["TelefCallCenter"].ToString();
    public static string N_TextoIndicador(Int32 index = 0)
    {
        String strIndicador = nombreMensaje("nTextoIndicador");
        String[] textos = strIndicador.Split('$');
        //////if (textos.Length == 1 && index > 0) return "";
        //////else return strIndicador = textos[index].ToString();
        return strIndicador = textos[index].ToString();
    }
    public static string N_TextoOferta(Int32 index = 0)
    {
        String strTextoOferta = String.Empty;

        strTextoOferta = nombreMensaje("nTextoOferta");
        if (strTextoOferta.Contains("["))
        {
            string strEmail = strTextoOferta.Substring(strTextoOferta.IndexOf("["), strTextoOferta.IndexOf("]") - strTextoOferta.IndexOf("[") + 1);
            strTextoOferta.Replace(strEmail, "<a href='mailto:" + strEmail.Replace("[", "").Replace("]", "") + "'>" + strEmail.Replace("[", "").Replace("]", "") + "</a>");
        }

        return strTextoOferta;
    }


    //Nombres de los Mensajes a mostrar [PERU - CHILE]
    public static string nombreMensaje(string strMSG)
    {
        return ConfigurationManager.AppSettings[strMSG + "_" + Convert.ToString(ConfigurationManager.AppSettings["CodPais"])];
    }

    public enum PARM
    {
        _01 = 1,
        _02 = 2,
        _03 = 3,
        _04 = 4,
        _05 = 5,
        _06 = 6,
        _07 = 7,
        _08 = 8,
        _09 = 9,
        _10 = 10,
        _11 = 11,
        _12 = 12,
        _13 = 13,
        _14 = 14,
        _15 = 15,
        _16 = 16,
        _17 = 17,
        _18 = 18,
        _19 = 19,
        _20 = 20
    }
    public static string GetValor(PARM Prm)
    {
        return ConfigurationManager.AppSettings["PRM_" + Convert.ToInt32(Prm).ToString()].ToString();
    }
    #endregion - Nombres de los Controles [PERU - CHILE]
    #region - "Mensajes a mostrar del WebConfig"
    public static string msgSeleccioneAnio = ConfigurationManager.AppSettings["msgSeleccioneAnio"];
    public static string msgSeleccioneTipo = ConfigurationManager.AppSettings["msgSeleccioneTipo"];
    public static string msgNoAsesores = nombreMensaje("msgNoAsesores");
    public static string msgCapacidadTaller = nombreMensaje("msgCapacidadTaller");
    public static string msgYaVencCita = nombreMensaje("msgYaVencCita");
    public static string msgNoHoraIni = nombreMensaje("msgNoHoraIni");
    public static string msgNoHoraFin = nombreMensaje("msgNoHoraFin");
    public static string msgServDia = nombreMensaje("msgServDia");
    public static string msgMarcaNo = nombreMensaje("msgMarcaNo");
    public static string msgError = nombreMensaje("msgError");
    public static string msgCitaRep = nombreMensaje("msgCitaRep");
    public static string msgCambioTaller = nombreMensaje("msgCambioTaller");
    public static string msgYaExistePlaca = nombreMensaje("msgYaExistePlaca");
    public static string msgAtenderUnid = nombreMensaje("msgAtenderUnid");
    public static string msgCitasPend = nombreMensaje("msgCitasPend");
    public static string msgCambDoc = nombreMensaje("msgCambDoc");
    public static string msgRegOKContacto = nombreMensaje("msgRegOKContacto");
    public static string msgActOKContacto = nombreMensaje("msgActOKContacto");
    public static string msgNoExisteContactoBD = nombreMensaje("msgNoExisteContactoBD");
    public static string msgNoExisteCita = nombreMensaje("msgNoExisteCita");
    public static string msgNoCita = nombreMensaje("msgNoCita");
    public static string msgRegCita = nombreMensaje("msgRegCita");
    public static string msgConfCita = nombreMensaje("msgConfCita");
    public static string msgAnulCita = nombreMensaje("msgAnulCita");
    public static string msgNoMapa = nombreMensaje("msgNoMapa");
    public static string msgNoHorario2 = nombreMensaje("msgNoHorario2");
    public static string msgNoHorario1 = nombreMensaje("msgNoHorario1");
    public static string msgYaReprogCita = nombreMensaje("msgYaReprogCita");
    public static string msgYaAnulCita = nombreMensaje("msgYaAnulCita");
    public static string msgYaAtendCita = nombreMensaje("msgYaAtendCita");
    public static string msgYaConfCita = nombreMensaje("msgYaConfCita");
    public static string msgNoExisteContacto = nombreMensaje("msgNoExisteContacto");
    public static string msgExistePlaca = nombreMensaje("msgExistePlaca");
    public static string msgFecMax = nombreMensaje("msgFecMax");
    public static string msgFecMin = nombreMensaje("msgFecMin");
    public static string msgFecIniFin = nombreMensaje("msgFecIniFin");
    public static string msgNoHorarioRango = nombreMensaje("msgNoHorarioRango");
    public static string msgSelFechaFin = nombreMensaje("msgSelFechaFin");
    public static string msgSelFec = nombreMensaje("msgSelFec");
    public static string msgSelHora = nombreMensaje("msgSelHora");
    public static string msgCitasPendPlaca = nombreMensaje("msgCitasPendPlaca");
    public static string msgNoExisteDoc = nombreMensaje("msgNoExisteDoc");
    public static string msgNoExisteRUC = nombreMensaje("msgNoExisteRUC");
    public static string msgNoExisteCE = ConfigurationManager.AppSettings["msgNoExisteCE"];
    public static string msgRepRUC = nombreMensaje("msgRepRUC");
    public static string msgRepDoc = nombreMensaje("msgRepDoc");
    public static string msgRepCont = nombreMensaje("msgRepCont");
    public static string msgEstaCambio = nombreMensaje("msgEstaCambio");
    public static string msgNoEncontroDoc = ConfigurationManager.AppSettings["msgNoEncontroDoc"];
    public static string msgSiEncontroDoc = ConfigurationManager.AppSettings["msgSIEncontroDoc"];
    #endregion - "Mensajes a mostrar del WebConfig"

    public enum EstadoCita
    {
        REGISTRADA = 1,
        REPROGRAMADA = 2,
        ANULADA = 3,
        CONFIRMADA = 4,
        REASIGNADA = 5,
        ATENDIDA = 6,
        COLA_ESPERA = 7,
        VENCIDA = 8
    }
    public enum PERSONA
    {
        CLIENTE = 1,
        ASESOR = 2,
        CALL_CENTER = 3,
        IMPRIMIR = 4
    }
}