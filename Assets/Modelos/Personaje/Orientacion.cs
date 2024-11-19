using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientacion : MonoBehaviour
{
    public float autoApuntado = 360f;
    public int Angulo {get;private set;}

    private Personaje personaje; // Referencia al script del personaje
    private DireccionPersonaje giroSprite;
    private void Awake()
    {
        // Carga la referencia al personaje
        personaje = GetComponent<Personaje>();
        giroSprite = GetComponentInChildren<DireccionPersonaje>();
    }

    void Update()
    {
        transform.rotation = Quaternion.identity;
        if (personaje.caminar.direccion == Vector2.zero)
		    return;
        ponerDireccion(personaje.caminar.direccion);
    }

    public int anguloSimplificado(float anguloEnGrados)
    {
        int angulo = Mathf.RoundToInt(anguloEnGrados / 45) * 45;
        return (angulo +360 ) % 360;
    }

    public void ponerDireccion(Vector2 direccion){
        if (esSlime())
            return;
        float anguloEnGrados = Vector2.SignedAngle(Vector2.right, direccion);
        apuntar(anguloEnGrados);
    }
    public bool esSlime(){
	    return personaje.skin == ListasTexturas.TexturasPersonaje.SLIME;
    }

    public void apuntar(float anguloEnGrados){
	    Angulo = anguloSimplificado(anguloEnGrados);
        switch (Angulo)
        {
            case 0:
                giroSprite.direccion = DireccionPersonaje.Direction.Derecha;
                break;
            case 45:
                giroSprite.direccion = DireccionPersonaje.Direction.ArribaDerecha;
                break;
            case 90:
                giroSprite.direccion = DireccionPersonaje.Direction.Arriba;
                break;
            case 135:
                giroSprite.direccion = DireccionPersonaje.Direction.ArribaIzquierda;
                break;
            case 180:
                giroSprite.direccion = DireccionPersonaje.Direction.Izquierda;
                break;
            case 225:
                giroSprite.direccion = DireccionPersonaje.Direction.AbajoIzquierda;
                break;
            case 270:
                giroSprite.direccion = DireccionPersonaje.Direction.Abajo;
                break;
            case 315:
                giroSprite.direccion = DireccionPersonaje.Direction.AbajoDerecha;
                break;
            default:
                // Acción para ángulo no esperado
                break;
        }
    }


}
