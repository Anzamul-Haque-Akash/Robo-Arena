using Arean.Interfaces;
using Arean.Player;
using UnityEngine;

namespace Arean.Others
{
    public class Collector : MonoBehaviour
    {
        [SerializeField] private PlayerData m_PlayerData;
        private void OnTriggerEnter(Collider other)
        {
            ICollectable iCollectable = other.GetComponent<ICollectable>();
            iCollectable.OnCollect();
            m_PlayerData.m_CollictiveCount++;
        }
    }
}