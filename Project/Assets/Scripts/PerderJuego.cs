using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PerderJuego : MonoBehaviour {
	public float tiempo=2f;
	public string nuevoTexto;
	public Transform nuevaPosicion;
	private Text textoCanvas;
	ScreenFader screenFader;

	void Start () {
		screenFader = GetComponent<ScreenFader> ();
		textoCanvas =  GameObject.FindGameObjectWithTag ("TextCanvas").GetComponent <Text> ();
	}
	
	void Update () {
	}
	void OnTriggerEnter(Collider otro){
		if(otro.CompareTag ("Enemy")){
		//ir a pantalla de mperdiste
			StartCoroutine (volverAEmpezar ());
		}
	}
	public IEnumerator volverAEmpezar(){
		{
			textoCanvas.text=nuevoTexto;
			screenFader.fadeIn = false;
			yield return new WaitForSeconds (tiempo);
			screenFader.fadeIn = true;
			transform.position = nuevaPosicion.position;
			transform.rotation = nuevaPosicion.rotation;
			textoCanvas.text="";
		}
	}
}
