using UnityEngine;
using Vuforia;
using TMPro;
public class Personajes : MonoBehaviour
{
	private ObserverBehaviour observer;
	[SerializeField] string personajeImageTarget;
	public GameController controladorJuego;

	void Awake()
	{
		observer = GetComponent<ObserverBehaviour>();
	}

	// Update is called once per frame
	private void OnEnable()
	{
		if (observer != null)
		{
			observer.OnTargetStatusChanged += OnTargetStatusChanged;
		}
	}
	private void OnDisable()
	{
		if (observer != null)
		{
			observer.OnTargetStatusChanged -= OnTargetStatusChanged;
		}
	}

	private void OnTargetStatusChanged(ObserverBehaviour behaviour, TargetStatus status)
	{
		//Logica del juego



		// personajeImageTarget.text = "Reconoce a Draculaura";
		controladorJuego.chequear(personajeImageTarget);
	}
}


