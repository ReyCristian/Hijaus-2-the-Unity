using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DireccionPersonaje : MonoBehaviour
{
    public enum Direction
    {
        AbajoIzquierda = 0,
        Izquierda = 1,
        ArribaIzquierda = 2,
        Arriba = 3,
        ArribaDerecha = 4,
        Derecha = 5,
        AbajoDerecha = 6,
        Abajo = 7
    }

    public Direction direccion;
    private SpriteRenderer spriteRenderer;
    public float offsetMultiplier = 0.125f;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        UpdateOffset();
    }

    void Update()
    {
        UpdateOffset();
    }

    private void UpdateOffset()
    {
        if (spriteRenderer != null && spriteRenderer.material != null)
        {
            // Calcula el offset usando el valor numérico de la dirección
            Vector2 offset = new Vector2(0, (int)direccion * offsetMultiplier);
            spriteRenderer.material.mainTextureOffset = offset;
        }
    }
}