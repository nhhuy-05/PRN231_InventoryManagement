using Client_InventoryManagement.DTO;
using Client_InventoryManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace Client_InventoryManagement.Pages.Category
{
    public class UpdateCategoryModel : PageModel
    {
        [BindProperty]
        public CategoryDTO categoryDTO { get; set; }
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
                    CategoryService categoryService = new CategoryService();
                    categoryDTO = categoryService.GetCategory(id, jwtToken);
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
            CategoryService categoryService = new CategoryService();

            // get token from cookie
            var jwtToken = Request.Cookies["jwtToken"];
            CategoryRequestDTO dto = new CategoryRequestDTO
            {
               CategoryName = categoryDTO.CategoryName,
               Description = categoryDTO.Description,
            };
            var response = categoryService.UpdateCategory(categoryDTO.Id, dto, jwtToken);
            if (response == HttpStatusCode.OK)
            {
                TempData["Message"] = "Update Category successfully";
                return RedirectToPage("CategoryList");
            }
            else
            {
                TempData["Message"] = "Update Category failed";
                return Page();
            }
        }
    }
}
