using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bala : MonoBehaviour
{
    public float velocity = 5f;

    void Update()
    {
        Vector2 novaPos = transform.position;
        novaPos.y += velocity * Time.deltaTime;
        transform.position = novaPos;

        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        float altura = spriteRenderer.bounds.size.y / 2;
        float maxY = Camera.main.orthographicSize + altura;

        // Verificar si la bala está fuera del mapa y destruirla si es así
        if (transform.position.y > maxY)
        {
            Destroy(gameObject);
        }
    }
}

