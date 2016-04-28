using Fwk.Bases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Allus_DXExpress.DataRepository
{
    [XmlRoot("Employees"), SerializableAttribute]
    public class EmployeesBEList : Entities<EmployeBE> 
    {
        public static EmployeesBEList Factory()
        {
            try
            {
                //Buscamos la data en el archivo xml
                var xmlEmp = Fwk.HelperFunctions.FileFunctions.OpenTextFile(@"DataRepository\Employees.xml");
                //Serializamos y retornamos el objeto y casteado
                return EmployeesBEList.GetFromXml<EmployeesBEList>(xmlEmp);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
    [XmlType("Employe"), Serializable]
    public class EmployeBE : Entity
    {
        public int EmployeeID { get; set; }
        public String LastName { get; set; }
        public String FirstName { get; set; }
        public String Title { get; set; }
        public String Address { get; set; }
        public String Country { get; set; }
        public String HomePhone { get; set; }
        public String City { get; set; }
        public String Region { get; set; }
        public Decimal Salary { get; set; }

        [XmlElementAttribute("Photo", DataType = "base64Binary")]
        public Byte[] Photo { get; set; }

    }
}
