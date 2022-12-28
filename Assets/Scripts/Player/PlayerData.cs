using Unity.VisualScripting;
using UnityEngine;

namespace Arean.Player
{
    [CreateAssetMenu(fileName = "Player Data", menuName = "Scriptable Objects/Player Data")]
    public class PlayerData : ScriptableObject
    {
        public float m_PlayerSpeed;
        public int m_CollictiveCount;

    }
}
