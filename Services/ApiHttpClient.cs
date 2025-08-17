using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using DesktopPsychologist_WF.Models;

namespace DesktopPsychologist_WF.Services
{
    public interface IHttpClient
    {
        Task<User> CheckUserByLoginAsync(string login);
        Task<Uri> CreateUserAsync(User newUser);

        Task<List<Theme>> GetThemesAsync();
        Task<Theme> GetThemeAsync(int id);
        Task<Uri> CreateThemeAsync(Theme newTheme);
        Task<Theme> UpdateThemeAsync(int id, Theme theme);
        Task<HttpStatusCode> DeleteThemeAsync(int id);

        Task<List<Review>> GetReviewsAsync();
        Task<Review> GetReviewAsync(int id);
        Task<Uri> CreateReviewAsync(Review newReview);
        Task<Review> UpdateReviewAsync(int id, Review review);
        Task<HttpStatusCode> DeleteReviewAsync(int id);

    }
    internal class ApiHttpClient : IHttpClient
    {

        private HttpClient client;

        public ApiHttpClient()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri("http://localhost:5180/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new MediaTypeWithQualityHeaderValue("application/json"));
        }


        // ================================== ПОЛЬЗОВАТЕЛИ =========================================

        public async Task<User> CheckUserByLoginAsync(string login)
        {
            User user = null;
            using (HttpResponseMessage response = await client.GetAsync($"users/by-login?login={login}").ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                {
                    user = await response.Content.ReadAsAsync<User>();
                }
                return user;
            }            
        }

        public async Task<Uri> CreateUserAsync(User newUser)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("users/", newUser);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }


        // ================================== УСЛУГИ =========================================

        public async Task<Uri> CreateThemeAsync(Theme newTheme)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("themes/", newTheme);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public async Task<HttpStatusCode> DeleteThemeAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"themes/{id}");
            return response.StatusCode;
        }

        public async Task<Theme> GetThemeAsync(int id)
        {
            Theme theme = null;
            using (HttpResponseMessage response = await client.GetAsync($"themes/{id}").ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                {
                    theme = await response.Content.ReadAsAsync<Theme>();
                }
                return theme;
            }
        }

        public async Task<List<Theme>> GetThemesAsync()
        {
            List<Theme> themes = null;
            using (HttpResponseMessage response = await client.GetAsync($"themes/").ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                {
                    themes = await response.Content.ReadAsAsync<List<Theme>>();
                }
                return themes;
            }
        }

        public async Task<Theme> UpdateThemeAsync(int id, Theme theme)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"themes/{id}", theme);
            response.EnsureSuccessStatusCode();

            theme = await response.Content.ReadAsAsync<Theme>();
            return theme;
        }



        // ================================== ОТЗЫВЫ =========================================

        public async Task<Uri> CreateReviewAsync(Review newReview)
        {
            HttpResponseMessage response = await client.PostAsJsonAsync("reviews/", newReview);
            response.EnsureSuccessStatusCode();
            return response.Headers.Location;
        }

        public async Task<HttpStatusCode> DeleteReviewAsync(int id)
        {
            HttpResponseMessage response = await client.DeleteAsync($"reviews/{id}");
            return response.StatusCode;
        }

        public async Task<Review> GetReviewAsync(int id)
        {
            Review review = null;
            using (HttpResponseMessage response = await client.GetAsync($"reviews/{id}").ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                {
                    review = await response.Content.ReadAsAsync<Review>();
                }
                return review;
            }
        }
        public async Task<List<Review>> GetReviewsAsync()
        {
            List<Review> reviews = null;
            using (HttpResponseMessage response = await client.GetAsync($"reviews/").ConfigureAwait(false))
            {
                if (response.IsSuccessStatusCode)
                {
                    reviews = await response.Content.ReadAsAsync<List<Review>>();
                }
                return reviews;
            }
        }

        public async Task<Review> UpdateReviewAsync(int id, Review review)
        {
            HttpResponseMessage response = await client.PutAsJsonAsync($"reviews/{id}", review);
            response.EnsureSuccessStatusCode();

            review = await response.Content.ReadAsAsync<Review>();
            return review;
        }


    }
}
