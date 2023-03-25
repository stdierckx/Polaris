using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Polaris.Api.DataLayer;
using Polaris.Api.Models;

namespace Polaris.Api.Controllers
{
    [Route("api/[controller]")]
    public class ExercisesController : ControllerBase
    {
        private readonly PolarisDbContext _context;

        public ExercisesController(PolarisDbContext context)
        {
            _context = context;
        }

        // GET: api/Exercises
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Exercise>>> GetExercises()
        {
            return await _context.Exercises.ToListAsync();
        }

        // GET: api/Exercises/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Exercise>> GetExercise(int id)
        {
            var exercise = await _context.Exercises.FindAsync(id);

            if (exercise == null)
            {
                return NotFound();
            }

            return exercise;
        }

        // POST: api/Exercises
        [HttpPost]
        public async Task<ActionResult<Exercise>> PostExercise(Exercise exercise)
        {
            _context.Exercises.Add(exercise);
            await _context.SaveChangesAsync();

            return CreatedAtAction(nameof(GetExercise), new { id = exercise.Id }, exercise);
        }
    }
}