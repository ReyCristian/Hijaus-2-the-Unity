using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Consumir : MonoBehaviour
{
    private HashSet<Collider2D> objetosDentro = new HashSet<Collider2D>();
    private void OnTriggerEnter2D(Collider2D otro)
    {
        if (otro.CompareTag("Boss"))
            return;
        Vida vida = otro.GetComponentInParent<Vida>();
        if (vida != null)
        {
            objetosDentro.Add(otro);
            StartCoroutine(DañarCada3Seg(otro, vida));
        }
    }

    private void OnTriggerExit2D(Collider2D otro)
    {
        if (otro.CompareTag("Boss"))
            return;
        objetosDentro.Remove(otro);
        if (otro.transform.position.y < transform.position.y)
        {
            Vida vida = otro.GetComponentInParent<Vida>();
            if (vida != null)
            {
                vida.Morir();
            }
            else
            {
                Destroy(otro.gameObject);
            }
        }
        else{
            Debug.Log(otro.transform.position);
            Debug.Log(transform.position);
        }
    }

    private IEnumerator DañarCada3Seg(Collider2D objeto, Vida vida)
    {
        while (!objeto.CompareTag("Boss") && objetosDentro.Contains(objeto))
        {
            vida.RecibirGolpe(gameObject);
            yield return new WaitForSeconds(3f);
        }
    }
    [SerializeField] private List<GameObject> objetos; 
    [SerializeField] private Camera camara; 
    private void Update()
    {
        foreach (var objeto in objetos.ToArray()) // Usar ToArray para evitar modificar la lista durante la iteración
        {
            foreach (Transform hijo in objeto.transform)
            {
                if (hijo.position.y < transform.position.y && !EsVisiblePorCamara(hijo.gameObject))
                {
                    if (!hijo.CompareTag("Boss"))
                    Destroy(hijo.gameObject);
                }
            }
        }
    }

    private bool EsVisiblePorCamara(GameObject obj)
    {
        var renderer = obj.GetComponent<Renderer>();
        if (renderer == null) return false; // Si no tiene Renderer, no es visible

        return GeometryUtility.TestPlanesAABB(GeometryUtility.CalculateFrustumPlanes(camara), renderer.bounds);
    }

}
