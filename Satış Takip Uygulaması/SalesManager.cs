using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System.Windows.Forms;

namespace SalesTrackingApp
{
    public class SaleItem
    {
        public string? Barcode { get; set; }
        public string? ProductName { get; set; }
        public string? Price { get; set; }
    }

    public class Sale
    {
        public string? TcNo { get; set; }
        public string? CustomerName { get; set; }
        public string? Phone { get; set; }
        public List<SaleItem> Items { get; set; } = new List<SaleItem>();
        public string TotalAmount { get; set; } = "0";
        public DateTime SaleDate { get; set; }
    }

    public static class SalesManager
    {
        private static readonly string AppPath = Application.StartupPath;
        private static readonly string JsonFilePath = Path.Combine(AppPath, "sales.json");

        public static string GetApplicationPath()
        {
            return AppPath;
        }

        public static string GetJsonFilePath()
        {
            return JsonFilePath;
        }

        public static void SaveSale(Sale sale)
        {
            List<Sale> sales = LoadSales();
            sales.Add(sale);

            string jsonString = JsonSerializer.Serialize(sales, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(JsonFilePath, jsonString);
        }

        public static List<Sale> LoadSales()
        {
            if (!File.Exists(JsonFilePath))
            {
                return new List<Sale>();
            }

            string jsonString = File.ReadAllText(JsonFilePath);
            if (string.IsNullOrEmpty(jsonString))
            {
                return new List<Sale>();
            }

            var sales = JsonSerializer.Deserialize<List<Sale>>(jsonString);
            return sales ?? new List<Sale>();
        }
    }
} 