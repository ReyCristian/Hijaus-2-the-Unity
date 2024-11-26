using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HudVidas : MonoBehaviour
{
    void Update()   
    {
        // Obtener el componente Vida del objeto padre
        Vida vida = GetComponentInParent<Vida>();
        if (vida == null) return;

        int vidaActual = vida.vida;
        int index = 0;

        // Recorrer los hijos y ajustar el parámetro "Lleno" en el Animator
        foreach (Transform child in transform)
        {
            Animator animator = child.GetComponent<Animator>();
            if (animator != null)
            {
                animator.SetBool("Lleno", index < vidaActual);
            }
            index++;
        }
    }
}
