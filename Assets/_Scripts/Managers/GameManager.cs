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

        private void OnDisable()
        {
            InputHandler.Instance.OnJumpInput -= HandleOnJumpInput;
        }

        private void Awake()
        {
            Instance = this;
        }

        private void Start()
        {
            InputHandler.Instance.OnJumpInput += HandleOnJumpInput;
            InvokeRepeating(nameof(StartWindowCoroutine), 1, Period);
        }

        private void StartWindowCoroutine()
        {
            StartCoroutine(WindowCoroutine());
        }

        private IEnumerator WindowCoroutine()
        {
            bool timeOut = false;
            float startTime = Time.time;
            active = true;
            spriteRenderer.color = Color.red;
            while (true)
            {
                if (InputHandler.Instance.JumpInput) break;
                if (Time.time > startTime + window)
                {
                    timeOut = true;
                    break;
                }
                yield return new WaitForSeconds(0.02f);
            }
            score = timeOut ? score - 1 : score + 1;
            active = false;
            spriteRenderer.color = timeOut ? Color.white : Color.green;
            yield return null;
        }

        private void HandleOnJumpInput()
        {
            if (!active) score--;
        }
        
    }
    
    public enum GameState
    {
        Gameplay,
        UI
    }
}