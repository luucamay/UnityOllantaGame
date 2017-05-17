using UnityEngine;
using System.Collections;

public class DuracionInstruccion : MonoBehaviour {
	public float DuracionTexto=5;
	float timer;
	void Start () {
		timer = 0;
	}
	
	void Update () {
		//desactivar este gameobject de instruccion
		if (timer > DuracionTexto) {
			activarInstruccion (false);
		} else {
			timer += Time.deltaTime;
		}
	}
	public void activarInstruccion (bool activar){
		this.gameObject.SetActive (activar);
	}
}
