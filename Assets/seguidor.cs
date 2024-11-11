using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Juego.Mecanicas  // Espacio de nombres
{
    public class Seguidor : MonoBehaviour
    {
        public GameObject objetivo;
        public float velocidad = 5f;


    void Start()
    {
        // Encuentra todos los objetos con el tag "Player"
        GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
        
        // Si hay jugadores, encuentra el más cercano
        if (players.Length > 0)
        {
            objetivo = players[0];
            float distanciaMinima = Vector2.Distance(transform.position, objetivo.transform.position);

            foreach (GameObject player in players)
            {
                float distanciaActual = Vector2.Distance(transform.position, player.transform.position);

                if (distanciaActual < distanciaMinima)
                {
                    distanciaMinima = distanciaActual;
                    objetivo = player;
                }
            }
        }
    }
        void Update()
        {
            if (objetivo != null)
            {
                
                Vector3 direccion = (objetivo.transform.position - transform.position).normalized;
                if (Vector3.Distance(objetivo.transform.position, transform.position) > velocidad * Time.deltaTime)
                    transform.Translate(direccion * velocidad * Time.deltaTime);
                    //transform.position += direccion * velocidad * Time.deltaTime;

                //else
                //    Destroy(gameObject);

            }

        }
    }
}