using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;

namespace SecureWcf
{
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerSession)]
    public class CoreSecurity : ICoreSecurity
    {

        int y = 0;
        public string GetData(int value)
        {

            y = value + y;

            //Si hay una excepción interna que no se atrapa y se define como FaultException<SomeError> exception,
            //entonces el canal se cerrará, así que para evitar que el canal se cierre, siempre se deben definir las excepciones como FaultException<SomeError> exception (
            if (value == 0)
                throw new Exception("Prieva manejo de excepciones WCF");

            if (value == 1)
            {

                WCFServiceError se = new WCFServiceError ();
                se.Message = "Prieva manejo de excepciones WCF, Este error no cerrara el canal";
                throw new FaultException< WCFServiceError>(se,"Por las simple razon de la prueva");
            }
            return string.Format("Usted ingreso {0}", value);
        }
        public int GetData_y()
        {
            return y;
        }
        public CompositeType GetDataUsingDataContract(CompositeType composite)
        {
            if (composite == null)
            {
                throw new ArgumentNullException("composite");
            }
            if (composite.BoolValue)
            {
                composite.StringValue += "Suffix";
            }
            return composite;
        }
    }
}
