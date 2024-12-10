using Microsoft.Data.SqlClient;
using System.Configuration;
using System.Data;
using System.Diagnostics.Eventing.Reader;

namespace ConsoleApp1
{
    public static class DB
    {
        public static async Task<DataTable> GetQueryResult(string queryString, string dbname, string login, string password)
        {
            return await GetQueryResultAsync(queryString, dbname, login, password, null);
        }

        public static async Task ExecuteChanges(string queryString, string dbname, string login, string password, Dictionary<string, object> dbParamsDict)
        {
            using (SqlConnection conn = await OpenConnectionAsync(dbname, login, password))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = queryString;
                try
                {
                    if (dbParamsDict != null)
                        cmd.Parameters.AddRange(dbParamsDict.Select(item => new SqlParameter(item.Key, item.Value)).ToArray());

                    await cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Не удалось выполнить запрос на изменение данных в БД.", ex);
                }
            }
        }

        public static async Task<DataTable> GetQueryResultAsync(string queryString, string dbname, string login, string password, Dictionary<string, object> dbParamsDict)
        {
            using (SqlConnection conn = await OpenConnectionAsync(dbname, login, password))
            using (SqlCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = queryString;
                try
                {
                    DataTable dt = new DataTable();
                    if (dbParamsDict != null)
                        cmd.Parameters.AddRange(dbParamsDict.Select(item => new SqlParameter(item.Key, item.Value)).ToArray());

                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        await Task.Run(() => da.Fill(dt));
                    }

                    return dt;
                }
                catch (Exception ex)
                {
                    throw new Exception("Не удалось выполнить запрос на получение данных из БД.", ex);
                }
            }
        }

        private static async Task<SqlConnection> OpenConnectionAsync(string dbname, string login, string password)
        {
            SqlConnection connection = new SqlConnection(GetUpdatedConnectionString(dbname, login, password));
            await connection.OpenAsync();
            return connection;
        }

        public static string GetConnectionString(string dbname)
        {
            return ConfigurationManager.ConnectionStrings[dbname]?.ConnectionString;
        }

        public static string GetUpdatedConnectionString(string dbname, string login, string password)
        {
            string connectionString = ConfigurationManager.ConnectionStrings[dbname].ConnectionString;

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder(connectionString)
            {
                UserID = login, // Устанавливаем новый логин
                Password = password // Устанавливаем новый пароль
            };

            // Возвращаем измененную строку подключения
            return builder.ConnectionString;
        }
    }
}