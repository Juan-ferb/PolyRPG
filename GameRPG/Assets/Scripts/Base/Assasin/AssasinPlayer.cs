using UnityEngine;
using UnityEngine.InputSystem;

public class AssasinPlayer : PlayerBase, ICharacterAbilities
{
    public GameObject knifePrefab;
    public GameObject poisonAreaPrefab;
    public float healAmount = 20f;

    protected override void Update()
    {
        base.Update();  // Mantener movimiento base

        if (Keyboard.current.qKey.wasPressedThisFrame)
            UseSkill1();  // Habilidad 1: Lanzar cuchillo

        if (Keyboard.current.eKey.wasPressedThisFrame)
            UseSkill2();  // Habilidad 2: Veneno

        if (Keyboard.current.rKey.wasPressedThisFrame)
            UseSkill3();  // Habilidad 3: Curarse
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
 
        Debug.Log("Assassin se curó " + healAmount + " puntos de vida.");
    }
}
