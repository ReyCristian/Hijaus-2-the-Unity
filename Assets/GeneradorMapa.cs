using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GeneradorMapa : MonoBehaviour
{

    // Definimos el enum con los diferentes objetivos del mapa
    public enum TipoObjetivo
    {
        SUELO,
        LATERAL_DERECHO,
        LATERAL_IZQUIERDO,
        OBSTACULOS
    }

    public List<GameObject>[] prefabs;
    public float altoChunk = 10f;  // Alto del chunk
    public float largoChunk = 17.78f; // Largo del chunk
    public Vector2 posicionInicial = Vector2.zero;  // Posición inicial (0,0)
    public Vector2 posicionFinal = Vector2.zero;  // Posición inicial (0,0)
    public List<TipoObjetivo> objetivosGenerador;
    public int nivel;

    void Start()
    {
        cargarSemilla();
        Reiniciar();
    }

    private void cargarSemilla(){
        int seed = System.DateTime.Now.DayOfYear;
        Random.InitState(seed);
    }

    void Reiniciar(){
        CargarObjetivosPrefab();
        CargarPrefabs();
        foreach (var objetivo in objetivosGenerador)
        {
            Generar(Vector2.zero,(int)objetivo);  
        }
    }

    void CargarObjetivosPrefab(){
        prefabs = new List<GameObject>[System.Enum.GetValues(typeof(TipoObjetivo)).Length];
        for (int i = 0; i < prefabs.Length; i++)
        {
            prefabs[i] = new List<GameObject>();
        }
    }

    void CargarPrefabs()
    {
        // Carga todos los prefabs desde la carpeta Resources/Mapas
        GameObject[] todosPrefabs = Resources.LoadAll<GameObject>("Mapas");

        if (todosPrefabs.Length == 0)
        {
            Debug.LogWarning("No se encontraron prefabs en la carpeta.");
            return;
        }

        // Recorremos todos los prefabs y los asignamos a la lista correcta según el objetivo
        foreach (var prefab in todosPrefabs)
        {
            PorcionMapa porcionMapa = prefab.GetComponent<PorcionMapa>();
            if (porcionMapa != null)
            {
                TipoObjetivo tipoGenerado = porcionMapa.tipoGenerado;
                if (objetivosGenerador.Contains(tipoGenerado) && porcionMapa.nivel.Contains(nivel))
                    prefabs[(int)tipoGenerado].Add(prefab);
            }
        }
    }

    public void Generar(Vector2 pos,int objetivo = (int) TipoObjetivo.SUELO,float capa = 0){
        if (posicionFinal == Vector2.zero || pos!=posicionFinal)
            GenerarAleatorio(prefabs[(int)objetivo],pos,capa);
    }
 
    private void GenerarAleatorio(List<GameObject> prefabsObjetivo,Vector2 pos, float capa = 0)
    {
        if (prefabsObjetivo.Count == 0) return;

        int indiceAleatorio = Random.Range(0, prefabsObjetivo.Count); // Elige un índice al azar
        GameObject prefabAEspawnear = prefabsObjetivo[indiceAleatorio];

        // Calcular la nueva posición sumando el alto y largo del chunk
        Vector3 posicionGenerada = new Vector3(posicionInicial.x + largoChunk * pos.x, posicionInicial.y+ altoChunk * pos.y, capa);

        // Instancia el prefab como hijo del objeto actual
        GameObject nuevaPorcion = Instantiate(prefabAEspawnear, posicionGenerada, Quaternion.identity, transform);

        // Asignamos la orientación de la porción (esto podría ser cualquier valor dependiendo del tipo de mapa)
        PorcionMapa porcionMapa = nuevaPorcion.GetComponent<PorcionMapa>();
        if (porcionMapa != null)
            porcionMapa.posicion = pos;
    }
    
}

