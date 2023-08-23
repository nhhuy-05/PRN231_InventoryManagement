using Client_InventoryManagement.DTO;
using System.Net;

namespace Client_InventoryManagement.Services
{
    public class UnitService : BaseService
    {
        public UnitService() { }


        public List<UnitDTO> GetAllUnits(string jwtToken)
        {
            var response = GetData<List<UnitDTO>>("Unit", jwtToken).Result;
            return response;
        }

        public HttpStatusCode AddUnit(UnitRequestDTO unit, string jwtToken)
        {
            var response = PushData<UnitRequestDTO>("Unit", unit, jwtToken).Result;
            return response;
        }

        public HttpStatusCode UpdateUnit(UnitDTO unit, string jwtToken)
        {
            var response = PutData<UnitDTO>("Unit", unit, jwtToken).Result;
            return response;
        }
    }
}
