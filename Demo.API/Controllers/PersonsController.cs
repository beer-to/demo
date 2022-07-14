using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Demo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PersonsController : ControllerBase
    {
        // private static IList<string> _names;
        public static IList<string> _names = new List<string>();
        //public static IList<string> _names;
        [HttpGet("{name}")]
        public async Task<IActionResult> Hello(string name)
        {
            //if (string.IsNullOrEmpty(name))
            //{
            //    return BadRequest();
            //}
            //return this.Ok($"Hello {name}");

            if (_names.Contains(name))
            {
                return this.Ok($"Hello {name}");
            }
            return this.NotFound();
        }


        [HttpPost("{name}")]
        public async Task<IActionResult> Create(string name)
        {
            if (_names.Contains(name))
            {
                return this.Ok($"{name} already exists!");
            }
            _names.Add(name);
            return this.Created($"/api/persons/{name}", $"Created {name}");
        }

        [HttpPut]
        public async Task<IActionResult> Update(string oldName, string newName)
        {
            if (_names.Contains(oldName))
            {
                _names.Remove(oldName);
                _names.Add(newName);
                return this.Ok($"{oldName} was renamed to {newName}");
            }
            return this.NotFound();
        }

        [HttpDelete]
        public async Task<IActionResult> Delete(string name)
        {
            if (_names.Contains(name))
            {
                _names.Remove(name);
                return this.Ok($"{name} was removed");
            }
                return this.NotFound();
        }
    }
}
