using System;
using System.Web;
using System.Web.UI;

public partial class MasterPage : System.Web.UI.MasterPage
{
    private String getPageName()
    {
        string[] arrResult = HttpContext.Current.Request.RawUrl.Split('/');
        String result = arrResult[arrResult.GetUpperBound(0)];

        return result;
    }
    public String nid_empresa_configurada;
    protected void Page_Init(object sender, EventArgs e)
    {
        String no_pagina = this.getPageName();
        String[] arrResult = no_pagina.Split('.');
        String result = arrResult[arrResult.GetLowerBound(0)];

        //if (Request.QueryString["co_marca"] == null && result != "SRC_Multimarca")
        //{
        //    String codEmpresas = System.Configuration.ConfigurationManager.AppSettings["CodEmpresa"].ToString();
        //    Int32 nu_empresas_configuradas = codEmpresas.Split('$').Length;
        //    if (nu_empresas_configuradas > 1)
        //        Response.Redirect("~/SRC_Multimarca.aspx");
        //    else
        //    {
        //        nid_empresa_configurada = codEmpresas.Split(':')[0].ToString();
        //    }
         
        //    if (result == "SRC_ReservarCita" && (String.IsNullOrEmpty(Request.QueryString["Origen"])))
        //    {
        //        String qs_marca = "";
        //        String qs_origen = "?Origen=0";
        //        if (Request.QueryString["co_marca"] != null)
        //        {
        //            qs_marca = "?co_marca=" + Request.QueryString["co_marca"].ToString();
        //            qs_origen = "&Origen=0";
        //        }
        //        Response.Redirect("~/SRC_ReservarCita.aspx" + qs_marca + qs_origen);
        //    }
        //}
        //else if (result != "SRC_Multimarca")
        //{
        //    String co_marca = Request.QueryString["co_marca"].ToString();
        //    String arr_marcas = System.Configuration.ConfigurationManager.AppSettings["MarcasPermitidas"].ToString();
        //    bool fl_marca_permitida = false;
        //    foreach (string strMarca in arr_marcas.Split('|'))
        //    {
        //        if (strMarca == co_marca)
        //        {
        //            fl_marca_permitida = true;
        //            break;
        //        }
        //    }
        //    if (fl_marca_permitida == false)
        //    {
        //        Response.Redirect("~/SRC_Multimarca.aspx");
        //    }
        //    else
        //    {
        //        if (Parametros.SRC_Pais_actual == Parametros.PAIS.PERU)
        //        {
        //            if (result == "SRC_ReservarCita" && (String.IsNullOrEmpty(Request.QueryString["Origen"])))
        //            {
        //                Response.Redirect("~/SRC_ReservarCita.aspx?co_marca=" + co_marca + "&Origen=0");
        //                return;
        //            }
        //        }
        //    }
        //}
    }

    protected void Page_Load(object sender, EventArgs e)
    {
        if (!Page.IsPostBack)
        {
            
        }
    }
}
