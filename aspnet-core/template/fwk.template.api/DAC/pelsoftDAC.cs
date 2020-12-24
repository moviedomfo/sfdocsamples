using fwk.template.api.common;
using pelsoft.api.be;
using pelsoft.api.models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace pelsoft.api.dac

{
    public class pelsoftDAC
    {
        /// <summary>
        /// Inserta socio
        /// </summary>
        /// <param name="reciveAction"></param>
        public static int Insert(ReciveActionReq reciveAction)
        {
            var connectionString = CommonHelpers.GetCnn(CommonHelpers.cnnStringName_pelsoft).ConnectionString;

            using (SqlConnection cnn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand("[Apipelsoft].[ReceivedUser_i]", cnn))
            {
                #region params

                cmd.CommandType = CommandType.StoredProcedure;
                SqlParameter param = new SqlParameter("@ReceivedUserId", SqlDbType.Int);
                param.Direction = ParameterDirection.Output;
                cmd.Parameters.Add(param);

                cmd.Parameters.AddWithValue("@SourceUserId", reciveAction.source_userid);
                cmd.Parameters.AddWithValue("@Channel", reciveAction.channel);
                cmd.Parameters.AddWithValue("@Owner", reciveAction.owner);
                
                cmd.Parameters.AddWithValue("@Action", reciveAction.action);

                string json = Newtonsoft.Json.JsonConvert.SerializeObject(reciveAction);
                cmd.Parameters.AddWithValue("@json", json);

                #endregion

                cnn.Open();
                cmd.ExecuteNonQuery();
                return ((int)cmd.Parameters["@ReceivedUserId"].Value);

            }

        }



        /// <summary>
        /// Si el canal es “Facebook” se ejecuta el siguiente sp
        /// </summary>
        /// <param name="owner"></param>
        /// <returns></returns>
        public static Guid Get_Facebook_Account(string owner)
        {
            Guid accountDetailUnique = new Guid ();

            try
            {
                using (SqlConnection cnn = new SqlConnection(CommonHelpers.GetCnn(CommonHelpers.cnnStringName_pelsoft).ConnectionString))
                using (SqlCommand cmd = new SqlCommand("[Apipelsoft].[Facebook_Account_s_Owner]", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@Owner", owner);

                    cnn.Open();
                  
                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accountDetailUnique = Guid.Parse(reader["AccountDetailUnique"].ToString());
                        }
                    }
                    return accountDetailUnique;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Si el canal es “Facebook” se ejecuta el siguiente sp
        /// -	Se obtienen datos particulares de la cuenta
        /// </summary>
        /// <param name="accountDetailUnique"></param>
        /// <returns></returns>
        public static AccountDetail Get_AccountDetail(Guid accountDetailUnique)
        {
            AccountDetail accountDetail = new AccountDetail();

            try
            {
                using (SqlConnection cnn = new SqlConnection(CommonHelpers.GetCnn(CommonHelpers.cnnStringName_pelsoft).ConnectionString))
                using (SqlCommand cmd = new SqlCommand("[Apipelsoft].[AccountDetail_s_AccountDetailUnique]", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountDetailUnique", accountDetailUnique);

                    cnn.Open();

                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            accountDetail.AccountId = Convert.ToInt32(reader["AccountId"].ToString());
                            accountDetail.AccountDetailId = Convert.ToInt32(reader["AccountDetailId"].ToString());
                            accountDetail.ServiceChannelId = Convert.ToInt32(reader["ServiceChannelId"].ToString());
                        }
                    }
                    return accountDetail;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }



        /// <summary>
        /// -	Se obtiene el id del usuario de pelsoft
        /// </summary>
        /// <param name="settingId">: Identificador para obtener el usuario de pelsoft. Se pasa el valor 183</param>
        /// <param name="accountId">Identificador de la Unidad de negocio</param>
        /// <returns></returns>
        public static ApplicationSettings Get_ApplicationSettings(int settingId, int? accountId)
        {
            ApplicationSettings applicationSettings = new ApplicationSettings();

            try
            {
                using (SqlConnection cnn = new SqlConnection(CommonHelpers.GetCnn(CommonHelpers.cnnStringName_pelsoft).ConnectionString))
                using (SqlCommand cmd = new SqlCommand("[Apipelsoft].[ApplicationSettings_s_BySettingId]", cnn))
                {
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@settingId", settingId);
                    if(accountId.HasValue)
                        cmd.Parameters.AddWithValue("@accountId", accountId);
                    
                    cnn.Open();

                    using (IDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            applicationSettings.SettingId = Convert.ToInt32(reader["SettingId"].ToString());
                            applicationSettings.Description = reader["Description"].ToString();
                            applicationSettings.Value = reader["Value"].ToString();
                        }
                    }
                    return applicationSettings;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }


        /// <summary>
        /// -	Se busca el caso relacionado al usuario de la red social para luego liberar o cerrar, de acuerdo a la acción recibida.
        /// </summary>
        /// <param name="accountDetail"></param>
        /// <param name="applicationSettings"></param>
        /// <param name="action">Identificador obtenido al insertar el registro recibido por pelsoft</param>
        /// <param name="accountDetailUnique">Identificador de la Unidad de negocio</param>
        /// <param name="sourceUserId">Identificador de la Unidad de negocio</param>
        /// <param name="receivedUserId"> Se pasa el valor del parámetro obtenido del sp [Apipelsoft].[ReceivedUser_i]</param>
        /// <returns></returns>
        public static int crear_caso(AccountDetail accountDetail, 
            ApplicationSettings applicationSettings,
            string action ,Guid accountDetailUnique,
            string sourceUserId,
            int receivedUserId)
        {


            try
            {
                using (SqlConnection cnn = new SqlConnection(CommonHelpers.GetCnn(CommonHelpers.cnnStringName_pelsoft).ConnectionString))
                using (SqlCommand cmd = new SqlCommand("[Apipelsoft].[Case_BySourceUserId_Action]", cnn))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    SqlParameter param = new SqlParameter("@CaseLogId", SqlDbType.Int);
                    param.Direction = ParameterDirection.Output;
                    cmd.Parameters.Add(param);
                    cmd.CommandType = System.Data.CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@AccountDetailId", accountDetail.AccountDetailId);
                    cmd.Parameters.AddWithValue("@ServiceChannelId", accountDetail.ServiceChannelId);
                    //Identificador del usuario en la red social. Se pasa el valor del parámetro
                    cmd.Parameters.AddWithValue("@SourceUserId", sourceUserId);
                    //Identificador del usuario pelsoft. Se pasa el valor de campo Value obtenido de la ejecución del sp [Apipelsoft].[ApplicationSettings_s_BySettingId]
                    cmd.Parameters.AddWithValue("@UsuarioChatBot", applicationSettings.Value);
                    //Identificador de la Unidad de negocio
                    cmd.Parameters.AddWithValue("@AccountId", accountDetail.AccountId);
                    //acción que se debe realizar sobre un caso
                    cmd.Parameters.AddWithValue("@Action", action);
                    //Identificador obtenido al insertar el registro recibido por pelsoft. Se pasa el valor del parámetro obtenido del sp [Apipelsoft].[ReceivedUser_i]
                    cmd.Parameters.AddWithValue("@ReceivedUserId", receivedUserId);

                 
                    cnn.Open();

                    cmd.ExecuteNonQuery();
                    if(cmd.Parameters["@CaseLogId"].Value != System.DBNull.Value)
                            return ((int)cmd.Parameters["@CaseLogId"].Value);

                    return -1;
                   
                }
            }
            catch (Exception ex)

            {
                throw ex;
            }
        }
    }
}
