using Arean.Interfaces;
using UnityEngine;

namespace Arean.Player
{
    public class Collector : MonoBehaviour
    {
        [SerializeField] private PlayerData m_PlayerData;
        private void OnTriggerEnter(Collider other)
        {
            ICollectable iCollectable = other.GetComponent<ICollectable>();
            if (iCollectable != null)
            {
                iCollectable.OnCollect();
                m_PlayerData.m_CollictiveCount++;
            }
        }
    }
}