using Client_InventoryManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace Client_InventoryManagement.Pages.Account
{
    public class LogoutModel : PageModel
    {
        public IActionResult OnGet()
        {
            // get token from cookie
            var jwtToken = Request.Cookies["jwtToken"];
            var response = new AccountService().Logout(jwtToken);
            if (response == HttpStatusCode.OK)
            {
                Response.Cookies.Delete("jwtToken");
                return RedirectToPage("/Account/Login");
            }
            else
            {
                return RedirectToPage("/Index");
            }
        }
    }
}
