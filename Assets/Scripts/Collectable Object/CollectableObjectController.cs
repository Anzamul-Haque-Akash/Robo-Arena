using System.Collections.Generic;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Arean.Collectable_Object
{
    public class CollectableObjectController : MonoBehaviour
    {
        [SerializeField] private GameObject m_ColectableObject1;
        [SerializeField] private float m_UpOffset;
        [SerializeField] private float m_Radius;
        
        private Vector3 _position;
        private Vector2 _direction;
        private void Start()
        {
            SpawnObject();
        }
        [Button]
        public void SpawnObject()
        {
            DOVirtual.DelayedCall(2f, delegate
            {
                GameObject obj = Instantiate(m_ColectableObject1, Vector3.zero, Quaternion.identity);

                _direction = Random.insideUnitCircle.normalized;
                _position = new Vector3((_direction.x * m_Radius), m_UpOffset, (_direction.y * m_Radius));
                obj.transform.position = _position;
                obj.SetActive(true);
                
            }, false);
        }
        #region Gizmos
        [Title("GIZMOS")]
        public float m_GexplosionRadius;
        public Vector3 m_Gposition;
        void OnDrawGizmosSelected()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireSphere(m_Gposition, m_GexplosionRadius);
        }
        #endregion
    }
}