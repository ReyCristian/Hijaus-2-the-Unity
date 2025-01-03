using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Choque : MonoBehaviour
{
    public bool destruirse = true;
    public LayerMask capaDeseada = -1;
    public GameObject lanzador;
    private void OnTriggerEnter2D(Collider2D golpeado)
    {
        if (((1 << golpeado.gameObject.layer) & capaDeseada) != 0)
        {     
        // Verificar si el objeto con el que colisionó tiene el script Vida
            Vida vidaGolpeado = golpeado.GetComponentInParent<Vida>();
            
            if (vidaGolpeado == null || vidaGolpeado.RecibirGolpe(lanzador))  // Si tiene el script Vida
            {
                if (destruirse)
                Destroy(gameObject);
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D golpeado) {
        OnTriggerEnter2D(golpeado.collider);
    }
}
