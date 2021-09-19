using Microsoft.AspNetCore.Mvc;
using Parcel.Handling.Application.common;
using System.Threading.Tasks;

namespace Parcel.Handling.WebApi.Controller
{

    [Route("api/v1/parcel")]
    [ApiController]
    public class ParcelController : ControllerBase
    {
        private readonly IParcelService _parcelService;


        public ParcelController(IParcelService parcelService) =>
            (_parcelService) = (parcelService);


        [HttpGet]
        public async Task<IActionResult> GetParcel()
        {
            var result = await _parcelService.GetParcels();
            if (result.Count == 0)
                return NoContent();
            
            return Ok(result);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetParcelById([FromRoute] int id)
        {
            var result = await _parcelService.GetParcelById(id);
            if (result.Count == 0)
                return NoContent();

            return Ok(result);
        }

        [HttpPost]
        [Route("new-parcel")]
        public async Task<IActionResult> Addparcel()
        {
            await _parcelService.AddParcel();
            return Created("created new parcel","") ;
        }
    }
}
