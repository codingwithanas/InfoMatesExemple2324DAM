using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    [SerializeField] private float _velNau;

    // Start is called before the first frame update
    void Start()
    {
        _velNau = 5f;
    }

    // Update is called once per frame
    void Update()
    {
        float direccioHoritzontal = Input.GetAxisRaw("Horizontal");
        float direccioVertical = Input.GetAxisRaw("Vertical");
        //Debug.Log("direcioHoritzontal=" + direcioHoritzontal);

        Vector2 direccioIndicada = new Vector2(direccioHoritzontal, direccioVertical).normalized;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        float anchura = spriteRenderer.bounds.size.x / 2;
        float altura = spriteRenderer.bounds.size.y / 2;

        float limitEsquerra = -Camera.main.orthographicSize * Camera.main.aspect + anchura;
        float limitDreta = Camera.main.orthographicSize * Camera.main.aspect - anchura;
        float limitInferior = -Camera.main.orthographicSize + altura;
        float limitSuperior = Camera.main.orthographicSize - altura;

        Vector2 novaPos = transform.position; // Ens retorna la posisció actual de la nau.
        novaPos += direccioIndicada * _velNau * Time.deltaTime;


        novaPos.x = Mathf.Clamp(novaPos.x, limitEsquerra, limitDreta);
        novaPos.y = Mathf.Clamp(novaPos.y, limitInferior, limitSuperior);

        transform.position = novaPos;

    }
}
