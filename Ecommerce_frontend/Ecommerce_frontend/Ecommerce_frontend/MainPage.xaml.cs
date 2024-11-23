using Ecommerce_frontend.Model;
using Ecommerce_frontend.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace Ecommerce_frontend
{
    public partial class MainPage : ContentPage
    {
        private ProductService productService = new ProductService();

        public MainPage()
        {
            InitializeComponent();
            LoadProducts();
        }

        private async void LoadProducts()
        {
            var products = await productService.GetProductsAsync();
            ProductsListView.ItemsSource = products;
        }

        private async void AddToCart_Clicked(object sender, EventArgs e)
        {
            var button = sender as Button;
            var product = button.BindingContext as Product;

            if (product != null)
            {
                // Check if there is an existing cart
                if (!Application.Current.Properties.ContainsKey("cart"))
                {
                    Application.Current.Properties["cart"] = new List<Product>(); // Create new cart
                }

                var cart = Application.Current.Properties["cart"] as List<Product>;

                if (!cart.Contains(product))
                {
                    cart.Add(product);  // Add product to cart
                    await DisplayAlert("Success", $"{product.Name} has been added to your cart!", "OK");
                }
                else
                {
                    await DisplayAlert("Info", $"{product.Name} is already in your cart.", "OK");
                }
            }
        }
        private async void OpenCart_Clicked(object sender, EventArgs e)
        {
            var cart = Application.Current.Properties.ContainsKey("cart")
                        ? Application.Current.Properties["cart"] as List<Product>
                        : new List<Product>();

            if (cart.Count > 0)
            {
                var cartSummary = string.Join("\n", cart.Select(p => $"{p.Name} - ${p.Price:F2}"));
                await DisplayAlert("Cart", cartSummary, "OK");
            }
            else
            {
                await DisplayAlert("Cart", "Your cart is empty.", "OK");
            }
        }

    }
}
