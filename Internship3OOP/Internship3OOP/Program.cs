using System;
using System.Collections.Generic;

namespace Internship3OOP
{
    class Program
    {

        public static Person InputPerson()
        {
            string name, lastName;
            int oib, phoneNumber;

            Console.WriteLine("Enter first name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter last name:");
            lastName = Console.ReadLine();
            Console.WriteLine("Enter OIB: ");
            oib = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter phone number: ");
            phoneNumber = int.Parse(Console.ReadLine());

            return new Person(name, lastName, oib, phoneNumber);
        }

        public static Event InputEvent()
        {
            string name;
            int type;
            DateTime start, end;

            Console.WriteLine("Enter event name: ");
            name = Console.ReadLine();
            Console.WriteLine("Enter event type:");
            type = int.Parse(Console.ReadLine());
            Console.WriteLine("Enter start time: ");
            start = DateTime.Parse(Console.ReadLine());
            Console.WriteLine("Enter end time: ");
            end = DateTime.Parse(Console.ReadLine());

            return new Event(name, type, start, end);
        }
        static void Main(string[] args)
        {

            var listOfEvents = new List<Event>();
            var listOfPeople = new List<Person>();
            var Event = new Event("", 5,DateTime.Parse("1 Jan 2000"), DateTime.Parse("1 Jan 2000"));
            var EventPeople = new Dictionary<Event,List<Person>>();
            Console.WriteLine("1.Dodavanje eventa\n2.Brisanje eventa\n3.Edit eventa\n4.Dodavanje osobe na event\n5.Uklanjanje osobe sa eventa\n6.Ispis detalja eventa.\n7.Prekid rada");
            bool query = true;
            while (query)
            {


                int option = int.Parse(Console.ReadLine());

                string question;
                
                switch (option)
                {
                    case 1:
                        Event e = InputEvent();
                        Event.addEvent(e, EventPeople);
                        listOfEvents.Add(e);
                        break;

                    case 2:
                        Console.WriteLine("Enter a name of which you want to delete:");
                        string nameEvent = Console.ReadLine();
                        Event temp = null;
                        for (int i = 0; i < listOfEvents.Count; i++)
                        {
                            if (nameEvent == listOfEvents[i].Name)
                            {
                                temp = listOfEvents[i];
                                listOfEvents.RemoveAt(i);
                            }
                                
                            if(temp==null)
                                Console.WriteLine("Event doesnt exist!");
                        }
                        Event.deleteEvent(temp, EventPeople);
                        
                        break;

                    case 3:
                        Console.WriteLine("Enter new name for event:");
                        string name = Console.ReadLine();
                        Console.WriteLine("Enter new type (0,1,2,3) :");
                        int type = int.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new start time: ");
                        DateTime start = DateTime.Parse(Console.ReadLine());
                        Console.WriteLine("Enter new end time:");
                        DateTime end = DateTime.Parse(Console.ReadLine());
                        Event.editEvent(name, type, start, end);
                        Console.WriteLine("Changed!");
                        break;

                    case 4:
                        Console.WriteLine("To which event?");
                        string eventName = Console.ReadLine();
                        foreach (var item in listOfEvents)
                        {
                            if (item.Name.ToUpper() == eventName.ToUpper())
                            {
                                Event temp2 = item;
                                List<Person> pers = EventPeople[temp2];
                                Person p = InputPerson();
                                pers.Add(p);
                                listOfPeople.Add(p);
                            }
                        }
                        break;

                    case 5:
                        Console.WriteLine("Which person do you want to delete (OIB)?");
                        int oibPerson = int.Parse(Console.ReadLine());
                        Person temp3 = null;
                        for (int i = 0; i < listOfPeople.Count; i++)
                        {
                            if (oibPerson == listOfPeople[i].OIB)
                            {
                                temp3 = listOfPeople[i];
                                listOfPeople.RemoveAt(i);
                            }
                            if (temp3 == null)
                                Console.WriteLine("Person doesnt exist!");
                        }
                        

                        break;

                    case 6:
                        Console.WriteLine("1.Ispis detalja eventa u formatu: name – event type – start time – end time – trajanje – ispis broja ljudi na eventu\n2.Ispis svih osoba na eventu u formatu: [Redni broj u listi].name – last name – broj mobitela\n3.Ispis svih detalja.");
                        int optionDetail = int.Parse(Console.ReadLine());
                        switch (optionDetail)
                        {
                            case 1:

                                for (int i = 0; i < listOfEvents.Count; i++)
                                {
                                    Console.WriteLine(listOfEvents[i].Name + "-" + listOfEvents[i].eventType + "-" + listOfEvents[i].StartTime + "-" + listOfEvents[i].EndTime + "-" + listOfPeople.Count);
                                }
                                break;

                            case 2:
                                for (int i = 0; i < listOfPeople.Count; i++)
                                {
                                    Console.WriteLine((i+1) + "-" + listOfPeople[i].FirstName + "-" + listOfPeople[i].LastName + "-" + listOfPeople[i].PhoneNumber);
                                }
                                break;

                            case 3:
                                for (int i = 0; i < listOfEvents.Count; i++)
                                {
                                    Console.WriteLine(listOfEvents[i].Name + "-" + listOfEvents[i].eventType + "-" + listOfEvents[i].StartTime + "-" + listOfEvents[i].EndTime + "-" + listOfPeople.Count);
                                }
                                for (int i = 0; i < listOfPeople.Count; i++)
                                {
                                    Console.WriteLine((i + 1) + "-" + listOfPeople[i].FirstName + "-" + listOfPeople[i].LastName + "-" + listOfPeople[i].PhoneNumber);
                                }
                                break;

                            default:
                                Console.WriteLine("Wrong input!");
                                break;
                        }
                        break;

                    case 7:
                        Console.WriteLine("Izlazak...");
                        System.Environment.Exit(1);
                        break;

                    default:
                        Console.WriteLine("Wrong input!");
                        break;
                }
                Console.WriteLine("Do you want to continue (yes/no): ");
                question = Console.ReadLine();
                if (question.ToUpper() == "YES")
                    query = true;
                else if (question.ToUpper() == "NO")
                    query = false;
                else
                    Console.WriteLine("Wrong input!");
            }

        }
    }
}
