using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ordenSprites : MonoBehaviour
{
    [SerializeField]
    private int pixelesPorChunk = 10;
    [SerializeField]
    private float alturaChunk = 0.1f;

    void Start()
    {
        actualizarOrdenY();
    }

    public void actualizarOrdenY(){
        // 16 pixeles por tile
        // 18 tiles por chunk
        // 0.1 altura del chunk
        transform.position = new Vector3(
            transform.position.x, 
            transform.position.y, 
            transform.position.y / pixelesPorChunk * alturaChunk
        );
    }

    private float previousY;

    void Update()
    {
        // Comprueba si la posición en Y ha cambiado
        if (transform.position.y != previousY)
        {
            actualizarOrdenY();
            previousY = transform.position.y;
        }
    }

}
