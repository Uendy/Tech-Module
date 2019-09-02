using System;
using System.Collections.Generic;
using System.Linq;
public class Program
{
    public static void Main()
    {
        #region
        //Roli is really busy with the recently started JS Core and DB Fundamentals modules at SoftUni.
        //She is used to going out with friends on various events. However, when the times comes, you need to tell her to start coding.

        //Roli is the organizer of those events, so she needs to keep track of the unique participants for each event. 
        //She saves the events by 'ID', which is the unique code for each event.
        //For each ID, she keeps the event name and the participants for it.

        //She receives request in the following format:
        //{id} #{eventName} @{participant1} @{participant2} … @{participantN}

        //If she is given event in an invalid format (such as without a hashtag), she ignores that line of input.
        //If she is given ID that already exists she needs to check if the eventName is the same. 
        //If it is, she adds the participants from the request to the other registered participants. 
        //If the event id exists but the name doesn’t, it is invalid and you need to ignore it.

        //After you receive "Time for Code", you need to print the results. 
        //All events must be sorted by participant count in descending order and then by alphabetical order. 
        //For each event, the participants must be sorted in alphabetical order.
        #endregion

        var tracker = new Dictionary<string, Concert>();

        string input = Console.ReadLine();
        while (input != "Time for Code")
        {
            bool invalidInput = !input.Contains("#");
            if (invalidInput)
            {
                input = Console.ReadLine();
                continue;
            }

            var stringTokens = input.Split(new[] { ' ', '#' }, StringSplitOptions.RemoveEmptyEntries).ToList();

            string id = stringTokens[0];
            string name = stringTokens[1];

            var performers = stringTokens.Skip(2).ToList();

            bool newID = !tracker.ContainsKey(id);
            if (newID)
            {
                var currentConcert = new Concert()
                {
                    Name = name,
                    Performers = performers
                };

                tracker[id] = currentConcert;
            }
            else // check if the same name and if yes add any missing performers
            {
                bool sameEventName = tracker.Values.Any(x => x.Name == name);
                if (sameEventName)
                {
                    var currentConcert = tracker[id];
                    var currentPerformers = currentConcert.Performers;

                    currentPerformers.AddRange(performers);
                    currentConcert.Performers = currentPerformers.Distinct().ToList();
                }
            }

            input = Console.ReadLine();
        }

        //order and print as requested
        var result = tracker
            .OrderByDescending(x => x.Value.Performers.Count())
            .ThenBy(x => x.Value.Name)
            .ToDictionary(x => x.Key, y => y.Value);

        foreach (var @event in result.Keys)
        {
            var currentEvent = result[@event];

            var eventName = currentEvent.Name;
            var sortedPerformers = currentEvent.Performers.OrderBy(x => x);

            Console.WriteLine($"{currentEvent.Name} - {currentEvent.Performers.Count()}");
            foreach (var performer in sortedPerformers)
            {
                Console.WriteLine(performer);
            }
        }
    }
}