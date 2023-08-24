using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Client_InventoryManagement.Pages.Account
{
    public class ProfileModel : PageModel
    {
        public async Task<IActionResult> OnGet()
        {
            // get token from cookie
            var jwtToken = Request.Cookies["jwtToken"];
            // check if token is null or empty
            if (string.IsNullOrEmpty(jwtToken))
            {
                // redirect to login page
                return RedirectToPage("/Account/Login");
            }
            else
            {
                return Page();
            }
        }
    }
}
