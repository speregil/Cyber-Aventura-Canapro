using UnityEngine;
using System.Collections;
using System.IO;

public class IOPreguntas{
	private string 		archivo;
	private int 		numPreguntas;
	private Pregunta[]	listaPreguntas;

	public IOPreguntas(string nArchivo){
		archivo = nArchivo;
		CargarPreguntas();
	}

	private void CargarPreguntas(){
		StreamReader sr = new StreamReader(Application.dataPath + "/Data/" + archivo);
		string contenido  = sr.ReadToEnd();
		string[] data = contenido.Split('\n');
		numPreguntas = System.Int32.Parse(data[0]);
		listaPreguntas = new Pregunta[numPreguntas];
		for(int i = 0; i < numPreguntas;i++){
			string[] dataPregunta = data[i+1].Split(';');
			Pregunta nueva = new Pregunta(dataPregunta[0],dataPregunta[1],dataPregunta[2], dataPregunta[3],dataPregunta[4],dataPregunta[5]);
			listaPreguntas[i] = nueva;
		}
	}

	public string Prueba(){
		return listaPreguntas[3].DarOpcionC();
	}
}