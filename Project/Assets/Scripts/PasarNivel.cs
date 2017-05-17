using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PasarNivel : MonoBehaviour {
	ScreenFader screenFader;
	public float Tiempo=10;
	public Transform posicionInicioNivel;
	public string nuevoTexto;
	private Text textoCanvas;
	public GameObject jugador;

 	void Awake () {
		screenFader = GetComponent<ScreenFader> ();
		textoCanvas =  GameObject.FindGameObjectWithTag ("TextCanvas").GetComponent <Text> ();

	}

	void Update () {

	}
		
	void OnTriggerEnter(Collider otro){
		//gameover()
		//ir a pantalla de mperdiste
		//SceneManager.LoadScene ("Nivel2", LoadSceneMode.Single);
		//Application.LoadLevel("Ganaste");
		if(otro.CompareTag ("Player")){
			jugador = otro.gameObject;
			jugador.GetComponent <PerderJuego>().nuevaPosicion=posicionInicioNivel;
			StartCoroutine (loadScene ());
		}
	}
	//esta funcion la llamaré desde el sript del boton correcto del primer nivel
	public void pasardenivel(){
		jugador.GetComponent <PerderJuego>().nuevaPosicion=posicionInicioNivel;
		StartCoroutine (loadScene ());
	}
	public IEnumerator loadScene(){
		{
			screenFader.fadeIn = false;
			//deshabilitando el movimiento en VR
			jugador.GetComponent <VRWalkWhilePressing>().enabled=false;
			yield return new WaitForSeconds (Tiempo);
			//cambiar la posicion del jugador
			jugador.transform.position= posicionInicioNivel.position;
			jugador.transform.rotation = posicionInicioNivel.rotation;
			screenFader.fadeIn = true;
			textoCanvas.text=nuevoTexto;
			jugador.GetComponent <VRWalkWhilePressing>().enabled=true;
			yield return new WaitForSeconds (Tiempo);
			textoCanvas.text="";
		}
	}
}
