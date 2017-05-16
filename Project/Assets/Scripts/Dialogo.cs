using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Dialogo : MonoBehaviour
{
	public string[] textos;
	public float tiempoDuracionTexto = 2f;
	Text texto;
	public float timer;
	int numeroTextos;
	int indice;
	GameObject jugador;
	public Canvas canvas;
	void Start ()
	{
		timer = tiempoDuracionTexto;
		indice = 0;
		numeroTextos = textos.Length;
		texto = GetComponentInChildren <Text> ();
		//para rotar a la sabia anciana hacia el jugador
		jugador = GameObject.FindGameObjectWithTag ("Player");
		transform.rotation = Quaternion.LookRotation (jugador.transform.forward*-1);

	}

	void Update ()
	{
		timer += Time.deltaTime;
		if (timer > tiempoDuracionTexto) {
			timer = 0;
			if (indice < numeroTextos) {
				texto.text = textos [indice];
				indice++;
			} else {
				texto.text = "";
				//activa el canvas que tiene los botones de preguntas
				canvas.gameObject.SetActive (true);
				//la idea es que no avance cuando aprete los botones
				//jugador.GetComponent <VRWalkWhilePressing>().enabled=false;
			}
		}
	}
}
