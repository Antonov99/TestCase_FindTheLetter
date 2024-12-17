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
        }

        private void OnStateChanged(int difficulty)
        {
            _cardSystem.DespawnCards();
            _cardSystem.SpawnCards(difficulty * 3);
        }

        void IDisposable.Dispose()
        {
            _difficulty.OnStateChanged -= OnStateChanged;
        }
    }
}