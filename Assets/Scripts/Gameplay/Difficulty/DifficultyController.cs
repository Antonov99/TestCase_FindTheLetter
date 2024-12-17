using Gameplay.Game;
using System;
using JetBrains.Annotations;
using Zenject;

namespace Gameplay.Difficulty
{
    [UsedImplicitly]
    public class DifficultyController : IInitializable, IDisposable
    {
        private readonly SelectObserver _selectObserver;
        private readonly IDifficulty _difficulty;

        public DifficultyController(SelectObserver selectObserver, IDifficulty difficulty)
        {
            _selectObserver = selectObserver;
            _difficulty = difficulty;
        }

        void IInitializable.Initialize()
        {
            _selectObserver.OnCorrectSelected += AddDifficulty;
            AddDifficulty();
        }

        private void AddDifficulty()
        {
            _difficulty.Next(out int difficulty);
        }

        void IDisposable.Dispose()
        {
            _selectObserver.OnCorrectSelected -= AddDifficulty;
        }
    }
}