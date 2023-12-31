using Client_InventoryManagement.DTO;
using Client_InventoryManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace Client_InventoryManagement.Pages.Customer
{
    public class UpdateCustomerModel : PageModel
    {
        [BindProperty]
        public CustomerDTO customerDTO { get; set; }
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
                    CustomerService customerService = new CustomerService();
                    customerDTO = customerService.GetCustomer(id, jwtToken);
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
            CustomerService customerService = new CustomerService();

            // get token from cookie
            var jwtToken = Request.Cookies["jwtToken"];
            CustomerRequestDTO dto = new CustomerRequestDTO
            {
                CustomerName = customerDTO.CustomerName,
                Email = customerDTO.Email,
                Address = customerDTO.Address,
                Phone = customerDTO.Phone,
                ContractDate= DateTime.Now,
            };
            var response = customerService.UpdateCustomer(customerDTO.Id, dto, jwtToken);
            if (response == HttpStatusCode.OK)
            {
                TempData["Message"] = "Update Customer successfully";
                return RedirectToPage("/Customer/CustomerList");
            }
            else
            {
                TempData["Message"] = "Update Customer failed";
                return Page();
            }
        }
    }
}
