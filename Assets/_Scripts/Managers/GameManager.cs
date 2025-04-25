using UnityEngine;


namespace _Scripts.Manager
{
    public class GameManager : MonoBehaviour
    {
        #region Variables

        public static GameManager Instance;

        public bool active;

        [SerializeField] private float bpm;
        [SerializeField] private float window;
        [SerializeField] private SpriteRenderer spriteRenderer;

        private float Period => 60 / bpm;

        #endregion

        #region Unity Callback Functions

        private void Awake()
        {
            Instance = this;
        }

        private void Update()
        {
            active = (Time.time % Period) < window;
            spriteRenderer.color = active ? Color.red : Color.white;
        }

        #endregion
    }
    
    public enum GameState
    {
        Gameplay,
        UI
    }
}