using Arean.Collectable_Object;
using Arean.Interfaces;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

namespace Arean.Player
{
    public class PlayerAttack : MonoBehaviour
    {
        [SerializeField] private PlayerData m_PlayerData;
        [SerializeField] private CollectableObjectController m_CollectableObjectController;
        [SerializeField] private Transform m_Bulletosition;
        [SerializeField] private ParticleSystem m_GreenBulletPartical;
        [SerializeField] private Transform m_RayStartPoint;
        [SerializeField] private LayerMask m_EnemyLayerMask = 3;

        private RaycastHit _hit;

         private void FixedUpdate()
        {
            if (Physics.Raycast(m_RayStartPoint.position, m_RayStartPoint.forward, out _hit, 100f, m_EnemyLayerMask))
            {
                IDamageable iDamageable = _hit.collider.GetComponent<IDamageable>();
                if (iDamageable != null && m_PlayerData.m_CollictiveCount > 0)
                {
                    iDamageable.OnHit();
                    DoAttack();
                }
            }

            Debug.DrawRay(m_RayStartPoint.position,m_RayStartPoint.forward * 10f);
        }
        public void DoAttack()
        {
            m_PlayerData.m_CollictiveCount--;
            
            ParticleSystem bulletPartical = Instantiate(m_GreenBulletPartical, m_Bulletosition.position, quaternion.identity);
            bulletPartical.Simulate(0);
            bulletPartical.Play();
            bulletPartical.transform.DOMove(_hit.point, 0.05f).SetEase(Ease.Linear).OnComplete(() =>
            {
                DOVirtual.DelayedCall(3f, delegate
                {
                    Destroy(bulletPartical.gameObject);
                }, false);
            }); 
                    
            m_CollectableObjectController.SpawnObject();
        }
    }
}