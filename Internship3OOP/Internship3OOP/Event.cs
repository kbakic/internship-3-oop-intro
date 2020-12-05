using System;
using System.Collections.Generic;

namespace Internship3OOP
{
    public class Event
    {

        public string Name { get; set; }
        public enum EventType { Coffee, Lecture, Concert, StudySession };
        public int eventType { get; set; }
        public DateTime StartTime { get; set; }
        public DateTime EndTime { get; set; }

        public Event(string name, int type, DateTime start, DateTime end)
        {
            Name = name;
            eventType = type;
            StartTime = start;
            EndTime = end;
        }

        public void addEvent(Event e,  Dictionary<Event, List<Person>> dict)
        {
            dict[e] =new List<Person>();
        }
        public void deleteEvent(Event e, Dictionary<Event, List<Person>> dict)
        {
            dict.Remove(e);
        }
        //Dodaj dateTime za start ili end 
        public void editEvent(string name , int type, DateTime start, DateTime end)
        {
            Name = name;
            eventType = type;
            StartTime = start;
            EndTime = end;
        }

        
         
    }
}
