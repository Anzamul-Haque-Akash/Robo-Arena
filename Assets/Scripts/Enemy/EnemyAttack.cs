using Arean.Interfaces;
using DG.Tweening;
using Unity.Mathematics;
using UnityEngine;

namespace Arean.Enemy
{
    public class EnemyAttack : MonoBehaviour
    {
        [SerializeField] private ParticleSystem m_EnemyBulletPartical;
        [SerializeField] private Transform m_EnemyBulletPosition;
        [SerializeField] private Transform m_PlayerPosition;

        private void OnTriggerEnter(Collider other)
        {
            IDamageable iDamageable = other.GetComponent<IDamageable>();
            if (iDamageable != null)
            {
                iDamageable.OnHit();
                DoAttack();
            }
        }
        public void DoAttack()
        {
            ParticleSystem bulletPartical = Instantiate(m_EnemyBulletPartical, m_EnemyBulletPosition.position, quaternion.identity);
            bulletPartical.Simulate(0);
            bulletPartical.Play();
            bulletPartical.transform.DOMove(m_PlayerPosition.position, 0.05f).SetEase(Ease.Linear).OnComplete(() =>
            {
                DOVirtual.DelayedCall(3f, delegate
                {
                    Destroy(bulletPartical.gameObject);
                }, false);
            });
        }
    }
}