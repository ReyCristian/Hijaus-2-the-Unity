using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Horda : MonoBehaviour
{
    private List<GameObject> spritesHorda = new List<GameObject>(); // Lista de hijos (sprites)
    private BoxCollider2D colliderRectangulo; // Collider para definir el área rectangular
    private float porcentajeDesplazamiento = 0.2f; // Porcentaje de desplazamiento (20%)
    [SerializeField] private Vector2 offset;

    void Start()
    {
        colliderRectangulo = GetComponent<BoxCollider2D>(); // Obtener el BoxCollider2D del mismo objeto
        ObtenerSpritesHorda(); // Llenar la lista con los hijos
        ClonarHorda();
    }

    void ObtenerSpritesHorda()
    {
        // Limpiar la lista en caso de que ya tenga elementos
        spritesHorda.Clear();

        // Agregar todos los hijos del objeto a la lista
        foreach (Transform hijo in transform)
        {
            if (hijo.gameObject.GetComponent<SpriteRenderer>() != null) // Asegurarse de que tenga un SpriteRenderer
            {
                spritesHorda.Add(hijo.gameObject);
            }
        }
    }

    void ClonarHorda()
    {
        Vector2 tamanoCollider = colliderRectangulo.size; // Tamaño del collider (área del rectángulo)
        Vector2 posicionInicio = colliderRectangulo.bounds.min; // Esquina inferior izquierda del collider

        // Obtener el tamaño del sprite (usamos el sprite de uno de los hijos)
        Sprite sprite = spritesHorda[0].GetComponent<SpriteRenderer>().sprite;
        float anchoSprite = sprite.bounds.size.x / 2;
        float altoSprite = sprite.bounds.size.y / 2;

        // Calcular cuántos clones caben en el eje X y Y
        int cantidadX = Mathf.FloorToInt((tamanoCollider.x+offset.x) / anchoSprite);
        int cantidadY = Mathf.FloorToInt((tamanoCollider.y+offset.y) / altoSprite );

        // Clonar los sprites dentro del área del collider
        for (int x = 0; x <= cantidadX; x++)
        {
            for (int y = 0; y <= cantidadY; y++)
            {
                // Calcular la posición de cada clon
                Vector2 posicionBase = new Vector2(posicionInicio.x + x * anchoSprite, posicionInicio.y + y * altoSprite);

                // Generar un desplazamiento aleatorio en X e Y (hasta un 20% del tamaño del sprite)
                float desplazamientoX = Random.Range(-anchoSprite * porcentajeDesplazamiento, anchoSprite * porcentajeDesplazamiento);
                float desplazamientoY = Random.Range(-altoSprite * porcentajeDesplazamiento, altoSprite * porcentajeDesplazamiento);

                // Aplicar el desplazamiento a la posición base
                Vector2 posicionFinal = posicionBase + new Vector2(desplazamientoX, desplazamientoY);



                // Seleccionar un sprite al azar de la lista
                GameObject spriteSeleccionado = spritesHorda[Random.Range(0, spritesHorda.Count)];

                // Instanciar el sprite seleccionado
                Instantiate(spriteSeleccionado, posicionFinal, Quaternion.identity,transform);
            }
        }
    }
}
