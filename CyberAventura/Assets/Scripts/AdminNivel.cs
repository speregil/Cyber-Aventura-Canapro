using UnityEngine;
using System.Collections;

public class AdminNivel : MonoBehaviour {

	public 	GameObject personaje;

	private Movimiento mov;

	// Use this for initialization
	void Start () {
		mov = (Movimiento)personaje.GetComponent(typeof(Movimiento));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void nuevoDestino(Vector3 destino){
		mov.IniciarMovimiento(destino);
	}
}