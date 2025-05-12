using UnityEngine;
using UnityEngine.InputSystem;  // Asegúrate de agregar esta referencia

public class CamaraLock : MonoBehaviour
{
    public float mouseSensitivy = 80f;
    public Transform playerBody;
    float xRotation = 0;

    private Mouse currentMouse;  // Variable para almacenar la información del ratón

    void Start()
    {
        // Obtener el ratón del nuevo sistema de entrada
        currentMouse = Mouse.current;
    }

    void Update()
    {
        // Obtener la entrada del ratón usando el Input System
        float mouseX = currentMouse.delta.x.ReadValue() * mouseSensitivy * Time.deltaTime;
        float mouseY = currentMouse.delta.y.ReadValue() * mouseSensitivy * Time.deltaTime;

        // Rotación de la cámara en el eje X (vertical)
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);  // Limitar la rotación

        // Aplicar la rotación de la cámara
        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        // Rotar el cuerpo del jugador en el eje Y (horizontal)
        playerBody.Rotate(Vector3.up * mouseX);
    }
}
