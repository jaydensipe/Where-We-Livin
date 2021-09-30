using System;
using System.Collections.Generic;
using System.Linq;

namespace WhereWeLivin.Pages
{
    public static class GameInformation
    {
        public const string NewRound = "newround";
        public const string Exit = "exit";

        private static Dictionary<string, double> _stateStorage = new Dictionary<string, double>
        {
            {"Florida", 0},
            {"New Jersey", 0},
            {"Delaware", 0}
        };

        private static Dictionary<string, double> _pickedStates = new Dictionary<string, double>();

        public static KeyValuePair<string, double> RandomPickState()
        {
            if (_stateStorage.Count == 0)
            {
                OnEndGame?.Invoke();
                return default;
            }

            var rand = new Random();
            var randomSelection = _stateStorage.ToList()[rand.Next(_stateStorage.Count)];
                
            Console.WriteLine(randomSelection);
            return randomSelection;

        }

        public static void RemovePickedState(KeyValuePair<string, double> pickedState)
        {
            _stateStorage.Remove(pickedState.Key);
            _pickedStates.Add(pickedState.Key, pickedState.Value);
            foreach (var VARIABLE in _pickedStates)
            {
                Console.WriteLine(VARIABLE.Key + " " + VARIABLE.Value);
            }
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