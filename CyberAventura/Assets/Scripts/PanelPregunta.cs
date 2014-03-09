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
	private	float		tiempoRestante;
	private float		tiempoInicio;
	private float		cambioTiempo;
	private float		seccion;

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
			// Dibujar la pregunta
			GUI.Label(new Rect(50,50,(WindowRect.width/2) - 50,WindowRect.height - 50),textoActual);
			if(GUI.Button(new Rect(WindowRect.width/2,50,WindowRect.width/2 - 50,WindowRect.height/8),AActual))
				ValidarRespuesta(Pregunta.OPCIONA);
			if(GUI.Button(new Rect(WindowRect.width/2,50 + (WindowRect.height/4),WindowRect.width/2 - 50,WindowRect.height/8),BActual))
				ValidarRespuesta(Pregunta.OPCIONB);
			if(GUI.Button(new Rect(WindowRect.width/2,50 + (WindowRect.height/2),WindowRect.width/2 - 50,WindowRect.height/8),CActual))
				ValidarRespuesta(Pregunta.OPCIONC);
			if(GUI.Button(new Rect(WindowRect.width/2,50 + 3*(WindowRect.height/4),WindowRect.width/2 - 50,WindowRect.height/8),DActual))
				ValidarRespuesta(Pregunta.OPCIOND);

			//Timer
			float guiTime = Time.time - tiempoInicio;
			cambioTiempo = Mathf.CeilToInt(tiempoRestante - guiTime);
			seccion = ((tiempoRestante - cambioTiempo)/tiempoRestante);
			Debug.Log(seccion);
			if(seccion < 1){
				int ancho = Mathf.CeilToInt(seccion*((WindowRect.width/2) - 100));
				GUI.Box(new Rect(50, WindowRect.height - 50,ancho,WindowRect.height/4),"");
			}
			else{
				preguntaActiva = false;
				respuestaIncorrecta = true;
			}
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
			if(GUI.Button(new Rect(WindowRect.width/3,WindowRect.height/3,WindowRect.width/3,WindowRect.height/3), "ESO NO ES CORRECTO")){
				if(listaPreguntas.AvanzarPregunta()){
					respuestaIncorrecta = false;
					MostrarPregunta();
				}
				else{
					respuestaIncorrecta = false;
					termino = true;
				}
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
		tiempoRestante = listaPreguntas.DarTiempo();
		seccion = 0.0f;
		cambioTiempo = 0.0f;
		tiempoInicio = Time.time;
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