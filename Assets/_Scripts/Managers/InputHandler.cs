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
        
        public event Action OnPrimaryInput;
        public event Action OnSecondaryInput;
        public event Action OnTertiaryInput;
        public event Action OnQuaternaryInput;

        private void Awake()
        {
            _instance = this;
        }

        public void Primary(InputAction.CallbackContext context)
        {
            if (context.canceled) JumpInput = false;
            if (!context.started) return;
            JumpInput = true;
            OnPrimaryInput?.Invoke();
        }
        
        public void Secondary(InputAction.CallbackContext context)
        {
            if (context.canceled) JumpInput = false;
            if (!context.started) return;
            JumpInput = true;
            OnSecondaryInput?.Invoke();
        }
        
        public void Tertiary(InputAction.CallbackContext context)
        {
            if (context.canceled) JumpInput = false;
            if (!context.started) return;
            JumpInput = true;
            OnTertiaryInput?.Invoke();
        }
        
        public void Quaternary(InputAction.CallbackContext context)
        {
            if (context.canceled) JumpInput = false;
            if (!context.started) return;
            JumpInput = true;
            OnQuaternaryInput?.Invoke();
        }
    }
}