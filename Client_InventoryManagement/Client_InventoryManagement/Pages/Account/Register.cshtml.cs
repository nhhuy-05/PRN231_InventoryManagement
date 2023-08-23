using Client_InventoryManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace Client_InventoryManagement.Pages.Account
{
    public class RegisterModel : PageModel
    {
        public void OnGet()
        {
        }

        public IActionResult OnPost(string email, string password, string fullname)
        {
            // check if username and password are correct
            if (email != null && password != null && fullname != null)
            {
                AccountService accountService = new AccountService();
                var response = accountService.Register(email, password, fullname);
                if (response == HttpStatusCode.OK)
                {
                    // redirect to home page
                    return RedirectToPage("/Account/Login");
                }
                else
                {
                    TempData["Message"] = "Register Failed!";
                    // redirect to login page
                    return RedirectToPage("/Account/Register");
                }
            }
            else
            {
                TempData["Message"] = "Please fill in all fields!";
                // redirect to login page
                return RedirectToPage("/Account/Register");
            }
        }
    }
}
