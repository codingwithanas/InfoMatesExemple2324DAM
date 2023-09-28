using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject nauJugador;
    public GameObject textGameOver;
    public GameObject TitolJoc;
    public GameObject butoInici;
    public GameObject generadorNumeros;

    public enum EstatsGameManager
    {
        Inici,
        Jugant,
        GameOver
    }

    private EstatsGameManager _estatGameManager;
    
    // Start is called before the first frame update
    void Start()
    {
        _estatGameManager = EstatsGameManager.Inici;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ActualizaEstatGameManager()
    {
        switch (_estatGameManager)
        {
                case EstatsGameManager.Inici:

                    nauJugador.SetActive(false);
                    TitolJoc.SetActive(true);
                    textGameOver.SetActive(false);
                    butoInici.SetActive(true);
                    //generadorNumeros.GetComponent<GeneradorNumeros>().AturaGeneracioNums();

                    break;

                case EstatsGameManager.Jugant:

                    nauJugador.SetActive(true);
                    TitolJoc.SetActive(false);
                    textGameOver.SetActive(false);
                    butoInici.SetActive(false);
                    generadorNumeros.GetComponent<GeneradorNumeros>().IniciaGeneracioNums();

                break;

                case EstatsGameManager.GameOver:

                    nauJugador.SetActive(false);
                    TitolJoc.SetActive(false);
                    textGameOver.SetActive(true);
                    butoInici.SetActive(false);
                    generadorNumeros.GetComponent<GeneradorNumeros>().AturaGeneracioNums();

                break;
        }
    }

    public void SetEstatGameManager(EstatsGameManager estat)    { 
        _estatGameManager = estat;
        ActualizaEstatGameManager();
    }

    public void PassarAEstatJugant()
    {
        _estatGameManager = EstatsGameManager.Jugant;
        ActualizaEstatGameManager();
    }
}
