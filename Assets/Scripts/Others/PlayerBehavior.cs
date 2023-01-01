using System;
using Arean.Interfaces;
using DG.Tweening;
using TGF.Utilities;
using UnityEngine;

namespace Arean.Others
{
    public class PlayerBehavior : MonoBehaviour, IDamageable
    {
        [SerializeField] private Animator m_Anim;
        [SerializeField] private float m_Health = 1f;
        [SerializeField] private float m_DamageAmount = 0.25f;
        [SerializeField] private ParticleSystem m_HitPartical;

        [SerializeField] private GameData m_GameData;
        public event Action<float> OnDamage;

        public void OnHit()
        {
            OnDamage?.Invoke(m_DamageAmount);

            DOVirtual.DelayedCall(0.2f, delegate
            {
                m_HitPartical.Simulate(0);
                m_HitPartical.Play();
            }, false);
            
            m_Health -= m_DamageAmount;
            if (m_Health <= 0f)
            {
                Die();
            }
        }
        private void Die()
        {
            m_Anim.SetParameter(AnimHashes.IsDeath , true, AnimatorParamType.Trigger);

            if (m_Anim.gameObject.CompareTag("Enemy"))
            {
                m_GameData.m_EnemyCount--;
            }

            DOVirtual.DelayedCall(1.5f, delegate
            {
                transform.DOScale(0f, 0.2f).SetEase(Ease.Linear).OnComplete(() =>
                {
                    gameObject.SetActive(false);
                });
            }, false);
        }
    }
}