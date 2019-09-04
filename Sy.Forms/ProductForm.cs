using Sy.Business.Repository;
using Sy.Core.Abstracts;
using Sy.Core.Entities;
using Sy.Core.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sy.Forms
{
    public partial class ProductForm : Form
    {
        private readonly IRepository<Product, Guid> _prpoductRepo;
        public ProductForm()
        {
            InitializeComponent();
            _prpoductRepo = new Repository<Product, Guid>();
            ListeyiDoldur();
        }

        private void ListeyiDoldur(string search = "")
        {
            var data = _prpoductRepo.Query(x => x.ProductName.Contains(search)).Select(x => new ProductViewModel()
            {
                Id = x.Id,
                UnitPrice = x.UnitPrice,
                CriticStock = x.CriticStock,
                ProductName = x.ProductName
            }) .ToList();
                            
            lstÜrünler.DataSource = data;
            lstÜrünler.DisplayMember = "Display";
        }

        private void btnkaydet_Click(object sender, EventArgs e)
        {
            try
            {
                _prpoductRepo.Insert(new Product()
                {
                    ProductName = txturunad.Text,
                    UnitPrice = nudFiyat.Value,
                    CriticStock = Convert.ToInt32(nudStok.Value)

                });
                MessageBox.Show("Ürün ekleme işlemi başarılıdır.");
                ListeyiDoldur();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.Message);
            }
        }

        private void txtara_KeyUp(object sender, KeyEventArgs e)
        {
            ListeyiDoldur(txtara.Text);
        }
    }
}
