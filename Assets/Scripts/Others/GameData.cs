using UnityEngine;

namespace Arean.Others
{
    [CreateAssetMenu(fileName = "Game Data", menuName = "Scriptable Objects/Game Data")]
    public class GameData : ScriptableObject
    {
        public int m_EnemyCount;
    }
}