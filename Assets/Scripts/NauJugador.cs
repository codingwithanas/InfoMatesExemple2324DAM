using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NauJugador : MonoBehaviour
{
    [SerializeField] public float _velNau;
    public GameObject _PreFabExplosio;

    // Start is called before the first frame update
    void Start()
    {
        _velNau = 7f;
    }

    // Update is called once per frame
    void Update()
    {
        MovimentNau();

        DispararBala();




        
    }


    private void OnTriggerEnter2D(Collider2D objecteTocat)
    {
        // Quan la nau toqui un objecte, automàticament es cridarà aquest mètode.
        // El valor de objecteTocat, serà l'objecte que hem tocat (per exemple, un número).
        if (objecteTocat.tag == "Numero")
        {
            GameObject explosio = Instantiate(_PreFabExplosio);
            explosio.transform.position = transform.position;
            //Destroy(gameObject);
            GameObject.Find("GameManager")
                .GetComponent<GameManager>()
                .SetEstatGameManager(GameManager.EstatsGameManager.GameOver);
        }
    }
    private void MovimentNau()
    {
        float direccioHoritzontal = Input.GetAxisRaw("Horizontal");
        float direccioVertical = Input.GetAxisRaw("Vertical");
        //Debug.Log("direcioHoritzontal=" + direcioHoritzontal);

        Vector2 direccioIndicada = new Vector2(direccioHoritzontal, direccioVertical).normalized;

        //T Trobar limits pantalla
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();

        float anchura = spriteRenderer.bounds.size.x / 2;
        float altura = spriteRenderer.bounds.size.y / 2;

        float limitEsquerra = -Camera.main.orthographicSize * Camera.main.aspect + anchura;
        float limitDreta = Camera.main.orthographicSize * Camera.main.aspect - anchura;
        float limitInferior = -Camera.main.orthographicSize + altura;
        float limitSuperior = Camera.main.orthographicSize - altura;

        // Moure nau
        Vector2 novaPos = transform.position; // Ens retorna la posisció actual de la nau.
        novaPos += direccioIndicada * _velNau * Time.deltaTime;


        novaPos.x = Mathf.Clamp(novaPos.x, limitEsquerra, limitDreta);
        novaPos.y = Mathf.Clamp(novaPos.y, limitInferior, limitSuperior);

        transform.position = novaPos;
    }

    private void DispararBala()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {         
            GameObject bala = Instantiate(Resources.Load("Prefabs/bullets_1") as GameObject);
            bala.transform.position = this.transform.position;
        }
    }
}
