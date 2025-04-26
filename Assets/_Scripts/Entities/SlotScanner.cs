using System;
using _Scripts.PlayerControls;
using UnityEngine;

namespace _Scripts.Entities
{
    public class SlotScanner : MonoBehaviour
    {
        private Vector2 _workSpace = new (4, 1);
        
        private void Start()
        {
            InputHandler.Instance.OnJumpInput += HandleOnJumpInput;
        }

        private void OnDisable()
        {
            InputHandler.Instance.OnJumpInput -= HandleOnJumpInput;
        }

        private void HandleOnJumpInput()
        {
            Physics2D.OverlapBox(transform.position, _workSpace)
        }
    }
}