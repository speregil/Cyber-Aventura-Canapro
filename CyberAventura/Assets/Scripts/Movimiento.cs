using UnityEngine;
using System.Collections;

public class Movimiento : MonoBehaviour {

	public 	float 	velocidad;
	private Vector3 posActual;
	private Vector3 posDestino;
	private bool	enMovimiento;

	// Use this for initialization
	void Start () {
		posActual = transform.position;
		posDestino = transform.position;
		enMovimiento = false;
	}
	
	// Update is called once per frame
	void Update () {
		if(enMovimiento){
			posActual = transform.position;
			transform.position = Vector3.MoveTowards(posActual,posDestino,velocidad*Time.deltaTime);
		}

		if(posActual.Equals(posDestino)){
			enMovimiento = false;
		}
	}

	public void IniciarMovimiento(Vector3 destino){
		posActual = transform.position;
		posDestino = destino;
		enMovimiento = true;
	}
}
