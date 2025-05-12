using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CambiarEscena : MonoBehaviour
{
    public GameObject funciones; // Objeto con el script GuardarPersonaje

    public void cambiar()
    {
        if (funciones != null)
        {
            GuardarPersonaje gp = funciones.GetComponent<GuardarPersonaje>();
            if (gp != null)
            {
                gp.Guardar(); // guardar antes de cambiar de escena
            }
        }

        SceneManager.LoadScene("Juego");
    }
}
