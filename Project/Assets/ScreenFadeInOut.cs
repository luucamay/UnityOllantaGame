using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class ScreenFadeInOut : MonoBehaviour {
	public int FadeSpeed=3;
	private bool sceneStarting=true;
	private Image image;
	void Awake(){
		image = GetComponentInChildren <Image> ();
	}
	void Update(){
		if (sceneStarting) {
			StartScene ();
		}
	}
	void FadeToClear(){
		image.color = Color.Lerp (image.color, Color.clear,FadeSpeed*Time.deltaTime);
	}
	void FadeToBlack(){
		image.color = Color.Lerp (image.color, Color.black,FadeSpeed*Time.deltaTime);
	}
	void StartScene(){
		FadeToClear ();
		//preguntar si el alfa es casi transparente
		if(image.color.a<=0.05f){
			image.color = Color.clear;
			sceneStarting = false;
		}
	}
	public void EndScene(){
		FadeToBlack ();
		if(image.color.a>=0.95f){
			SceneManager.LoadScene (0);
		}
	}
}
