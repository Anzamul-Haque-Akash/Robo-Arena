using DG.Tweening;
using UnityEngine;

namespace Arean.Enemy
{
    public class EnemyScarchSystem : MonoBehaviour
    {

        [SerializeField] private EnemyAnimComtroller m_EnemyAnimComtroller;

        private float _delayedCallTime;
        private Vector3 _lookPosition;
        
        private void Start()
        {
            _delayedCallTime = UnityEngine.Random.Range(2f, 5f);
            OnLook(_delayedCallTime);
        }
        private void OnLook(float t)
        {
            _lookPosition = Vector3.zero;
            _lookPosition.y = UnityEngine.Random.Range(0f, 360f);
            
            DOVirtual.DelayedCall(t, delegate
            {
                m_EnemyAnimComtroller.TrunLeft();
                
                transform.DORotate(_lookPosition, 1f).OnComplete(() =>
                {
                    m_EnemyAnimComtroller.Idle();
                    
                    _delayedCallTime = UnityEngine.Random.Range(2f, 10f);
                    OnLook(_delayedCallTime);
                });
                
            }, false);
        }
        
    }
}