using UnityEngine;
using System.Collections;

public class OnClick : MonoBehaviour {
	
	public 	GameObject 	Admin;
	private AdminNivel 	adminNivel;

	void Start () {
		adminNivel = (AdminNivel)Admin.GetComponent(typeof(AdminNivel));
	}
	
	void Update () {

	}

	void OnMouseDown(){
		adminNivel.nuevoDestino(transform.position);
	}              
}