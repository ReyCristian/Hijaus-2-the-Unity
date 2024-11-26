using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeguirObjetivo : MonoBehaviour
{
    public string tagObjetivo = "Player";
    private Transform objetivo;
    private Caminar caminante;
    private float tiempo = 0f;
    public float intervalo = 2f;
    private Vector2 objetivoPos;

    void Start()
    {
        caminante = GetComponent<Caminar>();  // Asumiendo que 'Caminante' es el script para moverse
        objetivoPos = transform.position;
    }

    void Update()
    {
        tiempo += Time.deltaTime;

        if (tiempo >= intervalo)
        {
            tiempo = 0f;
            SeleccionarObjetivo();
            MoverHaciaObjetivo();
            Debug.Log(objetivoPos);
        }
        if (Vector2.Distance(transform.position, objetivoPos) <= 0.1f)
        {
            caminante.direccion = Vector2.zero;  // Se detiene cuando llega al objetivo
        }
    }

    void MoverHaciaObjetivo()
    {
        if (objetivo != null)
        {
            Vector2 direccion = (objetivo.position - transform.position);

            caminante.direccion = direccion.normalized;
            caminante.isCorriendo = (direccion.magnitude > 10f);
            objetivoPos = objetivo.position;
        }
    }

    void SeleccionarObjetivo()
    {
        // Busca todos los objetos con el tag "Player"
        GameObject[] players = GameObject.FindGameObjectsWithTag(tagObjetivo);
        List<Transform> playersConPersonaje = new List<Transform>();

        // Filtra solo aquellos que tienen el componente "Personaje"
        foreach (GameObject player in players)
        {
            if (player.GetComponent<Personaje>() != null)
            {
                playersConPersonaje.Add(player.transform);
            }
        }

        if (playersConPersonaje.Count > 0)
        {
            // Selecciona un jugador al azar
            objetivo = playersConPersonaje[Random.Range(0, playersConPersonaje.Count)];
        }
    }
}
