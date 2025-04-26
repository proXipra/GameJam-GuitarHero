using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace _Scripts.PlayerControls
{
    public class InputHandler : MonoBehaviour
    {
        private static InputHandler _instance;
        public static InputHandler Instance 
        { 
            get
            { return _instance; }
        
        }




        public bool JumpInput { get; set; }
        
        public event Action OnJumpInput;

        private void Awake()
        {
            Instance = this;
        }

        public void Jump(InputAction.CallbackContext context)
        {
            if (context.canceled) JumpInput = false;
            if (!context.started) return;
            JumpInput = true;
            OnJumpInput?.Invoke();
        }
    }
}