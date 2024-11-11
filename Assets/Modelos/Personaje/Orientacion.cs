using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orientacion : MonoBehaviour
{
    public float autoApuntado = 360f;
    public int Angulo {get;private set;}

    private Personaje personaje; // Referencia al script del personaje
    private void Awake()
    {
        // Carga la referencia al personaje
        personaje = GetComponent<Personaje>();
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
        personaje.sprite.transform.rotation = Quaternion.Euler(0, 0, Angulo);
    }


}
