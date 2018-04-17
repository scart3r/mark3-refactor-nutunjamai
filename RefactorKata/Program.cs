﻿using System;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace RefactorKata
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> products = new List<Product>();

            using (var conn = new SqlConnection("Server=.;Database=myDataBase;User Id=myUsername;Password = myPassword;"))
            {
                var cmd = conn.CreateCommand();
                cmd.CommandText = "select * from Products";

                var reader = cmd.ExecuteReader();

                while (reader.Read())
                { products.Add(new Product { name = reader["Name"].ToString() }); }
            }

            Console.WriteLine("Products Loaded!");
            foreach (var Product in products)
            { Console.WriteLine(Product.name); }
        }
    }
}