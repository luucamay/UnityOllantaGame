using UnityEngine;
using System.Collections;

public class AutoDestroy : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
	
	}
	public void autodestruir(){
		Object.Destroy (this.gameObject);
	}
}
