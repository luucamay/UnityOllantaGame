using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PasarNivel : MonoBehaviour {
	ScreenFader screenFader;
	public float tiempo=10;
	public Transform posicionInicioNivel;
	public string nuevoTexto;
	private Text textoCanvas;
	private GameObject jugador;

 	void Awake () {
		screenFader = GetComponent<ScreenFader> ();
		textoCanvas =  GameObject.FindGameObjectWithTag ("TextCanvas").GetComponent <Text> ();
	}
	void Start () {

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
	public IEnumerator loadScene(){
		{
			screenFader.fadeIn = false;
			//deshabilitando el movimiento en VR
			jugador.GetComponent <VRWalkWhilePressing>().enabled=false;
			yield return new WaitForSeconds (tiempo);
			//cambiar la posicion del jugador
			jugador.transform.position= posicionInicioNivel.position;
			jugador.transform.rotation = posicionInicioNivel.rotation;
			screenFader.fadeIn = true;
			textoCanvas.text=nuevoTexto;
			jugador.GetComponent <VRWalkWhilePressing>().enabled=true;
			yield return new WaitForSeconds (tiempo);
			textoCanvas.text="";
		}
	}
}
