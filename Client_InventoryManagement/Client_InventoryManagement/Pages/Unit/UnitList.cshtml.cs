using Client_InventoryManagement.DTO;
using Client_InventoryManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;

namespace Client_InventoryManagement.Pages.Unit
{
    public class UnitListModel : PageModel
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
                // get user claims from token
                var token = new JwtSecurityToken(jwtToken);
                var claims = token.Claims;
                // check if user is admin
                if (claims.ElementAt(0).Value == "ADMIN")
                {
                    UnitService unitService = new UnitService();
                    List<UnitDTO> units = unitService.GetAllUnits(jwtToken);
                    ViewData["Units"] = units;
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
