using UnityEngine;
using System.Collections;

public class PruebaIO : MonoBehaviour {

	IOPreguntas p;
	// Use this for initialization
	void Start () {
		p = new IOPreguntas("data/prueba.txt");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnGUI(){
		GUI.Label(new Rect(10,10,100,100),p.DarContenido());
	}
}