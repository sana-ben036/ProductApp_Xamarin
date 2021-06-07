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
            var list = services.GetList().Result;
            listData.ItemsSource = list;
        }

        private void btnAddProduct_Clicked(object sender, EventArgs e)
        {
            this.Navigation.PushAsync(new AddProduct());
        }
    }
}