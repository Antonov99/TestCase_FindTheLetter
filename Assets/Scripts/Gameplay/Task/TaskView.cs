﻿using TMPro;
using UnityEngine;

namespace Gameplay.Task
{
    public class TaskView:MonoBehaviour
    {
        [SerializeField]
        private TMP_Text _taskText;

        public void UpdateText(string text)
        {
            _taskText.text = text;
        }
    }
}