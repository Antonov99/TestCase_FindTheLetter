using System;
using Gameplay.Difficulty;
using JetBrains.Annotations;
using Zenject;

namespace Gameplay.Cards
{
    [UsedImplicitly]
    public class CardSpawnController : IInitializable, IDisposable
    {
        private readonly CardSystem _cardSystem;
        private readonly IDifficulty _difficulty;

        public CardSpawnController(CardSystem cardSystem, IDifficulty difficulty)
        {
            _cardSystem = cardSystem;
            _difficulty = difficulty;
        }

        void IInitializable.Initialize()
        {
            _difficulty.OnStateChanged += OnStateChanged;
            _difficulty.Next(out int difficulty);
        }

        private void OnStateChanged()
        {
            _cardSystem.DespawnCards();
            _cardSystem.SpawnCards(_difficulty.Current * 3);
        }

        void IDisposable.Dispose()
        {
            _difficulty.OnStateChanged -= OnStateChanged;
        }
    }
}