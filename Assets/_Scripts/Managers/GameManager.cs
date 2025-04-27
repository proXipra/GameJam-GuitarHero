using _Scripts.PlayerControls;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.InputSystem;
using System.Collections.Generic;


namespace _Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public bool active;

        public InputAction playerControls;

        public float window;
        [SerializeField] private float bpm;
        [SerializeField] private AudioSource _audioSource;

        private bool _pressed;
        public int score;
        private int _bestScore;
        public int BestScore
        {
            get
            {
                return _bestScore;
            }
        }
        public float Period => 60 / bpm;

        public event Action OnStartMoving;

        public InputActionReference primaryAction;
        public InputActionReference secondaryAction;
        public InputActionReference tetriaryAction;
        public InputActionReference quaternaryAction;

        //public String[] primaryKeys = { "q","a","h"};
        //public String[] secondaryKeys = { "w", "f", "j" };
        //public String[] tetriaryKeys = { "e", "j", "k" };
        //public String[] quaternaryKeys = { "r", "i", "l" };

        private float _eventTimer;
        private float _nextChangeKeys;
        private int currentKeyState = 1;




        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            ChangeToKeyStateOne();
            _nextChangeKeys = UnityEngine.Random.Range(5f, 15f);

            OnStartMoving?.Invoke();
            Invoke(nameof(StartPlayingMusic), 3 - (GameManager.Instance.Period - GameManager.Instance.window) / 2);
            _bestScore = PlayerPrefs.GetInt("BestScore", 0);    

            
        }

        private void Update()
        {

            if (score > _bestScore)
            {
                _bestScore = score;
                PlayerPrefs.SetInt("BestScore", score);
                PlayerPrefs.Save();
            }

            _eventTimer = Time.time;
            Debug.Log(_eventTimer);
            if (_eventTimer >= _nextChangeKeys)
            {
                SwitchKeyState();
                _nextChangeKeys += UnityEngine.Random.Range(5f, 15f);
            }


        }

        void SwitchKeyState()
        {
            List<int> availableStates = new List<int>();

            // 0: One, 1: Two, 2: Three
            for (int i = 0; i < 3; i++)
            {
                if (i != currentKeyState)
                {
                    availableStates.Add(i);
                }
            }

            int newState = availableStates[UnityEngine.Random.Range(0, availableStates.Count)];
            currentKeyState = newState;

            switch (currentKeyState)
            {
                case 0:
                    ChangeToKeyStateOne();
                    break;
                case 1:
                    ChangeToKeyStateTwo();
                    break;
                case 2:
                    ChangeToKeyStateThree();
                    break;
            }

            Debug.Log("Yeni state: " + (currentKeyState + 1));
        }

        void ChangeToKeyStateOne()
        {
            primaryAction.action.ApplyBindingOverride(0, "<Keyboard>/h");
            secondaryAction.action.ApplyBindingOverride(0, "<Keyboard>/j");
            tetriaryAction.action.ApplyBindingOverride(0, "<Keyboard>/k");
            quaternaryAction.action.ApplyBindingOverride(0, "<Keyboard>/l");

            UIManager.Instance._pInput.text = "h";
            UIManager.Instance._sInput.text = "j";
            UIManager.Instance._tInput.text = "k";
            UIManager.Instance._qInput.text = "l";
        }

        void ChangeToKeyStateTwo()
        {
            primaryAction.action.ApplyBindingOverride(0, "<Keyboard>/a");
            secondaryAction.action.ApplyBindingOverride(0, "<Keyboard>/f");
            tetriaryAction.action.ApplyBindingOverride(0, "<Keyboard>/j");
            quaternaryAction.action.ApplyBindingOverride(0, "<Keyboard>/i");
            UIManager.Instance._pInput.text = "a";
            UIManager.Instance._sInput.text = "f";
            UIManager.Instance._tInput.text = "j";
            UIManager.Instance._qInput.text = "i";
        }

        void ChangeToKeyStateThree()
        {
            primaryAction.action.ApplyBindingOverride(0, "<Keyboard>/q");
            secondaryAction.action.ApplyBindingOverride(0, "<Keyboard>/w");
            tetriaryAction.action.ApplyBindingOverride(0, "<Keyboard>/e");
            quaternaryAction.action.ApplyBindingOverride(0, "<Keyboard>/r");
            UIManager.Instance._pInput.text = "q";
            UIManager.Instance._sInput.text = "w";
            UIManager.Instance._tInput.text = "e";
            UIManager.Instance._qInput.text = "r";
        }


        

        void StartPlayingMusic()
        {
            _audioSource.Play();
        }
    }
    
    public enum GameState
    {
        Gameplay,
        UI
    }
}