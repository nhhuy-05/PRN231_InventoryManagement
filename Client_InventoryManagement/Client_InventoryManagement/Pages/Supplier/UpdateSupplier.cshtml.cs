using Client_InventoryManagement.DTO;
using Client_InventoryManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace Client_InventoryManagement.Pages.Supplier
{
    public class UpdateSupplierModel : PageModel
    {
        [BindProperty]
        public SupplierDTO supplierDTO { get; set; }
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
                    SupplierService supplierService = new SupplierService();
                   supplierDTO= supplierService.GetSupplier(id, jwtToken);
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
            SupplierService supplierService = new SupplierService();

            // get token from cookie
            var jwtToken = Request.Cookies["jwtToken"];
            SupplierRequestDTO dto = new SupplierRequestDTO
            {
                SupplierName= supplierDTO.SupplierName,
                Email= supplierDTO.Email,
                Address= supplierDTO.Address,
                Phone= supplierDTO.Phone,
            };
            var response = supplierService.UpdateSupplier(supplierDTO.Id,dto, jwtToken);
            if (response == HttpStatusCode.OK)
            {
                TempData["Message"] = "Update Supplier successfully";
                return RedirectToPage("/Supplier/SupplierList");
            }
            else
            {
                TempData["Message"] = "Update Supplier failed";
                return Page();
            }
        }
    }
}

