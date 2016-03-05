using System;
using System.Collections.Generic;
using System.Linq;
using SportsClub.Common.BE;
using SportsClub.Linq;
using System.Data.Common;
using System.Data;
using System.Data.SqlClient;

namespace SportsClub.DAC
{
    public class PersonDAC
    {
        public const string CnnStringName = "DefaultConnection";
        public static string CnnString = string.Empty;
        static PersonDAC()
        {

         
          
            if (System.Configuration.ConfigurationManager.ConnectionStrings[CnnStringName] == null)
                throw new Exception(String.Concat("Falta cadena de coneccion", CnnStringName));
            CnnString = System.Configuration.ConfigurationManager.ConnectionStrings[CnnStringName].ConnectionString;
           


        }
        /// <summary>
        /// SearchByParam
        /// </summary>
        ///<param name="pPersonFullView">PersonFullView</param>
        /// <returns>PersonFullViewList</returns>
        /// <Date>2015-07-01T12:19:40</Date>
        /// <Author>moviedo</Author>
        public static List<PersonFullViewBE> SearchByParam_sp(string nombre, string apellido, string dni, Boolean? memmbersFlag)
        {
            SqlParameter param = null;
           
            List<PersonFullViewBE> wPersonFullViewList = new List<PersonFullViewBE>();
            PersonFullViewBE wPersonFullView;


            try
            {
                using (SqlConnection cnn = new SqlConnection(CnnString))
                {
                    cnn.Open();
                    using (SqlCommand cmd = new SqlCommand("dbo.PersonFullView_s", cnn) { CommandType = System.Data.CommandType.StoredProcedure })
                    {

                        if (!String.IsNullOrEmpty(nombre))
                        {
                            param = new SqlParameter("@Name", System.Data.SqlDbType.VarChar, 200);
                            param.Value = nombre;
                            cmd.Parameters.Add(param);
                        }
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                wPersonFullView = new PersonFullViewBE();

                                wPersonFullView.PersonId = Convert.ToInt32(reader["PersonId"]);
                              

                                wPersonFullView.DocNumber = reader["DocNumber"].ToString();
                              

                                wPersonFullView.Name = reader["Name"].ToString();
                                wPersonFullView.Lastname = reader["Lastname"].ToString();

                                
                                //wPersonFullView.City = reader["City"].ToString();
                         
                                wPersonFullViewList.Add(wPersonFullView);
                            }
                        }

                    }

                }





                return wPersonFullViewList;

            }
            catch (Exception ex)
            {
                throw ex;
            }

        }

     

        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="personId"></param>
        ///// <returns></returns>
        //public static PersonBE Get(int personId)
        //{

        //    using (clubDataDataContext dc = new clubDataDataContext(CommonStatics.CnnString))
        //    {
        //        var wPersons = from p in dc.PersonFullViews
        //                      where p.PersonId.Equals(personId)
        //                      select p;
        //        PersonFullView person = wPersons.FirstOrDefault();

        //        var photo = dc.PersonFiles.Where(p=> 
        //            p.PersonId.Equals(person.PersonId) && 
        //            p.ContentType== Enum.GetName( typeof(FileType), FileType.Avatar)).FirstOrDefault();
                
        //        PersonBE personBE = new PersonBE(person);
        //        if (photo != null)
        //        {
        //            personBE.PersonFileBE = Get_Photo_PersonFiles(personId);
        //        }

        //        return personBE;

        //    }
           
        //}
        ///// <summary>
        ///// 
        ///// </summary>
        ///// <param name="personId"></param>
        ///// <returns></returns>
        //public static System.Byte[] Get_Photo(int personId)
        //{

        //    using (clubDataDataContext dc = new clubDataDataContext(CommonStatics.CnnString))
        //    {
        //        System.Byte[] bytes = null;
 
           
        //        var photo = dc.PersonFiles.Where(p =>
        //           p.PersonId.Equals(personId) &&
        //           p.ContentType == Enum.GetName(typeof(FileType), FileType.Avatar)).FirstOrDefault();
        //        if (photo != null)
        //        {
        //            bytes = photo.ContentFile.ToArray();
        //        }
             
        //        return bytes;
        //    }
           
        //}

        
        //public static PersonFullView Get_FullView(int personId)
        //{

        //    using (clubDataDataContext dc = new clubDataDataContext(CnnString))
        //    {
        //        var persons = from p in dc.PersonFullViews
        //                      where p.PersonId.Equals(personId)
        //                      select p;

        //        return persons.FirstOrDefault<PersonFullView>();
        //    }
         
        //}

        //public static bool Exist(String nroDocumento)
        //{

        //    using (clubDataDataContext dc = new clubDataDataContext(CnnString))
        //    {

        //        return dc.Persons.Any<Person>(p => p.DocNumber.Equals(nroDocumento));

        //    }
        //}
    






     
    }
}

