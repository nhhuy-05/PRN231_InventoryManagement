using Client_InventoryManagement.DTO;
using Client_InventoryManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace Client_InventoryManagement.Pages.InputForm
{
    public class AddInputModel : PageModel
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
                if (claims.ElementAt(0).Value == "STAFF")
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

        public IActionResult OnPost(InputDTO InputDTOForm, string ProductData)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Please fill in all required fields";
                return Page();
            }
            var inputDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<List<InputDetailDTO>>(ProductData);
            var inputDTO = new InputDTO
            {
                SupplierId = InputDTOForm.SupplierId,
                Status = InputDTOForm.Status,
                Note = InputDTOForm.Note
            };
            // get token from cookie
            var jwtToken = Request.Cookies["jwtToken"];
            InputService inputService = new InputService();
            var newInputDTO = inputService.AddInput(inputDTO, jwtToken);
            foreach (var item in inputDetails)
            {
                var inputDetailRequestDTO = new InputDetailRequestDTO
                {
                    InputId = newInputDTO.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    ExpiredDate = item.ExpiredDate,
                    InputPrice = item.InputPrice
                };
                var response = inputService.AddInputDetail(inputDetailRequestDTO, jwtToken);
                if (response == HttpStatusCode.OK)
                {
                    TempData["Message"] = "Add input successfully";
                }
                else
                {
                    TempData["Message"] = "Add input failed";
                    return Page();
                }
            }         
            return RedirectToPage("/InputForm/InputList");
        }
    }
}
