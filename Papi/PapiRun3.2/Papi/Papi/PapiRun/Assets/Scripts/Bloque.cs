using UnityEngine;
using System.Collections;

public class Bloque : MonoBehaviour {

	private bool haColisionadoConElJugador = false;
	public float puntosGanados = 0;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D collision){
		if(!haColisionadoConElJugador && collision.gameObject.tag == "Player"){
			GameObject obj = collision.contacts[0].collider.gameObject;
			if(obj.name == "PierDerSup" || obj.name == "PierIzqSup"){
				haColisionadoConElJugador = true;
				NotificationCenter.DefaultCenter().PostNotification(this, "IncrementarPuntos", puntosGanados);
			}
		}
	} 
}
