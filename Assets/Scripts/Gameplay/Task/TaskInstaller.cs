using JetBrains.Annotations;
using Zenject;

namespace Gameplay.Task
{
    [UsedImplicitly]
    public class TaskInstaller : Installer<TaskView, string, TaskInstaller>
    {
        [Inject]
        private TaskView _taskView;

        [Inject]
        private string _allSymbols;

        public override void InstallBindings()
        {
            Container.BindInterfacesAndSelfTo<TaskPresenter>().AsSingle().WithArguments(_taskView, _allSymbols)
                .NonLazy();
        }
    }
}