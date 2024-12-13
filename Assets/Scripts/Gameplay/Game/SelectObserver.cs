using System;
using Gameplay.Cards;
using Gameplay.Difficulty;
using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Gameplay.Game
{
    [UsedImplicitly]
    public class SelectObserver:IInitializable, IDisposable
    {
        private readonly CardSystem _cardSystem;
        private readonly IDifficulty _difficulty;

        public SelectObserver(CardSystem cardSystem, IDifficulty difficulty)
        {
            _cardSystem = cardSystem;
            _difficulty = difficulty;
        }

        void IInitializable.Initialize()
        {
            _cardSystem.OnSelect += OnSelect;
        }

        private void OnSelect(bool value, Card card)
        {
            if (value)
            {
                if (_difficulty.Next(out int difficulty))
                    Debug.Log("OK");//animation
                else
                    Debug.Log("MAX");
            }
            else
            {
                Debug.Log("NOT OK");
                //animation
            }
        }

        void IDisposable.Dispose()
        {
            _cardSystem.OnSelect -= OnSelect;
        }
    }
}