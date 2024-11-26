using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    
    private Personaje personaje;
    public int vida = 3;
    public bool muerto { get; private set; } = false;
    //private bool limpiarCadaver = true;
    
    private Animator animator;

    public delegate void MuerteEvent(ListasTexturas.TexturasPersonaje skin);
    public event MuerteEvent Muerte;
    public AudioSource audioSource; // Asigna el AudioSource desde el Inspector
    public AudioClip deathSound;   // Asigna el sonido de muerte desde el Inspector


    private void Awake()
    {
        personaje = GetComponent<Personaje>();
        animator = GetComponentInChildren<Animator>();
        audioSource = GetComponentInChildren<AudioSource>();

    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    void Update(){
        // Actualiza el temporizador de inmunidad
        if (tiempoInmunidad > 0f){
            tiempoInmunidad -= Time.deltaTime;
        }
    }
    private float tiempoInmunidad = 0f; // Tiempo de inmunidad en segundos

    public bool RecibirGolpe(GameObject golpeador){
        if (golpeador != null && golpeador != gameObject && tiempoInmunidad <= 0f){
            vida--;
            comprobarVida();
            tiempoInmunidad = 0.5f; // Inicia la inmunidad por 1 segundo
            return true;
        }
        return false;
    }

    public void comprobarVida(){
        if (vida <= 0)
        {
            Morir();
        }
    }

    public void Morir()
    {
        if (muerto)
        {
            return;
        }
        vida =0;

        // Emite el evento si el personaje es un enemigo
        if (personaje && CompareTag("Enemigo"))
        {
            //Muerte?.Invoke(personaje.skin);
            Destroy(gameObject);
        }

        // Comprueba condiciones adicionales antes de morir
        if (!CompareTag("Demo"))
        {
            muerto = true;
            if (audioSource != null && deathSound != null)
            {
                audioSource.PlayOneShot(deathSound);
            }
            if (animator !=null)
            {
                animator.SetTrigger("Muere");
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                if (rb != null)
                {
                rb.velocity = Vector3.zero;
                rb.angularVelocity = 0;  
                }
                Destroy(gameObject,3f);
            }
            else
                Destroy(gameObject);
        }
        
    }

        

}
