using UnityEngine;
using UnityEngine.InputSystem;

public class MagicianPlayer : PlayerBase, ICharacterAbilities
{
    public GameObject fireballPrefab;
    public float fireballSpeed = 15f;
    public float teleportDistance = 10f;
    public float shieldAmount = 50f;

    private Camera mainCamera;
    private CharacterSkillSetup skillSetup;  // Referencia a CharacterSkillSetup

    protected override void Start()
    {
        base.Start();
        mainCamera = Camera.main;
        skillSetup = GetComponent<CharacterSkillSetup>(); // Obtener referencia al CharacterSkillSetup

        // Configurar las habilidades de este personaje
        skillSetup.skillIcons = new Sprite[]
        {
            Resources.Load<Sprite>("Icons/Fireball"),
            Resources.Load<Sprite>("Icons/Teleport"),
            Resources.Load<Sprite>("Icons/Shield")
        };

        skillSetup.skillCooldowns = new float[] { 5f, 10f, 15f };

        skillSetup.SetupCharacterSkills();  // Asignar los íconos y cooldowns a la UI
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

        Ray ray = mainCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        Vector3 targetDirection = ray.direction;

        GameObject fireball = Instantiate(fireballPrefab, transform.position + transform.forward, Quaternion.LookRotation(targetDirection));
        Rigidbody rb = fireball.GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.linearVelocity = targetDirection * fireballSpeed;
        }

        Destroy(fireball, 5f);
        Debug.Log("Magician lanzó una bola de fuego.");
    }

    public void UseSkill2()
    {
        transform.position += transform.forward * teleportDistance;
        Debug.Log("Magician se teletransportó.");
    }

    public void UseSkill3()
    {
        Debug.Log("Magician activó un escudo de " + shieldAmount + " puntos.");
    }
}
