using System;
using Game.View.Helpers;
using UnityEngine;
using UnityEngine.UI;

namespace Game.View
{
    public class PlayerView: MonoBehaviour
    {
        [SerializeField] private Image _progressBar;

        private GameFinishedPopUp _gameFinishedPopUp;


        private void OnInstaller()
        {
            
        }

        private void Awake()
        {
            _gameFinishedPopUp = GetComponentInChildren<GameFinishedPopUp>(true);
            _gameFinishedPopUp.Initialize();
        }

        public void UpdateProgressBar(float value)
        {
            _progressBar.fillAmount += value;
        }
    }
}
