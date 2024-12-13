using System;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using Random = UnityEngine.Random;

namespace Gameplay.Cards
{
    [UsedImplicitly]
    public class CardSystem
    {
        private readonly List<Card> _activeCards = new List<Card>();
        private readonly HashSet<int> _activeLetters = new HashSet<int>();
        private Card _targetCard;

        public event Action<Card> OnTargetRandomized;
        public event Action<bool, Card> OnSelect;

        private readonly CardSpawner _cardSpawner;

        public CardSystem(CardSpawner cardSpawner)
        {
            _cardSpawner = cardSpawner;
        }

        public void SpawnCards(int count)
        {
            for (int i = 0; i < count; i++)
            {
                var card = _cardSpawner.SpawnCard();
                GenerateCard(card);
                card.OnPressed += CheckWin;
            }

            GenerateTarget();
        }

        private void GenerateCard(Card card)
        {
            int bgIndex = Random.Range(0, card.BackgroundsCount);
            int letterIndex;

            do
            {
                letterIndex = Random.Range(0, card.LettersCount);
            } while (_activeLetters.Contains(letterIndex));

            card.SetBackground(bgIndex);
            card.SetLetter(letterIndex);

            _activeLetters.Add(letterIndex);
            _activeCards.Add(card);
        }

        private void GenerateTarget()
        {
            var index = Random.Range(0, _activeCards.Count);
            _targetCard = _activeCards[index];
            OnTargetRandomized?.Invoke(_targetCard);
        }

        private void CheckWin(Card card)
        {
            if (card == _targetCard)
                OnSelect?.Invoke(true, card);
            else
                OnSelect?.Invoke(false, card);
        }

        public void DespawnCards()
        {
            foreach (var card in _activeCards)
            {
                _cardSpawner.RemoveCard(card);
                card.OnPressed -= CheckWin;
            }

            _activeLetters.Clear();
            _activeCards.Clear();
        }
    }
}