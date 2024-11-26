using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VictoriaManager : MonoBehaviour
{
    public void ActivarVictoria()
    {
        // Busca el MenuController y llama a MostrarCreditos
        MenuController menuController = FindObjectOfType<MenuController>();
        if (menuController != null)
        {
            menuController.MostrarCreditos();
        }

        JuegoManager juegoController = FindObjectOfType<JuegoManager>();
        if (juegoController != null)
        {
            Destroy(juegoController.gameObject);
        }
    }

    void OnDestroy()
    {
        // Llama a ActivarVictoria antes de que el objeto sea destruido
        ActivarVictoria();
    }
}
