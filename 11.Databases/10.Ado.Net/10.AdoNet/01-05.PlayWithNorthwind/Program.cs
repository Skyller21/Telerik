namespace _01_05.PlayWithNorthwind
{
    using System;
    using System.Data.SqlClient;
    using System.IO;
    using System.Reflection;

    public class Program
    {
        public static void Main()
        {
            // Problem 1. Write a program that retrieves from the Northwind sample database
            // in MS SQL Server the number of rows in the Categories table.
            CountCategories();

            //// Problem 2. Write a program that retrieves the name and description of all categories in the Northwind DB.
            ExtractCategoriesNamesAndDescription();

            //// Problem 3. Write a program that retrieves from the Northwind database all product categories and the names of the products in each category.
            ExtractCategoriesAndProducts();

            // Problem 4. Write a method that adds a new product in the products table in the Northwind database.
            AddProductToDb("Загорка Ретро", 1, 1, "20x0.5l", 19.99m);

            // Problem 5. Write a program that retrieves the images for all categories in the Northwind database and stores them as JPG files in the file system.
            GetAllCategoryImages();

            // All other exercises are implemented in the team work. If you want to check them feel free to 
            // go to https://github.com/Team-Selenium
            // I don't have time to do them all again. :)))
        }

        private static void GetAllCategoryImages()
        {
            SqlConnection dbCon = new SqlConnection("Server=.; " + "Database=Northwind; Integrated Security=true");
            dbCon.Open();

            SqlCommand cmdGetAllPictures = new SqlCommand("SELECT CategoryName, Picture FROM Categories", dbCon);
            SqlDataReader reader = cmdGetAllPictures.ExecuteReader();
            using (reader)
            {
                while (reader.Read())
                {
                    string categoryName = (string)reader["CategoryName"];
                    categoryName = categoryName.Replace('/', '-');
                    byte[] fileContent = (byte[])reader["Picture"];
                    string fileName = categoryName;
                    string fileFormat = "jpg";
                    string path = "../../Images/";
                    SaveAsJpeg(path, fileName, fileFormat, fileContent);
                }
            }
        }

        private static void SaveAsJpeg(string path, string fileName, string fileFormat, byte[] fileContents)
        {
            FileStream stream = File.OpenWrite(string.Format("{0}{1}.{2}", path, fileName, fileFormat));
            using (stream)
            {
                stream.Write(fileContents, 78, fileContents.Length - 78);
            }
        }

        private static void AddProductToDb(
             string productName,
             int supplierId,
             int categoryId,
             string quantityPerUnit,
             decimal unitPrice)
        {
            SqlConnection dbCon = new SqlConnection("Server=.; " + "Database=Northwind; Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmdInserProduct = new SqlCommand(
                    @"INSERT INTO Products (ProductName, SupplierID, CategoryID, QuantityPerUnit, UnitPrice)
                        VALUES(@productName, @supplierId, @categoryId, @quantityPerUnit, @unitPrice)",
                        dbCon);

                var parameters = MethodBase.GetCurrentMethod().GetParameters();


                cmdInserProduct.Parameters.AddWithValue("@productName", productName);
                cmdInserProduct.Parameters.AddWithValue("@supplierID", supplierId);
                cmdInserProduct.Parameters.AddWithValue("@categoryID", categoryId);
                cmdInserProduct.Parameters.AddWithValue("@quantityPerUnit", quantityPerUnit);
                cmdInserProduct.Parameters.AddWithValue("@unitPrice", unitPrice);

                cmdInserProduct.ExecuteNonQuery();
            }
        }

        private static void ExtractCategoriesAndProducts()
        {
            SqlConnection dbCon = new SqlConnection("Server=.; " + "Database=Northwind; Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmdCategoriesNames = new SqlCommand(
                    @"SELECT c.CategoryName, p.ProductName FROM Categories c
                      JOIN Products p ON p.CategoryID=c.CategoryID ",
                      dbCon);

                SqlDataReader reader = cmdCategoriesNames.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string productName = (string)reader["ProductName"];

                        Console.WriteLine("{0}: {1}", categoryName, productName);
                    }
                }
            }
        }

        private static void ExtractCategoriesNamesAndDescription()
        {
            SqlConnection dbCon = new SqlConnection("Server=.; " + "Database=Northwind; Integrated Security=true");
            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmdCategoriesNames = new SqlCommand(
                    "SELECT c.CategoryName, c.Description FROM Categories c", dbCon);

                SqlDataReader reader = cmdCategoriesNames.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        string categoryName = (string)reader["CategoryName"];
                        string categoryDescription = (string)reader["Description"];

                        Console.WriteLine("Category name: {0}, Category description: {1}", categoryName, categoryDescription);
                    }
                }
            }
        }

        private static void CountCategories()
        {
            SqlConnection dbCon = new SqlConnection("Server=.; " + "Database=Northwind; Integrated Security=true");

            dbCon.Open();

            using (dbCon)
            {
                SqlCommand cmdCount = new SqlCommand(
                    "SELECT COUNT(*) FROM Categories", dbCon);
                int categoriesCount = (int)cmdCount.ExecuteScalar();
                Console.WriteLine("Categories count: {0} ", categoriesCount);
                Console.WriteLine();
            }
        }
    }
}
