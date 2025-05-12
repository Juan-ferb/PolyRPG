using UnityEngine;

public class Skills : MonoBehaviour
{
    public Skill[] skills; // Arreglo de habilidades que el personaje puede usar
    public SkillUIManager skillUIManager; // Referencia al UI que maneja los íconos y cooldowns

    void Start()
    {
        // Inicializamos las habilidades con los íconos y cooldowns correspondientes
        for (int i = 0; i < skills.Length; i++)
        {
            skillUIManager.SetSkillIcon(i, skills[i].icon, skills[i].cooldownTime);
        }
    }

    void Update()
    {
        // Comprobamos si las teclas de las habilidades 1, 2, o 3 han sido presionadas
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            UseSkill(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            UseSkill(1);
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            UseSkill(2);
        }
    }

    // Método para usar una habilidad
    void UseSkill(int skillIndex)
    {
        if (skillUIManager.IsSkillReady(skillIndex)) // Verifica si la habilidad está lista para usarse
        {
            // Ejecutar la habilidad (se debe definir lo que hace cada habilidad)
            skills[skillIndex].Use();

            // Iniciar el cooldown de la habilidad
            skillUIManager.TriggerCooldown(skillIndex);
        }
    }
}

// Clase Skill que define las propiedades de cada habilidad
[System.Serializable]
public class Skill
{
    public string skillName;   // Nombre de la habilidad
    public Sprite icon;        // Ícono de la habilidad
    public float cooldownTime; // Tiempo de cooldown de la habilidad

    // Método para activar la habilidad (esto puede ser extendido con lógica específica para cada habilidad)
    public void Use()
    {
        // Aquí va la lógica de lo que hace la habilidad (por ejemplo, lanzar un cuchillo, curarse, etc.)
        Debug.Log($"Usando habilidad: {skillName}");
    }
}
