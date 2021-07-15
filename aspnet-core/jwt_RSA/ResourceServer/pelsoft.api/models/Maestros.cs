using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace pelsoft.api.models
{
   
   
    public class EmpleadoBE
    {
        public string Mail_personal;
        public string Telefono;

        /// <summary>
        /// EMP_ID
        /// </summary>
        public int Emp_id { get; set; }

        public string Apellido { get; set; }

        public string Nombre { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public string Documento { get; set; }
        public string Cuil { get; set; }
        public string Sexo { get; set; }

        public string Estado_civil { get; set; }

        public string Nacionalidad { get; set; }

        public string Cuenta { get; set; }
        public string Cue_id { get; set; }
        public string Subarea { get; set; }


        

        
        public string Sucursal { get; set; }
        public int? suc_id { get; set; }
        public string Sociedad { get; set; }
        //public int? sociedad_id { get; set; }


        public string Superior { get; set; }

        public string Ubicacion { get; set; }
        //public int? site_id { get; set; }
        //public int? call_id { get; set; }
        //public int? sar_id { get; set; }
    }

    public class KonectaError
    {
        public string Message { get; set; }
        public string Trace { get; set; }
        public string ErrorId { get; set; }
    }
    public class vista_CuentaSubAreaServicio
    {
        public int cue_id { get; set; }
        public string cue_nombre { get; set; }
        public int sar_id { get; set; }
        public string sar_nombre { get; set; }
        public int srv_id { get; set; }
        public string srv_nombre { get; set; }
    }

    public class Vista_Sucursal
    {

        public int suc_id { get; set; }
        public string suc_nombre { get; set; }

    }

    public class vista_Ubicacion
    {
        public int site_id { get; set; }
        public string site_nombre { get; set; }
        public int call_id { get; set; }
        public string call_nombre { get; set; }
        public int suc_id { get; set; }
        public string suc_nombre { get; set; }
    }

    public class Vista_Sociedad
    {
        //        sociedad_id                                                                                                                      int                                                                                                                              no                                  4           10    0     no                                  (n/a)                               (n/a)                               NULL
        //sociedad_nombre                                                                                                                  varchar                                                                                                                          no                                  50                      no                                  no                                  no                                  Modern_Spanish_CI_AS
        //sociedad_Ruc                                                                                                                     varchar                                                                                                                          no                                  50                      no                                  no                                  no                                  Modern_Spanish_CI_AS
        //fechainicioAct                                                                                                                   datetime                                                                                                                         no                                  8                       yes                                 (n/a)                               (n/a)                               NULL
        //soc_nombre                                                                                                                       varchar                                                                                                                          no                                  50                      no                                  no                                  no                                  Modern_Spanish_CI_AS
        //calle                                                                                                                            varchar                                                                                                                          no                                  250                     yes                                 no                                  yes                                 Modern_Spanish_CI_AS
        //numero_calle                                                                                                                     int                                                                                                                              no                                  4           10    0     yes                                 (n/a)                               (n/a)                               NULL
        //Sociedad_cliente                                                                                                                 varchar                                                                                                                          no                                  50                      yes                                 no                                  yes                                 Modern_Spanish_CI_AS
        //Sociedad_subCuenta
        public int sociedad_id { get; set; }
        public string sociedad_nombre { get; set; }
        public string sociedad_Ruc { get; set; }
        public DateTime fechainicioAct { get; set; }
        public string soc_nombre { get; set; }
        public string calle { get; set; }
        public int? numero_calle { get; set; }
        public string Sociedad_cliente { get; set; }
        public string Sociedad_subCuenta { get; set; }
    }
}
