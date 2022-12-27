using DG.Tweening;
using UnityEngine;

namespace Arean.Player
{
    public class PlayerControlller : MonoBehaviour
    {
        [SerializeField] private PlayerAttackController m_PlayerAttackController;
        [SerializeField] private PlayerAnimController m_PlayerAnimController;
        [SerializeField] private PlayerData m_PlayerData;
        private Touch _touch;
        private float _screenWidth; 

        private void Start()
        {
            _screenWidth = Screen.width / 2f;
        }
        private void Update()
        {
            if (Input.touchCount > 0f)
            {
                _touch = Input.GetTouch(0);

                if (_touch.position.x > _screenWidth)
                {
                    Move(-1);
                    m_PlayerAnimController.RunRight();
                }
                else
                {
                    Move(1);
                    m_PlayerAnimController.RunLeft();
                }
            }
            else
            {
                m_PlayerAnimController.Idle();
                m_PlayerAttackController.Attack();
            }
        }
        private void Move(int horizontal)
        {
            transform.Rotate(0, horizontal * m_PlayerData.m_PlayerSpeed *Time.deltaTime, 0);
        }
    }

    internal class PlayerAnimControlller
    {
    }
}
