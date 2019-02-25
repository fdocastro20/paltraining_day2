using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    [Route("/time-entries")]
    public class TimeEntryController : ControllerBase
    {
        private readonly ITimeEntryRepository repository;
        public TimeEntryController(ITimeEntryRepository repo)
        {
            repository = repo;
        }

        [HttpGet]
        public IActionResult List()
        {
            return Ok(repository.List());
        }

        [HttpGet("{id}", Name = "GetTimeEntry")]
        public IActionResult Read(long id)
        {
            if (repository.Contains(id))
            {
                return Ok(repository.Find(id));
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] TimeEntry timeEntry)
        {
            var createdEntry = repository.Create(timeEntry);
            return CreatedAtRoute("GetTimeEntry", new { id = createdEntry.Id.Value }, createdEntry);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TimeEntry timeEntry)
        {
            if (repository.Contains(id))
            {
                return Ok(repository.Update(id, timeEntry));
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            if (repository.Contains(id))
            {
                repository.Delete(id);
                return NoContent();
            }

            return NotFound();
        }
    }
}