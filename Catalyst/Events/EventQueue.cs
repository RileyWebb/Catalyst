using System.Collections.Generic;

namespace Catalyst.Events
{
    public class EventQueue
    {
        private List<Event> Events = new List<Event>();

        public void Add(Event @event) => Events.Add(@event);
        public void Add(IEnumerable<Event> events) => Events.AddRange(events);
    }
}