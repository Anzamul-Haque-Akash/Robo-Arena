using Arean.Collectable_Object;
using Arean.Interfaces;
using Arean.Player;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

namespace Arean.Others
{
    public class Attack : MonoBehaviour
    {
        [SerializeField] private PlayerData m_PlayerData;
        [SerializeField] private CollectableObjectController m_CollectableObjectController;
        [SerializeField] private Transform m_Bulletosition;
        [SerializeField] private ParticleSystem m_GreenBulletPartical;
        [SerializeField] private ParticleSystem m_Explotion;
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
        }
        public void DoAttack()
        {
            m_PlayerData.m_CollictiveCount--;
            
            ParticleSystem bulletPartical = Instantiate(m_GreenBulletPartical, m_Bulletosition.position, quaternion.identity);
            bulletPartical.Simulate(0);
            bulletPartical.Play();
            bulletPartical.transform.DOMove(_hit.point, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
            {
                ParticleSystem explotion = Instantiate(m_Explotion, _hit.point, quaternion.identity);
                explotion.Simulate(0);
                explotion.Play();
                DOVirtual.DelayedCall(3f, delegate
                {
                    Destroy(bulletPartical.gameObject);
                    Destroy(explotion.gameObject);
                }, false);
            }); 
                    
            m_CollectableObjectController.SpawnObject();
        }
    }
}