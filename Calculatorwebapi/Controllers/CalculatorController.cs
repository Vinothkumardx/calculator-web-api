using Calculatorwebapi.model;
using Calculatorwebapi.Repository;
using Calculatorwebapi.Service;
using Microsoft.AspNetCore.Mvc;

namespace Calculatorwebapi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CalculatorController : Controller
    {
        private readonly Icalculator calculatorrepo;

        public CalculatorController(Icalculator calculatorrepo)
        {
            this.calculatorrepo = calculatorrepo;
        }

        [HttpPost]
        [Route("Addvalue")]

        public async Task<IActionResult> Addvalue(Calculatormodel calculator)
        {
            try
            {
                var result = await calculatorrepo.Addvalue(calculator);

                return Ok(result);
            }
            catch
            {

                throw;
            }
        }

        [HttpGet]
        [Route("Getcalculatorlist")]
        public async Task<List<Calculatormodel>> Getcalculatorlist()
        {
            try
            {
                return await calculatorrepo.Getcalculatorlist();
            }
            catch
            {
                throw;
            }
        }
        [HttpGet]
        [Route("GetvalueById")]

        public async Task<IEnumerable<Calculatormodel>> Getvaluebyid(int Id)
        {
            try
            {
                return await calculatorrepo.Getvaluebyid(Id);
            }
            catch
            {
                throw;
            }
        }

        [HttpPut]
        [Route("Updatevalue")]

        public async Task<IActionResult> updatevalue(Calculatormodel calculator)
        {
            try
            {
                var re = await calculatorrepo.Updatevalue(calculator);
                return Ok(re);
            }
            catch
            {
                throw;
            }
        }

        [HttpDelete]
        [Route("Deletevalue")]

        public async Task<int> Deletevalue(int Id)
        {
            
            try
            {
                return await calculatorrepo.Deletevalue(Id);
            }
            catch
            {
                throw;
            }
        }
        
    }
}
