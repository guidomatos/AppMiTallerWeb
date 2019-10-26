using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Services;
using System.Globalization;
using System.Collections;
using AppMiTaller.Web.BE;
using AppMiTaller.Web.BL;
using System.Configuration;

public partial class SRC_ReprogramarCita : System.Web.UI.Page
{
    public const string imgURL_HORA_LIBRE = "img/disponible.png";
    private const string imgURL_HORA_RESERVADA = "img/ocupado.PNG";
    private const string imgURL_HORA_VACIA = "img/vacio.PNG";
    private const string imgURL_HORA_EXCEPCIONAL = "img/vacio.PNG";
    public const string imgURL_HORA_SEPARADA = "img/SEPARA.PNG";
    private const string imgURL_VALORACION = "img/valoracion/estrellas-{0}.png";
    public static String fl_ubigeo_all = "1";
    private static Boolean fl_format_24_horas = true;

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
    public static object Get_UbigeoDisponible(String[] strParametros)
    {
        String msg_retorno = String.Empty;
        object strRetorno;
        String fl_seguir = "1";
        List<object> oComboDepartamento = new List<object>();
        List<object> oComboProvincia = new List<object>();
        List<object> oComboDistrito = new List<object>();
        String fl_quick_service = String.Empty, fl_dias_validos = String.Empty;
        try
        {
            Int32 nid_servicio; Int32.TryParse(strParametros[0], out nid_servicio);
            Int32 nid_modelo; Int32.TryParse(strParametros[1], out nid_modelo);
            String nid_marca_permitida = strParametros[2];
            if (nid_servicio > 0)
            {
                ServicioBL oServicioBL = new ServicioBL();
                ServicioBE oServicioBE = new ServicioBE();
                oServicioBE.nid_servicio = nid_servicio;
                ServicioBEList oServicioBEList = oServicioBL.Listar_Datos_Servicio(oServicioBE);
                fl_quick_service = oServicioBEList[0].fl_quick_service;
                fl_dias_validos = oServicioBEList[0].no_dias_validos;

                #region - Obtiene Ubigeo Disponible
                CitasBL oCitasBL = new CitasBL();
                CitasBE oCitasBE = new CitasBE();
                oCitasBE.nid_servicio = nid_servicio;
                oCitasBE.nid_modelo = nid_modelo;
                CitasBEList oUbigeoDisponible = oCitasBL.Listar_Ubigeos_Disponibles(oCitasBE);
                
                if (oUbigeoDisponible.Count > 0)
                {
                    object objDepartamento;
                    foreach (CitasBE oUbigeo in oUbigeoDisponible)
                    {
                        objDepartamento = new { value = oUbigeo.coddpto.ToString(), nombre = oUbigeo.nomdpto };
                        oComboDepartamento.Add(objDepartamento);
                    }

                    object objProvincia;
                    List<CitasBE> oProvinciaDisponible = oUbigeoDisponible.OrderBy(prov => prov.nomprov).ToList();
                    String codprov = String.Empty;
                    foreach (CitasBE oUbigeo in oProvinciaDisponible)
                    {
                        if (fl_ubigeo_all == "1") { codprov = oUbigeo.coddpto + oUbigeo.codprov; }
                        else { codprov = oUbigeo.codprov; }
                        objProvincia = new { value = codprov, nombre = oUbigeo.nomprov, coddpto = oUbigeo.coddpto };
                        oComboProvincia.Add(objProvincia);
                    }

                    object objDistrito;
                    List<CitasBE> oDistritoDisponible = oUbigeoDisponible.OrderBy(dist => dist.nomdist).ToList();
                    String coddist = String.Empty;
                    foreach (CitasBE oUbigeo in oDistritoDisponible)
                    {
                        if (fl_ubigeo_all == "1") { coddist = oUbigeo.coddpto + oUbigeo.codprov + oUbigeo.coddist; }
                        else { coddist = oUbigeo.coddist; }
                        objDistrito = new
                        {
                            value = coddist,
                            nombre = oUbigeo.nomdist,
                            coddpto = oUbigeo.coddpto,
                            codprov = oUbigeo.codprov
                        };
                        oComboDistrito.Add(objDistrito);
                    }
                }
                else
                {
                    msg_retorno = "No hay talleres disponibles para este servicio y modelo.";
                    fl_seguir = "0";
                }
                #endregion - Obtiene Ubigeo Disponible
            }

            strRetorno = new
            {
                fl_seguir = fl_seguir,
                msg_retorno = msg_retorno,
                oComboDepartamento = oComboDepartamento.Distinct(),
                oComboProvincia = oComboProvincia.Distinct(),
                oComboDistrito = oComboDistrito.Distinct()
            };
        }
        catch (Exception ex)
        {
            strRetorno = new
            {
                fl_seguir = "-1",
                msg_retorno = "Error: " + ex.Message,
                oComboDepartamento = oComboDepartamento,
                oComboProvincia = oComboProvincia,
                oComboDistrito = oComboDistrito
            };
        }

        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return serializer.Serialize(strRetorno);
    }

    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    [WebMethod]
    public static object Get_UbicacionDisponible(String[] strParametros)
    {
        String msg_retorno = String.Empty;
        object strRetorno;
        String fl_seguir = "1";
        List<object> oComboUbicacion = new List<object>();
        List<object> oComboTaller = new List<object>();
        String fl_quick_service = String.Empty, fl_dias_validos = String.Empty;
        try
        {
            Int32 nid_modelo; Int32.TryParse(strParametros[0], out nid_modelo);
            Int32 nid_servicio; Int32.TryParse(strParametros[1], out nid_servicio);
            String coddpto = strParametros[2] == "" ? "0" : strParametros[2];
            String codprov = strParametros[3] == "" ? "0" : strParametros[3];
            String coddist = strParametros[4] == "" ? "0" : strParametros[4];

            #region - Obtiene Ubicacion Disponible
            TallerBE oTallerBE = new TallerBE();
            TallerBL oTallerBL = new TallerBL();
            oTallerBE.nid_servicio = nid_servicio;
            oTallerBE.nid_modelo = nid_modelo;
            oTallerBE.coddpto = coddpto;
            oTallerBE.codprov = codprov;
            oTallerBE.coddist = coddist;
            TallerBEList oUbicacionDisponible = oTallerBL.Listar_PuntosRed(oTallerBE);
            if (oUbicacionDisponible.Count > 0)
            {
                object objUbicacion;
                String co_ubicacion = String.Empty;
                foreach (TallerBE oUbicacion in oUbicacionDisponible)
                {
                    if (fl_ubigeo_all == "1") { co_ubicacion = oUbicacion.coddpto + oUbicacion.codprov + oUbicacion.coddist + oUbicacion.nid_ubica.ToString(); }
                    else { co_ubicacion = oUbicacion.nid_ubica.ToString(); }
                    objUbicacion = new
                    {
                        value = co_ubicacion,
                        nombre = oUbicacion.no_ubica,
                        coddpto = oUbicacion.coddpto,
                        codprov = oUbicacion.codprov,
                        coddist = oUbicacion.coddist
                    };
                    oComboUbicacion.Add(objUbicacion);
                }
            }
            else
            {
                msg_retorno = "No hay talleres disponibles para este servicio y modelo.";
                fl_seguir = "0";
            }
            #endregion - Obtiene Ubicacion Disponible
            if (fl_seguir != "0")
            {
                #region - Obtiene Taller Disponible
                oTallerBE = new TallerBE();
                oTallerBE.nid_servicio = nid_servicio;
                oTallerBE.nid_modelo = nid_modelo;
                oTallerBE.coddpto = coddpto;
                oTallerBE.codprov = codprov;
                oTallerBE.coddist = coddist;
                oTallerBE.nid_ubica = 0; //para que liste todos los talleres
                TallerBEList oTallerDisponible = oTallerBL.Listar_Talleres(oTallerBE);
                if (oTallerDisponible.Count > 0)
                {
                    object objTaller;
                    String co_taller = String.Empty;
                    foreach (TallerBE oTaller in oTallerDisponible)
                    {
                        if (fl_ubigeo_all == "1")
                        {
                            co_taller = oTaller.coddpto + oTaller.codprov + oTaller.coddist
                                + oTaller.nid_ubica.ToString()
                                + "$" + oTaller.nid_taller;
                        }
                        else { co_taller = oTaller.nid_taller.ToString(); }
                        objTaller = new
                        {
                            value = co_taller,
                            nombre = oTaller.no_taller,
                            coddpto = oTaller.coddpto,
                            codprov = oTaller.codprov,
                            coddist = oTaller.coddist,
                            nid_ubica = oTaller.nid_ubica,
                            tx_mapa_taller = oTaller.tx_mapa_taller
                        };
                        oComboTaller.Add(objTaller);
                    }
                }
                else
                {
                    msg_retorno = "No hay talleres disponibles para este servicio y modelo.";
                    fl_seguir = "0";
                }
                #endregion - Obtiene Taller Disponible
            }

            strRetorno = new
            {
                fl_seguir = fl_seguir,
                msg_retorno = msg_retorno,
                oComboUbicacion = oComboUbicacion,
                oComboTaller = oComboTaller
            };
        }
        catch (Exception ex)
        {
            strRetorno = new
            {
                fl_seguir = "-1",
                msg_retorno = "Error: " + ex.Message,
                oComboUbicacion = oComboUbicacion,
                oComboTaller = oComboTaller
            };
        }

        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return serializer.Serialize(strRetorno);
    }

    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    [WebMethod]
    public static object Get_HorarioDisponible(String[] strParametros)
    {
        String msg_retorno = String.Empty;
        object strRetorno;
        String fl_seguir = "1";
        List<object> oHorarioDisponible = new List<object>();
        String sfe_max_reserva = GetFechaMaxReserva();
        List<object> oComboHoraInicio = new List<object>();
        List<object> oComboHoraFinal = new List<object>();
        Int32 intIntervaloT = 0;

        String tbl_Footable = String.Empty;

        List<object> Columns_data = new List<object>();
        String Header_Tbl = String.Empty;

        String fl_mostrar_calidad = ConfigurationManager.AppSettings["MostrarCalidad"].ToString();
        String fl_mostrar_promociones = ConfigurationManager.AppSettings["MostrarPromociones"].ToString();
        #region - Define Cabecera y Model Column
        ArrayList oHorario_Cabecera = new ArrayList();
        oHorario_Cabecera.Add(Parametros.N_Local);
        oHorario_Cabecera.Add(Parametros.N_Taller);
        oHorario_Cabecera.Add("Calidad Servicio");
        oHorario_Cabecera.Add("Dirección");
        oHorario_Cabecera.Add("Promociones y Noticias");
        oHorario_Cabecera.Add("Taller Disponible");

        Dictionary<string, object> oModelCol = null;
        ArrayList oHorario_ModelCol = new ArrayList();
        oModelCol = new Dictionary<string, object>();
        oModelCol.Add("name", "no_ubica"); oModelCol.Add("index", "no_ubica"); oModelCol.Add("width", 130); oModelCol.Add("sortable", false);
        oHorario_ModelCol.Add(oModelCol);
        oModelCol = new Dictionary<string, object>();
        oModelCol.Add("name", "no_taller"); oModelCol.Add("index", "no_taller"); oModelCol.Add("width", 130); oModelCol.Add("sortable", false);
        oHorario_ModelCol.Add(oModelCol);

        oModelCol = new Dictionary<string, object>();
        oModelCol.Add("name", "calidad_servicio"); oModelCol.Add("index", "calidad_servicio"); oModelCol.Add("width", 100); oModelCol.Add("align", "center");
        if (fl_mostrar_calidad == "0")
        {
            oModelCol.Add("hidden", true);
        }
        oHorario_ModelCol.Add(oModelCol);

        oModelCol = new Dictionary<string, object>();
        oModelCol.Add("name", "di_ubica"); oModelCol.Add("index", "di_ubica"); oModelCol.Add("width", 170); oModelCol.Add("sortable", false);
        oHorario_ModelCol.Add(oModelCol);

