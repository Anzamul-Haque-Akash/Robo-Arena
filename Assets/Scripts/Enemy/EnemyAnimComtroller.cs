using Arean.Others;
using TGF.Utilities;
using UnityEngine;

namespace Arean.Enemy
{
    public class EnemyAnimComtroller : MonoBehaviour
    {
        [SerializeField] private Animator m_Anim;
        public void TrunLeft()
        {
            m_Anim.SetParameter(AnimHashes.IsRunLeft , true, AnimatorParamType.Bool);
        }
        public void Idle()
        {
            m_Anim.SetParameter(AnimHashes.IsRunLeft , false, AnimatorParamType.Bool);
        }
    }
}