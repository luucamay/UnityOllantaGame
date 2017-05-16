using UnityEngine;
using System.Collections;
 
public class Thrower : MonoBehaviour {
   
    public GameObject ballscriptref;
 
    // Use this for initialization
    void Start () {
   
    }
   
    // Update is called once per frame
    void Update () {
   
    }
 
    public void ThrowBall(){
 
        ballscriptref.GetComponent<BallScript>().ReleaseMeow();
 
            //ballscriptref.ReleaseMeow ();
    }
}