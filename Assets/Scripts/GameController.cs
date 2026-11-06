
using UnityEngine;
using TMPro;
using Vuforia;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
	[SerializeField] float tiempoTotal = 10f;

	[SerializeField] TextMeshProUGUI puntuacionTxt;
	[SerializeField] TextMeshProUGUI tiempoTxt;
	[SerializeField] TextMeshProUGUI muñecaAdivinarTxt;

	[SerializeField]
	string[] opcionesMostrar =
	{
		"Draculaura", "Clawdeen", "Cleo", "Abbey",
		"Venus", "Lagoona", "Ghoulia"
	};

	[Header("Pantallas")]
	[SerializeField] GameObject gameOver;
	[SerializeField] GameObject victoria;
	[SerializeField] GameObject uiJuego;

	[Header("Sonido Game Over")]
	[SerializeField] AudioSource efectoSonidoGameOver;
	[SerializeField] AudioClip clipSonidoGameOver;

	private bool sonidoGameOverReproducido = false;
	private bool partidaTerminada = false;

	private int puntuacion = 0;

	private void Start()
	{
		gameOver.SetActive(false);
		victoria.SetActive(false);
		uiJuego.SetActive(true);

		puntuacionTxt.text = puntuacion.ToString();

		ElegirNuevaMuñeca();
	}

	private void Update()
	{
		if (partidaTerminada)
			return;

		tiempoTotal -= Time.deltaTime;

		if (tiempoTotal <= 0)
		{
			tiempoTotal = 0;
			tiempoTxt.text = "0.0";

			FinalizarPartida();
		}
		else
		{
			tiempoTxt.text = tiempoTotal.ToString("F1");
		}
	}

	private void FinalizarPartida()
	{
		partidaTerminada = true;

		uiJuego.SetActive(false);

		if (puntuacion < 0)
		{
			// GAME OVER
			gameOver.SetActive(true);

			if (clipSonidoGameOver != null &&
				efectoSonidoGameOver != null &&
				!sonidoGameOverReproducido)
			{
				efectoSonidoGameOver.PlayOneShot(clipSonidoGameOver);
				sonidoGameOverReproducido = true;
			}
		}
		else
		{
			// VICTORIA
			victoria.SetActive(true);
		}
	}

	private void ElegirNuevaMuñeca()
	{
		int posAleatoria = Random.Range(0, opcionesMostrar.Length);

		muñecaAdivinarTxt.text = opcionesMostrar[posAleatoria];
	}

	public void chequear(string muñecaEncontrada)
	{
		if (partidaTerminada)
			return;

		Debug.Log("Detectada: " + muñecaEncontrada);

		if (muñecaEncontrada == muñecaAdivinarTxt.text)
		{
			puntuacion++;
		}
		else
		{
			puntuacion--;
		}

		puntuacionTxt.text = puntuacion.ToString();

		ElegirNuevaMuñeca();
	}

	// BOTON REINICIAR
	public void reiniciar()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
	}

	// BOTON VOLVER AL MENU
	public void volverMenu()
	{
		SceneManager.LoadScene("MenuPrincipal");
	}

	// BOTON SALIR
	public void salir()
	{
		Application.Quit();
		Debug.Log("Saliendo del juego");
	}
}
