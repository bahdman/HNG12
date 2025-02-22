using System.Diagnostics;
using System.Net;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using src.Models;
using src.Repository.Interface;

namespace src.TaskController
{
    [Route("/")]
    [ApiController]
    public class TaskController : ControllerBase{
        private readonly ITelex _telex;
        public TaskController(ITelex telex)
        {
            _telex = telex;
        }        

        [HttpGet]
        public async Task<ActionResult> Bing()
        {
            var response = await _telex.GetToken();
            return Ok($"api is active!, Token - { response}");
        }

        [HttpGet("integration.json")]
        public ActionResult GetIntegration()
        {
            var configSettings = _telex.GetTelexConfiguration();
            return Ok(configSettings);
        }

        [HttpGet("GetLatestBarrz")]
        public async Task<ActionResult> GetLatestBarrz()
        {
            var response = await _telex.TelexReport();
            return Ok(response);            
        }

        [HttpPost("/tick")]
        public async Task<ActionResult> BingTelex()
        {
            var response = await _telex.BingTelex();
            return Ok(response);
        }
    }
}