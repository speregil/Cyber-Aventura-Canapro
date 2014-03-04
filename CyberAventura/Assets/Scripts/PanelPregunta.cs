using UnityEngine;
using System.Collections;

public class PanelPregunta : MonoBehaviour {

	private	IOPreguntas listaPreguntas;
	private Rect 		WindowRect;
	private bool		ventanaActiva;
	private bool 		respuestaCorrecta;
	private bool		respuestaIncorrecta;
	private bool		preguntaActiva;
	private bool		termino;
	private string		textoActual;
	private string 		AActual;
	private string		BActual;
	private string		CActual;
	private string		DActual;

	void Start () {
		textoActual = "";
		AActual = "";
		BActual = "";
		CActual = "";
		DActual = "";
		ventanaActiva = false;
		preguntaActiva = false;
		respuestaCorrecta = false;
		respuestaIncorrecta = false;
		termino = false;
		CargarLista("prueba");
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI(){
		if(ventanaActiva){
			WindowRect = new Rect(50,50,Screen.width - 100,Screen.height - 100);
			WindowRect = GUI.Window(0,WindowRect,WindowFunction,"");
		}
	}

	void WindowFunction(int WindowID){
		if(preguntaActiva){
			GUI.Label(new Rect(50,50,(WindowRect.width/2) - 50,WindowRect.height - 50),textoActual);
			if(GUI.Button(new Rect(WindowRect.width/2,50,WindowRect.width/2 - 50,WindowRect.height/8),AActual))
				ValidarRespuesta(Pregunta.OPCIONA);
			if(GUI.Button(new Rect(WindowRect.width/2,50 + 2*(WindowRect.height/8),WindowRect.width/2 - 50,WindowRect.height/8),BActual))
				ValidarRespuesta(Pregunta.OPCIONB);
			if(GUI.Button(new Rect(WindowRect.width/2,50 + 4*(WindowRect.height/8),WindowRect.width/2 - 50,WindowRect.height/8),CActual))
				ValidarRespuesta(Pregunta.OPCIONC);
			if(GUI.Button(new Rect(WindowRect.width/2,50 + 6*(WindowRect.height/8),WindowRect.width/2 - 50,WindowRect.height/8),DActual))
				ValidarRespuesta(Pregunta.OPCIOND);
		}
		else if(respuestaCorrecta){
			if(GUI.Button(new Rect(WindowRect.width/3,WindowRect.height/3,WindowRect.width/3,WindowRect.height/3), "¡CORRECTO!")){
				if(listaPreguntas.AvanzarPregunta()){
					respuestaCorrecta = false;
					MostrarPregunta();
				}
				else{
					respuestaCorrecta = false;
					termino = true;
				}
			}
		}
		else if(respuestaIncorrecta){
			if(GUI.Button(new Rect(WindowRect.width/3,WindowRect.height/3,WindowRect.width/3,WindowRect.height/3), "¡VUELVE A INTENTAR!")){
				respuestaIncorrecta = false;
				preguntaActiva = true;
			}
		}
		else if(termino){
			if(GUI.Button(new Rect(WindowRect.width/3,WindowRect.height/3,WindowRect.width/3,WindowRect.height/3), "¡TERMINASTE!")){
				termino = false;
				ventanaActiva = false;
			}
		}
	}

	void CargarLista(string NombreLista){
		listaPreguntas = new IOPreguntas(NombreLista);
		ventanaActiva = true;
		MostrarPregunta();
	}

	void MostrarPregunta(){
		textoActual = listaPreguntas.DarTexto();
		AActual = listaPreguntas.DarOpcionA();
		BActual = listaPreguntas.DarOpcionB();
		CActual = listaPreguntas.DarOpcionC();
		DActual = listaPreguntas.DarOpcionD();
		preguntaActiva = true;
	}

	void ValidarRespuesta(string Opcion){
		if(listaPreguntas.ValidarRespuesta(Opcion)){
			preguntaActiva = false;
			respuestaCorrecta = true;
		}
		else{
			preguntaActiva = false;
			respuestaIncorrecta = true;
		}
	}
}