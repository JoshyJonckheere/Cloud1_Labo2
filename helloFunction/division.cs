
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;

namespace helloFunction {
    public static class division {
        [FunctionName("division")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = "divide/{baseNum}/{dividerNum}")]HttpRequest req, int baseNum, int dividerNum, TraceWriter log) {
            try {
                if (dividerNum == 0){
                    return new BadRequestResult();
                }
                return new OkObjectResult($"{baseNum} divided by {dividerNum} equals {baseNum / dividerNum}");
            } catch (System.Exception ex) {
                log.Error($"An error has occured on server level {ex.ToString()}");
                return new StatusCodeResult(500);
            }
        }
    }
}
