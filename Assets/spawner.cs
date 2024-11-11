using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Juego.Mecanicas;

public class spawner : MonoBehaviour
{
    
    public GameObject asteroidPrefab; // Asigna el prefab del asteroide
    public float intervaloSpawn = 2f; // Intervalo de spawn en segundos
    public float velocidadAsteroide = 5f; // Velocidad de cada asteroide
    private BoxCollider2D boxCollider; // Referencia al BoxCollider2D

    void Start()
    {
        // Inicia el proceso de spawneo repetitivo
        InvokeRepeating("SpawnAsteroide", 0f, intervaloSpawn);
        boxCollider = GetComponent<BoxCollider2D>();
    }

    void SpawnAsteroide()
    {

        Vector2 posicionAleatoria = new Vector2(
            Random.Range(boxCollider.bounds.min.x, boxCollider.bounds.max.x),
            Random.Range(boxCollider.bounds.min.y, boxCollider.bounds.max.y)
        );

        // Genera un nuevo asteroide en la posición del marcador y con la rotación predeterminada
        GameObject nuevoAsteroide = Instantiate(asteroidPrefab, posicionAleatoria, Quaternion.identity);
        
        // Asignar valores al asteroide
        Seguidor seguidorScript = nuevoAsteroide.GetComponent<Seguidor>();
        if (seguidorScript != null){
            float valorRandom = Random.Range(0.7f, 1.3f);
            seguidorScript.velocidad = velocidadAsteroide * valorRandom; // Asigna la velocidad
        }
        Choque capacidadChoque = nuevoAsteroide.GetComponent<Choque>();
        if (capacidadChoque)
            capacidadChoque.lanzador = gameObject;
    }
}
