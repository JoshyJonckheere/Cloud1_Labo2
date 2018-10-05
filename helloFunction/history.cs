
using System.IO;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Azure.WebJobs.Host;
using Newtonsoft.Json;
using System.Diagnostics.Contracts;

namespace helloFunction {
    public static class history {
        [FunctionName("history")]
        public static IActionResult Run([HttpTrigger(AuthorizationLevel.Anonymous, "get", "post", Route = null)]HttpRequest req, TraceWriter log) {
            Contract.Ensures(Contract.Result<IActionResult>() != null);
            string from = string.Empty;
            string to = string.Empty;

            foreach (var key in req.Query.Keys) {
                if (key == "from"){
                    from = req.Query["from"];
                }

                if (key == "to"){
                    to = req.Query["to"];
                }
            }
            return new OkObjectResult($"from {from} to {to}");

        }
    }
}
