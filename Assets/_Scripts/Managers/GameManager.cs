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
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private AudioSource _audioSource;

        private bool _pressed;
        public int score;
        public float Period => 60 / bpm;

        public event Action OnStartMoving;


        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            InputHandler.Instance.OnJumpInput += HandleOnJumpInput;
            OnStartMoving?.Invoke();
            Invoke(nameof(StartGame), 3);
            Invoke(nameof(StartPlayingMusic), 3 - (GameManager.Instance.Period - GameManager.Instance.window) / 2);
        }
        
        private void OnDisable()
        {
            InputHandler.Instance.OnJumpInput -= HandleOnJumpInput;
        }

        private void StartGame()
        {
            InvokeRepeating(nameof(EnterWindow), 0, Period);
        }

        private void HandleOnJumpInput()
        {
            if (active)
            {
                score++;
                _pressed = true;
            }
            else
            {
                if (score == 0)
                {
                    return;
                }
                score--;
            }
            
        }

        private void EnterWindow()
        {
            active = true;
            _pressed = false;
            spriteRenderer.color = Color.red;
            Invoke(nameof(ExitWindow), window);
        }

        private void ExitWindow()
        {
            if (!_pressed)
            {
                if (score == 0)
                {
                    return;
                }
                score--;
            }
           
            spriteRenderer.color = Color.white;
            active = false;
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