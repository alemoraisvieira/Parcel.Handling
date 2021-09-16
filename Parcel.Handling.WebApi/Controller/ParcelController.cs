using Microsoft.AspNetCore.Mvc;
using Parcel.Handling.Application.common;
using Parcel.Handling.Application.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

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
            var parcelList = await _parcelService.GetParcels();
            return Ok(parcelList);
        }

        [HttpPost]
        [Route("new-parcel")]
        public async Task<IActionResult> Addparcel()
        {
            //XDocument document = XDocument.Load("C:\\ParcelDelivery\\Data\\Container_68465468.xml");

            //if (document == null)
            //    return NoContent();

            await _parcelService.AddParcel();
            return Ok();
        }
    }
}
