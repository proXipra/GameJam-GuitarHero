using System;
using UnityEngine;

namespace _Scripts.Slots
{
    public class Slot : MonoBehaviour
    {
        public float targetYDisplacement;

        public float distance;

        private bool _moving;

        public void FireSlot(int slotIndex)
        {
            transform.position = Vector3.down * distance + slotIndex switch
            {
                0 => Vector3.left * 1.5f,
                1 => Vector3.left * 0.5f,
                2 => Vector3.right * 0.5f,
                3 => Vector3.right * 1.5f,
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