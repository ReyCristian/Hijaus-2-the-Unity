using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public float velocidad = 10f;  // Velocidad del láser, configurable desde el Inspector

    void Update()
    {
        // Mueve el láser hacia adelante basado en su propia rotación
        transform.Translate(Vector3.right * velocidad * Time.deltaTime);
    }

    // Este método se llama automáticamente cuando el objeto sale de la pantalla
    void OnBecameInvisible()
    {
        Destroy(gameObject);  // Destruye el láser cuando sale de la pantalla
    }
}
