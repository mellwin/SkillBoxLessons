using System.Data;
using System.Xml.Linq;

namespace ConsoleApp1
{
    public static class CustumerDBRepo 
    {
        public static async Task<List<Custumer>> SelectAllCustumers(string dbname, string login)
        {
            string queryString = @"select *
                                   from [dbo].[Custumers]";

            List<Custumer> custumers = new List<Custumer>();

            DataTable dataTable = await DB.GetQueryResultAsync(queryString, "testDB", dbname, login, null);

            custumers = dataTable.AsEnumerable().Select(MapToCustumer).ToList();
            return custumers;
        }

        private static Custumer MapToCustumer(DataRow row)
        {
            Custumer Custumer = new Custumer(Guid.Parse(row["ID"].ToString()),
                                           row["LastName"].ToString(),
                                           row["Name"].ToString(),
                                           row["SecondName"].ToString(),
                                           row["PhoneNumber"].ToString(),
                                           row["Email"].ToString());

            return Custumer;
        }

        public static async Task Insert(Custumer custumer, string dbname, string login)
        {
            string queryString = @"insert into [dbo].[Custumers] ([Id], [LastName], [Name], [SecondName], [PhoneNumber], [Email])
                                                          values (@ID, @LastName, @Name, @SecondName, @PhoneNumber, @Email)";
                        
            await DB.ExecuteChanges(queryString, "testDB", dbname, login, CreateSqlParamsForSave(custumer));
        }

        public static async Task Update(Custumer custumer, string dbname, string login)
        {
            string queryString = @"update [dbo].[Custumers]
                                    set [LastName] = @LastName,
                                        [Name] = @Name,
                                        [SecondName] = @SecondName,
                                        [PhoneNumber] = @PhoneNumber,
                                        [Email] = @Email
                                    where id = @Id";

            await DB.ExecuteChanges(queryString, "testDB", dbname, login, CreateSqlParamsForSave(custumer));
        }

        public static async Task Delete(Guid custumerId, string dbname, string login)
        {
            string queryString = @"delete from [dbo].[Custumers]
                                   where [id] = @Id"
            ;

            DB.ExecuteChanges(queryString, "testDB", dbname, login, new Dictionary<string, object> { ["@Id"] = custumerId });
        }

        public static Dictionary<string, object> CreateSqlParamsForSave(Custumer custumer)
        {
            var paramsDict = new Dictionary<string, object>
            {
                ["@Id"] = custumer.Id,
                ["@LastName"] = custumer.LastName,
                ["@SecondName"] = custumer.SecondName,
                ["@Name"] = custumer.Name,
                ["@PhoneNumber"] = custumer.PhoneNumber,
                ["@Email"] = custumer.Email
            };
            return paramsDict;
        }

        public static Custumer Find(Guid custumerId, string dbname, string login)
        {
            string queryString = @"select * from [dbo].[Custumers]
                                    where [id] = @Id";

            DataRow dr = DB.GetQueryResultAsync(queryString, "testDB", dbname, login, new Dictionary<string, object> { ["@Id"] = custumerId.ToString() }).Result.Rows[0];

            Custumer custumer = new Custumer(Guid.Parse(dr["ID"].ToString()),
                                           dr["LastName"].ToString(),
                                           dr["Name"].ToString(),
                                           dr["SecondName"].ToString(),
                                           dr["PhoneNumber"].ToString(),
                                           dr["Email"].ToString());

            return custumer;
        }
    }
}
