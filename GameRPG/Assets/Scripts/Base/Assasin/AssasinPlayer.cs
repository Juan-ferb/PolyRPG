using UnityEngine;
using UnityEngine.InputSystem;

public class AssasinPlayer : PlayerBase, ICharacterAbilities
{
    public GameObject knifePrefab;
    public GameObject poisonAreaPrefab;
    public float healAmount = 20f;

    private PlayerStats playerStats;

    protected override void Start()
    {
        base.Start();
        playerStats = GetComponentInParent<PlayerStats>();

        if (playerStats == null)
        {
            Debug.LogError("PlayerStats no encontrado en el padre del Assasin.");
        }
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
