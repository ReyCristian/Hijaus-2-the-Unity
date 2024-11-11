using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Magia : MonoBehaviour
{

    public GameObject laserPrefab;  // Prefab del láser a instanciar
    private Dictionary<int, GameObject> puntosDisparo;  // Diccionario de puntos de disparo por ángulo
    public Transform conjuntoPuntosDisparo;
    private Personaje personaje; // Referencia al script del personaje

    private bool disparoHabilitado = true;
    private void Awake()
    {
        // Carga la referencia al personaje
        personaje = GetComponent<Personaje>();
    }

    void Start()
    {
        cargarPuntosDisparo();
    }

    private void cargarPuntosDisparo(){
        // Inicializamos el diccionario
        puntosDisparo = new Dictionary<int, GameObject>();

        // Llenamos el diccionario con los hijos del objeto padre
        foreach (Transform hijo in conjuntoPuntosDisparo)
        {
            int angulo = Mathf.RoundToInt(hijo.rotation.eulerAngles.z);  // Suponiendo que trabajas en 2D, usando la rotación en Z
            puntosDisparo[angulo] = hijo.gameObject;
        }
    }

    private GameObject ObtenerPuntoDisparoDesdeAngulo(int angulo)
    {
        if (puntosDisparo==null)
            cargarPuntosDisparo();

        // Buscamos el punto de disparo correspondiente al ángulo
        if (puntosDisparo.TryGetValue(angulo, out GameObject punto))
        {
            return punto;
        }
        else
            foreach (var item in puntosDisparo)
            {
                Debug.Log(item);
            }
        return null;  // Si no se encuentra un punto con el ángulo especificado
    }

    public void Shoot()
    {
        if (!disparoHabilitado)
            return;
        GameObject puntoDisparo = ObtenerPuntoDisparoDesdeAngulo(personaje.orientacion.Angulo);
        if (puntoDisparo!=null){
            GameObject laser = Instantiate(laserPrefab, puntoDisparo.transform.position, puntoDisparo.transform.rotation);
            Choque capacidadChoque = laser.GetComponent<Choque>();
            if (capacidadChoque)
                capacidadChoque.lanzador = gameObject;
            disparoHabilitado = false;
            StartCoroutine(RehabilitarDisparo());
        }
    }
    private IEnumerator RehabilitarDisparo()
{
    yield return new WaitForSeconds(0.5f);  // Espera 0.5 segundos
    disparoHabilitado = true;  // Habilita el disparo nuevamente
}



}
