using UnityEngine;
using UnityEngine.UI;
using System;

namespace JuveProduction.GameSystem
{
    public class GameplayUIManager : MonoBehaviour
    {
        public static GameplayUIManager Instance = null;

        public static bool HasInstance => (Instance != null);

        [SerializeField]
        private GameObject _timeStopUI;
        public GameObject TimeStopUI => _timeStopUI;

        [SerializeField]
        private Slider _exciteSliderUI;

        public Action<float> WhenExcitementChanged;

        private void Awake()
        {
            if (Instance != null)
            {
                Destroy(gameObject);
                return;
            }

            Instance = this;
        }

        private void Start()
        {
            WhenExcitementChanged += OnWhenExcitementChanged;
        }

        private void OnWhenExcitementChanged(float changeRate) 
        {
            _exciteSliderUI.value = changeRate;
        }
    }
}

