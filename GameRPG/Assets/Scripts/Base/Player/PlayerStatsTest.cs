using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerStatsTest : MonoBehaviour
{
    public PlayerStats playerStats;

    void Update()
    {
        // Usamos las teclas T para aplicar daño y Y para curarse
        if (Keyboard.current.tKey.wasPressedThisFrame)
        {
            // Aplica daño de ejemplo, por ejemplo, 10 de daño
            playerStats.TakeDamage(10);
        }

        if (Keyboard.current.yKey.wasPressedThisFrame)
        {
            // Aplica curación de ejemplo, por ejemplo, 10 de curación
            playerStats.Heal(10);
        }
    }
}
