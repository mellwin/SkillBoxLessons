using System.Configuration;
using System.Data;
using System.Data.OleDb;

namespace ConsoleApp1
{
    public static class OleDB
    {
        public static async Task<DataTable> GetQueryResult(string queryString, string dbname)
        {
            return await GetQueryResultAsync(queryString, dbname, null);
        }

        public static async Task ExecuteChanges(string queryString, string dbname, Dictionary<string, object> dbParamsDict)
        {
            using (OleDbConnection conn = await OpenConnectionAsync(dbname))
            using (OleDbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = queryString;
                try
                {
                    if (dbParamsDict != null)
                        cmd.Parameters.AddRange(dbParamsDict.Select(item => new OleDbParameter(item.Key, item.Value)).ToArray());

                    await cmd.ExecuteNonQueryAsync();
                }
                catch (Exception ex)
                {
                    throw new Exception("Не удалось выполнить запрос на изменение данных в БД.", ex);
                }
            }
        }

        public static async Task<DataTable> GetQueryResultAsync(string queryString, string dbname, Dictionary<string, object> dbParamsDict)
        {
            using (OleDbConnection conn = await OpenConnectionAsync(dbname))
            using (OleDbCommand cmd = conn.CreateCommand())
            {
                cmd.CommandText = queryString;
                try
                {
                    DataTable dt = new DataTable();
                    if (dbParamsDict != null)
                        cmd.Parameters.AddRange(dbParamsDict.Select(item => new OleDbParameter(item.Key, item.Value)).ToArray());

                    using (OleDbDataAdapter da = new OleDbDataAdapter(cmd))
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

        private static async Task<OleDbConnection> OpenConnectionAsync(string dbname)
        {
            OleDbConnection connection = new OleDbConnection(GetConnectionString(dbname));
            await connection.OpenAsync();
            return connection;
        }

        private static string GetConnectionString(string dbname)
        {
            return ConfigurationManager.ConnectionStrings[dbname]?.ConnectionString;
        }
    }
}
