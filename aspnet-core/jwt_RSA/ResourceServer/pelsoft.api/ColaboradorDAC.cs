using pelsoft.api.common;
using pelsoft.api.models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace pelsoft.api
{
    /// <summary>
    /// 
    /// </summary>
    public class ColaboradorDAC
    {
        private static string connectionString ;

        static ColaboradorDAC()
        {

            connectionString = CommonHelpers.GetCnn(CommonHelpers.CnnStringNameMeucci).ConnectionString;
        }

      


        internal static List<Vista_Sucursal> Vista_Sucursal()
        {
            List<Vista_Sucursal> list = new List<Vista_Sucursal>();
            Vista_Sucursal item = null;

            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("select * from [Vista_Sucursal]", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;



                    cnn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item = new Vista_Sucursal();
                            item.suc_id = (int)(reader["suc_id"]);
                            item.suc_nombre = (string)(reader["suc_nombre"]);



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


        internal static List<Vista_Sociedad> Vista_Sociedad()
        {
            List<Vista_Sociedad> list = new List<Vista_Sociedad>();
            Vista_Sociedad item = null;

            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("select * from [Vista_Sociedad]", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;



                    cnn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item = new Vista_Sociedad();
                            item.sociedad_id = (int)(reader["sociedad_id"]);
                            item.sociedad_Ruc = (string)(reader["sociedad_Ruc"]);

                            item.fechainicioAct = (DateTime)(reader["fechainicioAct"]);
                            item.soc_nombre = (string)(reader["soc_nombre"]);

                            if (reader["calle"] != DBNull.Value)
                                item.calle = (string)(reader["calle"]);

                            if (reader["numero_calle"] != DBNull.Value)
                                item.numero_calle = (int)(reader["numero_calle"]);



                            if (reader["sociedad_nombre"] != DBNull.Value)
                                item.sociedad_nombre = (string)(reader["sociedad_nombre"]);
                            if (reader["Sociedad_cliente"] != DBNull.Value)
                                item.Sociedad_cliente = (string)(reader["Sociedad_cliente"]);

                            if (reader["Sociedad_subCuenta"] != DBNull.Value)
                                item.Sociedad_subCuenta = (string)(reader["Sociedad_subCuenta"]);

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




        internal static List<vista_CuentaSubAreaServicio> vista_CuentaSubAreaServicio()
        {
            List<vista_CuentaSubAreaServicio> list = new List<vista_CuentaSubAreaServicio>();
            vista_CuentaSubAreaServicio item = null;

            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("select * from [vista_CuentaSubAreaServicio]", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;



                    cnn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item = new vista_CuentaSubAreaServicio();
                            item.cue_id = (int)(reader["cue_id"]);
                            item.sar_id = (int)(reader["sar_id"]);
                            item.srv_id = (int)(reader["srv_id"]);
                            item.cue_nombre = (string)(reader["cue_nombre"]);
                            item.sar_nombre = (string)(reader["sar_nombre"]);
                            item.srv_nombre = (string)(reader["srv_nombre"]);

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


        internal static List<vista_Ubicacion> vista_Ubicacion()
        {
            List<vista_Ubicacion> list = new List<vista_Ubicacion>();
            vista_Ubicacion item = null;

            try
            {
                using (SqlConnection cnn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand("select * from [vista_Ubicacion]", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.Text;



                    cnn.Open();

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            item = new vista_Ubicacion();
                            item.call_id = (int)(reader["call_id"]);
                            item.call_nombre = (string)(reader["call_nombre"]);
                            item.site_id = (int)(reader["site_id"]);
                            item.site_nombre = (string)(reader["site_nombre"]);
                            item.suc_id = (int)(reader["suc_id"]);
                            item.suc_nombre = (string)(reader["suc_nombre"]);

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
