using Biblio.Common;
using Biblio.Common.BE;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Biblio.DAC
{
    public class PrestamosDAC
    {        
        /// <summary>
             /// 
             /// </summary>
             /// <param name="socio"></param>
             /// <param name="libro"></param>
        public static void Prestamo(SocioBE socio, LibroBE libro)
        {
            using (SqlConnection cnn = new SqlConnection(CommonHelpers.Cnnstring))
            using (SqlCommand cmd = new SqlCommand("[dbo].[prestamo_i]", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                #region params
                SqlParameter param = new SqlParameter("@IdPrestamo", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@IdLibro", libro.IdLibro);
                cmd.Parameters.AddWithValue("@IdSocio", socio.SocioId);
                cmd.Parameters.AddWithValue("@IdUsuario", CommonHelpers.currenUser.Id);
                cmd.Parameters.AddWithValue("@Estado", "Prestado");

                #endregion

                cnn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public static void Devolucion(int prestamoId)
        {
            using (SqlConnection cnn = new SqlConnection(CommonHelpers.Cnnstring))
            using (SqlCommand cmd = new SqlCommand("[dbo].[devocucion_u]", cnn))
            {
                cmd.CommandType = CommandType.StoredProcedure;
                #region params

                cmd.Parameters.AddWithValue("@IdPrestamo", prestamoId);
                cmd.Parameters.AddWithValue("@IdUsuario", CommonHelpers.currenUser.Id);


                #endregion

                cnn.Open();

                cmd.ExecuteNonQuery();
            }
        }
        public static PrestamosViewList Search()
        {
            PrestamosViewList list = new PrestamosViewList();

            try
            {
                using (SqlConnection cnn = new SqlConnection(CommonHelpers.Cnnstring))
                using (SqlCommand cmd = new SqlCommand("[dbo].[PrestamosView_s]", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    
                    cnn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            PrestamosView item = new PrestamosView();
                            item.IdPrestamo = (int)(reader["IdPrestamo"]);
                            item.Usuario = (string)(reader["Usuario"]);
                            item.Apellido = (string)(reader["Apellido"]);
                            item.Nombre = (string)(reader["Nombre"]);
                            item.FechaMovimiento = (DateTime)(reader["FechaMovimiento"]);
                            item.Titulo = (string)(reader["Titulo"]);
                            item.Estado = (string)(reader["Estado"]);
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
