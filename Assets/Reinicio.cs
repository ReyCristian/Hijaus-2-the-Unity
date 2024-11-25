using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reinicio : MonoBehaviour
{
    [SerializeField] private GameObject prefab;
    public void Reiniciar()
    {

        if (prefab != null)
        {
            Instantiate(prefab, prefab.transform.position, prefab.transform.rotation);
        }
        
        Destroy(gameObject);
    }
}
