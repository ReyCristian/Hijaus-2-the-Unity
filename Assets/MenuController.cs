using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour
{

  [SerializeField] private GameObject MenuPrincipal, Personaje, Opciones, Niveles, Creditos;

  public void OnButtonClicked()
    {
        Debug.Log("¡Botón presionado!");
        // Aquí pones la lógica que quieres ejecutar
    }

  public void AbrirMenuPrincipal(){
    MenuPrincipal.SetActive(true);
    Personaje.SetActive(false);
    Opciones.SetActive(false);
    Niveles.SetActive(false);
  }

  public void AbrirPersonaje(){
    MenuPrincipal.SetActive(false);
    Personaje.SetActive(true);
    Opciones.SetActive(false);
    Niveles.SetActive(false);
  }

  public void AbrirOpciones(){
    MenuPrincipal.SetActive(false);
    Personaje.SetActive(false);
    Opciones.SetActive(true);
    Niveles.SetActive(false);
  }

  public void AbrirNiveles(){
    MenuPrincipal.SetActive(false);
    Personaje.SetActive(false);
    Opciones.SetActive(false);
    Niveles.SetActive(true);
  }

  public void MostrarCreditos(){
    ActivarCanvas();
    AbrirMenuPrincipal();
    Creditos.SetActive(true);
  }

  void ActivarCanvas()
  {
      if (transform.childCount > 0)
      {
          transform.GetChild(0).gameObject.SetActive(true);
      }
  }

  public void TerminarCreditos(){
    AbrirMenuPrincipal();
    Creditos.SetActive(false);
  }

  public void ToggleFullscreen()
  {
      Screen.fullScreen = !Screen.fullScreen;
  }
  
}
