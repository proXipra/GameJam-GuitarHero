using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Serialization;

namespace _Scripts.PlayerControls
{
    public class InputHandler : MonoBehaviour
    {
        public static InputHandler Instance;

        private PlayerInput PlayerInput => _playerInput ??= GetComponent<PlayerInput>();
        private PlayerInput _playerInput;

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