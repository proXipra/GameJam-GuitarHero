using System;
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
            InvokeRepeating(nameof(MovingBoxUpdate), 3 - (GameManager.Instance.Period - GameManager.Instance.window) / 2, 0.01f);
            InvokeRepeating(nameof(ResetPosition), 3 - (GameManager.Instance.Period - GameManager.Instance.window) / 2, GameManager.Instance.Period);

        }
        private void MovingBoxUpdate()
        {
            transform.Translate(Vector3.left * 0.01f * 2 * distance / GameManager.Instance.Period);
            
        }


        private void ResetPosition()
        {
            transform.position = Vector3.right * distance;
        }
    }
}