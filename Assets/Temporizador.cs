using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Temporizador : MonoBehaviour
{
    [SerializeField] private float tiempoEspera = 2f; // Tiempo configurable desde el Inspector
    private Magia magia;

    private void Start()
    {
        magia = GetComponent<Magia>();
        StartCoroutine(LlamarDisparo());
    }

    private IEnumerator LlamarDisparo()
    {
        while (true)
        {
            yield return new WaitForSeconds(tiempoEspera);
            magia.Shoot();
        }
    }
}