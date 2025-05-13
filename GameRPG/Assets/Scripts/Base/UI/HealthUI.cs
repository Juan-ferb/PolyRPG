using UnityEngine;
using UnityEngine.UI;

public class HealthUI : MonoBehaviour
{

    public PlayerStats playerStats;
    public Image fillImage; // Esta es la imagen que representa la barra de vida.

    private void Start()
    {
        if (playerStats != null)
        {
            // Inicializar la barra de vida al inicio
            UpdateHealthUI(playerStats.GetCurrentHealth(), playerStats.maxHealth);
        }
    }

    public void UpdateHealthUI(int currentHealth, int maxHealth)
    {
        if (fillImage != null)
        {
            // Calculamos el porcentaje de la vida y actualizamos el fillAmount
            float fillAmount = (float)currentHealth / maxHealth;
            fillImage.fillAmount = fillAmount;
        }
    }

    void Update()
    {
        if (playerStats != null && fillImage != null)
        {
            UpdateHealthUI(playerStats.GetCurrentHealth(), playerStats.maxHealth);
        }
    }

}
