using System;

namespace Gameplay.Difficulty
{
    public interface IDifficulty
    {
        event Action OnStateChanged; 
        
        int Current { get; }
        int Max { get; }
        bool Next(out int difficulty);
    }
}