        oModelCol = new Dictionary<string, object>();
        oModelCol.Add("name", "promociones_noticias"); oModelCol.Add("index", "promociones_noticias"); oModelCol.Add("width", 100); oModelCol.Add("align", "center"); oModelCol.Add("sortable", false);
        if (fl_mostrar_promociones == "0")
        {
            oModelCol.Add("hidden", true);
        }
        oHorario_ModelCol.Add(oModelCol);

        oModelCol = new Dictionary<string, object>();
        oModelCol.Add("name", "fl_disponible"); oModelCol.Add("index", "fl_disponible"); oModelCol.Add("hidden", true);
        oHorario_ModelCol.Add(oModelCol);
        #endregion - Define Cabecera y Model Column
        try
        {
            Int32 nid_modelo; Int32.TryParse(strParametros[0], out nid_modelo);
            Int32 nid_servicio; Int32.TryParse(strParametros[1], out nid_servicio);
            String coddpto = strParametros[2] == "" ? "0" : strParametros[2];
            String codprov = strParametros[3] == "" ? "0" : strParametros[3];
            String coddist = strParametros[4] == "" ? "0" : strParametros[4];
            Int32 nid_ubica; Int32.TryParse(strParametros[5], out nid_ubica);
            Int32 nid_taller; Int32.TryParse(strParametros[6], out nid_taller);
            String sfe_reserva = strParametros[7];

            #region - Obtiene Horario Disponible
            Int32 intPRM = 3;
            CitasBL oCitasBL = new CitasBL();
            CitasBE oCitasBE = new CitasBE();
            CitasBEList oCitasBEList = new CitasBEList();
            DateTime dtHITallerT = DateTime.MaxValue;
            DateTime dtHFTallerT = DateTime.MinValue;
            Int32 intPRM_13 = Convert.ToInt32(Parametros.GetValor(Parametros.PARM._13));

            //--------------------
            // 1 -> Departamento
            // 2 -> Provincia
            // 3 -> Distrito
            //--------------------
            //    1          2
            if (intPRM > intPRM_13)
            {
                CitasBEList lstTalleres_Disponibles = null;
                CitasBEList _lstTalleresHE = null;
                CitasBEList _lstAsesores_Disponibles = null;
                CitasBEList _lstCitas = null;
                #region - Obtiene Fecha mínima de reserva, Talleres disponibles, Talleres Horario Excepcional, Asesores disponibles y Citas
                oCitasBE.nid_servicio = nid_servicio;
                oCitasBE.nid_modelo = nid_modelo;
                oCitasBE.coddpto = coddpto;
                oCitasBE.codprov = codprov;
                oCitasBE.coddist = coddist;
                oCitasBE.nid_ubica = nid_ubica;
                oCitasBE.nid_taller = nid_taller;
                if ((string.IsNullOrEmpty(sfe_reserva)))
                {
                    sfe_reserva = SRC_FECHA_HABIL(nid_modelo, nid_servicio, coddpto, codprov, coddist, nid_ubica, nid_taller
                        , out lstTalleres_Disponibles, out _lstTalleresHE, out _lstAsesores_Disponibles, out _lstCitas).ToString(CultureInfo.CurrentCulture.DateTimeFormat.ShortDatePattern);
                }
                oCitasBE.fe_atencion = Convert.ToDateTime(sfe_reserva);
                oCitasBE.dd_atencion = getDiaSemana(oCitasBE.fe_atencion);
                if (lstTalleres_Disponibles == null)
                {
                    lstTalleres_Disponibles = oCitasBL.ListarTalleresDisponibles_PorFecha(oCitasBE);//   1-Listado todos Talleres                
                    _lstTalleresHE = oCitasBL.ListarHorarioExcepcional_Talleres(oCitasBE);// 2-Listado Horario Excepcionales
                    _lstAsesores_Disponibles = oCitasBL.ListarAsesoresDisponibles_PorFecha(oCitasBE);//  3-Listado Asesores Talleres
                    _lstCitas = oCitasBL.ListarCitasAsesores(oCitasBE);//                    4-Listado CitasAsesores Talleres
                }
                #endregion - Obtiene Fecha mínima de reserva, Talleres disponibles, Talleres Horario Excepcional, Asesores disponibles y Citas
                if (lstTalleres_Disponibles.Count == 0)
                {
                    fl_seguir = "0";
                    msg_retorno = "No hay Talleres disponibles para este día.";
                }
                else if (lstTalleres_Disponibles.Count == 1 && nid_taller > 0)
                { //Carga Asesores por Web Method
                    fl_seguir = "2";
                    goto Response;
                }
                else
                {
                    intIntervaloT = 0;
                    //Get Mayor Intervalo de Tiempo entre todos los Talleres 
                    //Get Hora_Inicio y Hora_Final entre todos los Talleres                    
                    foreach (CitasBE oTaller in lstTalleres_Disponibles)
                    {
                        if (Convert.ToDateTime(oTaller.ho_inicio_t) < dtHITallerT) dtHITallerT = Convert.ToDateTime(oTaller.ho_inicio_t);
                        if (Convert.ToDateTime(oTaller.ho_fin_t) > dtHFTallerT) dtHFTallerT = Convert.ToDateTime(oTaller.ho_fin_t);
                        if (Convert.ToInt32(oTaller.qt_intervalo_atenc) > intIntervaloT) intIntervaloT = Convert.ToInt32(oTaller.qt_intervalo_atenc);
                    }
                    oComboHoraInicio = cargarComboHorarioTaller(dtHITallerT, dtHFTallerT, intIntervaloT);
                    oComboHoraFinal = oComboHoraInicio;
                    #region "Generando CABECERA Y MODEL COLUMN de las horas"
                    Int32 qt_col_main = oHorario_Cabecera.Count;
                    DateTime _dtHITaller = dtHITallerT;
                    DateTime _dtHFTaller = dtHFTallerT;
                    string strHorasTaller = string.Empty;
                    //Agrega Columna de horas: RANGO DE HORAS                    
                    while (_dtHITaller < _dtHFTaller)
                    {
                        string strColumHora = Convert.ToDateTime(_dtHITaller).ToString("HHmm");
                        String no_columna = "HORA_" + strColumHora;

                        oHorario_Cabecera.Add(Convert.ToDateTime(_dtHITaller).ToString("HH:mm"));
                        oModelCol = new Dictionary<string, object>();
                        oModelCol.Add("name", no_columna);
                        oModelCol.Add("index", no_columna);
                        oModelCol.Add("width", 45);
                        oModelCol.Add("sortable", false);
                        oModelCol.Add("align", "center");
                        oModelCol.Add("hidden", false);
                        oHorario_ModelCol.Add(oModelCol);

                        strHorasTaller += Convert.ToDateTime(_dtHITaller).ToString("HH:mm") + "|";
                        _dtHITaller = _dtHITaller.AddMinutes(intIntervaloT);
                    }
                    if (strHorasTaller.Trim().Length > 0)
                        strHorasTaller = strHorasTaller.Substring(0, strHorasTaller.Length - 1);
                    #endregion "Generando CABECERA Y MODEL COLUMN de las horas"
                    #region "Ordena columna de grilla segun configuracion"
                    if (Parametros.SRC_OrdenGrilla.Equals("2"))
                    {
                        ArrayList oHorario_Cabecera_aux = new ArrayList();
                        ArrayList oHorario_ModelCol_aux = new ArrayList();
                        for (Int32 i = qt_col_main; i < oHorario_Cabecera.Count; i++)
                        {
                            oHorario_Cabecera_aux.Add(oHorario_Cabecera[i]);
                            oHorario_ModelCol_aux.Add(oHorario_ModelCol[i]);
                        }
                        for (Int32 i = 0; i < qt_col_main; i++)
                        {
                            oHorario_Cabecera_aux.Add(oHorario_Cabecera[i]);
                            oHorario_ModelCol_aux.Add(oHorario_ModelCol[i]);
                        }
                        oHorario_Cabecera = oHorario_Cabecera_aux;
                        oHorario_ModelCol = oHorario_ModelCol_aux;
                    }
                    #endregion "Ordena columna de grilla segun configuracion"
                    Int32 rowID = 1;
                    String imgValoracion = "<img title='' alt='' src='" + imgURL_VALORACION + "' />";
                    String lnkPromocionesNoticias = "<span class='enlace' onclick='fn_MostrarPromocion({0});'>(Ver Información)</span>";
                    String imghoraVacia = String.Empty;
                    String imgHoraLibre = "<img id='{2}' idfoo='{2}' style='cursor:pointer;' title='Seleccionar' alt='' src='" + imgURL_HORA_LIBRE + "' onclick='javascript: fn_SetHoraTaller(&#39;{0}&#39;, &#39;{1}&#39;, &#39;{2}&#39;, &#39;{3}&#39;);' />";
                    String imgHoraReservada = "<img title='' alt='' src='" + imgURL_HORA_RESERVADA + "' />";
                    String imgHoraExcepcional = "<img title='' alt='' src='" + imgURL_HORA_EXCEPCIONAL + "' />";
                    String imgHoraColumna = String.Empty;
                    #region "Rellenando el grid con los Puntos de Red, Taller y Direcciones"
                    foreach (CitasBE oTaller in lstTalleres_Disponibles)
                    {
                        Dictionary<string, object> oHorario = new Dictionary<string, object>();
                        oHorario.Add("no_ubica", oTaller.no_ubica);
                        oHorario.Add("no_taller", oTaller.no_taller);
                        oHorario.Add("calidad_servicio", String.Format(imgValoracion, oTaller.co_valoracion));
                        oHorario.Add("di_ubica", oTaller.di_ubica);
                        oHorario.Add("promociones_noticias", String.Format(lnkPromocionesNoticias, oTaller.nid_taller.ToString()));
                        oHorario.Add("fl_disponible", String.Empty);
                        //Agrega Columna de horas: RANGO DE HORAS
                        _dtHITaller = dtHITallerT;
                        _dtHFTaller = dtHFTallerT;
                        while (_dtHITaller < _dtHFTaller)
                        {
                            string strColumHora = Convert.ToDateTime(_dtHITaller).ToString("HHmm");
                            String no_columna = "HORA_" + strColumHora;

                            oHorario.Add(no_columna, String.Empty);

                            _dtHITaller = _dtHITaller.AddMinutes(intIntervaloT);
                        }
                        oHorarioDisponible.Add(oHorario);
                        rowID++;
                    }
                    #endregion "Rellenando el grid con los Puntos de Red, Taller y Direcciones"
                    #region "Set Horarios de cada taller"
                    // Horarios de cada taller
                    String strHorarioT = string.Empty;
                    Int32 intNoAsesores = 0;
                    Int32 nid_taller_aux; Int32 intervalo_taller;
                    DateTime dtHITaller; DateTime dtHFTaller;
                    Dictionary<string, object> oTallerHorario;
                    Int32 intFila = 0;
                    rowID = 1;
                    foreach (CitasBE oTaller in lstTalleres_Disponibles)
                    {
                        nid_taller_aux = oTaller.nid_taller;
                        dtHITaller = Convert.ToDateTime(oTaller.ho_inicio_t);
                        dtHFTaller = Convert.ToDateTime(oTaller.ho_fin_t);
                        intervalo_taller = int.Parse(oTaller.qt_intervalo_atenc);

                        oTallerHorario = new Dictionary<string, object>();
                        oTallerHorario = ((Dictionary<string, object>)(oHorarioDisponible[intFila]));

                        String fl_disponible = "1";
                        //Identifica si el taller está disponible y con cupos
                        if (oTaller.nid_dia_exceptuado_t == 1) //Validaciones Fecha Exceptuada - Taller
                            fl_disponible = "0";
                        else if (oTaller.qt_cantidad_t <= 0) //Validaciones Capacidad Atencion - Taller
                            fl_disponible = "0";
                        else if (Parametros.SRC_Pais_actual == Parametros.PAIS.PERU)//Validacion Capacidad Atencion - Taller y Modelo
                            if (oTaller.qt_cantidad_m <= 0)
                                fl_disponible = "0";

                        //Verifica que tenga asesores disponibles
                        List<CitasBE> lstAsesoresTaller = _lstAsesores_Disponibles.FindAll(ase => ase.nid_taller == nid_taller_aux
                            && ase.nid_dia_exceptuado_a == 0 //Validacion Fecha Exceptuada - Asesor
                            && ase.qt_cantidad_a > 0); //Validacion Capacidad Atencion - Asesor

                        if (lstAsesoresTaller.Count == 0) //No hay Asesores disponibles para este Taller
                        {
                            intNoAsesores += 1;
                            _dtHITaller = dtHITaller;
                            _dtHFTaller = dtHFTaller;
                            while (_dtHITaller <= _dtHFTaller)
                            {
                                strHorarioT += "0" + "-";
                                _dtHITaller = _dtHITaller.AddMinutes(intervalo_taller);
                            }
                            strHorarioT = strHorarioT.Substring(0, strHorarioT.Length - 1);
                            strHorarioT += "|";
                            fl_disponible = "0";
                        }

                        //Verifica si tiene Hora Excepcional del Taller
                        List<CitasBE> lstTalleresHE = _lstTalleresHE.FindAll(tllr => tllr.nid_taller == nid_taller_aux);
                        String strTotalHE = string.Empty;
                        foreach (CitasBE oHET in lstTalleresHE)
                        {
                            if (!string.IsNullOrEmpty(oHET.ho_rango1)) strTotalHE += oHET.ho_rango1 + "-";
                            if (!string.IsNullOrEmpty(oHET.ho_rango2)) strTotalHE += oHET.ho_rango2 + "-";
                            if (!string.IsNullOrEmpty(oHET.ho_rango3)) strTotalHE += oHET.ho_rango3 + "-";
                        }
                        if (!string.IsNullOrEmpty(strTotalHE))
                            strTotalHE = strTotalHE.Substring(0, strTotalHE.Length - 1);

                        //Asesores disponibles
                        String strHorarioA = String.Empty;
                        String[] strTemp;
                        foreach (CitasBE oAsesor in lstAsesoresTaller)
                        {
                            //SET HORARIO DEL ASESOR
                            _dtHITaller = dtHITaller;
                            _dtHFTaller = dtHFTaller;
                            strHorarioA = string.Empty;
                            while (_dtHITaller <= _dtHFTaller)
                            {
                                strHorarioA += "2" + "-"; //Para identificar Horario Vacio (por defecto)
                                _dtHITaller = _dtHITaller.AddMinutes(intervalo_taller);
                            }
                            //=================================================================================
                            //> Listar Citas Asesores 
                            //=================================================================================
                            // FILTRAR CITAS - TALLER - ASESOR
                            //-----------------------------------
                            DateTime ho_inicio_asesor; DateTime ho_final_asesor;
                            Int32 intCantRango = 0;
                            Int32 intCol;
                            foreach (string strRangoHA in oAsesor.horario_asesor.Split('|'))
                            {
                                _dtHITaller = dtHITaller;
                                _dtHFTaller = dtHFTaller;
                                intCol = 0;
                                ho_inicio_asesor = Convert.ToDateTime(strRangoHA.Split('-').GetValue(0).ToString());
                                ho_final_asesor = Convert.ToDateTime(strRangoHA.Split('-').GetValue(1).ToString());
                                while (_dtHITaller <= _dtHFTaller)
                                {
                                    if (_dtHITaller >= ho_inicio_asesor && _dtHITaller < ho_final_asesor)
                                    { //Si Horario del asesor está dentro del horario del taller, setea en "1"
                                        strTemp = strHorarioA.Split('-');
                                        strTemp[intCol] = "1"; //Para identificar Horario Libre
                                        strHorarioA = string.Empty;
                                        foreach (string strT in strTemp)
                                        {
                                            if (strT.Equals(""))
                                                continue;
                                            strHorarioA += strT + "-";
                                        }
                                    }
                                    intCol += 1;
                                    _dtHITaller = _dtHITaller.AddMinutes(intervalo_taller);
                                }
                                intCantRango += 1;
                            }
                            if (strHorarioA.Length > 0)
                                strHorarioA = strHorarioA.Substring(0, strHorarioA.Length - 1);

                            //Verificamos si en el horario del taller existen citas
                            List<CitasBE> lstCitasAsesor = _lstCitas.FindAll(ci => ci.nid_taller == nid_taller_aux && ci.nid_asesor == oAsesor.nid_asesor);
                            DateTime dtHICita, dtHFCita;
                            foreach (CitasBE oCita in lstCitasAsesor)
                            {
                                dtHICita = Convert.ToDateTime(oCita.ho_inicio_c);
                                dtHFCita = Convert.ToDateTime(oCita.ho_fin_c);
                                while (dtHICita < dtHFCita)
                                {
                                    _dtHITaller = dtHITaller;
                                    _dtHFTaller = dtHFTaller;
                                    intCol = 0;
                                    while (_dtHITaller <= _dtHFTaller)
                                    {
                                        if (_dtHITaller >= dtHICita && dtHICita < _dtHFTaller)
                                        { //Si Cita del asesor está dentro del horario del taller, setea en "0"
                                            //>> Si hay cita reservada (ICONO DE RESERVADO)
                                            strTemp = strHorarioA.Split('-');
                                            strTemp[intCol] = "0";
                                            strHorarioA = string.Empty;
                                            foreach (string strT in strTemp)
                                                strHorarioA += strT + "-";
                                            if (strHorarioA.Length > 0)
                                                strHorarioA = strHorarioA.Substring(0, strHorarioA.Length - 1);
                                            break;
                                        }
                                        intCol += 1;
                                        _dtHITaller = _dtHITaller.AddMinutes(intervalo_taller);
                                    }
                                    dtHICita = dtHICita.AddMinutes(intervalo_taller);
                                }
                            }
                            strHorarioT += strHorarioA + "|";
                        }

                        String[] strRangos;
                        strRangos = strHorarioT.Split('|');
                        strHorarioT = strHorarioA = string.Empty;

                        String[] strInd;
                        Int32 oCol, oColT;
                        foreach (string strRango in strRangos)
                        {
                            if (strRango.Equals(""))
                                continue;
                            strInd = strRango.Split('-');
                            oCol = 0; oColT = 0;
                            _dtHITaller = dtHITaller;
                            _dtHFTaller = dtHFTaller;
                            while (_dtHITaller < _dtHFTaller)
                            {
                                imgHoraLibre = "<img id='{2}' idfoo='{2}' style='cursor:pointer;' title='Seleccionar' alt='' src='" + imgURL_HORA_LIBRE + "' onclick='javascript: fn_SetHoraTaller(&#39;{0}&#39;, &#39;{1}&#39;, &#39;{2}&#39;, &#39;{3}&#39;);' />";
                                imgHoraColumna = string.Empty;
                                switch (strInd.GetValue(oCol).ToString())
                                {
                                    case "1": imgHoraColumna = (fl_disponible == "0") ? imgHoraReservada : imgHoraLibre; break;
                                    case "0": imgHoraColumna = imgHoraReservada; break;
                                    case "2": imgHoraColumna = imghoraVacia; break;
                                }
                                // SET HORARIO EXCEPCIONAL  ------------------------------------------------
                                DateTime dtHEITaller, dtHEFTaller;
                                if (!String.IsNullOrEmpty(strTotalHE))
                                {
                                    foreach (string _strRangoHE in strTotalHE.Split('-'))
                                    {
                                        dtHEITaller = Convert.ToDateTime(_strRangoHE.Split('|').GetValue(0));
                                        dtHEFTaller = Convert.ToDateTime(_strRangoHE.Split('|').GetValue(1));
                                        if (_dtHITaller >= dtHEITaller && _dtHITaller < dtHEFTaller) // Si es una hora excepcionl
                                        {
                                            imgHoraColumna = imgHoraExcepcional; // Icon: Horario Excepcional
                                            break;
                                        }
                                    }
                                }
                                oColT = 0;
                                DateTime _dtHITallerT, _dtHFTallerT;
                                _dtHITallerT = dtHITallerT;
                                _dtHFTallerT = dtHFTallerT;
                                while ((_dtHITallerT < _dtHFTallerT)) //Horas de la grilla
                                {
                                    if ((_dtHITaller >= _dtHITallerT) & (_dtHITaller < (_dtHITallerT.AddMinutes(intIntervaloT))))
                                    { //Si hora del taller está dentro de la hora de la grilla
                                        String no_columna = "HORA_" + _dtHITallerT.ToString("HHmm");

                                        if (imgHoraColumna == imgHoraLibre)
                                        {
                                            String keys = String.Empty;
                                            if (fl_ubigeo_all == "1")
                                            {
                                                keys = String.Format("{0}|{1}|{2}|{3}|{4}|{5}", oTaller.coddpto
                                                    , oTaller.coddpto + oTaller.codprov
                                                    , oTaller.coddpto + oTaller.codprov + oTaller.coddist
                                                    , oTaller.coddpto + oTaller.codprov + oTaller.coddist + oTaller.nid_ubica
                                                    , oTaller.coddpto + oTaller.codprov + oTaller.coddist + oTaller.nid_ubica + "$" + oTaller.nid_taller
                                                    , oTaller.qt_intervalo_atenc);
                                            }
                                            else
                                            {
                                                keys = String.Format("{0}|{1}|{2}|{3}|{4}|{5}", oTaller.coddpto, oTaller.codprov, oTaller.coddist, oTaller.nid_ubica, oTaller.nid_taller, oTaller.qt_intervalo_atenc);
                                            }

                                            imgHoraLibre = String.Format(imgHoraLibre, rowID.ToString(), no_columna, no_columna + "_" + rowID.ToString()
                                                , keys);
                                            imgHoraColumna = imgHoraLibre;
                                        }

                                        if (!oTallerHorario[no_columna].ToString().Contains("disponible"))
                                        { //Si en el horario ya existe un asesor disponible, se deja libre para el taller
                                            oTallerHorario[no_columna] = imgHoraColumna;
                                        }
                                    }
                                    oColT += 1;
                                    _dtHITallerT = _dtHITallerT.AddMinutes(intIntervaloT);
                                }
                                oCol += 1;
                                _dtHITaller = _dtHITaller.AddMinutes(intervalo_taller);
                            }
                        }

                        //----
                        oTallerHorario["fl_disponible"] = fl_disponible;
                        //----

                        intFila += 1;
                        rowID++;
                    }
                    #endregion "Set Horarios de cada taller"
                    if (intNoAsesores == lstTalleres_Disponibles.Count)
                    {
                        oHorario_Cabecera = null;
                        oHorario_ModelCol = null;
                        oHorarioDisponible = null;

                        fl_seguir = "0";
                        msg_retorno = Parametros.msgNoAsesores + " " + sfe_reserva;
                    }
                    else
                    {
                        #region "Quitar/Ocultar columnas en blanco"
                        //---------------------------------------------> REMOVE: HORARIO BLANCO
                        Int32 cont_sin_horario;
                        //Oculta horarios vacíos de la derecha
                        oHorario_ModelCol.Reverse();
                        foreach (Dictionary<string, object> obj_ModelCol in oHorario_ModelCol)
                        {
                            String no_columna = obj_ModelCol["name"].ToString();
                            if ((no_columna.Length == 5 && no_columna.Substring(2, 1) == ":") || no_columna.Substring(0, 5) == "HORA_") //Para las horas
                            {
                                cont_sin_horario = 0;
                                foreach (Dictionary<string, object> oHorario in oHorarioDisponible)
                                {
                                    if (oHorario[no_columna].ToString() == String.Empty)
                                        cont_sin_horario++;
                                }
                                if (cont_sin_horario == oHorarioDisponible.Count)
                                    obj_ModelCol["hidden"] = true;
                                else
                                    break;
                            }
                        }
                        oHorario_ModelCol.Reverse();
                        //Oculta horarios vacíos de la izquierda
                        foreach (Dictionary<string, object> obj_ModelCol in oHorario_ModelCol)
                        {
                            String no_columna = obj_ModelCol["name"].ToString();
                            if ((no_columna.Length == 5 && no_columna.Substring(2, 1) == ":") || no_columna.Substring(0, 5) == "HORA_") //Para las horas
                            {
                                cont_sin_horario = 0;
                                foreach (Dictionary<string, object> oHorario in oHorarioDisponible)
                                {
                                    if (oHorario[no_columna].ToString() == String.Empty)
                                        cont_sin_horario++;
                                }
                                if (cont_sin_horario == oHorarioDisponible.Count)
                                    obj_ModelCol["hidden"] = true;
                                else
                                    break;
                            }
                        }
                        #endregion "Quitar/Ocultar columnas en blanco"

                        #region "- Crea HTML Tabla Footable"
                        tbl_Footable = "<table id='grvUbicacion' class='footable' data-toggle-column='last' cellspacing='0' width='100%'><thead><tr>";
                        int intCol = 0;
                        Int32 intCol_Visible = 0;
                        String style_FontSize = String.Empty;

                        Int32 nu_column_max_visible_phone = 0;
                        if (fl_mostrar_calidad == "1" && fl_mostrar_promociones == "1")
                        {
                            nu_column_max_visible_phone = 5;
                        }
                        else if (fl_mostrar_calidad == "0" && fl_mostrar_promociones == "0")
                        {
                            nu_column_max_visible_phone = 9;
                        }
                        else //Si al menos se ve una de las 2 columnas (calidad o promociones)
                        {
                            nu_column_max_visible_phone = 4;
                        }

                        foreach (String cab in oHorario_Cabecera)
                        {
                            Dictionary<string, object> obj_ModelCol = (Dictionary<string, object>)oHorario_ModelCol[intCol];
                            if ((!obj_ModelCol.ContainsKey("hidden")) || (Convert.ToBoolean(obj_ModelCol["hidden"]) != true))
                            {
                                //if (cab.Length == 5 && cab.Substring(2, 1) == ":")
                                if (cab.Substring(2, 1) == ":")
                                    style_FontSize = " style='font-size:12px;padding:2px;'";
                                else
                                    style_FontSize = String.Empty;

                                if (intCol_Visible == 0) { tbl_Footable += String.Format("<th{1}>{0}</th>", cab, style_FontSize); }
                                else if (intCol_Visible == 1) { tbl_Footable += String.Format("<th>{0}</th>", cab); }
                                else if (intCol_Visible < nu_column_max_visible_phone) { tbl_Footable += String.Format("<th data-hide='phone'{1}>{0}</th>", cab, style_FontSize); }
                                else { tbl_Footable += String.Format("<th data-hide='phone,tablet'{1}>{0}</th>", cab, style_FontSize); }

                                intCol_Visible++;
                            }
                            intCol = intCol + 1;
                        }
                        tbl_Footable += "</tr></thead><tbody>";
                        String color_NoDisponible = "#B2D5F7";
                        foreach (Dictionary<string, object> oHorario in oHorarioDisponible)
                        {
                            if (oHorario["fl_disponible"].ToString() == "1")
                                tbl_Footable += "<tr>";
                            else
                                tbl_Footable += String.Format("<tr style='background-color:{0}';>", color_NoDisponible);

                            intCol = 0;
                            foreach (KeyValuePair<string, object> hor in oHorario)
                            {
                                Dictionary<string, object> obj_ModelCol = (Dictionary<string, object>)oHorario_ModelCol[intCol];
                                if ((!obj_ModelCol.ContainsKey("hidden")) || (Convert.ToBoolean(obj_ModelCol["hidden"]) != true))
                                {
                                    if (hor.Key.Substring(0, 5) == "HORA_") //Para las horas
                                        tbl_Footable += String.Format("<td style='text-align:center;'>{0}</td>", hor.Value);
                                    else
                                        tbl_Footable += String.Format("<td>{0}</td>", hor.Value);
                                }
                                intCol = intCol + 1;
                            }
                            tbl_Footable += "</tr>";
                        }
                        tbl_Footable += "</tbody></table>";
                        #endregion "- Crea HTML Tabla Footable"
                    }
                }
            }
            #endregion - Obtiene Horario Disponible

        Response:
            strRetorno = new
            {
                fl_seguir = fl_seguir,
                msg_retorno = msg_retorno,
                sfe_reserva = sfe_reserva,
                sfe_max_reserva = sfe_max_reserva,
                oHorario_Cabecera = oHorario_Cabecera,
                oHorario_ModelCol = oHorario_ModelCol,
                oHorarioDisponible = oHorarioDisponible,
                oComboHoraInicio = oComboHoraInicio,
                oComboHoraFinal = oComboHoraFinal,
                IntervaloT = intIntervaloT,
                Header_Tbl = Header_Tbl, //Para DataTables
                Columns_data = Columns_data, //Para DataTables
                tbl_Footable = tbl_Footable //Para FooTable
            };
        }
        catch (Exception ex)
        {
            strRetorno = new
            {
                fl_seguir = "-1",
                msg_retorno = "Error: " + ex.Message,
                sfe_reserva = String.Empty,
                sfe_max_reserva = String.Empty,
                oHorario_Cabecera = oHorario_Cabecera,
                oHorario_ModelCol = oHorario_ModelCol,
                oHorarioDisponible = oHorarioDisponible,
                oComboHoraInicio = oComboHoraInicio,
                oComboHoraFinal = oComboHoraFinal,
                Header_Tbl = Header_Tbl,
                Columns_data = Columns_data
            };
        }

        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return serializer.Serialize(strRetorno);
    }

