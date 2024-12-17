using System;
using Gameplay.Difficulty;
using Gameplay.Game;
using JetBrains.Annotations;
using Zenject;

namespace Gameplay.GameOver
{
    [UsedImplicitly]
    public class GameOverPresenter : IInitializable, IDisposable
    {
        private readonly SelectObserver _selectObserver;
        private readonly IDifficulty _difficulty;
        private readonly GameOverView _gameOverView;

        public GameOverPresenter(SelectObserver selectObserver, IDifficulty difficulty, GameOverView gameOverView)
        {
            _selectObserver = selectObserver;
            _difficulty = difficulty;
            _gameOverView = gameOverView;
        }

        void IInitializable.Initialize()
        {
            _difficulty.OnStateChanged += CheckGameOver;
        }

        private void OnRestart()
        {
            _gameOverView.Hide();
            _difficulty.SetDifficulty(1);

            _gameOverView.OnRestart -= OnRestart;
        }

        private void CheckGameOver(int level)
        {
            if (_difficulty.IsMax())
                _selectObserver.OnCorrectSelected += OnGameOver;
        }

        private void OnGameOver()
        {
            _gameOverView.Show();
            _selectObserver.OnCorrectSelected -= OnGameOver;

            _gameOverView.OnRestart += OnRestart;
        }

        void IDisposable.Dispose()
        {
            _difficulty.OnStateChanged -= CheckGameOver;
            _selectObserver.OnCorrectSelected -= OnGameOver;

            _gameOverView.OnRestart -= OnRestart;
        }
    }
}