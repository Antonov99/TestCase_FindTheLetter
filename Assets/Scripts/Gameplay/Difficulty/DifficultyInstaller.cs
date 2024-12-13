using JetBrains.Annotations;
using Zenject;

namespace Gameplay.Difficulty
{
    [UsedImplicitly]
    public class DifficultyInstaller : Installer<int, DifficultyInstaller>
    {
        [Inject]
        private int _difficulty;

        public override void InstallBindings()
        {
            Container.Bind<IDifficulty>().To<Difficulty>().AsSingle().WithArguments(_difficulty);
        }
    }
}