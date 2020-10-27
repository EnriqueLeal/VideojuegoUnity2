using UnityEngine;
using System.Collections;

public class muerte : MonoBehaviour {

	//int vida = 100f;

// Use this for initialization
// Use this for initialization
void Start () {
	
}

// Update is called once per frame
	void Update () {
		
	}
	
	void OnTriggerEnter2D(Collider2D other){
		if(other.tag == "Player"){                                   
			Debug.Break();
		
				Destroy(gameObject);
			}
			// POR HACER... HACER QUE SE MUESTRE LA PUNTUACION MAXIMA
			// (HA MUERTO EL PERSONAJE)
		}

	}


