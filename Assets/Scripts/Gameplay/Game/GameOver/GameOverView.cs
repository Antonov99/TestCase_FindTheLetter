using System;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

namespace Gameplay.Game
{
    public class GameOverView:MonoBehaviour
    {
        [SerializeField] private Button _restartButton;
        [SerializeField] private Image _fadeOverlay;

        public event Action OnRestart;
        
        private void Start()
        {
            _restartButton.onClick.AddListener(Restart);
            Hide();
        }

        private void Restart()
        {
            OnRestart?.Invoke();
        }

        public void Show()
        {
            _fadeOverlay.gameObject.SetActive(true);
            _fadeOverlay.DOFade(0.5f, 0.9f).OnComplete(() =>
            {
                _restartButton.gameObject.SetActive(true);
                _restartButton.interactable = true;
            });
        }
        
        public void Hide()
        {
            _restartButton.interactable = false;
            _restartButton.gameObject.SetActive(false);
            _fadeOverlay.color = new Color(0, 0, 0, 0);
            _fadeOverlay.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _restartButton.onClick.AddListener(Restart);
        }
    }
}