using System;
using System.Collections.Generic;
using System.Web;
using System.Collections;

public static class ClaseGlobal
{
    #region "Manejo de errores no controlados por aplicativo"
    public static System.Exception LastError;

    public static string getMensajeError()
    {
        while (LastError.InnerException != null)
        {
            LastError = LastError.InnerException;
        }
        return LastError.Message;
    }
    #endregion

    public static bool isMobileBrowser()
    {
        HttpContext context = HttpContext.Current;
        if (context.Request.Browser.IsMobileDevice)
        {
            return true;
        }
        if (context.Request.ServerVariables["HTTP_X_WAP_PROFILE"] != null)
        {
            return true;
        }
        if (context.Request.ServerVariables["HTTP_ACCEPT"] != null && context.Request.ServerVariables["HTTP_ACCEPT"].ToLower().Contains("wap"))
        {
            return true;
        }
        if (context.Request.ServerVariables["HTTP_USER_AGENT"] != null)
        {
            string[] mobiles = new[] { "midp", "j2me", "avant", "docomo", "novarra", "palmos", "palmsource", "240x320", "opwv", "chtml", "pda", "windows ce", "mmp/", "blackberry", "mib/", "symbian", "wireless", "nokia", "hand", "mobi", "phone", "cdm", "up.b", "audio", "SIE-", "SEC-", "samsung", "HTC", "mot-", "mitsu", "sagem", "sony", "alcatel", "lg", "eric", "vx", "philips", "mmm", "xx", "panasonic", "sharp", "wap", "sch", "rover", "pocket", "benq", "java", "pt", "pg", "vox", "amoi", "bird", "compal", "kg", "voda", "sany", "kdd", "dbt", "sendo", "sgh", "gradi", "jb", "dddi", "moto", "iphone" };
            //Loop through each item in the list created above 
            //and check if the header contains that text
            foreach (string s in mobiles)
            {
                if (context.Request.ServerVariables["HTTP_USER_AGENT"].ToLower().Contains(s.ToLower()))
                {
                    return true;
                }
            }
        }
        return false;
    }
}

public class JQGridJsonResponse
{
    public int CurrentPage = 1;
    public int RecordCount = 0;
    public List<JQGridJsonResponseRow> Items;
    public int PageCount = 0;
    public Hashtable userData = null;

    public JQGridJsonResponse(Int32 pageCount, Int32 currentPage, Int32 recordCount)
    {
        CurrentPage = currentPage;
        RecordCount = recordCount;
        PageCount = pageCount;
        Items = new List<JQGridJsonResponseRow>();
    }
}

public class JQGridJsonResponseRow
{
    public string ID;
    public object Row;
}