using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using SchoolManagementApp.Models;
using System.Text;
using System.Security.Cryptography.X509Certificates;
using System.Runtime.InteropServices;
namespace SchoolManagementApp.Controllers
{
    public class UserController : Controller
    {


        private readonly HttpClient _client;
        private readonly string _apiUrl = "https://localhost:7151/api/User";
        public UserController()
        {
            _client = new HttpClient();
        }


        //getting user 
        public async Task<IActionResult> Index()
        {
            var response = await _client.GetAsync(_apiUrl);
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
               var users = JsonSerializer.Deserialize<List<User>>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

                return View(users);
            }
            return View(new List<User>());
        }

        //Get: User/Create

        public IActionResult Create() => View();


        //POST: User/Create
        [HttpPost]
        public async Task<IActionResult> Create(User user)
        {
            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync(_apiUrl, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return View(user);
        }



        //get: user/edit/id
        public async Task<IActionResult> Edit(int id)
        {
            var response = await _client.GetAsync($"{_apiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var user = JsonSerializer.Deserialize<User>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return View(user);
            }
            return RedirectToAction("Index");
        }


        //post: user/edit/id
        [HttpPost]
        public async Task<IActionResult> Edit(int id, User user)
        {
            var json = JsonSerializer.Serialize(user);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PutAsync($"{_apiUrl}/{id}", content);
            if (response.IsSuccessStatusCode) {
                return RedirectToAction("Index");
            }
            return View(user);
        }

        //GET: User/Delete/id
        public async Task<IActionResult> Delete(int id)
        {
            var response = await _client.GetAsync($"{_apiUrl}/{id}");
            if (response.IsSuccessStatusCode)
            {
                var json = await response.Content.ReadAsStringAsync();
                var user = JsonSerializer.Deserialize<User>(json, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });
                return View(user);
            }
            return RedirectToAction("Index");

        }

        //Post: User/DeleteConfirmed/5
        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var response = await _client.DeleteAsync($"{_apiUrl}/{id}");
            return RedirectToAction("Index");
        }

    }
}
