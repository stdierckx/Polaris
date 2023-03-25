using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polaris.Api.DataLayer;
using Polaris.Api.Models;

namespace Polaris.Api.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExerciseTypesController : ControllerBase
    {
        private readonly PolarisDbContext _context;

        public ExerciseTypesController(PolarisDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ExerciseType>>> GetExerciseTypes()
        {
            return await _context.ExerciseTypes.ToListAsync();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ExerciseType>> GetExerciseType(int id)
        {
            var exerciseType = await _context.ExerciseTypes.FindAsync(id);

            if (exerciseType == null)
            {
                return NotFound();
            }

            return exerciseType;
        }

        [HttpPost]
        public async Task<ActionResult<ExerciseType>> PostExerciseType(ExerciseType exerciseType)
        {
            _context.ExerciseTypes.Add(exerciseType);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExerciseType), new { id = exerciseType.Id }, exerciseType);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> PutExerciseType(int id, ExerciseType exerciseType)
        {
            if (id != exerciseType.Id)
            {
                return BadRequest();
            }

            _context.Entry(exerciseType).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ExerciseTypeExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteExerciseType(int id)
        {
            var exerciseType = await _context.ExerciseTypes.FindAsync(id);
            if (exerciseType == null)
            {
                return NotFound();
            }

            _context.ExerciseTypes.Remove(exerciseType);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        private bool ExerciseTypeExists(int id)
        {
            return _context.ExerciseTypes.Any(e => e.Id == id);
        }
    }
}
