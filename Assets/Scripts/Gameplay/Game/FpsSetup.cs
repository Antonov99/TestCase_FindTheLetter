using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Gameplay.Game
{
    [UsedImplicitly]
    public class FpsSetup : IInitializable
    {
        private readonly int _targetFPS;

        public FpsSetup(int targetFPS)
        {
            _targetFPS = targetFPS;
        }

        public void Initialize()
        {
            Application.targetFrameRate = _targetFPS;
        }
    }
}