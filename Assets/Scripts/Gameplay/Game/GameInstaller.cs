using Gameplay.Cards;
using Gameplay.Difficulty;
using Gameplay.Task;
using UnityEngine;
using Zenject;

namespace Gameplay.Game
{
    public class GameInstaller : MonoInstaller
    {
        [Header("Card")]
        [SerializeField]
        private Card _cardPrefab;

        [SerializeField]
        private Transform _fieldOfView;

        [Header("Difficulty")]
        [SerializeField]
        private int _maxDifficulty;

        [Header("Task")]
        [SerializeField]
        private TaskView _taskView;
        
        [SerializeField]
        private string _allSymbols;
        
        [Header("FPS")]
        [SerializeField]
        private int _targetFPS;
        
        public override void InstallBindings()
        {
            TaskInstaller.Install(Container, _taskView, _allSymbols);
            CardInstaller.Install(Container, _cardPrefab, _fieldOfView);
            DifficultyInstaller.Install(Container, _maxDifficulty);

            Container.BindInterfacesAndSelfTo<SelectObserver>().AsSingle().NonLazy();
            Container.BindInterfacesTo<FpsSetup>().AsSingle().WithArguments(_targetFPS).NonLazy();
        }
    }
}