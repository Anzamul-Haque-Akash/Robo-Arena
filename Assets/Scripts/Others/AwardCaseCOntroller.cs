using Arean.Interfaces;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;

namespace Arean.Others
{
    public class AwardCaseCOntroller : MonoBehaviour, IExplotionable
    {
        [SerializeField] private GameObject m_BrokenClass;
        [SerializeField] private GameObject m_ActualGlass;
        [SerializeField] private Transform m_ForcePoint;
        private Rigidbody[] _rbs;

        [SerializeField] private ParticleSystem m_AwardCaseExplotionPartical;

        [SerializeField] private Transform m_Gun;
        [SerializeField] private GameData m_GameData;

        private bool _canExplotion;
        
        private void Start()
        {
            _canExplotion = true;
            m_GameData.m_EnemyCount = 1;
            
            m_Gun.DORotate(new Vector3(0f, 360f, 0f), 3f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear);
            
            _rbs = m_BrokenClass.GetComponentsInChildren<Rigidbody>();
            foreach (Rigidbody rb in _rbs)
            {
                rb.isKinematic = true;
            }
        }
        private void Update()
        {
            if (m_GameData.m_EnemyCount <= 0 && _canExplotion)
            {
                _canExplotion = false;
                OnExplotion();
            }
        }
        [Button]
        public void OnExplotion()
        {
            DOVirtual.DelayedCall(1f, delegate
            {
                m_AwardCaseExplotionPartical.Simulate(0);
                m_AwardCaseExplotionPartical.Play();

                DOVirtual.Float(0.8f, 1.5f, 0.2f, delegate(float value)
                {
                    m_AwardCaseExplotionPartical.transform.localScale = new Vector3(value, value, value);
                }).SetEase(Ease.Linear).SetLoops(4, LoopType.Yoyo).OnComplete(() =>
                {
                    DOVirtual.Float(0.8f, 3f, 0.5f, delegate(float value)
                    {
                        m_AwardCaseExplotionPartical.transform.localScale = new Vector3(value, value, value);
                    }).SetEase(Ease.Linear).OnComplete(()=>
                    {
                        m_AwardCaseExplotionPartical.transform.DOScale(new Vector3(0f, 0f, 0f), 0.2f).SetEase(Ease.Linear);
                        
                        m_BrokenClass.SetActive(true);
                        m_ActualGlass.SetActive(false);
                
                        foreach (Rigidbody rb in _rbs)
                        {
                            rb.isKinematic = false;
                            rb.AddExplosionForce(1500f, m_ForcePoint.position, 10f);
                        }
                    });
                });
            }, false);
        }
    }
}