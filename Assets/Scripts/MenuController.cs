
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuController : MonoBehaviour
{
	public void Jugar()
	{
		SceneManager.LoadScene("JuegoPrincipal");
	}

	public void Salir()
	{
		Application.Quit();
	}
}

