using UnityEngine;

public class CharacterSkillSetup : MonoBehaviour
{
    public Sprite[] skillIcons;           // Íconos de las habilidades
    public float[] skillCooldowns;        // Cooldowns de las habilidades

    private SkillUIManager uiManager;

    // Método que asigna los íconos y cooldowns al SkillUIManager
    public void SetSkillsToUI()
    {
        if (uiManager == null)
        {
            uiManager = FindObjectOfType<SkillUIManager>();
        }

        if (uiManager != null && skillIcons.Length == skillCooldowns.Length)
        {
            uiManager.SetAllSkills(skillIcons, skillCooldowns);
        }
        else
        {
            Debug.LogWarning("El SkillUIManager no se ha encontrado o los arrays de íconos y cooldowns no coinciden.");
        }
    }

    // Se puede llamar desde el Start de los personajes para asignar la configuración
    public void SetupCharacterSkills()
    {
        SetSkillsToUI();
    }
}
