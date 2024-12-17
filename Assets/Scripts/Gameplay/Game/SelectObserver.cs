using System;
using Gameplay.Cards;
using JetBrains.Annotations;
using Zenject;

namespace Gameplay.Game
{
    [UsedImplicitly]
    public class SelectObserver : IInitializable, IDisposable
    {
        private readonly CardSystem _cardSystem;
        public event Action OnCorrectSelected;

        public SelectObserver(CardSystem cardSystem)
        {
            _cardSystem = cardSystem;
        }

        void IInitializable.Initialize()
        {
            _cardSystem.OnSelect += OnSelect;
        }

        private void OnSelect(bool value, Card card)
        {
            if (value)
            {
                card.BounceAnimation(() => OnCorrectSelected?.Invoke());
            }
            else
            {
                card.ShakeAnimation();
            }
        }

        void IDisposable.Dispose()
        {
            _cardSystem.OnSelect -= OnSelect;
        }
    }
}