using UnityEngine;

public class Knife : MonoBehaviour
{
    public float speed = 15f;
    public float lifetime = 3f;

    void Start()
    {
        // Destruir el cuchillo después de X segundos
        Destroy(gameObject, lifetime);
    }

    void Update()
    {
        // Mover el cuchillo hacia adelante
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }
}
