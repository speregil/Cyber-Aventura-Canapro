using UnityEngine;
using System.Collections;
using System.IO;

public class IOPreguntas{
	string contenido;

	public IOPreguntas(string nArchivo){
		Debug.Log(Application.dataPath + "/" + nArchivo);
		StreamReader sr = new StreamReader(Application.dataPath + "/" + nArchivo);
		contenido  = sr.ReadToEnd();
	}

	public string DarContenido(){
		return contenido;
	}
}