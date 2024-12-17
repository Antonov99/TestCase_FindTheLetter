using System;
using JetBrains.Annotations;

namespace Gameplay.Difficulty
{
    [UsedImplicitly]
    public sealed class Difficulty : IDifficulty
    {
        public event Action<int> OnStateChanged;

        public int Current => _current;
        public int Max => _max;

        private int _current;
        private readonly int _max;

        public Difficulty(int max)
        {
            _max = max;
        }

        public bool Next(out int difficulty)
        {
            if (IsMax())
            {
                difficulty = default;
                return false;
            }

            _current++;
            OnStateChanged?.Invoke(_current);

            difficulty = _current;
            return true;
        }

        public bool IsMax()
        {
            return _current == _max;
        }

        public void SetDifficulty(int value)
        {
            _current = value;
            OnStateChanged?.Invoke(_current);
        }
    }
}