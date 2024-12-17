using JetBrains.Annotations;
using UnityEngine;
using Zenject;

namespace Gameplay.Cards
{
    [UsedImplicitly]
    public class CardInstaller : Installer<Card, Transform, CardInstaller>
    {
        [Inject]
        private Transform _fieldOfView;

        [Inject]
        private Card _cardPrefab;

        public override void InstallBindings()
        {
            Container.Bind<CardSpawner>().AsSingle().WithArguments(_fieldOfView).NonLazy();
            Container.BindInterfacesAndSelfTo<CardSpawnController>().AsSingle().NonLazy();
            Container.Bind<CardSystem>().AsSingle().NonLazy();

            Container.BindMemoryPool<Card, MonoMemoryPool<Card>>()
                .WithInitialSize(9)
                .FromComponentInNewPrefab(_cardPrefab)
                .UnderTransformGroup("Cards").NonLazy();
        }
    }
}