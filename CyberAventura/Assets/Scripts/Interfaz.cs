using UnityEngine;
using System.Collections;

public class Interfaz : MonoBehaviour {

	private GUIStyle estiloBotonModoJuego;
	private GUIStyle estiloBotonMapa;
	private GUIStyle estiloBotonEstadisticas;
	private GUIStyle estiloBotonLogin;
	private GUIStyle estiloTextLogin;
	private GUIStyle estiloTextPassword;

	private GUIContent contenidoBoxLogin;
	private GUIContent contenidoBotonLogin;

	private const int LOGIN = 1;
	private const int TUTO = 2;
	private const int PRINCIPAL = 3;
	private const int MAPA = 4;
	private const int ESTADISTICAS = 5;
	private const int MODO = 6;

	private int estado;
	private string login = "ingrese su cuenta aqui";
	private string pass = "prueba";

	// Use this for initialization
	void Start () {
		estiloBotonModoJuego = new GUIStyle();
		estiloBotonMapa = new GUIStyle();
		estiloBotonEstadisticas = new GUIStyle();
		estiloBotonLogin = new GUIStyle();

		contenidoBoxLogin = new GUIContent();
		contenidoBotonLogin = new GUIContent();

		estado = 1;
	}
	
	// Update is called once per frame
	void OnGUI () {
		if(LOGIN == estado)
		{
			if(GUI.Button(new Rect((Screen.width*3/8),(Screen.height/2+Screen.height*2/16),(Screen.width*1/8),(Screen.height*1/32)), "Loguearse"))
			{
				estado = TUTO;
			}
			GUI.Label(new Rect((Screen.width/4),(Screen.height*3/8)-(Screen.height*1/32),(Screen.width*1/4),(Screen.height*1/16)), "Cuenta");
			GUI.Label(new Rect((Screen.width/4),(Screen.height/2)-(Screen.height*1/32),(Screen.width*1/4),(Screen.height*1/16)), "Contraseña");
			GUI.Box(new Rect((Screen.width*1/8),(Screen.height*1/4),(Screen.width*3/4),(Screen.height*1/2)), contenidoBoxLogin);
			login = GUI.TextField(new Rect((Screen.width/4),(Screen.height*3/8),(Screen.width*1/4),(Screen.height*1/16)), login);
			pass = GUI.PasswordField(new Rect((Screen.width/4),(Screen.height/2),(Screen.width*1/4),(Screen.height*1/16)), pass, "*"[0]);
			GUI.Label(new Rect((Screen.width*1/8),(Screen.height*1/4-Screen.height*1/16),(Screen.width*1/4),(Screen.height*1/16)), "Login");
		}
		else if(TUTO == estado)
		{
			estado = PRINCIPAL;
		}
		else if(PRINCIPAL == estado)
		{
			if(GUI.Button(new Rect((Screen.width*1/8),(Screen.height*3/16),(Screen.width*1/4),(Screen.height*1/16)), "Mapa"))
			{
				Application.LoadLevel("Mapa");
			}
			if(GUI.Button(new Rect((Screen.width*3/8),(Screen.height*7/16+Screen.height*1/32),(Screen.width*1/4),(Screen.height*1/16)), "Modos de Juego"))
			{
				estado = MODO;
			}
			if(GUI.Button(new Rect((Screen.width*5/8),(Screen.height*12/16),(Screen.width*1/4),(Screen.height*1/16)), "Estadisticas"))
			{
				estado = ESTADISTICAS;
			}
			if(GUI.Button(new Rect((Screen.width*1/8),(Screen.height*12/16),(Screen.width*1/4),(Screen.height*1/16)), "Repetir Tutorial"))
			{
				estado= TUTO;
			}
			GUI.Label(new Rect((Screen.width*5/8),(Screen.height*3/16),(Screen.width*1/4),(Screen.height*1/4)), "Logo");
		}
		/**else if(MAPA == estado)
		{
			mapa.SetActive(true);
		}**/
		else if(ESTADISTICAS == estado)
		{
		}
		else if(MODO == estado)
		{
			if(GUI.Button(new Rect((Screen.width*3/8),(Screen.height*3/16),(Screen.width*1/4),(Screen.height*1/16)), "Modo 1"))
			{
				//do something....
			}
			if(GUI.Button(new Rect((Screen.width*3/8),(Screen.height*7/16+Screen.height*1/32),(Screen.width*1/4),(Screen.height*1/16)), "Modo 2"))
			{
				//do something....
			}
			if(GUI.Button(new Rect((Screen.width*3/8),(Screen.height*12/16),(Screen.width*1/4),(Screen.height*1/16)), "Modo 3"))
			{
				//do something....
			}
		}
	}
}
