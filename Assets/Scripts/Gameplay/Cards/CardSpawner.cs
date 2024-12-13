using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Gameplay.Cards
{
    [UsedImplicitly]
    public class CardSpawner
    {
        private readonly MonoMemoryPool<Card> _cardPool;
        private readonly Transform _fieldOfView;

        public CardSpawner(MonoMemoryPool<Card> cardPool, Transform fieldOfView)
        {
            _cardPool = cardPool;
            _fieldOfView = fieldOfView;
        }

        public Card SpawnCard()
        {
            var card = _cardPool.Spawn();
            card.transform.SetParent(_fieldOfView, false);

            return card;
        }

        public void RemoveCard(Card card)
        {
            _cardPool.Despawn(card);
        }
    }
}