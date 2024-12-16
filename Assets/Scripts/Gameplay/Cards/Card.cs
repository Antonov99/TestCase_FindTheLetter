using System;
using System.Collections.Generic;
using DG.Tweening;
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
        
        private bool _isAnimating;

        private int _currentIndex;

        public event Action<Card> OnPressed;

        private void OnEnable()
        {
            _button.onClick.AddListener(() => OnPressed?.Invoke(this));
            BounceAnimation();
        }

        private void BounceAnimation()
        {
            _isAnimating = true;
            transform.localScale = Vector3.zero;
            transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBounce);
            _isAnimating = false;
        }

        public void ShakeAnimation()
        {
            if (_isAnimating) return;
            _isAnimating = true;
            
            Vector3 originalPosition = transform.localPosition;
            float shakeDistance = 15f; 
            float shakeDuration = 0.2f;

            transform.DOLocalMoveX(originalPosition.x - shakeDistance, shakeDuration).SetEase(Ease.InBounce)
                .OnComplete(() => 
                    transform.DOLocalMoveX(originalPosition.x + shakeDistance, shakeDuration).SetEase(Ease.InBounce)
                        .OnComplete(() => 
                            transform.DOLocalMove(originalPosition, shakeDuration).SetEase(Ease.InBounce)
                            .OnComplete(() => _isAnimating = false)));
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