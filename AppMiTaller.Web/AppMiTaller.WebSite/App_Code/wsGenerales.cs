using System;
using System.Web.Services;
using AppMiTaller.Web.BE;
using AppMiTaller.Web.BL;

/// <summary>
/// Summary description for wsGenerales
/// </summary>
[WebService(Namespace = "http://tempuri.org/")]
[WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
// To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
[System.Web.Script.Services.ScriptService]
public class wsGenerales : System.Web.Services.WebService {

    public wsGenerales () {
        //Uncomment the following line if using designed components 
        //InitializeComponent(); 
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    public object Get_Combo(String co_maestro)
    {
        ComboBL oComboBL = new ComboBL();
        ComboBE oComboBE = new ComboBE();
        String co_padre = String.Empty;
        ComboBEList oComboBEList = oComboBL.Get_Combo(co_maestro, co_padre);

        //return oComboBEList;
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return serializer.Serialize(oComboBEList);
    }

    [WebMethod]
    [System.Web.Script.Services.ScriptMethod(ResponseFormat = System.Web.Script.Services.ResponseFormat.Json)]
    public object Get_ComboxPadre(String co_maestro, String co_padre)
    {
        ComboBL oComboBL = new ComboBL();
        ComboBE oComboBE = new ComboBE();
        ComboBEList oComboBEList = oComboBL.Get_Combo(co_maestro, co_padre);

        //return oComboBEList;
        System.Web.Script.Serialization.JavaScriptSerializer serializer = new System.Web.Script.Serialization.JavaScriptSerializer();
        return serializer.Serialize(oComboBEList);
    }
}
