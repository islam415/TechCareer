using UnityEngine;

namespace DefaultNamespace
{
    public class CharacterController : MonoBehaviour
    {
        [SerializeField] private float _speed = 2f;

        private Animator _playerAnim;
        private Rigidbody _rb;

        private void Awake()
        {
            _playerAnim = GetComponent<Animator>();
            _rb = GetComponent<Rigidbody>();
        }

        private void Update()
        {
            if (Input.touchCount < 1) return;
            Touch touch = Input.GetTouch(0);

            if (touch.phase == TouchPhase.Began)
                _playerAnim.SetBool("isWalking", true);

            else if (touch.phase == TouchPhase.Stationary)
            {
                Vector3 movement = _rb.velocity;
                movement.z = _speed;
                _rb.velocity = movement;
            }

            else if (touch.phase == TouchPhase.Ended)
            {
                _playerAnim.SetBool("isWalking", false);
                _rb.velocity = Vector3.zero;
            }
        }
    }
}