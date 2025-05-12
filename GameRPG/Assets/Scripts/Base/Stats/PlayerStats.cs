using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public int maxHealth = 200;
    protected int currentHealth;

    [Header("Health UI Reference")]
    public HealthUI healthUI; // Referencia al script que actualiza la barra de vida.

    protected virtual void Start()
    {
        currentHealth = maxHealth;

        // Asegúrate de que la barra de vida esté actualizada desde el inicio
        if (healthUI != null)
        {
            healthUI.UpdateHealthUI(currentHealth, maxHealth);
        }
    }

    public virtual void TakeDamage(int amount)
    {
        currentHealth -= amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log(gameObject.name + " recibió " + amount + " de daño. Vida restante: " + currentHealth);

        // Actualizamos la UI de la vida
        if (healthUI != null)
        {
            healthUI.UpdateHealthUI(currentHealth, maxHealth);
        }

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public virtual void Heal(int amount)
    {
        currentHealth += amount;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log(gameObject.name + " se curó " + amount + " de vida. Vida actual: " + currentHealth);

        // Actualizamos la UI de la vida
        if (healthUI != null)
        {
            healthUI.UpdateHealthUI(currentHealth, maxHealth);
        }
    }

    protected virtual void Die()
    {
        Debug.Log(gameObject.name + " ha muerto.");
        // Aquí puedes desactivar el objeto, reproducir animación, etc.
    }

    public int GetCurrentHealth()
    {
        return currentHealth;
    }
}
