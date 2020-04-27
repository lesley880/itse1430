/*
 * Lesley Reller
 * ITSE 1430
 * 04/14/2020
 */
using System;
using System.Windows.Forms;
using System.Configuration;
using System.Data;
using Nile.Stores;
using Nile;

namespace Nile.Windows
{
    public partial class MainForm : Form
    {
        #region Construction

        public MainForm()
        {
            InitializeComponent();
        }
        #endregion

        protected override void OnLoad( EventArgs e )
        {
            base.OnLoad(e);

            var connString = ConfigurationManager.ConnectionStrings["MovieDatabase"];
            _gridProducts.AutoGenerateColumns = false;

            UpdateList();
        }

        #region Event Handlers
        
        private void OnFileExit( object sender, EventArgs e )
        {
            Close();
        }

        private void OnProductAdd( object sender, EventArgs e )
        {
            ProductDetailForm child = new ProductDetailForm();

            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;
                try
                {
                    var product = _database.Add(child.Product);

                        UpdateList();
                        return;
                    
                } catch (Exception ex)
                {
                    DisplayError(ex.Message);
                };
            } while (true);
        }

        private void OnProductEdit( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
                return;

            var child = new ProductDetailForm();
            child.Product = product;
            do
            {
                if (child.ShowDialog(this) != DialogResult.OK)
                    return;

                // Save
                try
                {
                    _products.Update(product.Id, child.Product);
                    UpdateList();
                    return;
                } catch (Exception ex)
                {
                    DisplayError(ex.Message);
                };
            } while (true);
        }        

        private void OnProductDelete( object sender, EventArgs e )
        {
            var product = GetSelectedProduct();
            if (product == null)
                return;

            DeleteProduct(product);
        }        
                
        private void OnEditRow( object sender, DataGridViewCellEventArgs e )
        {
            var grid = sender as DataGridView;

            //Handle column clicks
            if (e.RowIndex < 0)
                return;

            var row = grid.Rows[e.RowIndex];
            var item = row.DataBoundItem as Product;

            if (item != null)
                EditProduct(item);
        }

        private void OnKeyDownGrid( object sender, KeyEventArgs e )
        {
            if (e.KeyCode != Keys.Delete)
                return;

            var product = GetSelectedProduct();
            if (product != null)
                DeleteProduct(product);
			
			//Don't continue with key
            e.SuppressKeyPress = true;
        }

        #endregion

        #region Private Members

        private void DeleteProduct ( Product product )
        {
            //Confirm
            if (MessageBox.Show(this, $"Are you sure you want to delete '{product.Name}'?",
                                "Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;
            //Delete product
            _database.Remove(product.Id);
            UpdateList();
        }

        private void EditProduct ( Product product )
        {
            var child = new ProductDetailForm("Product Details");
            child.Product = product;
            if (child.ShowDialog(this) != DialogResult.OK)
                return;

            //Save product
            _database.Update(product.Id, child.Product);
            UpdateList();
        }

        private Product GetSelectedProduct ()
        {
            if (_gridProducts.SelectedRows.Count > 0)
                return _gridProducts.SelectedRows[0].DataBoundItem as Product;

            return null;
        }

        private void UpdateList ()
        {
            _bsProducts.DataSource = _database.GetAll();
        }
        #endregion

        private void HelpAbout ( object sender, EventArgs e )
        {
            var aboutBox = new AboutBox();
            aboutBox.Show();
        }

        private void DisplayError ( string message )
        {
            MessageBox.Show(message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private readonly IProductDatabase _database = new Nile.Stores.MemoryProductDatabase();
        private IProductDatabase _products;
    }
}
