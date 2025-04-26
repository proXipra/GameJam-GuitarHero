using System;
using System.Linq;
using _Scripts.Manager;
using _Scripts.PlayerControls;
using _Scripts.Slots;
using UnityEngine;

namespace _Scripts.Entities
{
    public class SlotScanner : MonoBehaviour
    {
        [SerializeField] private LayerMask slotLayer;
        
        private Vector2 _workSpace = new (4, 0.01f);
        
        private void Start()
        {
            InputHandler.Instance.OnPrimaryInput += HandleOnPrimaryInput;
            InputHandler.Instance.OnSecondaryInput += HandleOnSecondaryInput;
            InputHandler.Instance.OnTertiaryInput += HandleOnTertiaryInput;
            InputHandler.Instance.OnQuaternaryInput += HandleOnQuaternaryInput;
        }

        private void OnDisable()
        {
            InputHandler.Instance.OnPrimaryInput -= HandleOnPrimaryInput;
            InputHandler.Instance.OnSecondaryInput -= HandleOnSecondaryInput;
            InputHandler.Instance.OnTertiaryInput -= HandleOnTertiaryInput;
            InputHandler.Instance.OnQuaternaryInput -= HandleOnQuaternaryInput;
        }

        private void HandleOnPrimaryInput()
        {
            var otherColliders = Physics2D.OverlapBoxAll(transform.position, _workSpace,
                0, slotLayer);
            var filteredColliders = otherColliders.Where(v => v.GetComponent<Slot>().index == 0).ToArray();
            if (filteredColliders.Length == 0)
            {
                GameManager.Instance.score--;
                return;
            }
            foreach (var otherCollider in filteredColliders)
            {
                otherCollider.GetComponent<Slot>().caught = true;
                GameManager.Instance.score++;
                otherCollider.GetComponent<Slot>().DestroySlot();
            }
        }
        
        private void HandleOnSecondaryInput()
        {
            var otherColliders = Physics2D.OverlapBoxAll(transform.position, _workSpace,
                0, slotLayer);
            var filteredColliders = otherColliders.Where(v => v.GetComponent<Slot>().index == 1).ToArray();
            if (filteredColliders.Length == 0)
            {
                GameManager.Instance.score--;
                return;
            }
            foreach (var otherCollider in filteredColliders)
            {
                otherCollider.GetComponent<Slot>().caught = true;
                GameManager.Instance.score++;
                otherCollider.GetComponent<Slot>().DestroySlot();
            }
        }
        
        private void HandleOnTertiaryInput()
        {
            var otherColliders = Physics2D.OverlapBoxAll(transform.position, _workSpace,
                0, slotLayer);
            var filteredColliders = otherColliders.Where(v => v.GetComponent<Slot>().index == 2).ToArray();
            if (filteredColliders.Length == 0)
            {
                GameManager.Instance.score--;
                return;
            }
            foreach (var otherCollider in filteredColliders)
            {
                otherCollider.GetComponent<Slot>().caught = true;
                GameManager.Instance.score++;
                otherCollider.GetComponent<Slot>().DestroySlot();
            }
        }
        
        private void HandleOnQuaternaryInput()
        {
            var otherColliders = Physics2D.OverlapBoxAll(transform.position, _workSpace,
                0, slotLayer);
            var filteredColliders = otherColliders.Where(v => v.GetComponent<Slot>().index == 3).ToArray();
            if (filteredColliders.Length == 0)
            {
                GameManager.Instance.score--;
                return;
            }
            foreach (var otherCollider in filteredColliders)
            {
                otherCollider.GetComponent<Slot>().caught = true;
                GameManager.Instance.score++;
                otherCollider.GetComponent<Slot>().DestroySlot();
            }
        }

        private void OnTriggerExit2D(Collider2D other)
        {
            if ((slotLayer.value & 1 << other.gameObject.layer) != 0 && !other.GetComponent<Slot>().caught)
            {
                GameManager.Instance.score--;
            }
        }
    }
}