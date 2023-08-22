using Client_InventoryManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Net;

namespace Client_InventoryManagement.Pages.Account
{
    public class LogoutModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LogoutModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public IActionResult OnGet()
        {
            var response = new AccountService(_httpContextAccessor).Logout();
            if (response == HttpStatusCode.OK)
            {
                Response.Cookies.Delete("jwtToken");
                return RedirectToPage("/Index");
            }
            else
            {
                return RedirectToPage("/Account/Login");
            }
        }
    }
}
