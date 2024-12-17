using JetBrains.Annotations;
using Zenject;

namespace Gameplay.GameOver
{
    [UsedImplicitly]
    public class GameOverInstaller : Installer<GameOverView, GameOverInstaller>
    {
        [Inject]
        private GameOverView _gameOverView;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<GameOverPresenter>().AsSingle().WithArguments(_gameOverView).NonLazy();
        }
    }
}