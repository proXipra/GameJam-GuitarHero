using System;
using System.Collections.Generic;
using _Scripts.Manager;
using UnityEngine;
using Random = UnityEngine.Random;

namespace _Scripts.Slots
{
    public class SlotSpawner : MonoBehaviour
    {
        [SerializeField] private Slot slot;
        [SerializeField] private float distance;
        
        private Queue<Slot> _slotInstances = new Queue<Slot>();
        
        private void Start()
        {
            for (int i = 0; i < 300; i++)
            {
                var slotInstance = Instantiate(slot, transform);
                slotInstance.distance = distance;
                _slotInstances.Enqueue(slotInstance);
            }
            InvokeRepeating(nameof(SpawnSlot), 3, GameManager.Instance.Period);
        }

        private void SpawnSlot()
        {
            if (_slotInstances.TryPeek(out _)) _slotInstances.Dequeue().FireSlot(Random.Range(0, 4));
        }
    }
}