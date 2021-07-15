using pelsoft.api.common;
using pelsoft.api.models;
using System;

using System.Data.SqlClient;


namespace pelsoft.api
{
    /// <summary>
    /// 
    /// </summary>
    public class EmpleadosDAC
    {
        private static string connectionString ;

        static EmpleadosDAC()
        {

            connectionString = CommonHelpers.GetCnn(CommonHelpers.CnnStringNameMeucci).ConnectionString;
        }

        public static EmpleadoBE Get(string usuario, string dominio)
        {
            //List<ColaboradorModel> list = new List<ColaboradorModel>();
            EmpleadoBE item = null;
            dominio = dominio.Replace("-", ".");
            try
            {
               
                using (SqlConnection cnn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("[dbo].[usp_DatosEmpleados_Api]", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@usuario", usuario);

                    cmd.Parameters.AddWithValue("@dominio", dominio);

                    cnn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item = new EmpleadoBE();
                            item.Emp_id = (int)(reader["EMP_ID"]);

                            item.Apellido = (string)(reader["apellido"]);
                            item.Nombre = (string)(reader["nombre"]);

                            if (reader["Fecha_de_nacimiento"] != DBNull.Value)
                                item.FechaNacimiento = Convert.ToDateTime(reader["Fecha_de_nacimiento"]);

                            if (reader["Documento"] != DBNull.Value)
                                item.Documento = reader["Documento"].ToString();
                            if (reader["Cuil"] != DBNull.Value)
                                item.Cuil = reader["Cuil"].ToString();

                            if (reader["sexo"] != DBNull.Value)
                                item.Sexo = reader["sexo"].ToString();
                            if (reader["nacionalidad"] != DBNull.Value)
                                item.Nacionalidad = reader["nacionalidad"].ToString();

                            if (reader["telefono"] != DBNull.Value)
                                item.Telefono = reader["telefono"].ToString();
                            if (reader["mail_personal"] != DBNull.Value)
                                item.Mail_personal = reader["mail_personal"].ToString();

                            if (reader["Cuenta"] != DBNull.Value)
                                item.Cuenta = reader["Cuenta"].ToString();
                            if (reader["Subarea"] != DBNull.Value)
                                item.Subarea = reader["Subarea"].ToString();

                      
                            if (reader["Sucursal"] != DBNull.Value)
                                item.Sucursal = (string)(reader["Sucursal"]);


                            if (reader["sociedad"] != DBNull.Value)
                                item.Sociedad = (string)(reader["sociedad"]);
                            if (reader["ubicacion"] != DBNull.Value)
                                item.Ubicacion = reader["ubicacion"].ToString();


                            if (reader["Superior"] != DBNull.Value)
                                item.Superior = (string)(reader["Superior"]);



                            //if (reader["site_id"] != DBNull.Value)
                            //    item.site_id = (int)(reader["site_id"]);
                            //if (reader["call_id"] != DBNull.Value)
                            //    item.call_id = (int)(reader["call_id"]);

                            if (reader["suc_id"] != DBNull.Value)
                                item.suc_id = (int)(reader["suc_id"]);
                            if (reader["cue_id"] != DBNull.Value)
                                item.Cue_id = (reader["cue_id"]).ToString();
                            //if (reader["srv_id"] != DBNull.Value)
                            //    item.srv_id = (int)(reader["srv_id"]);

                            //if (reader["sar_id"] != DBNull.Value)
                            //    item.sar_id = (int)(reader["sar_id"]);

                            //if (reader["sociedad_id"] != DBNull.Value)
                            //    item.sociedad_id = (int)(reader["sociedad_id"]);

                        }
                    }

                }
            }
            catch (Exception ex)
            {
                throw ex;
            }

            return item;
        }


    }
}
