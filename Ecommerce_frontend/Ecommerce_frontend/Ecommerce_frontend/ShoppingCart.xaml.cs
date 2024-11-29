using Ecommerce_frontend.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Ecommerce_frontend
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ShoppingCart : ContentPage
    {
        private List<Product> Cart;

        public ShoppingCart()
        {
            InitializeComponent();
            LoadCart();
        }


        private void LoadCart()
        {
            // Load the cart from Application.Current.Properties
            Cart = Application.Current.Properties.ContainsKey("cart")
                    ? Application.Current.Properties["cart"] as List<Product>
                    : new List<Product>();

            // Bind cart to the CollectionView
            CartCollectionView.ItemsSource = Cart;
            TotalPriceLabel.Text = $"Total: ${Cart.Sum(p => p.Price):F2}";

        }

        private async void RemoveFromCart_Clicked(object sender, EventArgs e)
        {
            // Get the product to remove
            var button = sender as Button;
            var product = button.BindingContext as Product;

            if (product != null)
            {
                // Remove from cart
                Cart.Remove(product);

                // Update Application.Current.Properties
                Application.Current.Properties["cart"] = Cart;

                // Refresh the CollectionView
                CartCollectionView.ItemsSource = null;
                CartCollectionView.ItemsSource = Cart;

                await DisplayAlert("Removed", $"{product.Name} has been removed from your cart.", "OK");
            }
        }
        private void IncrementQuantity_Clicked(object sender, EventArgs e)
        {
            // Get the button and product
            var button = sender as Button;
            var product = button.BindingContext as Product;

            if (product != null)
            {
                // Increment the product's quantity
                product.Qte++;

                // Update the CollectionView
                CartCollectionView.ItemsSource = null;
                CartCollectionView.ItemsSource = Cart;

                // Update the total price (if added in the UI)
                UpdateTotalPrice();
            }

          
        }

       




        private void UpdateTotalPrice()
        {
            var total = Cart.Sum(p => p.Price * p.Qte);
            TotalPriceLabel.Text = $"Total: ${total:F2}";
        }

    }
}