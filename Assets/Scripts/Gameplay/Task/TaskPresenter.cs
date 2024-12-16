using System;
using Gameplay.Cards;
using JetBrains.Annotations;
using Zenject;

namespace Gameplay.Task
{
    [UsedImplicitly]
    public class TaskPresenter:IInitializable,IDisposable
    {
        private readonly CardSystem _cardSystem;
        private readonly TaskView _taskView;
        private readonly string _letters;

        public TaskPresenter(CardSystem cardSystem, TaskView taskView, string letters)
        {
            _cardSystem = cardSystem;
            _taskView = taskView;
            _letters = letters;
        }

        void IInitializable.Initialize()
        {
            _cardSystem.OnTargetRandomized += UpdateTarget;
        }

        private void UpdateTarget(Card card)
        {
            var index = card.GetIndex();
            _taskView.UpdateText($"Find {_letters[index]}");
        }

        void IDisposable.Dispose()
        {
            _cardSystem.OnTargetRandomized -= UpdateTarget;
        }
    }
}