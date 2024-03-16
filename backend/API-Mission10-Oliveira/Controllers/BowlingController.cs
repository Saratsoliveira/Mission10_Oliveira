using API_Mission10_Oliveira.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_Mission10_Oliveira.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BowlingController : ControllerBase
    {
        private IBowlingRepository _bowlerRepository;

        public BowlingController(IBowlingRepository temp)
        {
            _bowlerRepository = temp;
        }

    // had to add the tag so I would be able to get rid of an error
        [HttpGet]
        public IEnumerable<Bowler> Get()
        {
            //Get data method 
            var bowlersWithTeams = _bowlerRepository.GetBowlersWithTeams(["Marlins", "Sharks"]);

            return bowlersWithTeams;
        }


    }
}
