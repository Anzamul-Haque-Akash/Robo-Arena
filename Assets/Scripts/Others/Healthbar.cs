using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.UI;

namespace Arean.Others
{
    public class Healthbar : MonoBehaviour
    {
        [SerializeField] private PlayerBehavior m_PlayerBehavior;
        [SerializeField] private Image m_HealthbarSprite;
        private Camera _cam;
        
        private void Start()
        {
            _cam = Camera.main;

            m_PlayerBehavior.OnDamage += UpdateHealthbar;
        }
        private void Update()
        {
            transform.rotation = Quaternion.LookRotation(transform.position - _cam.transform.position);
        }
        
        [Button]
        public void UpdateHealthbar(float damageAmount)
        {
            float currentHealth = m_HealthbarSprite.fillAmount;
            
            DOVirtual.Float(currentHealth, currentHealth - damageAmount, 0.5f, delegate(float value)
            {
                m_HealthbarSprite.fillAmount = value;

                // if (m_HealthbarSprite.fillAmount <= 0)
                // {
                //     Debug.Log("Death");
                //
                //     GameObject obj = transform.root.gameObject;
                //     Destroy(obj);
                // }
            });
        }
    }
}