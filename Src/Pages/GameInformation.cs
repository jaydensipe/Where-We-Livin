using System;
using System.Collections.Generic;
using System.Linq;

namespace WhereWeLivin.Pages
{
    public static class GameInformation
    {
        public const string NewRound = "newround";
        public const string Exit = "exit";
        public const string End = "end";

        private static readonly Dictionary<string, double> StateStorage = new Dictionary<string, double>
        {
            {"Florida", 0},
            {"New Jersey", 0},
            {"Delaware", 0},
            {"New York", 0},
            {"Pennyslvania", 0},
            {"New Hampshire", 0},
            {"Forod", 0},
            {"aeaswe", 0},
            {"awe", 0},
            {"fsdfdsfs", 0},
            {"s132fsf", 0},
            {"sdfs123fsf", 0},
            {"sdfsd124124fsf", 0},
            {"sdf214sdfsf", 0},
            {"sdf21412sdfsf", 0},
            {"sdf112324sdfsf", 0},
            {"sdf1223s12424dfsf", 0},
            {"sdfs124dfsf", 0},
            {"sdfsd45fsf", 0},
            {"sdfs515dfsf", 0},
            {"sdfs273dfsf", 0},
            {"sd745fsdfsf", 0},
            {"sdf556sd3423fsf", 0},
            {"sdfs445758dfsf", 0},
            {"sdf47sdfsf", 0},
            {"sdf8sdfsf", 0},
            {"sdfs457dfsf", 0},
            {"sdfs57457dfsf", 0},
            {"sdf7sdfsf", 0},
        };

        private static readonly List<KeyValuePair<string, double>> PickedStates = new List<KeyValuePair<string, double>>();

        // Picks a random state from SharedStates and returns it, also sends game end event if list is empty 
        public static KeyValuePair<string, double> RandomPickState()
        {
            if (StateStorage.Count == 0)
            {
                OnEndGame?.Invoke();
                return default;
            }

            var rand = new Random();
            var randomSelection = StateStorage.ToList()[rand.Next(StateStorage.Count)];
                
            return randomSelection;
        }

        // Returns a list containing the top 10 most wanted states, with the top 10 least wanted states concatenated to the end
        public static List<KeyValuePair<string, double>> ReturnsTopAndLeastMostWantedStates()
        {
            var top10List = PickedStates.OrderByDescending(o => o.Value).Take(10).ToList();
            var least10List = PickedStates.OrderBy(o => o.Value).Take(10).ToList();
            top10List.AddRange(least10List);
            
            return top10List;
        }

        // Removes picked state from state storage and adds to picked state list
        public static void RemovePickedState(KeyValuePair<string, double> pickedState)
        {
            StateStorage.Remove(pickedState.Key);
            PickedStates.Add(pickedState);
        }
        
        // https://stackoverflow.com/questions/1641392/the-default-for-keyvaluepair
        public static bool IsNull<T, TU>(this KeyValuePair<T, TU> pair)
        {
            return pair.Equals(new KeyValuePair<T, TU>());
        }

        public delegate void EndGameHandler();
        public static event EndGameHandler OnEndGame;
    }
}