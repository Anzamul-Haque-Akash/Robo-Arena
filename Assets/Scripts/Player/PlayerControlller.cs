using UnityEngine;

namespace Arean.Player
{
    public class PlayerControlller : MonoBehaviour
    {
        [SerializeField] private PlayerData m_PlayerData;
        private Touch _touch;
        private float _screenWidth; 

        private void Start()
        {
            _screenWidth = Screen.width / 2f;
        }
        private void Update()
        {
            _touch = Input.GetTouch(0);
            
            if(_touch.position.x > _screenWidth && Input.touchCount > 0f) Move(-1);
            else if(Input.touchCount > 0f) Move(1);
        }
        private void Move(int horizontal)
        {
            transform.Rotate(0, horizontal * m_PlayerData.m_PlayerSpeed *Time.deltaTime, 0);
        }
    }
}
