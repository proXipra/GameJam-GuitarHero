using System;
using _Scripts.Manager;
using _Scripts.PlayerControls;
using _Scripts.Slots;
using UnityEngine;

namespace _Scripts.Entities
{
    public class SlotScanner : MonoBehaviour
    {
        [SerializeField] private LayerMask slotLayer;
        
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
            var otherColliders = Physics2D.OverlapBoxAll(transform.position, _workSpace,
                0, slotLayer);
            if (otherColliders.Length == 0)
            {
                GameManager.Instance.score--;
                Debug.Log("Fuc");
                return;
            }
            foreach (var otherCollider in otherColliders)
            {
                otherCollider.GetComponent<Slot>().caught = true;
                GameManager.Instance.score++;
                Debug.Log("Yea");
                otherCollider.GetComponent<Slot>().DestroySlot();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if ((slotLayer.value & 1 << other.gameObject.layer) != 0 && !other.GetComponent<Slot>().caught)
            {
                GameManager.Instance.score--;
                Debug.Log("Noo");
            }
        }
    }
}