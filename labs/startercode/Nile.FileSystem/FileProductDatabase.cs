/*
 * Lesley Reller
 * ITSE 1430
 * 04/25/2020
 */

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Nile.Stores;

namespace Nile.FileSystem
{
    public class FileProductDatabase : ProductDatabase
    {
        public FileProductDatabase ( string filename )
        {
            if (filename == null)
                throw new ArgumentNullException(nameof(filename));  //"filename"
            if (String.IsNullOrEmpty(filename))
                throw new ArgumentException("Filename cannot be empty", nameof(filename));

            _filename = filename;
        }

        protected override Product AddCore ( Product product )
        {
            EnsureLoaded();

            product.Id = (_items.Any() ? _items.Max(p => p.Id) : 0) + 1;

            _items.Add(product);
            SaveProducts();

            return product;
        }

        private void EnsureLoaded ()
        {
            if (_items == null)
                GetAllCore();
        }

        protected override void RemoveCore ( int id )
        {
            var product = FindProduct(id);
            if (product != null)
            {
                _items.Remove(product);
                SaveProducts();
            };
        }

        protected override Product GetCore ( int id )
        {
            if (!File.Exists(_filename))
                return null;
            //IOException

            using (var reader = new StreamReader(_filename))
            {

                while (!reader.EndOfStream)
                {
                    var line = reader.ReadLine();
                    var product = LoadProduct(line);
                    if (product?.Id == id)
                        return product;
                }
            }

            return null;
        }

        protected override IEnumerable<Product> GetAllCore ()
        {
            _items = new List<Product>();
            if (File.Exists(_filename))
            {
                try
                {
                    var products = LoadProducts();

                    _items.AddRange(products);

                } catch (FileNotFoundException)
                { /* Ignore */ };
            };

            return _items;
        }

        protected override void UpdateCore ( int id, Product product )
        {
            var existing = FindProduct(id);
            if (existing == null)
                throw new Exception("product not found");

            _items.Remove(existing);

            product.Id = id;
            _items.Add(product);

            SaveProducts();
        }

        protected override Product FindName ( string name )
        {
            EnsureLoaded();

            return _items.FirstOrDefault(m => String.Compare(m.Name, name, true) == 0);
        }

        protected override Product FindProduct ( int id )
        {
            EnsureLoaded();

            return _items.FirstOrDefault(p => p.Id == id);
        }

        private IEnumerable<Product> LoadProducts ()
        {           
            var lines = File.ReadAllLines(_filename);
            foreach (var line in lines)
            {
                var product = LoadProduct(line);
                if (product != null)
                    yield return product;
            };
        }
        private void SaveProducts ()
        {
            var lines = new List<string>();
            foreach (var product in _items)
            {
                var line = SaveProduct(product);
                if (!String.IsNullOrEmpty(line))
                    lines.Add(line);
            };
            File.WriteAllLines(_filename, lines);
        }

        private Product LoadProduct ( string line )
        {
            var tokens = line.Split(',');

            if (tokens.Length != 7)
                return null;

            if (!Int32.TryParse(tokens[0], out var id) || id <= 0)
                return null;

            var name = UnquotedString(tokens[1]);
            if (String.IsNullOrEmpty(name))
                return null;

            var description = UnquotedString(tokens[2]);

            if (!Int32.TryParse(tokens[3], out var price))
                return null;

            if (!Boolean.TryParse(tokens[4], out var isDiscontinued))
                return null;

            return new Product() {
                Id = id,
                Name = name,
                Description = description,
                Price = price,
                IsDiscontinued = isDiscontinued
            };
        }

        private string SaveProduct ( Product product )
        {
            return $"{product.Id}, {QuotedString(product.Name)}, {QuotedString(product.Description)}, {product.Price}, {product.IsDiscontinued}";
        }

        private static string QuotedString ( string value ) => $"\"{value}\"";

        private static string UnquotedString ( string value ) => value?.Trim('"', ' ', '\t')?.Trim() ?? "";

        private List<Product> _items;
        private readonly string _filename;
    }

}
