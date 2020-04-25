/*
 * LesleyReller
 * ITSE 1430
 * 04/17/2020
 */
using System;
using System.Collections.Generic;
using System.Linq;

namespace Nile.Stores
{
    /// <summary>Base class for product database.</summary>
    public abstract class ProductDatabase : IProductDatabase
    {        
        /// <summary>Adds a product.</summary>
        /// <param name="product">The product to add.</param>
        /// <returns>The added product.</returns>
        public Product Add ( Product product )
        {
            //TODO: Check arguments
            if (product == null)
                throw new ArgumentNullException(nameof(Product), "Product is null.");

            //TODO: Validate product
            //.Net
            ObjectValidator.Validate(product);

            // Names need to be unique
            try
            {
                var existing = FindName(product.Name);
                if (existing != null)
                    throw new InvalidOperationException("Product must be unique");

                return AddCore(product);
            } catch (InvalidOperationException)
            {
                // Rethrow exception
                throw;
            } catch (Exception e)
            {
                // Rewrite exception with original exception as the inner exception
                throw new InvalidOperationException("Error adding product", e);
            };
            //Emulate database by storing copy
            // return AddCore(product);
        }

        /// <summary>Get a specific product.</summary>
        /// <returns>The product, if it exists.</returns>
        public Product Get ( int id )
        {
            //TODO: Check arguments
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");
            try
            {
                return GetCore(id);
            } catch (Exception e)
            {
                //Rewrite exception
                throw new InvalidOperationException("Error reading product.", e);
            };
        }
        
        /// <summary>Gets all products.</summary>
        /// <returns>The products.</returns>
        public IEnumerable<Product> GetAll ()
        {
            try
            {
                return GetAllCore() ?? Enumerable.Empty<Product>();
            } catch (Exception e)
            {
                //Rewrite exception
                throw new InvalidOperationException("Error reading products.", e);
            };
        }
        
        /// <summary>Removes the product.</summary>
        /// <param name="id">The product to remove.</param>
        public void Remove ( int id )
        {
            //TODO: Check arguments
            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "Id must be greater than zero");
            try
            {
                RemoveCore(id);
            }catch (Exception e)
            {
                // rewrite exception
                throw new InvalidOperationException("Error removing product.", e);
            }
        }
        
        /// <summary>Updates a product.</summary>
        /// <param name="product">The product to update.</param>
        /// <returns>The updated product.</returns>
        public void Update ( int id, Product product )
        {
            //TODO: Check arguments
            if (product == null)
                throw new ArgumentNullException(nameof(Product), "Product is null.");

            //TODO: Validate product
            ObjectValidator.TryValidate(product);

            if (id <= 0)
                throw new ArgumentOutOfRangeException(nameof(id), "ID must be greater than zero");

            try
            {
                var existing = FindProduct(id);
                if (existing == null)
                    throw new ArgumentException("Product not found", nameof(id));

                //Unique name
                var sameName = FindName(product.Name);
                if (sameName != null && sameName.Id != id)
                    throw new InvalidOperationException("Product must be unique");

                UpdateCore(id, product);
            } catch (ArgumentException)
            {
                // Rethrow exception
                throw;
            } catch (InvalidOperationException)
            {
                throw;
            }catch(Exception e)
            {
                // Rewrite exception with original exception as the inner exception
                throw new InvalidOperationException("Error adding product", e);
            };
        }

        #region Protected Members

        protected abstract Product GetCore( int id );

        protected abstract IEnumerable<Product> GetAllCore();

        protected abstract void RemoveCore( int id );

        protected abstract void UpdateCore( int id, Product product );

        protected abstract Product AddCore( Product product );

        protected abstract Product FindProduct ( int id );

        protected abstract Product FindName ( string name );
        #endregion
    }
}
