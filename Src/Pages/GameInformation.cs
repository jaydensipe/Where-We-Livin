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
            {"Alabama", 0},
            {"Alaska", 0},
            {"Arizona", 0},
            {"Arkansas", 0},
            {"California", 0},
            {"Colorado", 0},
            {"Connecticut", 0},
            {"Delaware", 0},
            {"Florida", 0},
            {"Georgia", 0},
            {"Hawaii", 0},
            {"Idaho", 0},
            {"Illinois", 0},
            {"Indiana", 0},
            {"Iowa", 0},
            {"Kansas", 0},
            {"Kentucky", 0},
            {"Louisiana", 0},
            {"Maine", 0},
            {"Maryland", 0},
            {"Massachusetts", 0},
            {"Michigan", 0},
            {"Minnesota", 0},
            {"Mississippi", 0},
            {"Missouri", 0},
            {"Montana", 0},
            {"Nebraska", 0},
            {"Nevada", 0},
            {"New Hampshire", 0},
            {"New Jersey", 0},
            {"New Mexico", 0},
            {"New York", 0},
            {"North Carolina", 0},
            {"North Dakota", 0},
            {"Ohio", 0},
            {"Oklahoma", 0},
            {"Oregon", 0},
            {"Pennsylvania", 0},
            {"Rhode Island", 0},
            {"South Carolina", 0},
            {"South Dakota", 0},
            {"Tennessee", 0},
            {"Texas", 0},
            {"Utah", 0},
            {"Vermont", 0},
            {"Virginia", 0},
            {"Washington", 0},
            {"West Virginia", 0},
            {"Wisconsin", 0},
            {"Wyoming", 0}
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