using UnityEngine;
using UnityEngine.InputSystem;

public class MagicianPlayer : PlayerBase, ICharacterAbilities
{
    public GameObject fireballPrefab;
    public float teleportDistance = 10f;
    public float shieldAmount = 50f;

    protected override void Update()
    {
        base.Update();  // Mantener movimiento base

        if (Keyboard.current.qKey.wasPressedThisFrame)
            UseSkill1();  // Habilidad 1: Lanzar bola de fuego

        if (Keyboard.current.eKey.wasPressedThisFrame)
            UseSkill2();  // Habilidad 2: Teletransportarse

        if (Keyboard.current.rKey.wasPressedThisFrame)
            UseSkill3();  // Habilidad 3: Activar escudo
    }

    public void UseSkill1()
    {
        // Implementación específica para el Magician
        Instantiate(fireballPrefab, transform.position + transform.forward, transform.rotation);
        Debug.Log("Magician lanzó una bola de fuego.");
    }

    public void UseSkill2()
    {
        // Implementación específica para el Magician
        transform.position += transform.forward * teleportDistance;
        Debug.Log("Magician se teletransportó.");
    }

    public void UseSkill3()
    {
        // Implementación específica para el Magician
        Debug.Log("Magician activó un escudo de " + shieldAmount + " puntos.");
        // Lógica de escudo aquí
    }
}
