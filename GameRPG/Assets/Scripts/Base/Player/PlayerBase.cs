using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBase : MonoBehaviour
{
    protected CharacterController controller;
    public float speed = 10f;
    public float jumpHeight = 3f;
    public float gravity = -9.81f;

    private Vector3 velocity;

    protected virtual void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    protected virtual void Update()
    {
        if (controller == null || !controller.enabled)
            return;

        float x = 0f;
        float z = 0f;

        if (Keyboard.current.aKey.isPressed) x = -1;
        if (Keyboard.current.dKey.isPressed) x = 1;
        if (Keyboard.current.wKey.isPressed) z = 1;
        if (Keyboard.current.sKey.isPressed) z = -1;

        Vector3 move = transform.right * x + transform.forward * z;
        controller.Move(move * speed * Time.deltaTime);

        // Aplicar gravedad
        if (controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;  // evitar que quede flotando
        }

        // Salto
        if (controller.isGrounded && Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;
        controller.Move(velocity * Time.deltaTime);
    }
}
