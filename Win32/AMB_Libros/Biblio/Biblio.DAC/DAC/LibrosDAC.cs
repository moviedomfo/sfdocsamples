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
    public class LibrosDAC
    {
        /// <summary>
        /// Inserta socio
        /// </summary>
        /// <param name="libroBE"></param>
        public static void Create(LibroBE libroBE)
        {
            
            using (SqlConnection cnn = new SqlConnection(CommonHelpers.Cnnstring))
            using (SqlCommand cmd = new SqlCommand("[dbo].[libros_i]", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                #region params
                SqlParameter param = new SqlParameter("@IdLibro", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@Autor", libroBE.Autor);
                cmd.Parameters.AddWithValue("@ISBN", libroBE.ISBN);
                cmd.Parameters.AddWithValue("@Stock", libroBE.Stock);
                cmd.Parameters.AddWithValue("@Titulo", libroBE.Titulo);
            
                #endregion

                cnn.Open();

                libroBE.IdLibro = cmd.ExecuteNonQuery();
            }

        }


        /// <summary>
        /// Busca por autor y/o titulo: si searchText es null retorna todos
        /// </summary>
        /// <param name="searchText"></param>
        /// <returns></returns>
        public static List<LibroBE> Search(string searchText)
        {
            List<LibroBE> list = new List<LibroBE>();

            try
            {
                using (SqlConnection cnn = new SqlConnection(CommonHelpers.Cnnstring))
                using (SqlCommand cmd = new SqlCommand("[dbo].[libros_s_byParams]", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@searchText", searchText);
                    cnn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            LibroBE item = new LibroBE();
                            item.IdLibro = (int)(reader["IdLibro"]);
                            item.Titulo = (string)(reader["Titulo"]);
                            item.Autor = (string)(reader["Autor"]);
                            item.ISBN = (string)(reader["ISBN"]);
                            item.Stock = (int)(reader["Stock"]);
                            list.Add(item);
                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return list;
        }




    }
}
