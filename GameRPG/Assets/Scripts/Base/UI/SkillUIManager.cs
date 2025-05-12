using UnityEngine;
using UnityEngine.UI;

public class SkillUIManager : MonoBehaviour
{
    // Referencias a los íconos de las habilidades
    public Image[] skillIcons;
    public Text[] skillCooldownText;

    private float[] cooldownTimers;
    private float[] skillCooldowns;

    void Start()
    {
        // Inicializamos el arreglo de cooldowns y timers
        cooldownTimers = new float[skillIcons.Length];
        skillCooldowns = new float[skillIcons.Length];

        // Inicializamos los cooldowns de las habilidades (esto se debe ajustar según cada habilidad)
        for (int i = 0; i < skillCooldowns.Length; i++)
        {
            skillCooldowns[i] = 5f; // Puedes ajustar estos valores a la duración del cooldown de cada habilidad
        }
    }

    void Update()
    {
        // Actualizamos cada habilidad
        for (int i = 0; i < skillIcons.Length; i++)
        {
            // Si la habilidad está en cooldown
            if (cooldownTimers[i] > 0)
            {
                // Reducir el tiempo del cooldown
                cooldownTimers[i] -= Time.deltaTime;

                // Actualiza la imagen del ícono con un color gris
                skillIcons[i].color = new Color(1f, 1f, 1f, Mathf.Lerp(0.5f, 1f, cooldownTimers[i] / skillCooldowns[i]));

                // Actualizar el texto del cooldown
                skillCooldownText[i].text = Mathf.Ceil(cooldownTimers[i]).ToString("F0");
            }
            else
            {
                // Si no está en cooldown, mostrar el ícono normal
                skillIcons[i].color = Color.white;
                skillCooldownText[i].text = "";
            }
        }
    }

    // asignar los íconos de las habilidades y sus tiempos de cooldown
    public void SetSkillIcon(int index, Sprite icon, float cooldown)
    {
        if (index < skillIcons.Length)
        {
            skillIcons[index].sprite = icon;
            skillCooldowns[index] = cooldown;
        }
    }

    // activar el cooldown de una habilidad
    public void TriggerCooldown(int index)
    {
        if (index < cooldownTimers.Length)
        {
            cooldownTimers[index] = skillCooldowns[index];
        }
    }

    // verificar si una habilidad está lista para ser usada
    public bool IsSkillReady(int index)
    {
        return cooldownTimers[index] <= 0;
    }
}
