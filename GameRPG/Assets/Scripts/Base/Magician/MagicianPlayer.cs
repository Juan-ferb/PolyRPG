using UnityEngine;
using UnityEngine.InputSystem;

public class MagicianPlayer : PlayerBase, ICharacterAbilities
{
    public GameObject fireballPrefab;
    public float fireballSpeed = 15f;
    public float teleportDistance = 10f;
    public float shieldAmount = 50f;

    private Camera mainCamera;

    protected override void Start()
    {
        base.Start();
        mainCamera = Camera.main;
    }

    protected override void Update()
    {
        base.Update();

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            UseSkill1();  // Lanzar bola de fuego

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
            UseSkill2();  // Teletransportarse

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
            UseSkill3();  // Activar escudo
    }

    public void UseSkill1()
    {
        if (mainCamera == null) return;

        // Disparo hacia la mirilla (centro de pantalla)
        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 targetDirection = ray.direction;

        GameObject fireball = Instantiate(fireballPrefab, transform.position + transform.forward, Quaternion.LookRotation(targetDirection));
        Rigidbody rb = fireball.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = targetDirection * fireballSpeed;
        }

        Destroy(fireball, 5f);
        Debug.Log("Magician lanz� una bola de fuego.");
    }

    public void UseSkill2()
    {
        transform.position += transform.forward * teleportDistance;
        Debug.Log("Magician se teletransport�.");
    }

    public void UseSkill3()
    {
        Debug.Log("Magician activ� un escudo de " + shieldAmount + " puntos.");
    }
}
