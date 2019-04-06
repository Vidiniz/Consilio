using ConsilioServices.Infrastructure.CrossCutting.ValueObject;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace ConsilioServices.Infrastructure.CrossCutting.AccessContext
{
    public class DataExecuteCommand
    {
        private readonly string QueryUser =
            @"SELECT SystemUsers.Id as UserId,
   	                 SystemUsers.Name UserName,
 	                 SystemProfiles.Id ProfileId,
	                 SystemProfiles.Name ProfileName 
                FROM SystemUsers 
                JOIN SystemProfiles ON (SystemUsers.SystemProfileId = SystemProfiles.Id)
               WHERE SystemUsers.id = @idUser";

        private readonly string QueryMenuAccess =
            @" SELECT MenuAccesses.Name 
                 FROM MenuAccesses
                 JOIN SystemProfileMenuAccesses ON (MenuAccesses.Id = SystemProfileMenuAccesses.MenuAccessId)
                 JOIN SystemProfiles ON (SystemProfileMenuAccesses.SystemProfileId = SystemProfiles.Id)
                WHERE SystemProfiles.Id = @idProfile";

        public VOUserAccess GetDataAccess(int idUser)
        {
            var connection = DataSQLConnection.GetConnection();

            var command = new SqlCommand(QueryUser, connection);
            command.Parameters.Add(new SqlParameter("idUser", idUser));

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                VOUserAccess resultData;

                if (reader.HasRows)
                {
                    resultData = new VOUserAccess
                    {
                        IdUser      = (int)reader["UserId"],
                        UserName    = reader["UserName"].ToString(),
                        IdProfile   = (int)reader["ProfileId"],
                        ProfileName = reader["ProfileName"].ToString()
                    };

                    resultData.MenuAccess = LoadMenuAcces(resultData.IdProfile, connection);

                    connection.Close();

                    return resultData;
                }

                return null;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {                
                connection.Close();
            }
        }

        private IEnumerable<string> LoadMenuAcces(int idProfile, SqlConnection connection)
        {
            var StringList = new List<string>();

            connection.Open();

            var command = new SqlCommand(QueryMenuAccess, connection);
            command.Parameters.Add(new SqlParameter("IdProfile",idProfile ));

            SqlDataReader reader = command.ExecuteReader();

            while(reader.Read())
            {
                StringList.Add(reader[0].ToString());
            }

            return StringList;
        }
    }
}
