using Client_InventoryManagement.DTO;
using Client_InventoryManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace Client_InventoryManagement.Pages.Unit
{
    public class AddUnitModel : PageModel
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
                    return Page();
                }
                else
                {
                    // response a message
                    return RedirectToPage("/Error404");
                }
            }
        }


        public async Task<IActionResult> OnPost(string unitName)
        {

            if (unitName == null)
            {
                TempData["Message"] = "Please fill the data!";
                return Page();
            }
            else
            {
                UnitService unitService = new UnitService();
                var unitRequestDTO = new UnitRequestDTO
                {
                    UnitName = unitName,
                };
                // get token from cookie
                var jwtToken = Request.Cookies["jwtToken"];
                var response = unitService.AddUnit(unitRequestDTO, jwtToken);
                if (response == HttpStatusCode.OK)
                {
                    TempData["Message"] = "Add unit successfully";
                    return RedirectToPage("/Unit/UnitList");
                }
                else
                {
                    TempData["Message"] = "Add Unit failed";
                    return Page();
                }
            }
        }
    }
}
