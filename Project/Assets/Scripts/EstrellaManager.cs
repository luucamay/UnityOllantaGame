using UnityEngine;
using System.Collections;

public class EstrellaManager : MonoBehaviour {
	public float Duracion=1.5f;
	public float velocidadRotacion=4;
	public float Distancia=-0.03f;
	void Start () {
	
	}
	
	void Update () {
		if (Duracion > 0) {
			StartAnimation ();
		} else {
			this.enabled = false;
		}
	}
	void StartAnimation(){
		Duracion -= Time.deltaTime;
		transform.Rotate (0,0,velocidadRotacion);
		transform.Translate (0, 0, Distancia);
	}
}
