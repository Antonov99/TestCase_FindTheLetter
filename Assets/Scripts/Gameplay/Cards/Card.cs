using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Cards
{
    public class Card : MonoBehaviour
    {
        [SerializeField]
        private Image _background;

        [SerializeField]
        private Image _letter;

        [SerializeField]
        private Button _button;

        [SerializeField]
        private List<Sprite> _letterSprites;

        public int LettersCount => _letterSprites.Count;

        [SerializeField]
        private List<Sprite> _backgroundSprites;

        public int BackgroundsCount => _backgroundSprites.Count;

        private int _currentIndex;

        public event Action<Card> OnPressed;

        private void OnEnable()
        {
            _button.onClick.AddListener(() => OnPressed?.Invoke(this));
        }

        public void SetBackground(int backgroundIndex)
        {
            _background.sprite = _backgroundSprites[backgroundIndex];
        }

        public void SetLetter(int letterIndex)
        {
            _letter.sprite = _letterSprites[letterIndex];
            _currentIndex = letterIndex;
        }

        public int GetIndex()
        {
            return _currentIndex;
        }

        private void OnDisable()
        {
            _button.onClick.RemoveListener(() => OnPressed?.Invoke(this));
        }
    }
}