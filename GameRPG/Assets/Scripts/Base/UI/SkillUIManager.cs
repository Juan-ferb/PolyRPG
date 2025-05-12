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

                if (skillCooldownText[i] != null)
                    skillCooldownText[i].text = Mathf.Ceil(cooldownTimers[i]).ToString("F0");
            }
            else
            {
                if (skillIcons[i] != null)
                    skillIcons[i].color = Color.white;

                if (skillCooldownText[i] != null)
                    skillCooldownText[i].text = "";
            }
        }
    }

    public void SetSkillIcon(int index, Sprite icon, float cooldown)
    {
        if (index < skillIcons.Length)
        {
            if (skillIcons[index] != null)
                skillIcons[index].sprite = icon;

            skillCooldowns[index] = cooldown;
        }
    }

    public void SetAllSkills(Sprite[] icons, float[] cooldowns)
    {
        for (int i = 0; i < skillIcons.Length; i++)
        {
            SetSkillIcon(i, icons[i], cooldowns[i]);
        }
    }

    public void TriggerCooldown(int index)
    {
        if (index < cooldownTimers.Length)
        {
            cooldownTimers[index] = skillCooldowns[index];
        }
    }

    public bool IsSkillReady(int index)
    {
        return cooldownTimers[index] <= 0;
    }

    public void ResetAllCooldowns()
    {
        for (int i = 0; i < cooldownTimers.Length; i++)
        {
            cooldownTimers[i] = 0f;
        }
    }
}
