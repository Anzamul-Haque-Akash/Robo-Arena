using Arean.Collectable_Object;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

namespace Arean.Player
{
    public class PlayerAttackController : MonoBehaviour
    {
        [SerializeField] private PlayerData m_PlayerData;
        [SerializeField] private PlayerAnimController m_PlayerAnimController;
        [SerializeField] private CollectableObjectController m_CollectableObjectController;
        [SerializeField] private Transform m_Bulletosition;
        [SerializeField] private ParticleSystem m_GreenBulletPartical;

        public void Attack()
        {
            if (m_PlayerData.m_CollictiveCount > 0)
            {
                m_PlayerAnimController.Attack();
                DOVirtual.DelayedCall(0.8f, delegate
                {
                    ParticleSystem p = Instantiate(m_GreenBulletPartical, m_Bulletosition.position, quaternion.identity);
                    p.Simulate(0);
                    p.Play();
                    p.transform.DOMove(new Vector3(transform.position.x, transform.position.y + 0.8f, transform.position.z), 0.2f); 
                    
                    m_CollectableObjectController.SpawnObject();
                    
                }, false);
                
                m_PlayerData.m_CollictiveCount--;
            }
        }
        
    }
}