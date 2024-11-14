using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PorcionMapa : MonoBehaviour
{
    public Vector2 orientacion;  // Dirección en la que se moverá
    public Vector2 posicion;     // Posición inicial de la porción
    private GeneradorMapa generador;  // Referencia al generador que lo instanció
    private bool esperandoInicializacion = false;
    public GeneradorMapa.TipoObjetivo tipoGenerado;
    private bool isConectado = false;
    [SerializeField] public List<int> nivel = new List<int>();


    void Start()
    {
        generador = GetComponentInParent<GeneradorMapa>();
        if (esperandoInicializacion)
            OnBecameVisible();
    }

    // Llamado cuando el objeto se vuelve visible
    void OnBecameVisible()
    {
        // Generar la siguiente porción
        if (!isConectado)
            if (generador != null)
            {
                esperandoInicializacion = false;
                generador.Generar(posicion + orientacion,(int)tipoGenerado,transform.position.z+0.1f);
                isConectado = true;
            }
            else
            {
                esperandoInicializacion = true;
            }
    }

    // Llamado cuando el objeto se vuelve invisible
    void OnBecameInvisible()
    {
        // Deshabilitar el objeto si está fuera de la pantalla
        //gameObject.SetActive(false);
    }
}
