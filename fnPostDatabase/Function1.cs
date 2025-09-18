using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace fnPostDatabase
{
    public class Function1
    {
        private readonly ILogger<Function1> _logger;

        public Function1(ILogger<Function1> logger)
        {
            _logger = logger;
        }

        [Function("movie")]
        [CosmosDBOutput("%DatabaseName%", "%ContainerName%", Connection = "CosmosDBConnection", CreateIfNotExists = true, PartitionKey = "/id")]
        public async Task<object?> Run([HttpTrigger(AuthorizationLevel.Function, "post")] HttpRequest req)
        {
            _logger.LogInformation("Inserindo o registro do filme");

            MovieRequest movie = null;

            var content = await new StreamReader(req.Body).ReadToEndAsync();

            try
            {
                movie = JsonConvert.DeserializeObject<MovieRequest>(content);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Erro ao desserializar o conteúdo da requisição: {ex.Message}");
                return new BadRequestObjectResult("O corpo da requisição não é um JSON válido.");
            }

            return JsonConvert.SerializeObject(movie);
        }
    }
}
