using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Numero : MonoBehaviour
{
    // Start is called before the first frame update

    private float _vel;
    private int _valorNumero;

    public Sprite[] _spritesNumeros = new Sprite[10];
    void Start()
    {
        _vel = 2f;
        // Carreguem una imatge de número aleatori.
        System.Random aleatori = new System.Random();
        _valorNumero = aleatori.Next(0, 10); //Aleatori entre 0 i 9
        // Accedim al component Sprite Renderer i dins d'aquest, a l'atribut Sprite
        gameObject.GetComponent<SpriteRenderer>().sprite = _spritesNumeros[_valorNumero];
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 novaPos = transform.position;
        novaPos.y = novaPos.y - _vel 
            * Time.deltaTime;
        transform.position = novaPos;

        DestrueixSiSurtFora();
    }
    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        // Quan la nau toqui un objecte, automàticament es cridarà aquest mètode.
        // El valor de objecteTocat, serà l'objecte que hem tocat (per exemple, un número).
        if (objecteTocat.tag == "Bala" || objecteTocat.tag == "NauJugador")
        {
            GameObject.Find("NumText").GetComponent<NumText>().AfegirNum(_valorNumero);
            Destroy(gameObject);
        }
    }

    // Destrueix quan surt fora.
    private void DestrueixSiSurtFora()
            {
        Vector2 costatInferiorEsquerra = Camera.main.ViewportToWorldPoint(new Vector2(0, 0));
                if (transform.position.y <= costatInferiorEsquerra.y)
            {
                Destroy(gameObject);
            }
        }

 }

