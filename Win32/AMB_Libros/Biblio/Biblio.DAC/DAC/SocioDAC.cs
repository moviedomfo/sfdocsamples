using Biblio.Common;
using Biblio.Common.BE;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.DAC
{
    public class SocioDAC
    {
        /// <summary>
        /// Inserta socio
        /// </summary>
        /// <param name="socioBE"></param>
        public static void Create(SocioBE socioBE)
        {

            using (SqlConnection cnn = new SqlConnection(CommonHelpers.Cnnstring))
            using (SqlCommand cmd = new SqlCommand("[dbo].[socios_i]", cnn))
            {
                #region params

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@Apellido", socioBE.Apellido);
                cmd.Parameters.AddWithValue("@DNI", socioBE.DNI);
                cmd.Parameters.AddWithValue("@FechaAlta", socioBE.FechaAlta);
                cmd.Parameters.AddWithValue("@FechaBaja", socioBE.FechaBaja);
                cmd.Parameters.AddWithValue("@socioBE", socioBE.Nombre);
                cmd.Parameters.AddWithValue("@Telefono", socioBE.Telefono);
                #endregion

                cnn.Open();

                cmd.ExecuteNonQuery();
            }

        }


        /// <summary>
        /// Busca por apellido y/o nombre: si searchText es null retorna todos
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public static List<SocioBE> CaseLogSearchById(string searchText)
        {
            List<SocioBE> list = new List<SocioBE>();

            try
            {
                string wConnectionStr = ConfigurationManager.ConnectionStrings["EpironConfigurador"].ConnectionString;

                using (SqlConnection cnn = new SqlConnection(wConnectionStr))
                using (SqlCommand cmd = new SqlCommand("[dbo].[socios_s_byParams]", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@searchText", searchText);
                    cnn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            SocioBE item = new SocioBE();
                            item.SocioId = (int)(reader["SocioId"]);

                            item.Apellido = (string)(reader["Apellido"]);

                            item.Nombre = (string)(reader["Nombre"]);


                            item.FechaAlta = (DateTime)(reader["FechaAlta"]);

                            if (reader["FechaBaja"] != DBNull.Value)
                                item.FechaBaja = (DateTime)(reader["FechaBaja"]);

                            if (reader["DNI"] != DBNull.Value)
                                item.DNI = (string)(reader["DNI"]);

                            if (reader["Telefono"] != DBNull.Value)
                                item.Telefono = (string)(reader["Telefono"]);

                            list.Add(item);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;// Fwk.Exceptions.ExceptionHelper.ProcessException(ex);
            }

            return list;
        }
    }
}
