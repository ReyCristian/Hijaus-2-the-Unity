using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class esperandoCamara : MonoBehaviour
{
    public Caminar caminarComponent; // Asume que tienes un script llamado "Caminar".

    void Start()
    {
        caminarComponent = GetComponent<Caminar>();
        if (caminarComponent != null)
            caminarComponent.enabled = false;
    }

    void OnBecameVisible()
    {
        if (caminarComponent != null)
            caminarComponent.enabled = true;
    }
}

