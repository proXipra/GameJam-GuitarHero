using _Scripts.PlayerControls;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using System;
using UnityEngine.InputSystem;


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


        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            if (score > _bestScore)
            {
                _bestScore = score;
                PlayerPrefs.SetInt("BestScore", score);
                PlayerPrefs.Save();
            }

        }

        private void Start()
        {
            OnStartMoving?.Invoke();
            Invoke(nameof(StartPlayingMusic), 3 - (GameManager.Instance.Period - GameManager.Instance.window) / 2);
            _bestScore = PlayerPrefs.GetInt("BestScore", 0);
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