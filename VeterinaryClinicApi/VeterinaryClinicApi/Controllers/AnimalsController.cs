using Microsoft.AspNetCore.Mvc;
using VeterinaryClinicApi.Models;
using VeterinaryClinicApi.Data;
using System.Linq;

namespace VeterinaryClinicApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AnimalsController : ControllerBase
    {
        [HttpGet]
        public IActionResult GetAnimals()
        {
            return Ok(ClinicDatabase.Animals);
        }

        [HttpGet("{id}")]
        public IActionResult GetAnimal(int id)
        {
            var animal = ClinicDatabase.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
                return NotFound();

            return Ok(animal);
        }

        [HttpPost]
        public IActionResult CreateAnimal([FromBody] Animal animal)
        {
            animal.Id = ClinicDatabase.Animals.Any() ? ClinicDatabase.Animals.Max(a => a.Id) + 1 : 1;
            ClinicDatabase.Animals.Add(animal);
            return CreatedAtAction(nameof(GetAnimal), new { id = animal.Id }, animal);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateAnimal(int id, [FromBody] Animal updatedAnimal)
        {
            var animal = ClinicDatabase.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
                return NotFound();

            animal.Name = updatedAnimal.Name;
            animal.Category = updatedAnimal.Category;
            animal.Weight = updatedAnimal.Weight;
            animal.FurColor = updatedAnimal.FurColor;
            return Ok(animal);
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteAnimal(int id)
        {
            var animal = ClinicDatabase.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
                return NotFound();

            ClinicDatabase.Animals.Remove(animal);
            return NoContent();
        }

        [HttpGet("{id}/visits")]
        public IActionResult GetVisits(int id)
        {
            var animal = ClinicDatabase.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
                return NotFound();

            return Ok(animal.Visits);
        }

        [HttpPost("{id}/visits")]
        public IActionResult CreateVisit(int id, [FromBody] Visit visit)
        {
            var animal = ClinicDatabase.Animals.FirstOrDefault(a => a.Id == id);
            if (animal == null)
                return NotFound();

            visit.Id = animal.Visits.Any() ? animal.Visits.Max(v => v.Id) + 1 : 1;
            animal.Visits.Add(visit);
            return CreatedAtAction(nameof(GetVisits), new { id = animal.Id }, visit);
        }
    }
}
