using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Personaje : MonoBehaviour
{
    public bool esperando { get; private set; } = false;
    public bool enDemo = false;

    public ListasTexturas.TexturasPersonaje skin;
    public bool tieneEspada = true;

    public GameObject sprite;


    // Referencias a otros componentes que reemplazan los nodos en Godot
    public Magia magia{ get; private set; }
    //public Espada espada{ get; private set; }
    public Vida vida{ get; private set; }
    //public Skin sprite{ get; private set; }
    public Caminar caminar{ get; private set; }
    public Orientacion orientacion{ get; private set; }
    
    private void Awake()
    {
        // Asigna las referencias a los componentes necesarios
        magia = GetComponent<Magia>();
        //espada = GetComponentInChildren<Espada>();
        vida = GetComponent<Vida>();
        //sprite = GetComponentInChildren<Skin>();
        caminar = GetComponent<Caminar>();
        orientacion = GetComponent<Orientacion>();
    }

    private void Start()
    {
        // Inicializa la dirección del sprite
        //orientacion.poner_direccion(orientacion)
        
        vida.comprobarVida();
    }
}
