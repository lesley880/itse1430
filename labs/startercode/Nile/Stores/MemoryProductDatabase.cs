/*
 * Lesley Reller
 * ITSE 1430
 * 04/17/2020
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public class MemoryProductDatabase : ProductDatabase
    {        
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        protected override Product AddCore ( Product product )
        {
            var newProduct = CloneProduct(product);
            newProduct.Id = _nextId++;
            _products.Add(newProduct);

            return CloneProduct(newProduct);
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        protected override Product GetCore ( int id )
        {
            var product = FindProduct(id);
            if (product == null)
                return null;

            return CloneProduct(product);
        }

        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        protected override IEnumerable<Product> GetAllCore ()
        {
            // filter
            var items = _products.Where(p => true);
            // transformation
            return _products.Select(p => CloneProduct(p));
        }

        /// <summary>Removes the product.</summary>
        /// <param name="product">The product to remove.</param>
        protected override void RemoveCore ( int id )
        {
            var product = FindProduct(id);
            if (product != null)
                _products.Remove(product);
        }

        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        protected override void UpdateCore ( int id, Product product)
        {
            //Replace 
            var exsisting = FindProduct(id);

            CopyProduct(exsisting, product, false);
        }
        
        private void CopyProduct ( Product target, Product source, bool includeId )
        {
            if (includeId)
                target.Id = source.Id;
            target.Name = source.Name;
            target.Description = source.Description;
            target.Price = source.Price;
            target.IsDiscontinued = source.IsDiscontinued;
        }
        private Product CloneProduct ( Product product )
        {
            var item = new Product();
            CopyProduct(item, product, true);

            return item;
        }

        //Find a product by ID
        protected override Product FindProduct ( int id ) => _products.FirstOrDefault(p => p.Id == id);

        // Find Product by Name
        protected override Product FindName ( string name ) =>(from product in _products
                                                               where String.Compare(product.Name, name, true) == 0
                                                               select product).FirstOrDefault();
        //{
        //    foreach (var product in _products)
        //    {
        //        if (product.Id == id)
        //            return product;
        //    };

        //    return null;
        //}

        private List<Product> _products = new List<Product>();
        private int _nextId = 1;
    }
}
