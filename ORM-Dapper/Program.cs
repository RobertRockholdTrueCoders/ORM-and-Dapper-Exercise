using System;
using System.Data;
using System.IO;
using MySql.Data.MySqlClient;
using Microsoft.Extensions.Configuration;
using ORM_Dapper;

//^^^^MUST HAVE USING DIRECTIVES^^^^

var config = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json")
    .Build();
string connString = config.GetConnectionString("DefaultConnection");
IDbConnection conn = new MySqlConnection(connString);

var departmentRepo = new DepartmentRepository(conn);

departmentRepo.InsertDepartment("CSharp-50");

var departments = departmentRepo.GetAllDepartments();

foreach (var dep in departments)
{
    Console.WriteLine($"Name: {dep.Name} | ID: {dep.DepartmentID}");
}

var prodRepo = new ProductRepository(conn);

prodRepo.CreateProduct("Banana", 5.00, 10, false, 25);
prodRepo.UpdateProduct("Fallout: New Vegas", 60.00, 8, false, 500, 940);
prodRepo.DeleteProduct(940);

var products = prodRepo.GetAllProducts();

foreach (var product in products)
{
    Console.WriteLine($"ID: {product.ProductID} | Name: {product.Name} | Price: {product.Price} | Category ID: {product.CategoryID} | Sale: {product.OnSale} | Stock: {product.StockLevel}");
}