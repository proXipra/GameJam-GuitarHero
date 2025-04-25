using _Scripts.Manager;
using UnityEngine;

public class IncomingSlot : MonoBehaviour
{
    [SerializeField] private float distance;

    private float speed => distance / GameManager.Instance.Period;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }

    private void FixedUpdate()
    {
        transform.Translate(Vector3.left * 0.02f * GameManager.Instance.Period);
    }
}
