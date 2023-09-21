using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Numero : MonoBehaviour
{
    // Start is called before the first frame update

    private float _vel;
    void Start()
    {
        _vel = 2f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 novaPos = transform.position;
        novaPos.y = novaPos.y - _vel * Time.deltaTime;
        transform.position = novaPos;

        DestrueixSiSurtFora();
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

