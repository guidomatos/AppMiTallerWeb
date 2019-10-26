using AppMiTaller.Web.BE;
using AppMiTaller.Web.BL;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Web.Services;
using System.Web.UI;


public partial class SRC_ActualizarCliente : System.Web.UI.Page
{

    private const string COD_DNI = "01";
    private const string COD_RUC = "03";
    private const string COD_CE = "04";

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
        }
    }

    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    [WebMethod]
    public static object Get_Inicial()
    {
        #region "Obtiene Tipo Documento"
        ComboBL oComboBL = new ComboBL();
        List<object> oComboTipoPersona = new List<object>();
        ComboBEList listaTipoPersona = oComboBL.Get_Combo("TIPO_PERSONA", "");
        if (listaTipoPersona != null) {
            foreach (ComboBE oTD in listaTipoPersona)
            {
                oComboTipoPersona.Add(new { value = oTD.value.Trim(), oTD.nombre });
            }
        }
        #endregion

        #region "Obtiene Tipo Documento"
        ClienteBL oClienteBL = new ClienteBL();
        List<object> oComboTipoDocumento = new List<object>();
        ClienteBEList oClienteBEList = oClienteBL.ListarTipoDocumentos();
        if (oClienteBEList != null)
        {
            foreach (ClienteBE oTD in oClienteBEList)
            {
                oComboTipoDocumento.Add(new { value = oTD.cod_tipo_documento.Trim(), nombre = oTD.des_tipo_documento });
            }
        }
        #endregion "Obtiene Tipo Documento"

        #region "Obtiene Marcas"
        VehiculoBL oVehiculoBL = new VehiculoBL();
        ArrayList oComboMarca = new ArrayList();
        VehiculoBEList oMarcas = oVehiculoBL.ListarMarcas();
        
        foreach (VehiculoBE oMarca in oMarcas)
        {
            object objMarca;
            objMarca = new { value = oMarca.nid_marca.ToString(), nombre = oMarca.no_marca };
            oComboMarca.Add(objMarca);
        }
        #endregion "Obtiene Marcas"

        object response = new
        {
            oComboTipoPersona,
            oComboTipoDocumento,
            oComboMarca
        };

        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return serializer.Serialize(response);
    }

    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    [WebMethod]
    public static object Get_ConsultarClientePorDocumento(String[] strParametros)
    {
        ClienteBL oClienteBL = new ClienteBL();
        ClienteBE oClienteBE = new ClienteBE();
         
        oClienteBE.co_tipo_documento = strParametros[0];
        oClienteBE.nu_documento = strParametros[1];
        ClienteBEList oClienteBEList = oClienteBL.ListarDatosContactoPorDoc(oClienteBE);

        int nid_cliente = 0;
        string co_tipo_documento = "";
        string nu_documento = "";
        string no_nombre = "";
        string no_ape_paterno = "";
        string no_ape_materno = "";
        string nu_tel_movil = "";
        string no_email = "";
        string msgSiEncontroDoc = "";
        string msgNoEncontro = "";
        String msgTextoVerificacion = Parametros.msgSiEncontroDoc;

        if (oClienteBEList != null && oClienteBEList.Count > 0) {

            ClienteBE oCliente = oClienteBEList[0];

            nid_cliente = oCliente.nid_cliente;
            co_tipo_documento = oCliente.co_tipo_documento;
            nu_documento = oCliente.nu_documento;
            no_nombre = oCliente.no_nombre;
            no_ape_paterno = oCliente.no_ape_paterno;
            no_ape_materno = oCliente.no_ape_materno;

            if (!(string.IsNullOrEmpty(oCliente.nu_tel_movil)))
            {
                if (oCliente.nu_tel_movil.Trim().Length > 0)
                {
                    if (oCliente.nu_tel_movil.Contains("-"))
                    {
                        nu_tel_movil = oCliente.nu_tel_movil.Split('-')[1].ToString();
                    }
                    else
                    {
                        nu_tel_movil = oCliente.nu_tel_movil.ToString();
                    }
                }
            }
            no_email = oCliente.no_email;

            msgSiEncontroDoc = Parametros.msgSiEncontroDoc;
        }
        else
        {
            msgTextoVerificacion = Parametros.msgNoEncontroDoc;

            if (oClienteBE.co_tipo_documento.ToString().Trim().Equals(COD_DNI))
                msgNoEncontro = "1";
            else if (oClienteBE.co_tipo_documento.ToString().Trim().Equals(COD_RUC))
                msgNoEncontro = "2";
            else if (oClienteBE.co_tipo_documento.ToString().Trim().Equals(COD_CE))
                msgNoEncontro = "3";
        }

        object response = new
        {
            nid_cliente,
            co_tipo_documento,
            nu_documento,
            no_nombre,
            no_ape_paterno,
            no_ape_materno,
            nu_tel_movil,
            no_email,
            msgSiEncontroDoc,
            msgNoEncontro,
            msgTextoVerificacion
        };

        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return serializer.Serialize(response);
    }


    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    [WebMethod]
    public static object Get_Modelo(String[] strParametros)
    {
        ArrayList oComboModelo = null;
        VehiculoBL oVehiculoBL = new VehiculoBL();
        VehiculoBE oVehiculoBE = new VehiculoBE();
        oVehiculoBE.nid_marca = Convert.ToInt32(strParametros[0]);

        VehiculoBEList oModelos = oVehiculoBL.ListarModelosPorMarca(oVehiculoBE);
        if (oModelos != null)
        {
            oComboModelo = new ArrayList();
            foreach (VehiculoBE oModelo in oModelos)
            {
                object objModelo = new { value = oModelo.nid_modelo.ToString(), nombre = oModelo.no_modelo };
                oComboModelo.Add(objModelo);
            }
        }

        object response = new
        {
            oComboModelo
        };

        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return serializer.Serialize(response);
    }




    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    [WebMethod]
    public static object Get_ConsultarClientePorId(String[] strParametros)
    {
        ClienteBL oClienteBL = new ClienteBL();
        ClienteBE param = new ClienteBE();

        Int32 nid_cliente = Convert.ToInt32(strParametros[0]);
        param.nid_cliente = nid_cliente;
        ClienteBE oCliente = oClienteBL.ListarClientePorId(param);

        
        string co_tipo_documento = "";
        string nu_documento = "";
        string no_nombre = "";
        string no_ape_paterno = "";
        string no_ape_materno = "";
        string nu_tel_movil = "";
        string no_email = "";
        string tx_direccion = "";
        //Datos del Vehiculo
        int nid_vehiculo = 0;
        string nu_placa = "";
        int nid_marca = 0;
        int nid_modelo = 0;

        if (oCliente != null)
        {
            nid_cliente = oCliente.nid_cliente;
            co_tipo_documento = oCliente.co_tipo_documento;
            nu_documento = oCliente.nu_documento;
            no_nombre = oCliente.no_nombre;
            no_ape_paterno = oCliente.no_ape_paterno;
            no_ape_materno = oCliente.no_ape_materno;

            if (!(string.IsNullOrEmpty(oCliente.nu_tel_movil)))
            {
                if (oCliente.nu_tel_movil.Trim().Length > 0)
                {
                    if (oCliente.nu_tel_movil.Contains("-"))
                    {
                        nu_tel_movil = oCliente.nu_tel_movil.Split('-')[1].ToString();
                    }
                    else
                    {
                        nu_tel_movil = oCliente.nu_tel_movil.ToString();
                    }
                }
            }
            no_email = oCliente.no_email;
            tx_direccion = oCliente.tx_direccion;

            nid_vehiculo = oCliente.nid_vehiculo;
            nu_placa = oCliente.nu_placa;
            nid_marca = oCliente.nid_marca;
            nid_modelo = oCliente.nid_modelo;

        }

        object response = new
        {
            nid_cliente,
            co_tipo_documento,
            nu_documento,
            no_nombre,
            no_ape_paterno,
            no_ape_materno,
            nu_tel_movil,
            no_email,
            tx_direccion,
            nid_vehiculo,
            nu_placa,
            nid_marca,
            nid_modelo
        };

        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return serializer.Serialize(response);
    }

}