using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    
    private Personaje personaje;
    public int vida = 3;
    public bool muerto { get; private set; } = false;
    //private bool limpiarCadaver = true;

    public delegate void MuerteEvent(ListasTexturas.TexturasPersonaje skin);
    public event MuerteEvent Muerte;

    private void Awake()
    {
        personaje = GetComponent<Personaje>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public bool RecibirGolpe(GameObject golpeador){
        if (golpeador != null && golpeador != gameObject){
            vida--;
            comprobarVida();
            return true;
        }
        //devuelve falso si falla el golpe
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

        // Ejecuta la animación de muerte
        //animacion.Morir();

        // Emite el evento si el personaje es un enemigo
        if (personaje && CompareTag("Enemigo"))
        {
            Muerte?.Invoke(personaje.skin);
        }

        // Comprueba condiciones adicionales antes de morir
        if (!CompareTag("Demo"))
        {
            muerto = true;
            Destroy(gameObject);
        }
        
    }

        

}
