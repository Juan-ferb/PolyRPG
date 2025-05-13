using UnityEngine;
using UnityEngine.UI;

public class SkillUIManager : MonoBehaviour
{
    public Image[] skillIcons;           // Iconos visibles de las habilidades
    public Text[] skillCooldownText;     // Texto que muestra el cooldown en segundos

    private float[] cooldownTimers;      // Tiempo restante de cooldown para cada habilidad
    private float[] skillCooldowns;      // Tiempo total de cooldown para cada habilidad

    void Start()
    {
        int skillCount = skillIcons.Length;
        cooldownTimers = new float[skillCount];
        skillCooldowns = new float[skillCount];

        // Asignar cooldowns por defecto
        for (int i = 0; i < skillCount; i++)
        {
            skillCooldowns[i] = 5f;
        }
    }

    void Update()
    {
        for (int i = 0; i < skillIcons.Length; i++)
        {
            if (cooldownTimers[i] > 0)
            {
                cooldownTimers[i] -= Time.deltaTime;

                float alpha = Mathf.Lerp(0.5f, 1f, cooldownTimers[i] / skillCooldowns[i]);
                if (skillIcons[i] != null)
                    skillIcons[i].color = new Color(1f, 1f, 1f, alpha);

                if (skillCooldownText != null && i < skillCooldownText.Length && skillCooldownText[i] != null)
                    skillCooldownText[i].text = Mathf.Ceil(cooldownTimers[i]).ToString("F0");
            }
            else
            {
                if (skillIcons[i] != null)
                    skillIcons[i].color = Color.white;

                if (skillCooldownText != null && i < skillCooldownText.Length && skillCooldownText[i] != null)
                    skillCooldownText[i].text = "";
            }
        }
    }

    public void SetSkillIcon(int index, Sprite icon, float cooldown)
    {
        if (index < skillIcons.Length && skillIcons[index] != null && icon != null)
        {
            skillIcons[index].sprite = icon;
            skillCooldowns[index] = cooldown;
        }
        else
        {
            Debug.LogWarning($"SkillUIManager: skillIcons[{index}] está vacío o el icono es null.");
        }
    }

    public void SetAllSkills(Sprite[] icons, float[] cooldowns)
    {
        if (icons == null || cooldowns == null)
        {
            Debug.LogWarning("SkillUIManager: Los arrays de íconos o cooldowns son null.");
            return;
        }

        for (int i = 0; i < Mathf.Min(skillIcons.Length, icons.Length, cooldowns.Length); i++)
        {
            SetSkillIcon(i, icons[i], cooldowns[i]);
        }
    }

    public void SetSkillIcons(Sprite[] icons)
    {
        for (int i = 0; i < skillIcons.Length && i < icons.Length; i++)
        {
            if (skillIcons[i] != null && icons[i] != null)
            {
                skillIcons[i].sprite = icons[i];
                skillIcons[i].color = Color.white; // Asegura que se vea correctamente
            }
        }
    }

    public void TriggerCooldown(int index)
    {
        if (index < cooldownTimers.Length && index < skillCooldowns.Length)
        {
            cooldownTimers[index] = skillCooldowns[index];
        }
        else
        {
            Debug.LogWarning($"SkillUIManager: índice de habilidad {index} fuera de rango en TriggerCooldown.");
        }
    }

    public bool IsSkillReady(int index)
    {
        if (index < cooldownTimers.Length)
            return cooldownTimers[index] <= 0;
        return false;
    }

    public void ResetAllCooldowns()
    {
        for (int i = 0; i < cooldownTimers.Length; i++)
        {
            cooldownTimers[i] = 0f;
        }
    }
}
