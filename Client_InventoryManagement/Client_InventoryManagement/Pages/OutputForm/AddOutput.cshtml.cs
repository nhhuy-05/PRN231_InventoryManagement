using Client_InventoryManagement.DTO;
using Client_InventoryManagement.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IdentityModel.Tokens.Jwt;
using System.Net;

namespace Client_InventoryManagement.Pages.OutputForm
{
    public class AddOutputModel : PageModel
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

        public IActionResult OnPost(OutputDTO OutputDTOForm, string ProductData)
        {
            if (!ModelState.IsValid)
            {
                TempData["Message"] = "Please fill in all required fields";
                return Page();
            }
            var outputDetails = Newtonsoft.Json.JsonConvert.DeserializeObject<List<OutputDetailDTO>>(ProductData);
            var outputDTO = new OutputDTO
            {
                CustomerId = OutputDTOForm.CustomerId,
                Status = OutputDTOForm.Status,
                Note = OutputDTOForm.Note
            };
            // get token from cookie
            var jwtToken = Request.Cookies["jwtToken"];
            OutputService outputService = new OutputService();
            var newOutputDTO = outputService.AddOutput(outputDTO, jwtToken);
            foreach (var item in outputDetails)
            {
                var outputDetailRequestDTO = new OutputDetailRequestDTO
                {
                    OutputId = newOutputDTO.Id,
                    ProductId = item.ProductId,
                    Quantity = item.Quantity,
                    OutputPrice = item.OutputPrice,
                    InputId = item.InputId
                };
                var response = outputService.AddOutputDetail(outputDetailRequestDTO, jwtToken);
                if (response == HttpStatusCode.OK)
                {
                    TempData["Message"] = "Add output successfully";
                }
                else
                {
                    TempData["Message"] = "Add output failed";
                    return Page();
                }
            }
            return RedirectToPage("/OutputForm/OutputList");
        }
    }
}
