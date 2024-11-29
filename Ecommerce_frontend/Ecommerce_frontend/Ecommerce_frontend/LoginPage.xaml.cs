using Ecommerce_frontend.Services;
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

    public partial class LoginPage : ContentPage
    {
        private readonly AuthService _authService;

        public LoginPage()
        {
            InitializeComponent();
            _authService = new AuthService(); // Initialize AuthService
        }

        private async void OnLoginClicked(object sender, EventArgs e)
        {
            string Email= UsernameEntry.Text;
            string password = PasswordEntry.Text;

            if (string.IsNullOrEmpty(Email) || string.IsNullOrEmpty(password))
            {
                ResultLabel.Text = "Please fill in both fields!";
                return;
            }

            var token = await _authService.LoginAsync(Email, password);
            if (string.IsNullOrEmpty(token) || token == "Login failed!")
            {
                ResultLabel.Text = "Login failed!";
            }
            else
            {
                ResultLabel.Text = $"Login successful! Token: {token}";
                Navigation.PushAsync(new MainPage());
                // You can store the token securely for further use, e.g., using Xamarin Preferences
            }
        }
        private async void OnNavigateToSignupClicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new SignUpPage());  // Navigating to SignupPage
        }

    }
}