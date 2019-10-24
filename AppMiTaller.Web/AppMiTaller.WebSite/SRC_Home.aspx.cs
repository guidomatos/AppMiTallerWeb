using AppMiTaller.Web.BE;
using AppMiTaller.Web.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;

/// <summary>
/// </summary>

public partial class SRC_Home : System.Web.UI.Page
{
    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
        }
    }


    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    [WebMethod]
    public static object Login(String[] strParametros)
    {
        ClienteBL oClienteBL = new ClienteBL();
        ClienteBE oClienteBE;
        
        String msg_retorno;
        Int32 co_retorno;
        object strRetorno;

        try
        {
            String usuario = strParametros[0];
            String clave = strParametros[1];

            oClienteBE = new ClienteBE
            {
                nu_documento = usuario,
                no_clave_web = clave
            };

            ClienteBE retorno = oClienteBL.Login(oClienteBE);

            if (retorno != null)
            {
                co_retorno = retorno.nid_cliente;
                msg_retorno = "Login exitoso";
            }
            else {
                co_retorno = 0;
                msg_retorno = "Usuario no existe";
            }

            strRetorno = new
            {
                co_retorno,
                msg_retorno
            };

        }
        catch (Exception ex)
        {
            strRetorno = new
            {
                co_retorno = -1,
                msg_retorno = "Error: " + ex.Message
            };
        }

        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return serializer.Serialize(strRetorno);
    }

}