using _Scripts.PlayerControls;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;


namespace _Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance;

        public bool active;

        public InputAction playerControls;

        [SerializeField] private float bpm;
        [SerializeField] private float window;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private bool _pressed;
        public int score;
        public float Period => 60 / bpm;

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            InputHandler.Instance.OnJumpInput += HandleOnJumpInput;

            InvokeRepeating(nameof(EnterWindow), 0, Period);
        }
        
        private void OnDisable()
        {
            InputHandler.Instance.OnJumpInput -= HandleOnJumpInput;
        }

        private void HandleOnJumpInput()
        {
            score = active ? score + 1 : score - 1;
            if (active) _pressed = true;
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
            if (!_pressed) score--;
            spriteRenderer.color = Color.white;
            active = false;
        }
    }
    
    public enum GameState
    {
        Gameplay,
        UI
    }
}