using System;

namespace Gameplay.Difficulty
{
    public interface IDifficulty
    {
        event Action<int> OnStateChanged;

        int Current { get; }
        int Max { get; }
        bool Next(out int difficulty);
        bool IsMax();
        void SetDifficulty(int value);
    }
}