using UnityEngine;
using System.Collections;

public class PanelPregunta : MonoBehaviour {

	private	IOPreguntas listaPreguntas;
	private Rect 		WindowRect;
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

		CargarLista("prueba");
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnGUI(){
		WindowRect = new Rect(50,50,Screen.width - 100,Screen.height - 100);
		WindowRect = GUI.Window(0,WindowRect,WindowFunction,"");
	}

	void WindowFunction(int WindowID){
		GUI.Label(new Rect(50,50,(WindowRect.width/2) - 50,WindowRect.height - 50),textoActual);
		GUI.Button(new Rect(WindowRect.width/2,50,WindowRect.width/2 - 50,WindowRect.height/8),AActual);
		GUI.Button(new Rect(WindowRect.width/2,50 + 2*(WindowRect.height/8),WindowRect.width/2 - 50,WindowRect.height/8),BActual);
		GUI.Button(new Rect(WindowRect.width/2,50 + 4*(WindowRect.height/8),WindowRect.width/2 - 50,WindowRect.height/8),CActual);
		GUI.Button(new Rect(WindowRect.width/2,50 + 6*(WindowRect.height/8),WindowRect.width/2 - 50,WindowRect.height/8),DActual);
	}

	void CargarLista(string NombreLista){
		listaPreguntas = new IOPreguntas(NombreLista);
		MostrarPregunta();
	}

	bool CambiarPregunta(){
		if(listaPreguntas.HaySiguiente()){
			listaPreguntas.AvanzarPregunta();
			MostrarPregunta();
			return true;
		}
		return false;
	}

	void MostrarPregunta(){
		textoActual = listaPreguntas.DarTexto();
		AActual = listaPreguntas.DarOpcionA();
		BActual = listaPreguntas.DarOpcionB();
		CActual = listaPreguntas.DarOpcionC();
		DActual = listaPreguntas.DarOpcionD();
	}
}