using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem; // Para nuevo Input System (opcional, ver abajo)

public class PresionaCualquierTecla : MonoBehaviour
{
    [SerializeField] private string nombreEscenaJuego = "Juego"; // Cambiá por tu escena
    [SerializeField] private float tiempoEsperaInicial = 1f; // Para evitar input accidental al inicio

    private float timer;
    private bool puedeIniciar = false;

    private void Start()
    {
        timer = 0f;
        puedeIniciar = false;
    }

    private void Update()
    {
        // Espera un segundo antes de aceptar input
        if (timer < tiempoEsperaInicial)
        {
            timer += Time.deltaTime;
            if (timer >= tiempoEsperaInicial)
                puedeIniciar = true;
            return;
        }

        if (!puedeIniciar) return;

        // === DETECCIÓN DE CUALQUIER TECLA O TOQUE ===
        if (Input.anyKeyDown ||
            (Touchscreen.current != null && Touchscreen.current.primaryTouch.press.wasPressedThisFrame))
        {
            IniciarJuego();
        }
    }

    private void IniciarJuego()
    {
        puedeIniciar = false; // Evita múltiples cargas
        SceneManager.LoadScene(nombreEscenaJuego);
    }
}
