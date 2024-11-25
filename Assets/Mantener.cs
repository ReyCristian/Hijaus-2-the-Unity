using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mantener : MonoBehaviour
{
    private void Awake()
    {
        // Esto asegura que el objeto no se destruya al cambiar o recargar la escena
        DontDestroyOnLoad(gameObject);
    }
}
