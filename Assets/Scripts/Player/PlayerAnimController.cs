using Arean.Others;
using TGF.Utilities;
using UnityEngine;

namespace Arean.Player
{
    public class PlayerAnimController : MonoBehaviour
    {
        [SerializeField] private Animator m_Anim;

        public void RunLeft()
        {
            m_Anim.SetParameter(AnimHashes.IsRunLeft , true, AnimatorParamType.Bool);
            m_Anim.SetParameter(AnimHashes.IsRunRight , false, AnimatorParamType.Bool);
        }
        public void RunRight()
        {
            m_Anim.SetParameter(AnimHashes.IsRunRight , true, AnimatorParamType.Bool);
            m_Anim.SetParameter(AnimHashes.IsRunLeft , false, AnimatorParamType.Bool);
        }
        public void Idle()
        {
            m_Anim.SetParameter(AnimHashes.IsRunRight , false, AnimatorParamType.Bool);
            m_Anim.SetParameter(AnimHashes.IsRunLeft , false, AnimatorParamType.Bool);
        }
    }
}