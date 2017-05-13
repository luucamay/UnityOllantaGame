using UnityEngine;
using System.Collections;

public class PasarNivel : MonoBehaviour {
	ScreenFader screenFader;
	public float tiempo=10;
	public Transform posicionInicioNivel;
	Transform jugador;
	void Awake () {
		screenFader = GetComponent<ScreenFader> ();
	}
		
	void OnTriggerEnter(Collider otro){
		//gameover()
		//ir a pantalla de mperdiste
		//SceneManager.LoadScene ("Nivel2", LoadSceneMode.Single);
		//Application.LoadLevel("Ganaste");
		if(otro.CompareTag ("Player")){
			jugador = otro.transform;
			StartCoroutine (loadScene (screenFader.fadeTime));
		}
	}
	public IEnumerator loadScene(float time){
		{
			screenFader.fadeIn = false;
			yield return new WaitForSeconds (tiempo);
			jugador.Translate (posicionInicioNivel.position);
			screenFader.fadeIn = true;
		}
	}
}
