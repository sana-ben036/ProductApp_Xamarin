using ProductApp.Model;
using ProductApp.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ProductApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class AddProduct : ContentPage
    {
        ProductService services;
        bool IsUpdate;
        int productId;
         
        public AddProduct()
        {
            InitializeComponent();
            services = new ProductService();
            IsUpdate = false;
        }
        public AddProduct(Product model )
        {
            InitializeComponent();
            services = new ProductService();
            if(model != null)
            {
                productId = model.Id;
                txtName.Text = model.Name;
                txtDescription.Text = model.Description;
                txtPrice.Text = model.Price.ToString();
                IsUpdate = true;

            }
        }

        private void btnSaveUpdate_Clicked(object sender, EventArgs e)
        {
            Product model = new Product();
            model.Name = txtName.Text;
            model.Description = txtDescription.Text;
            model.Price = double.Parse( txtPrice.Text);

            if (IsUpdate)
            {
                model.Id = productId;
                services.UpdateProduct(model);
            }
            else
            {
                services.CreateProduct(model);
            }
            this.Navigation.PopAsync();
        }


       
    }
}