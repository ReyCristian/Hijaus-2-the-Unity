using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour
{
    //public GameObject mapa;
    private Personaje personaje;
    public SetDeControles setDeControles;
    private string[] controles;


    void Awake()
    {
        personaje = GetComponent<Personaje>();
    }


    void Start()
    {
        controles = GetControlesActivos();
        loadMovimientoAutomatico();
    }
    private void loadMovimientoAutomatico()
    {
        //personaje.autoMovimiento.y = -mapa.GetComponent<Mapa>().velocidad / 100f;
    }

    // Update is called once per frame
    private void Update()
    {
        if (personaje != null && !personaje.vida.muerto)
        {
            Reset();
            CheckMovimiento();
            //CheckCorriendo();
            //CheckGolpe();
            CheckShot();
        }
    }

    private void Reset()
    {
        personaje.caminar.direccion = Vector2.zero;
    }
    private void CheckMovimiento()
    {
        float horizontal = Input.GetAxis(controles[(int)Movimiento.Horizontal]); // Detecta movimiento horizontal (A/D, flechas)
        float vertical = Input.GetAxis(controles[(int)Movimiento.Vertical]);     // Detecta movimiento vertical (W/S, flechas)

        // Ajusta la dirección del personaje con los valores de los ejes
        personaje.caminar.direccion = new Vector2(horizontal, vertical);
    }

    private void CheckCorriendo()
    {
        personaje.caminar.isCorriendo = Input.GetButton(controles[(int)Movimiento.Fire2]);
    }

    private void CheckShot()
    {
        if (Input.GetButton(controles[(int)Movimiento.Jump]))
        {
            personaje.magia.Shoot();
        }
    }

    public enum Movimiento
    {
        Horizontal = 0,
        Vertical = 1,
        Jump = 2,
        Fire = 3,
        Fire2 = 4
    }

    private string[] controlesJugador1 = { "Horizontal", "Vertical", "Jump", "Fire1", "Fire2" };
    private string[] controlesJugador2 = { "Horizontal_P2", "Vertical_P2", "Jump_P2", "Fire1_P2", "Fire2_P2" };
    private string[] controlesJugador3 = { "Horizontal_P3", "Vertical_P3", "Jump_P3", "Fire1_P3", "Fire2_P3" };
    private string[] controlesJugador4 = { "Horizontal_P4", "Vertical_P4", "Jump_P4", "Fire1_P4", "Fire2_P4" };
    public enum SetDeControles
    {
        Jugador1,
        Jugador2,
        Jugador3,
        Jugador4
    }
    public string[] GetControlesActivos()
    {
        switch (setDeControles)
        {
            case SetDeControles.Jugador1: return controlesJugador1;
            case SetDeControles.Jugador2: return controlesJugador2;
            case SetDeControles.Jugador3: return controlesJugador3;
            case SetDeControles.Jugador4: return controlesJugador4;
            default: return controlesJugador1;
        }
    }

}
