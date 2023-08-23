using Client_InventoryManagement.DTO;
using Client_InventoryManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace Client_InventoryManagement.Pages.Category
{
    public class AddCategoryModel : PageModel
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AddCategoryModel(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

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

        public async Task<IActionResult> OnPost(string categoryName, string description)
        {
            if (categoryName == null || description == null)
            {
                TempData["Message"] = "Please fill the data!";
                return Page();
            }
            else
            {
                CategoryService categoryService = new CategoryService(_httpContextAccessor);
                var categoryRequestDTO = new CategoryRequestDTO
                {
                    CategoryName = categoryName,
                    Description = description
                };
                var response = categoryService.AddCategory(categoryRequestDTO);
                if (response == HttpStatusCode.OK)
                {
                    TempData["Message"] = "Add category successfully";
                    return RedirectToPage("/Category/CategoryList");
                }
                else
                {
                    TempData["Message"] = "Add category failed";
                    return Page();
                }
            }
        }


    }
}
