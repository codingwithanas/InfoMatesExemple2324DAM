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
        //Debug.Log("direcioHoritzontal=" + direcioHoritzontal);

        Vector2 direccioIndicada = new Vector2(direccioHoritzontal, 0f);
        Vector2 novaPos = transform.position; // Ens retorna la posisció actual de la nau.
        novaPos += direccioIndicada * _velNau * Time.deltaTime;
        transform.position = novaPos;
    }
}
