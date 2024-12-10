using System.Data;

namespace ConsoleApp1
{
    public class ProductDBRepo
    {
        public static async Task<List<Product>> SelectAllProducts()
        {
            string queryString = @"select *
                                   from Products";

            List<Product> Products = new List<Product>();

            DataTable dataTable = await OleDB.GetQueryResultAsync(queryString, "testOleDB", null);

            Products = dataTable.AsEnumerable().Select(MapToProduct).ToList();
            return Products;
        }

        private static Product MapToProduct(DataRow row)
        {
            Product product = new Product(Guid.Parse(row["ID"].ToString()),
                                           row["Email"].ToString(),
                                           int.Parse(row["ProductCode"].ToString()),
                                           row["ProductName"].ToString());
            return product;
        }

        public static async Task Insert(Product Product)
        {
            string queryString = @"insert into Products (Id, ProductCode, ProductName, Email)
                                                          values (?, ?, ?, ?)";

            await OleDB.ExecuteChanges(queryString, "testOleDB", CreateSqlParamsForSave(Product));
        }

        public static async Task Update(Product Product)
        {
            string queryString = @"update Products
                                    set ProductCode = @ProductCode,
                                        ProductName = @ProductName,
                                        Email = @Email
                                    where id = @Id";

            await OleDB.ExecuteChanges(queryString, "testOleDB", CreateSqlParamsForUpdate(Product));
        }

        public static async Task Delete(Guid ProductId)
        {
            string queryString = @"delete from Products
                                   where id = @Id";

            await OleDB.ExecuteChanges(queryString, "testOleDB", new Dictionary<string, object> { ["@Id"] = ProductId.ToString() });
        }

        public static Dictionary<string, object> CreateSqlParamsForSave(Product Product)
        {
            var paramsDict = new Dictionary<string, object>
            {
                ["@Id"] = Product.Id.ToString(),
                ["@ProductCode"] = Product.ProductCode,
                ["@ProductName"] = Product.ProductName,
                ["@Email"] = Product.Email
            };
            return paramsDict;
        }

        public static Dictionary<string, object> CreateSqlParamsForUpdate(Product Product)
        {
            var paramsDict = new Dictionary<string, object>
            {
                ["@ProductCode"] = Product.ProductCode,
                ["@ProductName"] = Product.ProductName,
                ["@Email"] = Product.Email,
                ["@Id"] = Product.Id.ToString()
            };
            return paramsDict;
        }

        public static Product Find(string ProductId)
        {
            string queryString = @"select * from Products
                                    where id = @Id";

            DataRow row = OleDB.GetQueryResultAsync(queryString, "testOleDB", new Dictionary<string, object> { ["@Id"] = ProductId.ToString() }).Result.Rows[0];

            Product product = new Product(Guid.Parse(row["ID"].ToString()),
                                           row["Email"].ToString(),
                                           int.Parse(row["ProductCode"].ToString()),
                                           row["ProductName"].ToString());

            return product;
        }
    }
}
