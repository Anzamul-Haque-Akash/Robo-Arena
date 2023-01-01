using Arean.Interfaces;
using DG.Tweening;
using UnityEngine;

namespace Arean.Collectable_Object
{
    public class CollectableObject : MonoBehaviour, ICollectable
    {
        private void Start()
        {
            transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.5f).SetEase(Ease.InQuad).OnComplete(() =>
            {
                DOVirtual.Float(1.5f, 1f, 1f, delegate(float value)
                {
                    transform.localScale = new Vector3(value, value, value);
                }).SetEase(Ease.Linear).SetLoops(-1, LoopType.Yoyo);
            });
            transform.DORotate(new Vector3(0f, 360f, 0f), 2f, RotateMode.FastBeyond360).
                SetEase(Ease.Linear).SetLoops(-1, LoopType.Restart);
        }
        public void OnCollect()
        {
            transform.DOScale(new Vector3(0f, 0f, 0f), 0.2f).SetEase(Ease.Linear).OnComplete(() =>
            {
                transform.position = Vector3.zero;
                transform.gameObject.SetActive(false);
                transform.DOScale(new Vector3(1.2f, 1.2f, 1.2f), 0.1f);
                
                Destroy(gameObject);
            });
        }
        
    }
}