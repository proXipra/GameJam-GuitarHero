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
            var otherCollider = Physics2D.OverlapBox(transform.position, _workSpace,
                0, slotLayer);
            if (otherCollider) otherCollider.GetComponent<Slot>().DestroySlot();
        }
    }
}