    private static DateTime SRC_FECHA_HABIL(Int32 nid_modelo, Int32 nid_servicio, String coddpto, String codprov, String coddist, Int32 nid_ubica, Int32 nid_taller
        , out CitasBEList lstTalleres, out CitasBEList _lstTalleresHE, out CitasBEList _lstAsesores, out CitasBEList _lstCitas)
    {
        lstTalleres = _lstTalleresHE = _lstAsesores = _lstCitas = null;

        CitasBL oCitasBL = new CitasBL();
        CitasBE oCitasBE = new CitasBE();
        Int32 _ID_TALLER = nid_taller;
        Int32 _INTERVALO = 0;
        Int32 _ID_SERVICIO = nid_servicio;
        Int32 _ID_MODELO = nid_modelo;
        string _TALLER = string.Empty;
        DateTime dFechaIni = Convert.ToDateTime(GetFechaMinReserva(nid_modelo));
        DateTime dFechaFin = Convert.ToDateTime(GetFechaMaxReserva());
        DateTime dHoraIni_T, dHoraFin_T, _dHoraIni_T, _dHoraFin_T, dHoraIni_A, dHoraFin_A;
        dHoraIni_T = dHoraFin_T = _dHoraIni_T = _dHoraFin_T = dHoraIni_A = dHoraFin_A = DateTime.MinValue;
        CitasBEList lstAsesores, lstCitas, lstTalleresHE;
        string strTotalHE = string.Empty;
        DateTime dtHEITaller, dtHEFTaller;
        DateTime dtHoraI_ddl = DateTime.MaxValue;
        DateTime dtHoraF_ddl = DateTime.MinValue;
        Int32 hay1 = 0, hay2 = 0;
        try
        {
            //Recorremos Fecha por Fecha 
            while (dFechaIni <= dFechaFin)
            {
                oCitasBE.nid_servicio = _ID_SERVICIO;
                oCitasBE.nid_modelo = _ID_MODELO;
                oCitasBE.coddpto = coddpto;
                oCitasBE.codprov = codprov;
                oCitasBE.coddist = coddist;
                oCitasBE.nid_ubica = nid_ubica;
                oCitasBE.nid_taller = _ID_TALLER;
                oCitasBE.fe_atencion = dFechaIni;
                oCitasBE.dd_atencion = getDiaSemana(dFechaIni);
                lstTalleres = oCitasBL.ListarTalleresDisponibles_PorFecha(oCitasBE);//   1-Listado todos Talleres
                if (lstTalleres.Count == 0)
                {
                    dFechaIni = dFechaIni.AddDays(+1);
                    continue;
                }
                _lstTalleresHE = oCitasBL.ListarHorarioExcepcional_Talleres(oCitasBE);// 2-Listado Horario Excepcionales
                _lstAsesores = oCitasBL.ListarAsesoresDisponibles_PorFecha(oCitasBE);//  3-Listado Asesores Talleres
                _lstCitas = oCitasBL.ListarCitasAsesores(oCitasBE);//                    4-Listado CitasAsesores Talleres
                //===========================================
                foreach (CitasBE oTaller in lstTalleres)
                {
                    string _NO_TALLER_ = oTaller.no_taller;
                    string _ID_TALLER_ = oTaller.nid_taller.ToString();
                    _INTERVALO = Convert.ToInt32(oTaller.qt_intervalo_atenc);
                    _dHoraIni_T = Convert.ToDateTime(oTaller.ho_inicio_t);
                    _dHoraFin_T = Convert.ToDateTime(oTaller.ho_fin_t);
                    //=================================================================================
                    //> Validaciones
                    //=================================================================================
                    if (oTaller.qt_cantidad_t <= 0) continue;//Capacidad Atencion Taller
                    if (Parametros.SRC_Pais_actual == Parametros.PAIS.PERU)
                        if (oTaller.qt_cantidad_m <= 0)
                            continue;//Capacidad Atencion Taller y Modelo
                    if (oTaller.nid_dia_exceptuado_t == 1) continue;//Dia Exceptuado
                    //=================================================================================
                    //> Horas Excepcional del Taller
                    //=================================================================================
                    // 0 - FILTRAR HORARIO EXCEPCIONAL
                    //--------------------------------
                    lstTalleresHE = new CitasBEList();
                    hay1 = 0; hay2 = 0;
                    foreach (CitasBE oEntidad in _lstTalleresHE)
                    {
                        hay1 = 0;
                        if (oTaller.nid_taller.Equals(oEntidad.nid_taller))
                        {
                            hay1 = 1; hay2 = 1;
                            lstTalleresHE.Add(oEntidad);
                        }
                        if ((hay1 == 0) && (hay2 == 1))
                            break;
                    }
                    // 1 - Get Horario Excepcional
                    //---------------------------------
                    strTotalHE = string.Empty;
                    foreach (CitasBE oHET in lstTalleresHE)
                    {
                        if (!string.IsNullOrEmpty(oHET.ho_rango1)) strTotalHE += oHET.ho_rango1 + "-";
                        if (!string.IsNullOrEmpty(oHET.ho_rango2)) strTotalHE += oHET.ho_rango2 + "-";
                        if (!string.IsNullOrEmpty(oHET.ho_rango3)) strTotalHE += oHET.ho_rango3 + "-";
                    }
                    strTotalHE = !string.IsNullOrEmpty(strTotalHE) ? strTotalHE.Substring(0, strTotalHE.Length - 1) : string.Empty;
                    //=================================================================================
                    //> Listado de Asesores 
                    //=================================================================================
                    // 0 - FILTRAR ASESORES - TALLER
                    //-----------------------------------
                    lstAsesores = new CitasBEList();// 2
                    hay1 = 0; hay2 = 0;
                    foreach (CitasBE oEntidad in _lstAsesores)
                    {
                        hay1 = 0;
                        if (oTaller.nid_taller.Equals(oEntidad.nid_taller))
                        {
                            hay1 = 1; hay2 = 1;
                            if (oEntidad.nid_dia_exceptuado_a == 0) //Validar FechaExceptuada
                                if (oEntidad.qt_cantidad_a > 0) //Validar Capacidad de Atencion
                                    lstAsesores.Add(oEntidad);
                        }
                        if ((hay1 == 0) && (hay2 == 1))
                            break;
                    }
                    DateTime odHIA = _dHoraIni_T, odHFA = _dHoraFin_T;
                    foreach (CitasBE oAsesor in lstAsesores)//==========================>>>> Por cada Asesor
                    {
                        //=================================================================================
                        //> Listar Citas Asesores
                        //=================================================================================
                        // 0 - FILTRAR CITAS - TALLER - ASESOR
                        //------------------------------------
                        lstCitas = new CitasBEList();
                        hay1 = 0; hay2 = 0;
                        foreach (CitasBE oEntidad in _lstCitas)
                        {
                            hay1 = 0;
                            if (oTaller.nid_taller.Equals(oEntidad.nid_taller) && oAsesor.nid_asesor.Equals(oEntidad.nid_asesor))
                            {
                                hay1 = 1; hay2 = 1;
                                lstCitas.Add(oEntidad);
                            }
                            if ((hay1 == 0) && (hay2 == 1))
                                break;
                        }
                        //Recorrer cada horario del Asesor
                        //-------------------------------------------------------------
                        foreach (string strHorario in oAsesor.horario_asesor.Split('|'))
                        {
                            dHoraIni_A = Convert.ToDateTime(strHorario.Split('-').GetValue(0).ToString());
                            dHoraFin_A = Convert.ToDateTime(strHorario.Split('-').GetValue(1).ToString());
                            if (dHoraIni_A < odHIA) dHoraIni_A = odHIA;
                            if (dHoraFin_A > odHFA) dHoraFin_A = odHFA;
                            //----------------------------------------------------
                            //> Get menor HI y mayor HF de Horarios disponibles
                            //---------------------------------------------------- 
                            if (dHoraFin_A > dtHoraF_ddl) dtHoraF_ddl = dHoraFin_A;
                            if (dHoraIni_A < dtHoraI_ddl) dtHoraI_ddl = dHoraIni_A;
                        Continue_While_2:
                            while (dHoraIni_A < dHoraFin_A)
                            {
                                foreach (CitasBE oCita in lstCitas)
                                {
                                    DateTime dtHActual = dHoraIni_A;
                                    DateTime dtHICita = Convert.ToDateTime(oCita.ho_inicio_c);
                                    DateTime dtHFCita = Convert.ToDateTime(oCita.ho_fin_c);
                                    if (dtHActual >= dtHICita & dtHActual < dtHFCita)
                                    {
                                        dHoraIni_A = dHoraIni_A.AddMinutes(_INTERVALO);
                                        goto Continue_While_2; //> Es una Cita ya reservada
                                    }
                                }
                                // > Se verifica que la hora del Asesor no sea una hora excepcional
                                if (!string.IsNullOrEmpty(strTotalHE))
                                {
                                    foreach (string _strRangoHE in strTotalHE.Split('-'))
                                    {
                                        dtHEITaller = Convert.ToDateTime(_strRangoHE.Split('|').GetValue(0));// Hora Inicial HET
                                        dtHEFTaller = Convert.ToDateTime(_strRangoHE.Split('|').GetValue(1));// Hora Final   HET
                                        //> Si es una hora excepcional
                                        if (dHoraIni_A >= dtHEITaller & dHoraIni_A < dtHEFTaller)
                                        {
                                            dHoraIni_A = dHoraIni_A.AddMinutes(_INTERVALO);
                                            goto Continue_While_2; //> Es Horario Excepcional
                                        }
                                    }
                                }
                                //> FECHA ENCONTRADA
                                //-------------------------
                                return dFechaIni;
                            }
                        }
                    }
                }
                dFechaIni = dFechaIni.AddDays(+1);
            }
        }
        catch (Exception ex)
        {
            string strError = ex.Message;
        }
        return dFechaFin;
    }
    private static string GetFechaMinReserva(Int32 nid_modelo)
    {
        string strFechaMin = string.Empty;
        VehiculoBE oVehiculoBE = new VehiculoBE();
        VehiculoBL oVehiculoBL = new VehiculoBL();
        oVehiculoBE.nid_modelo = nid_modelo;
        string strDiasMin = oVehiculoBL.MinimoDiasReservaPorModelo(oVehiculoBE);
        strFechaMin = String.Format("{0:d}", DateTime.Now.AddDays(Convert.ToDouble(strDiasMin)));
        return strFechaMin;
    }
    private static string GetFechaMaxReserva()
    {
        string strFechaMin = string.Empty;
        strFechaMin = String.Format("{0:d}", DateTime.Now.AddDays(Convert.ToDouble(Parametros.GetValor(Parametros.PARM._06))));
        return strFechaMin;
    }
    private static Int32 getDiaSemana(DateTime dtFecha)
    {
        Int32 intDia = 0;
        switch (dtFecha.DayOfWeek)
        {
            case DayOfWeek.Monday: intDia = 1; break;
            case DayOfWeek.Tuesday: intDia = 2; break;
            case DayOfWeek.Wednesday: intDia = 3; break;
            case DayOfWeek.Thursday: intDia = 4; break;
            case DayOfWeek.Friday: intDia = 5; break;
            case DayOfWeek.Saturday: intDia = 6; break;
            case DayOfWeek.Sunday: intDia = 7; break;
        }
        return intDia;
    }
    private static List<object> cargarComboHorarioTaller(DateTime dtHoraIni, DateTime dtHoraFin, Int32 intInterv)
    {
        List<object> oComboHora = new List<object>();
        if (intInterv.Equals(0)) return oComboHora;
        while (dtHoraIni <= dtHoraFin)
        {
            object oHora = new
            {
                value = dtHoraIni.ToString("HH:mm"),
                nombre = (Parametros.SRC_Pais_actual == Parametros.PAIS.CHILE ? dtHoraIni.ToString("HH:mm") : FormatoHora(dtHoraIni.ToString("HH:mm")))
            };
            oComboHora.Add(oHora);
            dtHoraIni = dtHoraIni.AddMinutes(intInterv);
        }
        return oComboHora;
    }
    private static string GetFechaLarga(DateTime dt)
    {
        return dt.ToString("D", CultureInfo.CurrentCulture);
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

    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    [WebMethod]
    public static object Get_HorarioDisponible_Asesor(String[] strParametros)
    {
        String msg_retorno = String.Empty;
        object strRetorno;
        String fl_seguir = "1";
        List<object> oHorarioDisponible = new List<object>();
        List<object> oComboHoraInicio = new List<object>();
        List<object> oComboHoraFinal = new List<object>();

        String tbl_Footable = String.Empty;

        #region - Define Cabecera y Model Column
        ArrayList oHorario_Cabecera = new ArrayList();
        oHorario_Cabecera.Add(Parametros.N_Taller);
        oHorario_Cabecera.Add("Asesor de Servicio");
        oHorario_Cabecera.Add("ID Asesor");
        oHorario_Cabecera.Add("Nom. Asesor");
        oHorario_Cabecera.Add("Teléfono");
        oHorario_Cabecera.Add("Email");
        oHorario_Cabecera.Add("Asesor Disponible");

        Dictionary<string, object> oModelCol = null;
        ArrayList oHorario_ModelCol = new ArrayList();
        oModelCol = new Dictionary<string, object>();
        oModelCol.Add("name", "no_taller"); oModelCol.Add("index", "no_taller"); oModelCol.Add("width", 130); oModelCol.Add("sortable", false);
        oHorario_ModelCol.Add(oModelCol);
        oModelCol = new Dictionary<string, object>();
        oModelCol.Add("name", "no_asesor_servicio"); oModelCol.Add("index", "no_asesor_servicio"); oModelCol.Add("width", 130); oModelCol.Add("sortable", false);
        oHorario_ModelCol.Add(oModelCol);
        oModelCol = new Dictionary<string, object>();
        oModelCol.Add("name", "nid_asesor"); oModelCol.Add("index", "nid_asesor"); oModelCol.Add("hidden", true);
        oHorario_ModelCol.Add(oModelCol);
        oModelCol = new Dictionary<string, object>();
        oModelCol.Add("name", "no_asesor"); oModelCol.Add("index", "no_asesor"); oModelCol.Add("hidden", true);
        oHorario_ModelCol.Add(oModelCol);
        oModelCol = new Dictionary<string, object>();
        oModelCol.Add("name", "nu_telefono"); oModelCol.Add("index", "nu_telefono"); oModelCol.Add("hidden", true);
        oHorario_ModelCol.Add(oModelCol);
        oModelCol = new Dictionary<string, object>();
        oModelCol.Add("name", "no_correo"); oModelCol.Add("index", "no_correo"); oModelCol.Add("hidden", true);
        oHorario_ModelCol.Add(oModelCol);
        oModelCol = new Dictionary<string, object>();
        oModelCol.Add("name", "fl_disponible"); oModelCol.Add("index", "fl_disponible"); oModelCol.Add("hidden", true);
        oHorario_ModelCol.Add(oModelCol);
        #endregion - Define Cabecera y Model Column
        try
        {
            Int32 nid_modelo; Int32.TryParse(strParametros[0], out nid_modelo);
            Int32 nid_servicio; Int32.TryParse(strParametros[1], out nid_servicio);
            String coddpto = strParametros[2] == "" ? "0" : strParametros[2];
            String codprov = strParametros[3] == "" ? "0" : strParametros[3];
            String coddist = strParametros[4] == "" ? "0" : strParametros[4];
            Int32 nid_ubica; Int32.TryParse(strParametros[5], out nid_ubica);
            Int32 nid_taller; Int32.TryParse(strParametros[6], out nid_taller);
            String sfe_atencion = strParametros[7];
            String sho_inicio_preseleccion = strParametros[8];
            Int32 qt_intervalo_atenc_tllr; Int32.TryParse(strParametros[9], out qt_intervalo_atenc_tllr);
            Int32 qt_intervalo_global_taller; Int32.TryParse(strParametros[10], out qt_intervalo_global_taller);
            String sho_inicio_visible = strParametros[11];
            String sho_final_visible = strParametros[12];

            DateTime ho_inicio_preseleccion = DateTime.Now, ho_final_preseleccion = DateTime.Now;
            if (!String.IsNullOrEmpty(sho_inicio_preseleccion))
            {
                sho_inicio_preseleccion = sho_inicio_preseleccion.Contains(":") ? sho_inicio_preseleccion : (sho_inicio_preseleccion.Insert(2, ":"));
                ho_inicio_preseleccion = Convert.ToDateTime(String.Format("{0} {1}", DateTime.Now.ToShortDateString(), sho_inicio_preseleccion));
                ho_final_preseleccion = ho_inicio_preseleccion.AddMinutes(qt_intervalo_global_taller);
            }

            if (nid_taller == 0)
            {
                fl_seguir = "0";
                msg_retorno = "- Debe seleccionar taller.";
                goto Response;
            }

            #region - Obtiene Horario Disponible
            CitasBE oCitasBE;

            DateTime dHoraIni_T;//  Horario Inicial del Taller (08:00)
            DateTime dHoraFin_T;//  Horario Final del   Taller (18:00)
            DateTime _dHoraIni_T;//HI Taller Temp
            DateTime _dHoraFin_T;//HF Taller Temp
            DateTime dHoraIni_E;// Horario Excepcional Inicial del Taller (12:00)
            DateTime dHoraFin_E;// Horario Excepcional Final   del Taller (15:00)
            DateTime dHoraIni_C;// Horario Inicial Cita
            DateTime dHoraFin_C;// Horario Final   Cita
            DateTime dHoraIni_A = DateTime.MinValue;
            DateTime dHoraFin_A = DateTime.MinValue;

            Int32 _ID_TALLER = nid_taller;
            Int32 _INTERVALO = qt_intervalo_atenc_tllr;
            string _TALLER = string.Empty;
            string strTotalHE;// Acumulacion de Rangos de HE
            //Int32 hay1 = 0, hay2 = 0;

            #region - Obtiene Talleres disponibles, Talleres Horario Excepcional, Asesores disponibles y Citas de Asesores
            oCitasBE = new CitasBE();
            oCitasBE.nid_servicio = nid_servicio;
            oCitasBE.nid_modelo = nid_modelo;
            oCitasBE.coddpto = coddpto;
            oCitasBE.codprov = codprov;
            oCitasBE.coddist = coddist;
            oCitasBE.nid_ubica = nid_ubica;
            oCitasBE.nid_taller = nid_taller;
            oCitasBE.fe_atencion = Convert.ToDateTime(sfe_atencion);
            oCitasBE.dd_atencion = getDiaSemana(oCitasBE.fe_atencion);
            CitasBL oCitasBL = new CitasBL();
            CitasBEList _lstCitas, lstTalleres, lstAsesores, lstTalleresHE;
            lstTalleres = oCitasBL.ListarTalleresDisponibles_PorFecha(oCitasBE);//  1-Listado el Taller

            if (lstTalleres.Count == 0)
            {
                fl_seguir = "0";
                msg_retorno = "No hay Talleres disponibles para este día.";
                goto Response;
            }

            lstTalleresHE = oCitasBL.ListarHorarioExcepcional_Talleres(oCitasBE);// 2-Listado Horario Excepcionales
            lstAsesores = oCitasBL.ListarAsesoresDisponibles_PorFecha(oCitasBE);//  3-Listado Asesores - Taller
            _lstCitas = oCitasBL.ListarCitasAsesores(oCitasBE);//                   4-Listado CitasAsesores - Taller

            if (_INTERVALO == 0) _INTERVALO = Convert.ToInt32(lstTalleres[0].qt_intervalo_atenc); //Asigna intervalo del taller

            CitasBE oTaller = new CitasBE();
            if (lstTalleres.Count > 0)
            {
                oTaller = lstTalleres[0];
                dHoraIni_T = Convert.ToDateTime(oTaller.ho_inicio_t);
                dHoraFin_T = Convert.ToDateTime(oTaller.ho_fin_t);
                _TALLER = oTaller.no_taller;
            }
            else
            {
                fl_seguir = "0";
                msg_retorno = Parametros.msgNoHorario2 + " " + sfe_atencion;
                goto Response;
            }
            if (lstAsesores.Count == 0)
            {
                fl_seguir = "0";
                msg_retorno = Parametros.msgNoAsesores + " " + sfe_atencion;
                goto Response;
            }
            #endregion - Obtiene Talleres disponibles, Talleres Horario Excepcional, Asesores disponibles y Citas de Asesores

            //=================================================================================
            //> Verifica Horas Excepcional del Taller
            //=================================================================================
            strTotalHE = string.Empty;
            foreach (CitasBE oHET in lstTalleresHE)
            {
                if (!string.IsNullOrEmpty(oHET.ho_rango1)) strTotalHE += oHET.ho_rango1 + "-";
                if (!string.IsNullOrEmpty(oHET.ho_rango2)) strTotalHE += oHET.ho_rango2 + "-";
                if (!string.IsNullOrEmpty(oHET.ho_rango3)) strTotalHE += oHET.ho_rango3 + "-";
            }
            if (!string.IsNullOrEmpty(strTotalHE))
                strTotalHE = strTotalHE.Substring(0, strTotalHE.Length - 1);

            #region "Generando CABECERA Y MODEL COLUMN de las horas"
            _dHoraIni_T = dHoraIni_T;
            _dHoraFin_T = dHoraFin_T;
            //string _strHT;
            while ((_dHoraIni_T < _dHoraFin_T))
            {
                String no_columna = _dHoraIni_T.ToString(fl_format_24_horas ? "HH:mm" : "hh:mm").ToUpper().Replace(".", "");

                //Cabecera
                oHorario_Cabecera.Add(no_columna);
                //Model Column
                oModelCol = new Dictionary<string, object>();
                oModelCol.Add("name", no_columna); oModelCol.Add("index", no_columna); oModelCol.Add("width", 45);
                oModelCol.Add("sortable", false); oModelCol.Add("align", "center"); oModelCol.Add("hidden", false);
                oHorario_ModelCol.Add(oModelCol);

                _dHoraIni_T = _dHoraIni_T.AddMinutes(_INTERVALO);
            }
            #endregion "Generando CABECERA Y MODEL COLUMN de las horas"
            string strPARM_10 = Parametros.GetValor(Parametros.PARM._10).ToString();
            #region "Rellenando el grid con los Puntos de Red, Taller y Direcciones"
            foreach (CitasBE oAsesor in lstAsesores)
            {
                Dictionary<string, object> oHorario = new Dictionary<string, object>();
                oHorario.Add("no_taller", _TALLER);
                oHorario.Add("no_asesor_servicio", (strPARM_10.Equals("0") ? "Asesor de Servicio - " + oAsesor.nid_asesor.ToString() : oAsesor.no_asesor));
                oHorario.Add("nid_asesor", oAsesor.nid_asesor);
                oHorario.Add("no_asesor", oAsesor.no_asesor.Trim());
                oHorario.Add("nu_telefono", oAsesor.nu_telefono_a.Trim());
                oHorario.Add("no_correo", oAsesor.no_correo_a.Trim());
                oHorario.Add("fl_disponible", String.Empty);

                //Agrega Columna de horas: RANGO DE HORAS
                _dHoraIni_T = dHoraIni_T;
                _dHoraFin_T = dHoraFin_T;
                while ((_dHoraIni_T < _dHoraFin_T))
                {
                    String no_columna = _dHoraIni_T.ToString(fl_format_24_horas ? "HH:mm" : "hh:mm").ToUpper().Replace(".", "");
                    oHorario.Add(no_columna, String.Empty);

                    _dHoraIni_T = _dHoraIni_T.AddMinutes(_INTERVALO);
                }
                oHorarioDisponible.Add(oHorario);
            }
            #endregion "Rellenando el grid con los Puntos de Red, Taller y Direcciones"

            bool blNoDisponibleT = false;
            if (oTaller.nid_dia_exceptuado_t == 1) //Validaciones Fecha Exceptuada - Taller
                blNoDisponibleT = true;
            else if (oTaller.qt_cantidad_t <= 0) //Validaciones Capacidad Atencion - Taller
                blNoDisponibleT = true;
            else if (Parametros.SRC_Pais_actual == Parametros.PAIS.PERU) //Validacion Capacidad Atencion - Taller y Modelo
                if (oTaller.qt_cantidad_m <= 0)
                    blNoDisponibleT = true;

            //------------------------------------------------------------------------
            // Colocamos los iconos de Horario Disponible, Reservado y Excepcional
            //------------------------------------------------------------------------            
            String imghoraVacia = String.Empty;
            String imgHoraLibre = "<img id='{2}' idfoo='{2}' style='cursor:pointer;' title='Seleccionar' alt='' src='" + imgURL_HORA_LIBRE + "' onclick='javascript: fn_SetHoraAsesor(&#39;{0}&#39;, &#39;{1}&#39;, &#39;{2}&#39;, &#39;{3}&#39;);' />";
            String imgHoraReservada = "<img title='' alt='' src='" + imgURL_HORA_RESERVADA + "' />";
            String imgHoraExcepcional = "<img title='' alt='' src='" + imgURL_HORA_EXCEPCIONAL + "' />";
            String imgHoraColumna = String.Empty;

            #region "Set Horarios de cada Asesor"
            Int32 intFila = 0, intCol = 0;
            Int32 rowID = 1;
            foreach (CitasBE oAsesor in lstAsesores)
            {
                Dictionary<string, object> oHorario = new Dictionary<string, object>();
                oHorario = ((Dictionary<string, object>)(oHorarioDisponible[intFila]));

                String fl_disponible = "1";
                //Identifica si el Asesor está disponible y con cupos
                if (blNoDisponibleT) //Por Taller
                    fl_disponible = "0";
                else//Por Asesor
                {
                    if (oAsesor.nid_dia_exceptuado_a == 1) //Validacion Fecha Exceptuada - Asesor
                    {
                        fl_disponible = "0";
                    }
                    if (fl_disponible == "1")
                    {
                        if (oAsesor.qt_cantidad_a <= 0) //Validacion Capacidad Atencion - Asesor
                        {
                            fl_disponible = "0";
                        }
                    }
                }

                //-------------------------
                // SET HORARIO DEL ASESOR 
                //-------------------------
                intCol = 0;
                foreach (string strHorario in oAsesor.horario_asesor.Split('|'))
                {
                    _dHoraIni_T = dHoraIni_T;
                    _dHoraFin_T = dHoraFin_T;
                    intCol = 0;
                    dHoraIni_A = Convert.ToDateTime(strHorario.Split('-').GetValue(0).ToString());
                    dHoraFin_A = Convert.ToDateTime(strHorario.Split('-').GetValue(1).ToString());
                    while (_dHoraIni_T <= _dHoraFin_T)
                    {
                        if (_dHoraIni_T >= dHoraIni_A && _dHoraIni_T < dHoraFin_A)
                        {
                            String no_columna = _dHoraIni_T.ToString(fl_format_24_horas ? "HH:mm" : "hh:mm").ToUpper().Replace(".", "");
                            imgHoraColumna = String.Empty;
                            if (fl_disponible == "0")
                            {
                                imgHoraColumna = imgHoraReservada;
                            }
                            else
                            {
                                String lblSeleccion = "Selección de Reserva -  " + ((Parametros.GetValor(Parametros.PARM._10).ToString().Equals("0")) ? Parametros.N_Asesor + " " + oAsesor.nid_asesor.ToString() : oAsesor.no_asesor) + " - " + GetFechaLarga(Convert.ToDateTime(sfe_atencion)) + " - " + FormatoHora(no_columna);
                                String ho_inicio_a = no_columna;
                                imgHoraColumna = String.Format(imgHoraLibre, rowID.ToString(), no_columna, no_columna + "_" + rowID.ToString()
                                    , String.Format("{0}${1}${2}${3}", oAsesor.nid_asesor, ho_inicio_a, _INTERVALO, lblSeleccion));
                            }
                            if (oHorario.ContainsKey(no_columna))
                            {
                                oHorario[no_columna] = imgHoraColumna;
                            }
                        }
                        intCol += 1;
                        _dHoraIni_T = _dHoraIni_T.AddMinutes(_INTERVALO);
                    }
                }
                oHorario["fl_disponible"] = fl_disponible;
                //-------------------------
                // SET CITAS 
                //------------------------------------------------------                   
                // Filtrar Citas por Asesor
                //------------------------------------------------------
                List<CitasBE> lstCitas = _lstCitas.FindAll(ci => ci.nid_asesor == oAsesor.nid_asesor);
                foreach (CitasBE oCita in lstCitas)
                {
                    dHoraIni_C = DateTime.Parse(oCita.ho_inicio_c.ToString());
                    dHoraFin_C = DateTime.Parse(oCita.ho_fin_c.ToString());
                    while (dHoraIni_C < dHoraFin_C)
                    {
                        _dHoraIni_T = dHoraIni_T;
                        _dHoraFin_T = dHoraFin_T;
                        intCol = 0;
                        while (_dHoraIni_T <= _dHoraFin_T)
                        {
                            if (_dHoraIni_T >= dHoraIni_C && dHoraIni_C < _dHoraFin_T)
                            {
                                String no_columna = _dHoraIni_T.ToString(fl_format_24_horas ? "HH:mm" : "hh:mm").ToUpper().Replace(".", "");
                                imgHoraColumna = String.Empty;

                                //>> Si hay cita reservada (ICONO DE RESERVADO)
                                imgHoraColumna = imgHoraReservada;

                                oHorario[no_columna] = imgHoraColumna;
                                break;
                            }
                            intCol += 1;
                            _dHoraIni_T = _dHoraIni_T.AddMinutes(_INTERVALO);
                        }
                        dHoraIni_C = dHoraIni_C.AddMinutes(_INTERVALO);
                    }
                }
                //--------------------------
                // SET HORARIO EXCEPCIONAL  
                //--------------------------
                if (!string.IsNullOrEmpty(strTotalHE))
                {
                    foreach (string _strRangoHE in strTotalHE.Split('-'))
                    {
                        dHoraIni_E = Convert.ToDateTime(_strRangoHE.Split('|').GetValue(0));// Hora Inicial HET
                        dHoraFin_E = Convert.ToDateTime(_strRangoHE.Split('|').GetValue(1));// Hora Final   HET
                        _dHoraIni_T = dHoraIni_T;
                        _dHoraFin_T = dHoraFin_T;
                        intCol = 0;
                        while (_dHoraIni_T <= _dHoraFin_T)
                        {
                            if (_dHoraIni_T >= dHoraIni_E && _dHoraIni_T < dHoraFin_E) // Si es una hora excepcionl
                            {
                                String no_columna = _dHoraIni_T.ToString(fl_format_24_horas ? "HH:mm" : "hh:mm").ToUpper().Replace(".", "");
                                imgHoraColumna = String.Empty;
                                imgHoraColumna = imgHoraExcepcional;
                                oHorario[no_columna] = imgHoraColumna;
                            }
                            intCol += 1;
                            _dHoraIni_T = _dHoraIni_T.AddMinutes(_INTERVALO);
                        }
                    }
                }
                intFila += 1;
                rowID++;
            }
            #endregion "Set Horarios de cada Asesor"

            if (String.IsNullOrEmpty(sho_inicio_visible))
            {
                oComboHoraInicio = cargarComboHorarioTaller(dHoraIni_T, dHoraFin_T, _INTERVALO);
                oComboHoraFinal = oComboHoraInicio;
            }

            #region "Quitar/Ocultar columnas en blanco"
            //---------------------------------------------> REMOVE: HORARIO BLANCO
            Int32 cont_sin_horario;
            //Oculta horarios vacíos de la derecha
            oHorario_ModelCol.Reverse();
            foreach (Dictionary<string, object> obj_ModelCol in oHorario_ModelCol)
            {
                String no_columna = obj_ModelCol["name"].ToString();
                if (no_columna.Length == 5 && no_columna.Substring(2, 1) == ":") //Para las horas
                {
                    cont_sin_horario = 0;
                    foreach (Dictionary<string, object> oHorario in oHorarioDisponible)
                    {
                        if (oHorario[no_columna].ToString() == String.Empty)
                            cont_sin_horario++;
                    }
                    if (cont_sin_horario == oHorarioDisponible.Count)
                        obj_ModelCol["hidden"] = true;
                    else
                        break;
                }
            }
            oHorario_ModelCol.Reverse();
            //Oculta horarios vacíos de la izquierda
            foreach (Dictionary<string, object> obj_ModelCol in oHorario_ModelCol)
            {
                String no_columna = obj_ModelCol["name"].ToString();
                if (no_columna.Length == 5 && no_columna.Substring(2, 1) == ":") //Para las horas
                {
                    cont_sin_horario = 0;
                    foreach (Dictionary<string, object> oHorario in oHorarioDisponible)
                    {
                        if (oHorario[no_columna].ToString() == String.Empty)
                            cont_sin_horario++;
                    }
                    if (cont_sin_horario == oHorarioDisponible.Count)
                        obj_ModelCol["hidden"] = true;
                    else
                        break;
                }
            }
            #endregion "Quitar/Ocultar columnas en blanco"

            #region "Pre-Seleccion de Hora"
            //----------------------
            //> SET PRE-SELECCION
            //----------------------
            String color_PreSeleccion = "#B2D5F7";
            if (Parametros.SRC_Pais_actual == Parametros.PAIS.PERU)
            {
                if (!(string.IsNullOrEmpty(sho_inicio_preseleccion)))
                {
                    DateTime dtRangoHI = ho_inicio_preseleccion;
                    DateTime dtRangoHF = ho_final_preseleccion;
                    Int32 intRango = 0;
                    DateTime dtHoraC;
                    foreach (Dictionary<string, object> obj_ModelCol in oHorario_ModelCol)
                    {
                        String no_columna = obj_ModelCol["name"].ToString();
                        if (no_columna.Length == 5 && no_columna.Substring(2, 1) == ":") //Para las horas
                        {
                            dtHoraC = Convert.ToDateTime(no_columna);
                            if (dtHoraC >= dtRangoHI && dtHoraC < dtRangoHF)
                            {
                                obj_ModelCol["cellattr"] = "function(rowId, val, rowObject, cm, rdata){ return 'style=\"background-color: " + color_PreSeleccion + "\"';}";
                            }
                        }
                        intRango += 1;
                    }
                }
            }
            #endregion "Pre-Seleccion de Hora"

            //Para ocultar las horas de acuerdo a combo de Horas
            DateTime dt_ho_inicio_visible = DateTime.MinValue, dt_ho_final_visible = DateTime.MaxValue;
            if (!String.IsNullOrEmpty(sho_inicio_visible))
            {
                dt_ho_inicio_visible = Convert.ToDateTime(sho_inicio_visible);
                dt_ho_final_visible = Convert.ToDateTime(sho_final_visible);
            }
            DateTime dt_hora_grilla;
            #region "- Crea HTML Tabla Footable"
            tbl_Footable = "<table id='grvUbicacion' class='footable' data-toggle-column='last' cellspacing='0' width='100%'><thead><tr>";
            intCol = 0;
            Int32 intCol_Visible = 0;
            String style_FontSize = String.Empty;
            foreach (String cab in oHorario_Cabecera)
            {
                Dictionary<string, object> obj_ModelCol = (Dictionary<string, object>)oHorario_ModelCol[intCol];

                //Para ocultar las horas de acuerdo a combo de Horas
                if (!String.IsNullOrEmpty(sho_inicio_visible))
                {
                    if (cab.Length == 5 && cab.Substring(2, 1) == ":") //Horas
                    {
                        dt_hora_grilla = Convert.ToDateTime(cab);
                        if (dt_hora_grilla < dt_ho_inicio_visible || dt_hora_grilla > dt_ho_final_visible)
                        {
                            obj_ModelCol["hidden"] = true;
                        }
                    }
                }

                if ((!obj_ModelCol.ContainsKey("hidden")) || (Convert.ToBoolean(obj_ModelCol["hidden"]) != true))
                {
                    if (cab.Length == 5 || cab.Substring(2, 1) == ":")
                        style_FontSize = " style='font-size:12px;padding:2px;'";
                    else
                        style_FontSize = String.Empty;

                    if (intCol_Visible == 0) { tbl_Footable += String.Format("<th{1}>{0}</th>", cab, style_FontSize); }
                    else if (intCol_Visible == 1) { tbl_Footable += String.Format("<th>{0}</th>", cab); }
                    else if (intCol_Visible < 12) { tbl_Footable += String.Format("<th data-hide='phone'{1}>{0}</th>", cab, style_FontSize); }
                    else { tbl_Footable += String.Format("<th data-hide='phone,tablet'{1}>{0}</th>", cab, style_FontSize); }

                    intCol_Visible++;
                }
                intCol = intCol + 1;
            }
            tbl_Footable += "</tr></thead><tbody>";
            String color_NoDisponible = "#B2D5F7";
            foreach (Dictionary<string, object> oHorario in oHorarioDisponible)
            {
                if (oHorario["fl_disponible"].ToString() == "1")
                    tbl_Footable += "<tr>";
                else
                    tbl_Footable += String.Format("<tr style='background-color:{0}';>", color_NoDisponible);

                intCol = 0;
                foreach (KeyValuePair<string, object> hor in oHorario)
                {
                    Dictionary<string, object> obj_ModelCol = (Dictionary<string, object>)oHorario_ModelCol[intCol];
                    if ((!obj_ModelCol.ContainsKey("hidden")) || (Convert.ToBoolean(obj_ModelCol["hidden"]) != true))
                    {
                        if (hor.Key.Length == 5 && hor.Key.Substring(2, 1) == ":") //Para las horas
                        {
                            if (obj_ModelCol.ContainsKey("cellattr")) //Pre-Seleccion
                                tbl_Footable += String.Format("<td style='text-align:center;background-color:{1};'>{0}</td>", hor.Value, color_PreSeleccion);
                            else
                                tbl_Footable += String.Format("<td style='text-align:center;'>{0}</td>", hor.Value);
                        }
                        else
                            tbl_Footable += String.Format("<td>{0}</td>", hor.Value);
                    }
                    intCol = intCol + 1;
                }
                tbl_Footable += "</tr>";
            }
            tbl_Footable += "</tbody></table>";
            #endregion "- Crea HTML Tabla Footable"

            #endregion - Obtiene Horario Disponible

        Response:
            strRetorno = new
            {
                fl_seguir = fl_seguir,
                msg_retorno = msg_retorno,
                sfe_reserva = sfe_atencion,
                oHorario_Cabecera = oHorario_Cabecera,
                oHorario_ModelCol = oHorario_ModelCol,
                oHorarioDisponible = oHorarioDisponible,
                oComboHoraInicio = oComboHoraInicio,
                oComboHoraFinal = oComboHoraFinal,
                tbl_Footable = tbl_Footable //Para FooTable
            };
        }
        catch (Exception ex)
        {
            strRetorno = new
            {
                fl_seguir = "-1",
                msg_retorno = "Error: " + ex.Message,
                sfe_reserva = String.Empty,
                sfe_max_reserva = String.Empty,
                oHorario_Cabecera = oHorario_Cabecera,
                oHorario_ModelCol = oHorario_ModelCol,
                oHorarioDisponible = oHorarioDisponible,
                oComboHoraInicio = oComboHoraInicio,
                oComboHoraFinal = oComboHoraFinal,
                tbl_Footable = tbl_Footable //Para FooTable
            };
        }

        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return serializer.Serialize(strRetorno);
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            string Param_nid_cita = Request.Params["nid_cita"];
            string Param_nu_estado = Request.Params["nu_estado"];
            if (Param_nid_cita != null)
            {
                if (Param_nid_cita != "")
                {
                    ScriptManager.RegisterStartupScript(this, this.GetType(), "SeleccionaCita", "fn_SeleccionaCita('" + Param_nid_cita + "','" + Param_nu_estado + "', true);", true);
                }
            }
        }
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
        String imgSeleccionar = "<img " + id_img + " title='Seleccionar' alt='Seleccionar' src='img/disponible.png' style='width: 18px; height: 18px;' onclick='javascript: fn_SeleccionaCita(&#39;{0}&#39;, &#39;{1}&#39;);' />";
        foreach (CitasBE obj in oCitasBEList)
        {
            oCita = new
            {
                no_taller = obj.no_taller,
                fe_inicio = obj.fecha_prog + " - " + obj.ho_inicio_c,
                nu_servicio = obj.no_servicio,
                no_asesor = obj.no_asesor,
                co_estado = obj.no_estado,
                seleccionar = String.Format(imgSeleccionar, obj.nid_cita.ToString(), obj.nu_estado.ToString())
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

        String codprov_value;
        String coddist_value;
        String nid_ubica_value;
        String nid_taller_value;
        if (fl_ubigeo_all == "1")
        {
            codprov_value = oCitasBEList[0].coddpto + oCitasBEList[0].codprov;
            coddist_value = oCitasBEList[0].coddpto + oCitasBEList[0].codprov + oCitasBEList[0].coddist;
            nid_ubica_value = oCitasBEList[0].coddpto + oCitasBEList[0].codprov + oCitasBEList[0].coddist + oCitasBEList[0].nid_ubica;
            nid_taller_value = oCitasBEList[0].coddpto + oCitasBEList[0].codprov + oCitasBEList[0].coddist + oCitasBEList[0].nid_ubica + "$" + oCitasBEList[0].nid_taller;
        }
        else
        {
            codprov_value = oCitasBEList[0].codprov;
            coddist_value = oCitasBEList[0].coddist;
            nid_ubica_value = oCitasBEList[0].nid_ubica.ToString();
            nid_taller_value = oCitasBEList[0].nid_taller.ToString();
        }

        object filas = new
        {
            nid_cita = oCitasBEList[0].nid_cita,
            cod_reserva_cita = oCitasBEList[0].cod_reserva_cita,
            fecha_prog = oCitasBEList[0].fecha_prog,
            fecha_prog_format = GetFechaLarga(Convert.ToDateTime(oCitasBEList[0].fecha_prog)) + ", a las " + FormatoHora(oCitasBEList[0].ho_inicio_c),
            ho_inicio_c = oCitasBEList[0].ho_inicio_c,
            ho_fin_c = oCitasBEList[0].ho_fin_c,
            fl_origen = oCitasBEList[0].fl_origen,
            nid_estado = oCitasBEList[0].nid_estado,
            fl_datos_pend = oCitasBEList[0].fl_datos_pend,
            tx_observacion = oCitasBEList[0].tx_observacion,
            qt_km_inicial = oCitasBEList[0].qt_km_inicial,
            fecha_atencion = oCitasBEList[0].fecha_atencion,
            tx_glosa_atencion = oCitasBEList[0].tx_glosa_atencion,
            co_estado = oCitasBEList[0].co_estado,
            no_estado = oCitasBEList[0].no_estado,
            nu_estado = oCitasBEList[0].nu_estado,
            flg_estado_botones = flg_estado_botones,
            nid_cliente = oCitasBEList[0].nid_cliente,
            no_cliente = oCitasBEList[0].no_cliente,
            no_ape_paterno = oCitasBEList[0].no_ape_paterno,
            no_ape_materno = oCitasBEList[0].no_ape_materno,
            co_tipo_documento = oCitasBEList[0].co_tipo_documento,
            nu_documento = oCitasBEList[0].nu_documento,
            no_correo = oCitasBEList[0].no_correo,
            no_correo_trabajo = oCitasBEList[0].no_correo_trabajo,
            no_correo_alter = oCitasBEList[0].no_correo_alter,
            nu_telefono_c = oCitasBEList[0].nu_telefono_c,
            nu_celular_c = oCitasBEList[0].nu_celular_c,
            nid_servicio = oCitasBEList[0].nid_servicio,
            no_servicio = oCitasBEList[0].no_servicio,
            fl_quick_service = oCitasBEList[0].fl_quick_service,
            nid_tipo_servicio = oCitasBEList[0].nid_tipo_servicio,
            no_tipo_servicio = oCitasBEList[0].no_tipo_servicio,
            nid_taller = oCitasBEList[0].nid_taller,
            no_taller = oCitasBEList[0].no_taller,
            co_intervalo = oCitasBEList[0].co_intervalo,
            nu_intervalo = oCitasBEList[0].nu_intervalo,
            no_direccion_t = oCitasBEList[0].no_direccion_t,
            nu_telefono_t = oCitasBEList[0].nu_telefono_t,
            tx_mapa_taller = oCitasBEList[0].tx_mapa_taller,
            tx_url_taller = oCitasBEList[0].tx_url_taller,
            dd_atencion = oCitasBEList[0].dd_atencion,
            ho_inicio_t = oCitasBEList[0].ho_inicio_t,
            ho_fin_t = oCitasBEList[0].ho_fin_t,
            nid_ubica = oCitasBEList[0].nid_ubica,
            no_ubica = oCitasBEList[0].no_ubica,
            coddpto = oCitasBEList[0].coddpto,
            codprov = oCitasBEList[0].codprov,
            coddist = oCitasBEList[0].coddist,
            no_distrito = oCitasBEList[0].no_distrito,
            nid_vehiculo = oCitasBEList[0].nid_vehiculo,
            nu_placa = oCitasBEList[0].nu_placa,
            nid_modelo = oCitasBEList[0].nid_modelo,
            no_modelo = oCitasBEList[0].no_modelo,
            nid_marca = oCitasBEList[0].nid_marca,
            no_marca = oCitasBEList[0].no_marca,
            nid_asesor = oCitasBEList[0].nid_asesor,
            no_asesor = oCitasBEList[0].no_asesor,
            nu_telefono_a = oCitasBEList[0].nu_telefono_a,
            no_correo_asesor = oCitasBEList[0].no_correo_asesor,
            nid_taller_empresa = oCitasBEList[0].nid_taller_empresa,
            no_banco = oCitasBEList[0].no_banco,
            nu_cuenta = oCitasBEList[0].nu_cuenta,
            no_correo_callcenter = oCitasBEList[0].no_correo_callcenter,
            nu_callcenter = oCitasBEList[0].nu_callcenter,
            fl_nota = oCitasBEList[0].fl_nota,
            //////co_tipo_cliente = oCitasBEList[0].co_tipo_cliente,
            //////no_razon_social = oCitasBEList[0].no_razon_social,
            //////fl_campania_veh = oCitasBEList[0].fl_campania_veh,
            //////tipo_cliente_ax = oCitasBEList[0].tipo_cliente_ax,
            codprov_value = codprov_value,
            coddist_value = coddist_value,
            nid_ubica_value = nid_ubica_value,
            nid_taller_value = nid_taller_value
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

    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    [WebMethod]
    public static object SaveReprogramacion(String[] strParametros)
    {
        String fl_seguir = "0";
        String msg_retorno = String.Empty;
        object strRetorno;
        object oDatosCita = null;
        String fl_ir_home = "0";

        //1:      Registrada      
        //2:      Reprogramada
        //3:      Cancelada
        //4:      Confirmada
        //5:      Reasignada
        //6:      Atendida
        try
        {
            //----------------
            #region "- Seteando variables Request"
            Int32 nid_cita; Int32.TryParse(strParametros[0], out nid_cita);
            Int32 nid_estado; Int32.TryParse(strParametros[1], out nid_estado);
            Int32 nid_taller; Int32.TryParse(strParametros[2], out nid_taller);
            String sfe_programada = strParametros[3];
            String ho_inicio = strParametros[4];
            Int32 nid_asesor; Int32.TryParse(strParametros[5], out nid_asesor);
            Int32 qt_intervalo_atenc; Int32.TryParse(strParametros[6], out qt_intervalo_atenc);
            #endregion "- Seteando variables Request"
            //------------------------------
            //--> REPROGRAMAMOS LA CITA
            //------------------------------
            CitasBL oCitasBL = new CitasBL();
            CitasBE oCitasBE = new CitasBE();
            oCitasBE.nid_cita = nid_cita;
            oCitasBE.nid_estado = nid_estado;
            oCitasBE.nid_taller = (Parametros.SRC_CambiarTaller.Equals("1") ? nid_taller : 0);
            oCitasBE.fe_prog = Convert.ToDateTime(sfe_programada);
            oCitasBE.dd_atencion = getDiaSemana(oCitasBE.fe_prog);
            oCitasBE.ho_inicio = ho_inicio;
            oCitasBE.ho_fin = Convert.ToDateTime(ho_inicio).AddMinutes(qt_intervalo_atenc).ToString("HH:mm");
            oCitasBE.tx_observacion = "";
            oCitasBE.nid_usuario = nid_asesor;
            //---------------------------------------------------
            // Verificamos si hay Cliente en Cola de Espera
            //---------------------------------------------------
            Int32 intCitaCE = 0;
            string strCitaCE = oCitasBL.GetCitaColaEspera(oCitasBE);
            if (!string.IsNullOrEmpty(strCitaCE)) intCitaCE = Convert.ToInt32(strCitaCE);
            Int32 resCita = 0;

            
            CitasBE oCitasBEPrm = new CitasBE();
            CitasBEList oDatos = new CitasBEList();
            oCitasBEPrm.nid_cita = nid_cita;
            oDatos = oCitasBL.Listar_Datos_Cita(oCitasBEPrm);
            //bool saveQRPNG = true;
            if (oDatos[0].no_nombreqr == null)
                oCitasBE.no_nombreqr = new CitasBL().GetNombreImagenQR(oDatos[0].nu_placa);
            else if (oDatos[0].no_nombreqr == "")
                oCitasBE.no_nombreqr = new CitasBL().GetNombreImagenQR(oDatos[0].nu_placa);
            else
            {
                oCitasBE.no_nombreqr = oDatos[0].no_nombreqr;
                //saveQRPNG = false;
            }
            //string resultado = new CitasBL().SaveImageQRText(new Parametros().SRC_GuardaQR, oCitasBE.no_nombreqr, oDatos[0].nu_placa, oCitasBE.fe_prog, oCitasBE.ho_inicio, oDatos[0].no_marca, oDatos[0].no_modelo, oDatos[0].no_color_exterior, saveQRPNG);

            resCita = oCitasBL.Reprogramar(oCitasBE);
            if (resCita == 11)
            {
                msg_retorno = ("Ya se ha reprogramado una cita con estos mismos datos.");
            }
            else if (resCita == 22)
            {
                msg_retorno = ("Ya se ha reservado una Cita en este mismo horario.");
            }
            else if (resCita == 33)
            {
                msg_retorno = ("Este vehículo ya tiene cita separada para esta fecha y hora programada.");
            }
            else if (resCita == 44)
            {
                msg_retorno = ("Ya se ha alcanzado el limite de atenciones por día del Taller.");
            }
            else if (resCita == 55)
            {
                msg_retorno = ("Ya se ha alcanzado el limite de atenciones por día del Asesor.");
            }
            else if (resCita == 66)
            {
                msg_retorno = ("Ya se ha alcanzado el limite de atenciones por día del Taller y Modelo");
            }
            else if (resCita == 1)
            {
                fl_seguir = "1";
                //ENVIAMOS UN EMAIL TANTO AL CLIENTE  COMO AL ASESOR CON LA NUEVA REPROGRACION DE LA CITA
                //----------------------------------------------------------------------------------------
                oCitasBE = new CitasBE();
                CitasBEList oCitasBEList = new CitasBEList();
                oCitasBE.nid_cita = nid_cita;
                oCitasBE.cod_reserva_cita = "";
                oCitasBEList = new CitasBEList();
                oCitasBEList = oCitasBL.Listar_Datos_Cita(oCitasBE);
                oCitasBE = new CitasBE();
                oCitasBE = oCitasBEList[0];

                //Set Datos Cita
                oDatosCita = new
                {
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

                //CorreoElectronico oEmail = new CorreoElectronico(HttpContext.Current.Server.MapPath("~/"));
                //>>------ ENVIO DE CORREOS  - SMS --------- >>
                //oEmail.EnviarCorreo_Cliente(oCitasBE, Parametros.EstadoCita.REPROGRAMADA);
                //oEmail.EnviarCorreo_Asesor(oCitasBE, Parametros.EstadoCita.REPROGRAMADA);

                //ASIGNAMOS LA CITA, A UN CLIENTE EN COLA DE ESPERA SI LO HUBIESE
                //---------------------------------------------------------------------                
                if (intCitaCE != 0) //Si hay cita a Asignar
                {
                    try
                    {
                        nid_cita = intCitaCE; //Cita en Cola de espera
                        oCitasBE = new CitasBE();
                        oCitasBE.nid_cita = intCitaCE;
                        oCitasBE.nid_asesor = nid_asesor;
                        oCitasBE.no_pais = "PE";
                        string strResultCE = oCitasBL.AsignarClienteColaEspera(oCitasBE);
                        if (!string.IsNullOrEmpty(strResultCE))
                        {
                            oCitasBE = new CitasBE();
                            oCitasBE.nid_cita = intCitaCE;
                            oCitasBE.cod_reserva_cita = "";
                            oCitasBEList = new CitasBEList();
                            oCitasBEList = oCitasBL.Listar_Datos_Cita(oCitasBE);
                            //>>------ ENVIO DE CORREOS --------- >>
                            //oEmail.EnviarCorreo_Cliente(oCitasBEList[0], Parametros.EstadoCita.REASIGNADA);
                        }
                        else
                            msg_retorno = ("Error al reasignar");
                    }
                    catch (Exception ex)
                    {
                        msg_retorno = ("Error al reasignar \n " + ex.Message);
                    }
                }
            }
            else if (resCita == 0)
            {
                msg_retorno = (Parametros.msgNoExisteCita);
                fl_ir_home = "1";
                //REPROGRAMADA POR OTRO USUARIO
            }
            else if (resCita > 10)
            {
                msg_retorno = (Parametros.msgEstaCambio);
            }
            else
                msg_retorno = (resCita.ToString()); //< 0 -> ERROR DE BD
            //-----------


            //Response:
            strRetorno = new
            {
                fl_seguir = fl_seguir,
                msg_retorno = msg_retorno,
                oDatosCita = oDatosCita,
                fl_ir_home = fl_ir_home
            };
        }
        catch (Exception ex)
        {
            strRetorno = new
            {
                fl_seguir = "-1",
                msg_retorno = "Error: " + ex.Message,
                oDatosCita = oDatosCita,
                fl_ir_home = fl_ir_home
            };
        }

        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return serializer.Serialize(strRetorno);
    }
}