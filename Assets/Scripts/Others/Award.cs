using DG.Tweening;
using UnityEngine;

namespace Arean.Others
{
    public class Award : MonoBehaviour
    {
        private void Start()
        {
            transform.DORotate(new Vector3(0f, 360f, 0f), 4f, RotateMode.FastBeyond360).SetLoops(-1, LoopType.Restart)
                .SetEase(Ease.Linear);
        }
    }
}