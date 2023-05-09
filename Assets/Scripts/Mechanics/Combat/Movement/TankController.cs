using DefaultNamespace;
using UDT.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Movement
{
    [RequireStandardComponent(typeof(Weapon))]
    public class TankController : StandardComponent<TankControllerData>
    {
        [SerializeField] private float moveSpeed = 10f;
        [SerializeField] private float turnSpeed = 10f;
        [SerializeField] private Weapon weapon;

        private Rigidbody tankBody;

        private void Awake()
        {
            tankBody = GetComponent<Rigidbody>();
        }

        private void FixedUpdate()
        {
            // Do nothing if there is no input
        }

        private void MoveTank(Vector2 direction, float speed)
        {
            // Calculate the forward/backward movement vector based on the input direction
            Vector3 movement = new Vector3(direction.x, 0f, direction.y) * speed * Time.fixedDeltaTime;

            // Calculate the rotation vector based on the input direction
            Quaternion rotation = Quaternion.LookRotation(movement);

            // Apply the movement and rotation to the tank body
            tankBody.MovePosition(tankBody.position + movement);
            tankBody.MoveRotation(rotation);
        }

        public void OnInputAction(InputAction.CallbackContext context)
        {
            if (context.action.name == "Move")
            {
                Vector2 direction = context.ReadValue<Vector2>();
                MoveTank(direction, moveSpeed);
            }
            else if (context.action.name == "Fire" && context.started)
            {
                weapon.Fire();
            }
        }
    }
}