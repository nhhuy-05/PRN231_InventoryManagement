using Client_InventoryManagement.DTO;
using Client_InventoryManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace Client_InventoryManagement.Pages.Product
{
    public class AddProductModel : PageModel
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
                    CategoryService categoryService = new CategoryService();
                    var cartegories = categoryService.GetCategories(jwtToken);

                    UnitService unitService= new UnitService();
                    var units = unitService.GetAllUnits(jwtToken);

                    SupplierService supplierService = new SupplierService();
                    var suppliers = supplierService.GetAllSuppliers(jwtToken);
                    ViewData["Suppliers"] = suppliers;
                    ViewData["Units"] = units;
                    ViewData["Categories"] = cartegories;
                    return Page();
                }
                else
                {
                    // response a message
                    return RedirectToPage("/Error404");
                }
            }
        }


        public async Task<IActionResult> OnPost(ProductRequestDTO dto)
        {

            if (dto == null)
            {
                TempData["Message"] = "Please fill the data!";
                return Page();
            }
            else
            {
                ProductService productService = new ProductService();

                // get token from cookie
                var jwtToken = Request.Cookies["jwtToken"];
                var response = productService.AddProduct(dto, jwtToken);
                if (response == HttpStatusCode.OK)
                {
                    TempData["Message"] = "Add product successfully";
                    return RedirectToPage("ProductList");
                }
                else
                {
                    TempData["Message"] = "Add prouduct failed";
                    return Page();
                }

            }
        }
    }
}
