using UnityEngine;
using UnityEngine.EventSystems;
using System.Collections;

public class TiempoBrillo : MonoBehaviour
{
	public float Duracion = 3f;
	public Material materialNuevo;
	public GameObject jugador;
	float timer;
	MeshRenderer[] renderer;
	GameObject puntasEstrella;
	Material []vectorMateriales = new Material[2];
	EventTrigger eventTrigger;
	void Start ()
	{
		timer = 0;	
		renderer = GetComponentsInChildren <MeshRenderer> ();
		eventTrigger = GetComponent <EventTrigger> ();
	}

	void Update ()
	{
		timer += Time.deltaTime;
		if (timer > Duracion) {
			renderer [0].material = materialNuevo;
			renderer [1].material = materialNuevo;
			renderer [2].material = materialNuevo;
			renderer [3].material = materialNuevo;
			//renderer [4].material = materialNuevo;
			vectorMateriales [0] = materialNuevo;
			vectorMateriales [1] = materialNuevo;
			renderer [4].materials = vectorMateriales;
			eventTrigger.enabled = false;
		}
	}
}
