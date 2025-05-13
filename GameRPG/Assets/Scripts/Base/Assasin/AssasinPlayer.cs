using UnityEngine;
using UnityEngine.InputSystem;

public class AssasinPlayer : PlayerBase, ICharacterAbilities
{
    public GameObject knifePrefab;
    public GameObject poisonAreaPrefab;
    public float healAmount = 50f;

    private PlayerStats playerStats;
    private CharacterSkillSetup skillSetup;  // Referencia a CharacterSkillSetup

    protected override void Start()
    {
        base.Start();
        playerStats = GetComponentInParent<PlayerStats>();
        skillSetup = GetComponentInChildren<CharacterSkillSetup>(); // Buscar también en hijos

        if (playerStats == null)
        {
            Debug.LogError("PlayerStats no encontrado en el padre del Assasin.");
        }

        if (skillSetup == null)
        {
            Debug.LogError("CharacterSkillSetup no encontrado. Asegúrate de que esté en este objeto o en sus hijos.");
            return; // Detener ejecución para evitar errores
        }

        // Configurar las habilidades de este personaje
        skillSetup.skillIcons = new Sprite[]
        {
            Resources.Load<Sprite>("Icons/knife"),
            Resources.Load<Sprite>("Icons/Poison"),
            Resources.Load<Sprite>("Icons/Heal")
        };

        skillSetup.skillCooldowns = new float[] { 5f, 10f, 15f };

        skillSetup.SetupCharacterSkills();  // Asignar los íconos y cooldowns a la UI
    }

    protected override void Update()
    {
        base.Update();

        if (Keyboard.current.digit1Key.wasPressedThisFrame)
            UseSkill1();  // Lanzar cuchillo

        if (Keyboard.current.digit2Key.wasPressedThisFrame)
            UseSkill2();  // Área de veneno

        if (Keyboard.current.digit3Key.wasPressedThisFrame)
            UseSkill3();  // Curarse
    }

    public void UseSkill1()
    {
        Instantiate(knifePrefab, transform.position + transform.forward, transform.rotation);
        Debug.Log("Assassin lanzó un cuchillo.");
    }

    public void UseSkill2()
    {
        Instantiate(poisonAreaPrefab, transform.position, Quaternion.identity);
        Debug.Log("Assassin creó un área de veneno.");
    }

    public void UseSkill3()
    {
        if (playerStats != null)
        {
            playerStats.Heal((int)healAmount);
        }
    }
}
