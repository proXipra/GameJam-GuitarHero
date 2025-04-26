using UnityEngine;

namespace _Scripts.Manager
{
    public class MovingBox : MonoBehaviour
    {
        [SerializeField] private float distance;

        private void Start()
        {
            GameManager.Instance.OnStartMoving += HandleOnStartMoving;
        }

        private void OnDisable()
        {
            GameManager.Instance.OnStartMoving -= HandleOnStartMoving;
        }

        public void HandleOnStartMoving()
        {
            InvokeRepeating(nameof(MovingBoxUpdate), 3 - GameManager.Instance.Period / 2, 0.01f);
        }
        private void MovingBoxUpdate()
        {
            transform.Translate(Vector3.left * 0.01f * 2 * distance / GameManager.Instance.Period);
            if (transform.position.x <= -distance) transform.position = Vector3.right * distance;
        }
    }
}