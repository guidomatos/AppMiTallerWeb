using System;
using AppMiTaller.Web.BE;
using AppMiTaller.Web.DA;

namespace AppMiTaller.Web.BL
{
    public class ComboBL
    {
        ComboDA oComboDA = new ComboDA();
        public ComboBEList Get_Combo(String co_maestro, String co_padre)
        {
            try
            {
                ComboBEList oComboBEList = oComboDA.Get_Combo(co_maestro, co_padre);
                return oComboBEList;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
            }
        }

    }
}
