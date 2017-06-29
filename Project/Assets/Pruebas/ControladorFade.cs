using UnityEngine;
using System.Collections;

public class ControladorFade : MonoBehaviour {

	public float fader = 0;
	void Start () {
		
	}
	
	void Update () {
		fader += Time.deltaTime;
		if (fader > 5) {
			PanelFade pf = GameObject.Find("PanelFadeObject").GetComponent<PanelFade>();
			pf.loadLevel("Ollantay");
		}
	}
}
