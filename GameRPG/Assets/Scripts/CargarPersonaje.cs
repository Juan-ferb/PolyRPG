using UnityEngine;

public class CargarPersonaje : MonoBehaviour
{
    public GameObject AssasinPersonaje;
    public GameObject MagicianPersonaje;

    public bool Assasin;
    public bool Magician;

    private void Update()
    {
        Assasin = PlayerPrefs.GetInt("Assasin Seelect") == 1;
        Magician = PlayerPrefs.GetInt("Magician select") == 1;

        if (Assasin == true)
        {
            AssasinPersonaje.SetActive(true);
            Destroy(MagicianPersonaje);
        }

        if (Magician == true)
        {
            MagicianPersonaje.SetActive(true);
            Destroy(AssasinPersonaje);
            Destroy(AssasinPersonaje);
        }
    }
}
