using UnityEngine;

public class CamaraSeguir : MonoBehaviour
{
    private Transform jugador;  // Referencia al jugador
    private Rigidbody2D rbJugador;   // Componente Rigidbody2D del jugador

    public float velocidadMinima = 0f;  // Velocidad mínima
    public float velocidadMaxima = 3f;  // Velocidad máxima
    public float factorDistancia = 0.05f;  // Factor que controla cómo cambia la velocidad

    private Vector3 desplazamiento;  // Desplazamiento entre la cámara y el jugador
    [SerializeField] private Transform hordaTransform;
    private Camera camara;
    public float limiteSuperiorY = Mathf.Infinity;
    public float limiteInferiorY = -Mathf.Infinity;


    void Start()
    {
        loadPlayer();
        camara = GetComponent<Camera>();

    }

    private void loadPlayer()
    {
        GameObject[] jugadores = GameObject.FindGameObjectsWithTag("Player");
        foreach (GameObject obj in jugadores)
        {
            if (obj.GetComponent<Personaje>() != null)
            {
                jugador = obj.transform;
                rbJugador = jugador.GetComponent<Rigidbody2D>();

                // Calculamos el desplazamiento inicial
                desplazamiento.z = (transform.position - jugador.position).z;
                break;
            }
        }
    }

    void LateUpdate()
    {
        if (rbJugador == null)
            loadPlayer();
        if (rbJugador == null)
            return;
        Vector3 vectorDistancia = transform.position - jugador.position;

        vectorDistancia.x = vectorDistancia.x * 9 / 16;
    

        // Obtenemos la velocidad del jugador (magnitude de la velocidad)
        float velocidadJugador = rbJugador.velocity.magnitude;

        // Calculamos la velocidad en función de la distancia
        Vector2 velocidad = Vector2.zero;
        velocidad.x = Mathf.Lerp(velocidadMinima, Mathf.Max(velocidadJugador,velocidadMaxima), factorDistancia * Mathf.Pow(vectorDistancia.x,2));
        velocidad.y = Mathf.Lerp(velocidadMinima, Mathf.Max(velocidadJugador,velocidadMaxima), factorDistancia * Mathf.Pow(vectorDistancia.y,2));
        
    
        // Calculamos la nueva posición de la cámara
        Vector3 posicionObjetivo = jugador.position + desplazamiento;
        
        //Anulo en X para q no se mueva la camara en ese sentido.
        if (isDesplazamientoVertical())
            posicionObjetivo.x = transform.position.x;
        if (hordaTransform != null)
        {
            limiteInferiorY  = hordaTransform.position.y + camara.orthographicSize;
        }

        // Mueve la cámara suavemente en el eje X
        float nuevaPosX = Mathf.MoveTowards(transform.position.x, posicionObjetivo.x, velocidad.x * Time.deltaTime);
        
        // Mueve la cámara suavemente en el eje Y
        float nuevaPosY = Mathf.MoveTowards(transform.position.y, posicionObjetivo.y, velocidad.y * Time.deltaTime);
        nuevaPosY = Mathf.Clamp(nuevaPosY, limiteInferiorY, limiteSuperiorY);

        transform.position = new Vector3(nuevaPosX, nuevaPosY, transform.position.z);

    }

    private bool isDesplazamientoVertical(){
        return true;
    }

    public void Reiniciar()
    {
        Vector3 nuevaPosicion = transform.position;
        nuevaPosicion.y = jugador.position.y;
        
        if (!isDesplazamientoVertical())
            nuevaPosicion.x = jugador.position.x;
        
        transform.position = nuevaPosicion;
    }


}