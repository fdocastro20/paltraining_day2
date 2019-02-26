using Microsoft.AspNetCore.Mvc;

namespace PalTracker
{
    [Route("/time-entries")]
    public class TimeEntryController : ControllerBase
    {
        private readonly ITimeEntryRepository repository;
        private readonly IOperationCounter<TimeEntry> _operationCounter;
        public TimeEntryController(ITimeEntryRepository repo, IOperationCounter<TimeEntry> operationCounter)
        {
            repository = repo;
            _operationCounter = operationCounter;
        }

        [HttpGet]
        public IActionResult List()
        {
            _operationCounter.Increment(TrackedOperation.List);
            return Ok(repository.List());
        }

        [HttpGet("{id}", Name = "GetTimeEntry")]
        public IActionResult Read(long id)
        {
            _operationCounter.Increment(TrackedOperation.Read);
            if (repository.Contains(id))
            {
                return Ok(repository.Find(id));
            }
            return NotFound();
        }

        [HttpPost]
        public IActionResult Create([FromBody] TimeEntry timeEntry)
        {
            _operationCounter.Increment(TrackedOperation.Create);
            var createdEntry = repository.Create(timeEntry);
            return CreatedAtRoute("GetTimeEntry", new { id = createdEntry.Id.Value }, createdEntry);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, [FromBody] TimeEntry timeEntry)
        {
            _operationCounter.Increment(TrackedOperation.Update);
            if (repository.Contains(id))
            {
                return Ok(repository.Update(id, timeEntry));
            }
            return NotFound();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            _operationCounter.Increment(TrackedOperation.Delete);
            if (repository.Contains(id))
            {
                repository.Delete(id);
                return NoContent();
            }

            return NotFound();
        }
    }
}