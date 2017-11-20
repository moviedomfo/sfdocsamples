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
    public class SecurityDAC
    {
        /// <summary>
        /// si retorna != null esta autenticado
        /// </summary>
        /// <param name="usr">usuario</param>
        /// <param name="pwd">password</param>
        /// <returns></returns>
        public static UsarioBE Authenticate(string usr, string pwd)
        {
            UsarioBE user = null;
            try
            {
                using (SqlConnection cnn = new SqlConnection(CommonHelpers.Cnnstring))
                using (SqlCommand cmd = new SqlCommand("[dbo].[usuario_g]", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@usuario", usr);
                    cmd.Parameters.AddWithValue("@password", pwd);
                    cnn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            user = new UsarioBE();
                            user.Id = (int)(reader["IdUsuario"]);
                            user.Apellido = (string)(reader["Apellido"]);
                            user.Nombre = (string)(reader["Nombre"]);
                            user.Usuario = (string)(reader["Usuario"]);

                        }
                    }
                }
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }

        }
    }
}
