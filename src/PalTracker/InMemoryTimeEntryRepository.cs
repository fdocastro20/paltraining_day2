using System.Collections.Generic;
using System.Linq;

namespace PalTracker {

    public class InMemoryTimeEntryRepository : ITimeEntryRepository
    {
        private readonly IDictionary<long, TimeEntry> timeEntries = new Dictionary<long, TimeEntry>();

        public bool Contains(long id)=> timeEntries.ContainsKey(id);

        public TimeEntry Create(TimeEntry timeEntry)
        {
           timeEntry.Id = timeEntries.Count + 1;
           timeEntries.Add(timeEntry.Id.Value, timeEntry);
           return timeEntry;
        }

        public void Delete(long id)
        {
            timeEntries.Remove(id);
        }

        public TimeEntry Find(long id) => timeEntries[id];

        public IEnumerable<TimeEntry> List() => timeEntries.Values.ToList();
        

        public TimeEntry Update(long id, TimeEntry timeEntry)
        {
            timeEntry.Id = id;
            timeEntries[id] = timeEntry;
            return timeEntry;
        }
    }
}