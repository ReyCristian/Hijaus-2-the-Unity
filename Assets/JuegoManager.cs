using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JuegoManager : MonoBehaviour
{

    [SerializeField] private GameObject Mapa,Camara,Menu, spawnParties;
    

    public void Jugar(){
        Menu.SetActive(false);
        Camara.SetActive(true);
        Mapa.SetActive(true);
        ActivateSpawnparties();
    }

    public void Pausa(){
        Menu.SetActive(true);
        Camara.SetActive(false);
        Mapa.SetActive(false);
    }

    void ActivateSpawnparties()
    {
        if (spawnParties != null)
        {
            foreach (Transform child in spawnParties.transform)
            {
                child.gameObject.SetActive(true);
            }
        }
    }

    public void Nivel1(){
        Jugar();
    }
    public void Nivel2(){
        Jugar();
    }
    public void Nivel3(){
        Jugar();
    }

    public void Salir(){
    }

    void Update()
    {
    if (Input.GetButton("Pausa"))
        {
            Pausa();
        }
    }

}
