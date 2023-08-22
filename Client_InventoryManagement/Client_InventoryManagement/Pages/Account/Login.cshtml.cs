using Client_InventoryManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client_InventoryManagement.Pages.Account
{
    public class LoginModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public LoginModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }
        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPost(string email, string password)
        {
            AccountService accountService = new AccountService(_httpContextAccessor);
            var response = accountService.GetToken(email, password);
            // check if username and password are correct
            if (response != null)
            {
                // set token in cookie
                Response.Cookies.Append("jwtToken", response.ToString());
                return RedirectToPage("/Index");
            }
            else
            {
                // redirect to login page
                TempData["Message"] = "Login Failed!";
                return RedirectToPage("/Account/Login");
            }
        }
    }
}
