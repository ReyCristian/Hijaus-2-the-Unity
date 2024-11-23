using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espada : MonoBehaviour
{

    private Animator animator;

    void Start()
    {
        animator = GetComponentInChildren<Animator>();
    }

    void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Player"))
        {
            Vida vida = otro.GetComponentInParent<Vida>();
            if (vida != null)
            {
                vida.RecibirGolpe(gameObject);
            }
            animator.SetTrigger("Ataca");
        }
    }
}
