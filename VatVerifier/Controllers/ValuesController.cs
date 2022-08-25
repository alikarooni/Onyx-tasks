using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace VatVerifier.Controllers
{
    [ApiController]
    public class VatVerifierController : ControllerBase
    {
        [HttpGet]
        [Route("api/Verify")]
        public async Task<ActionResult> Verify(string Countrycode, string vatNumber)
        {
            Onyx.VatVerifier varVerifier = new Onyx.VatVerifier();
            var verifyResult = await varVerifier.VatVerification(Countrycode, vatNumber);

            return new JsonResult(new { result = Enum.GetName(verifyResult) });
        }
    }
}
