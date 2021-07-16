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

            //connectionString = CommonHelpers.GetCnn(CommonHelpers.CnnStringNameMeucci).ConnectionString;
        }

        public static EmpleadoBE Get(string usuario, string dominio)
        {
            //List<ColaboradorModel> list = new List<ColaboradorModel>();
            EmpleadoBE item = new EmpleadoBE { Nombre = "Marcelo",Apellido="Oviedo" };
         

            return item;
        }


    }
}
