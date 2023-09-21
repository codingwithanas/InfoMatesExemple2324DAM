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

        // Verificar si la bala est� fuera del mapa y destruirla si es as�
        if (transform.position.y > maxY)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        // Quan la nau toqui un objecte, autom�ticament es cridar� aquest m�tode.
        // El valor de objecteTocat, ser� l'objecte que hem tocat (per exemple, un n�mero).
        if (objecteTocat.tag == "Numero")
        {
            Destroy(gameObject);
        }
    }
}

