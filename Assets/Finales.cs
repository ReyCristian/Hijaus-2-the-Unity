using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.SceneManagement;



public class Finales : MonoBehaviour
{
    [SerializeField] private GameObject Derrota;
    [SerializeField] private float delayDerrota = 10f;
    private bool derrotaActivada = false;

    void Update()
    {
        if (!derrotaActivada && !Derrota.activeInHierarchy)
        {
            GameObject[] jugadores = GameObject.FindGameObjectsWithTag("Player");
            Vida[] objetosVida = jugadores
                .Select(jugador => jugador.GetComponent<Vida>())
                .Where(vida => vida != null)
                .ToArray();
            if (objetosVida.All(obj => !obj.isActiveAndEnabled || obj.muerto))
            {
                derrotaActivada = true;
                Invoke(nameof(ActivarDerrota), delayDerrota);
            }
        }
    }

    private void ActivarDerrota()
    {
        if (Derrota != null){
            Derrota.SetActive(true);
            derrotaActivada = false;
        }
    }

    public void Reiniciar()
    {
        StartCoroutine(ReloadSceneCoroutine());
    }

    private IEnumerator ReloadSceneCoroutine()
    {
        // Cargar la escena de forma asincrónica
        AsyncOperation asyncOperation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().name);
        
        // Esperar hasta que la escena se haya cargado completamente
        while (!asyncOperation.isDone)
        {
            yield return null; // Esperar un frame
        }

        // Después de que la escena se haya cargado, buscar el JuegoManager y reiniciar el juego
        JuegoManager juego = FindObjectOfType<JuegoManager>();
        if (juego != null)
        {
            juego.AsignarNivel(1);
            juego.Jugar();
        }

        Destroy(gameObject);
    }
}