using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controles : MonoBehaviour
{

    public GameObject heroe;
    //public GameObject mapa;
    private Personaje personaje;

    void Awake()
    {
        personaje = heroe.GetComponent<Personaje>();
    }


    void Start()
    {
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
            CheckCorriendo();
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
        float horizontal = Input.GetAxis("Horizontal"); // Detecta movimiento horizontal (A/D, flechas)
        float vertical = Input.GetAxis("Vertical");     // Detecta movimiento vertical (W/S, flechas)

        // Ajusta la dirección del personaje con los valores de los ejes
        personaje.caminar.direccion = new Vector2(horizontal, vertical);
    }

    private void CheckCorriendo()
    {
        personaje.caminar.isCorriendo = Input.GetKey(KeyCode.LeftShift);
    }

    private void CheckShot()
    {
        if (Input.GetKey(KeyCode.X))
        {
            personaje.magia.Shoot();
        }
    }
}
