using System;
using System.Data;
using System.Data.SqlClient;
using AppMiTaller.Web.BE;

namespace AppMiTaller.Web.DA
{
    public class ComboDA
    {
        SqlCommand SqlCommand;

        public ComboBEList Get_Combo(String co_maestro, String co_padre)
        {
            ComboBEList oComboBEList = new ComboBEList();

            SqlConnection cn = new SqlConnection(DataBaseHelper.GetDbConnectionString());
            /*Propiedades del SqlCommand*/
            SqlCommand = new SqlCommand();
            SqlCommand.CommandText = "src_sps_combo_FO";
            SqlCommand.Connection = cn;
            SqlCommand.CommandType = CommandType.StoredProcedure;

            /*Agregar Parametros al SqlCommand */
            SqlCommand.Parameters.AddWithValue("@vi_co_maestro", co_maestro);
            SqlCommand.Parameters.AddWithValue("@vi_co_padre", co_padre);            

            SqlDataReader reader = null;
            try
            {
                cn.Open();
                reader = SqlCommand.ExecuteReader();

                while (reader.Read())
                {
                    int indice;

                    ComboBE oBE = new ComboBE();
                    indice = reader.GetOrdinal("value");
                    oBE.value = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    indice = reader.GetOrdinal("nombre");
                    oBE.nombre = reader.IsDBNull(indice) ? string.Empty : reader.GetString(indice);

                    oComboBEList.Add(oBE);
                }
                reader.Close();
            }
            catch (Exception)
            {
                if (reader != null && !reader.IsClosed) reader.Close();
                throw;
            }
            finally
            {
                cn.Close();
                cn.Dispose();
            }
            return oComboBEList;
        }

    }
}
