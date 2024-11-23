using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Caminar : MonoBehaviour
{

    public float velocidad = 5.0f;
    public float velocidadCorriendo = 25.0f;
    public float velocidadDash = 1000.0f;
    public bool isCorriendo = false;
    public bool dash = false;
    public Vector2 direccion = Vector2.zero;
    public Vector2 autoMovimiento = Vector2.zero;

    private Personaje personaje; // Referencia al script del personaje
    private Rigidbody2D rb;       // Referencia al Rigidbody2D
    public float velocidadSuavizado = 1f;  // Factor que controla cómo cambia la velocidad
    public Animator animator;



    private void Awake()
    {
        // Carga la referencia al personaje
        personaje = GetComponent<Personaje>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();        
    }

    private void FixedUpdate()
    {
        // Si el personaje está en espera o muerto, no hace nada
        if (personaje != null && (personaje.esperando || personaje.vida.muerto))
        {
            if (animator != null)
                animator.SetBool("Camina", false);
            return;
        }
        
        // Normaliza la dirección del personaje
        Vector2 direccionNormalizada = direccion.normalized;
        Vector2 direccionFinal = AgregarDireccionAutomatica(direccionNormalizada);

        // Calcula el movimiento en función de la dirección y deltaTime
        Vector2 movimiento = CalcularMovimiento(direccionFinal, Time.fixedDeltaTime);

        // Si el personaje está en un camino fijo, sigue ese camino; si no, se mueve y colisiona
        if (EstaEnCaminoFijo())
        {
            SeguirCamino(movimiento);
        }
        else
        {
            // Mueve el personaje con colisiones (utiliza el CharacterController o Rigidbody según el setup)
            //transform.Translate(movimiento);
            //rb.velocity = Vector3.Lerp(rb.velocity, direccionFinal * personaje.velocidad, Time.deltaTime * velocidadSuavizado);
            rb.velocity = direccionFinal * velocidad;
            if (animator != null)
                animator.SetBool("Camina", direccionFinal.magnitude > 0);
            rb.angularVelocity = 0;
        }

    }

    private Vector2 AgregarDireccionAutomatica(Vector2 direccion)
    {
        // Implementación de agregar dirección automática (personalizar según sea necesario)
        return direccion; // Esto es un placeholder; ajustar según el comportamiento deseado
    }

    private Vector2 CalcularMovimiento(Vector2 direccion, float delta)
    {
        // Implementación para calcular el movimiento, basada en velocidad y delta
        return direccion * velocidad * delta;
    }

    private bool EstaEnCaminoFijo()
    {
        // Implementación para verificar si está en un camino fijo (personalizar según sea necesario)
        return false; // Placeholder; ajustar según el comportamiento deseado
    }

    private void SeguirCamino(Vector2 movimiento)
    {
        // Implementación para seguir un camino fijo
    }
}
