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
    public partial class ShowProductPage : ContentPage
    {
        readonly ProductService services;
        public ShowProductPage()
        {
            InitializeComponent();
            services = new ProductService();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            ShowProduct();
        }

        private void ShowProduct()
        {
            var products = services.GetList().Result;
            listData.ItemsSource = products;
        }

        private void btnAddProduct_Clicked(object sender , EventArgs e)
        {
            this.Navigation.PushAsync(new AddProduct());
        }


        private async void listData_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            if(e.SelectedItem != null)
            {
                Product product = (Product)e.SelectedItem;
                string action = await DisplayActionSheet("Actions", "Cancel", null, "Update", "Remove");

                switch (action)
                {
                    case "Update":
                        await this.Navigation.PushAsync(new AddProduct(product));
                        break;
                    case "Remove":
                        services.DeleteProduct(product);
                        ShowProduct();
                        break;
                }
                listData.SelectedItem = null;
            }

        }
    }
}