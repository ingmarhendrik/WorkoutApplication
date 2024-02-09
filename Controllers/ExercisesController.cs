using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RestApi_1.Model;

namespace RestApi_1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExercisesController : ControllerBase
    {
        private readonly DataContext _context;

        public ExercisesController(DataContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetExercises()
        {
            return Ok(_context.Exercises);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetails(int? id)
        {
            var exercise = _context.Exercises.FirstOrDefault(e => e.Id == id);
            if (exercise == null)
            {
                return NotFound();
            }
            return Ok(exercise);
        }

        [HttpPost]
        public IActionResult Create([FromBody] Exercise exercise)
        {
            var dbExercise = _context.Exercises.Find(exercise.Id);
            if (dbExercise == null)
            {
                _context.Add(exercise);
                _context.SaveChanges();

                return CreatedAtAction(nameof(GetDetails), new {Id = exercise.Id}, exercise);
            }
            else
            {
                return Conflict();
            }
            
        }

    }
}