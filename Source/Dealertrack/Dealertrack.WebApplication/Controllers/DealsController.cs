using System.IO;
using Dealertrack.Domain.Service.Core;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Dealertrack.WebApi.Models.Mappers;
using System.Text;

namespace DealerTrack.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DealsController : ControllerBase
    {
        private IHostingEnvironment _hostingEnvironment;
        private readonly IDealsService _dealsService;

        public DealsController(IHostingEnvironment hostingEnvironment, IDealsService dealsService)
        {
            _hostingEnvironment = hostingEnvironment;
            _dealsService = dealsService;
        }
        // GET: api/Deals
        [HttpGet]
        public JsonResult  Get()
        {
            var deals = _dealsService.GetDealData();
            return new JsonResult(deals);
             
        }
        // GET: api/Deals/VehicleSales
        [Route("vehiclesales")]
        [HttpGet]
        public JsonResult GetVehicleSales()
        {
            var deals = _dealsService.GetVehicleSalesByUnit(true);
            return new JsonResult(deals);
        }
        [HttpPost, DisableRequestSizeLimit]
        public ActionResult UploadFile()
        {
            try
            {
                var file = Request.Form.Files[0];
                if (file.Length > 0)
                {
                   var streamReader = new StreamReader(file.OpenReadStream(), Encoding.GetEncoding("iso-8859-1"));
                   var fileConent = streamReader.ReadToEnd();
                    var deals = DealMapper.ToDealList(fileConent);
                    _dealsService.SaveDealData(deals);
                }

                return new JsonResult("Upload Successful.");
            }
            catch (System.Exception ex)
            {
                return new JsonResult ("Upload Failed: " + ex.Message);
            }
        }
    }

}

