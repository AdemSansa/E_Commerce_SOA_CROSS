using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xamarin.Forms;  // Ensure you're using Xamarin.Forms namespace for Application.Current

namespace Ecommerce_frontend.Services
{
    public class AuthService
    {
        private const string BaseUrl = "http://172.20.10.4:8080/api/auth"; // Your Spring Boot API URL

        // Signup method
        public async Task<string> SignupAsync(string email, string password,string username)
        {
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(new
            {
                username = username,
                email = email,
                password = password
            }), Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{BaseUrl}/register", content);

            if (response.IsSuccessStatusCode)
            {
                return "Signup successful!";
            }
            else
            {
                return "Signup failed!";
            }
        }

        // Login method
        public async Task<string> LoginAsync(string email, string password)
        {
            var client = new HttpClient();
            var content = new StringContent(JsonConvert.SerializeObject(new
            {
                email = email,
                password = password
            }), Encoding.UTF8, "application/json");

            var response = await client.PostAsync($"{BaseUrl}/login", content);

            if (response.IsSuccessStatusCode)
            {
                var token = await response.Content.ReadAsStringAsync();
                // Save the token to Application.Current.Properties (or a secure storage option)
                Application.Current.Properties["auth_token"] = token;  // Correct usage of Application.Current
                return token;  // Return the token for further use
            }
            else
            {
                return "Login failed!";
            }
        }

        // Get Auth Token from Application properties
        public string GetAuthToken()
        {
            if (Application.Current.Properties.ContainsKey("auth_token"))
            {
                return Application.Current.Properties["auth_token"].ToString();
            }
            return null;
        }
    }
}
