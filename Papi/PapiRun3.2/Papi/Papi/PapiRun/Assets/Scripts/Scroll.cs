using UnityEngine;
using System.Collections;

public class Scroll : MonoBehaviour {

	public bool IniciarEnMovimiento = false;
	public float velociadad = 0f;
	private bool EmpiezaAcorrer = false;
	private float TiempoInicial = 0f;
	// Use this for initialization
	void Start () {
		NotificationCenter.DefaultCenter().AddObserver(this, "PersonajeEmpiezaACorrer");

	if (IniciarEnMovimiento) 
		{
			PersonajeEmpiezaACorrer ();
		}
	}

	void PersonajeEmpiezaACorrer(){
		EmpiezaAcorrer = true;
		TiempoInicial = Time.time;
	}

	// Update is called once per frame
	void Update () {
		if (EmpiezaAcorrer == true)
		{
			GetComponent<Renderer>().material.mainTextureOffset = new Vector2 (((Time.time - TiempoInicial)* velociadad)%1,0);
		}
	}
	 
}
