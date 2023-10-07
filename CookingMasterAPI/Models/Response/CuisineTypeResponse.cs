using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CookingMasterAPI.Models.Response
{
    public record CuisineTypeResponse
    (
         int CuisineId,
         string CuisineName,
         string Uid
    );
}
