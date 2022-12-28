using System;
using Arean.Interfaces;
using UnityEngine;

namespace Arean.Others
{
    public class PlayerBehavior : MonoBehaviour, IDamageable
    {
        [SerializeField] private Animator m_Anim;
        [SerializeField] private float m_Health = 1f;
        [SerializeField] private float m_DamageAmount = 0.5f;

        public event Action<float> OnDamage; 

        public void OnHit()
        {
            OnDamage?.Invoke(m_DamageAmount);
            
            m_Health -= m_DamageAmount;
            if(m_Health  <= 0f) Die();
        }
        private void Die()
        {
            m_Anim.SetTrigger("isDeath");
            Debug.Log("Death");
        }
    }
}