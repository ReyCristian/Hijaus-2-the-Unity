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
        AsignarNivel(1);
        Jugar();
    }
    public void Nivel2(){
        AsignarNivel(2);
        Jugar();
    }
    public void Nivel3(){
        AsignarNivel(3);
        Jugar();
    }

    public void Salir(){
        Application.Quit();
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }

    void Update()
    {
        if (Input.GetButton("Pausa"))
        {
            Pausa();
        }
    }

    public void AsignarNivel(int nivel){
        foreach (Transform child in Mapa.transform)
        {
            GeneradorMapa generador = child.GetComponent<GeneradorMapa>();
            if (generador != null)
            {
                generador.nivel = nivel;
            }
        }
    }
    
    public void setMapa(GameObject mapa){
        Mapa = mapa;
    }
}