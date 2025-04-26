using System;
using UnityEngine;

namespace _Scripts.Slots
{
    public class Slot : MonoBehaviour
    {
        public float targetYDisplacement;

        public float distance;
        
        private SpriteRenderer SpriteRenderer => _spriteRenderer ??= GetComponent<SpriteRenderer>();
        private SpriteRenderer _spriteRenderer;

        private bool _moving;

        private void Awake()
        {
            SpriteRenderer.color = Color.clear;
        }

        public void FireSlot(int slotIndex)
        {
            SpriteRenderer.color = Color.white;
            transform.position = Vector3.down * distance + slotIndex switch
            {
                0 => Vector3.left * 1.2f,
                1 => Vector3.left * 0.5f,
                2 => Vector3.right * 0.5f,
                3 => Vector3.right * 1.2f,
                _ => transform.position
            };
            _moving = true;
        }

        private void FixedUpdate()
        {
            if (_moving) transform.Translate(Vector3.up * Time.fixedDeltaTime);
        }
    }
}