using Client_InventoryManagement.DTO;
using Client_InventoryManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace Client_InventoryManagement.Pages.Unit
{
    public class UpdateUnitModel : PageModel
    {
        [BindProperty]
        public UnitDTO unitDTO { get; set; }
        public async Task<IActionResult> OnGet(int id)
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
                    unitDTO = unitService.UnitDTOGetUnitById(id, jwtToken);
                    //ViewData["Unit"] = unit;
                    return Page();
                }
                else
                {
                    // response a message
                    return RedirectToPage("/Error404");
                }
            }
        }
        public async Task<IActionResult> OnPost()
        {
            UnitService unitService = new UnitService();
            
            // get token from cookie
            var jwtToken = Request.Cookies["jwtToken"];
            var response = unitService.UpdateUnit(unitDTO, jwtToken);
            if (response == HttpStatusCode.OK)
            {
                TempData["Message"] = "Update unit successfully";
                return RedirectToPage("/Unit/UnitList");
            }
            else
            {
                TempData["Message"] = "Update Unit failed";
                return Page();
            }
        }
    }
}
