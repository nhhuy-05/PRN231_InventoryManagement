using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;

namespace Client_InventoryManagement.Pages.OutputForm
{
    public class OutputDetailModel : PageModel
    {
        public async Task<IActionResult> OnGet(string OutputId)
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
                // get user claims from token
                var token = new JwtSecurityToken(jwtToken);
                var claims = token.Claims;
                // check if user is admin
                if (claims.ElementAt(0).Value == "ADMIN" || claims.ElementAt(0).Value == "STAFF")
                {
                    ViewData["OutputId"] = OutputId;
                    return Page();
                }
                else
                {
                    // response a message
                    return RedirectToPage("/Error404");
                }
            }
        }
    }
}
