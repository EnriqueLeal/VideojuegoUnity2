                                   using UnityEngine;
using System.Collections;


public class salto : MonoBehaviour

{
	public float alturaSalto;
	private bool enSuelo = true;

	public Transform comprobadorSuelo;
	private float comprobadorRadio = 0.07f;
	public LayerMask mascaraSuelo;
	private bool dobleSalto = false;
	private Animator animator;

	public float velocidadMovimiento;

	private bool corriendo = false;
	public float velocidad = 1f;
	public float itemSoundVolume = 0f;
	// Use this for initialization
	void Start ()
	{
	
	}
	void Awake(){
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (enSuelo == true) {
		 
		}

		if (Input.GetMouseButtonDown(0)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, alturaSalto);

		}
		/*if (Input.GetKeyDown (KeyCode.D)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocidadMovimiento, GetComponent<Rigidbody2D> ().velocity.y);
			
	}
		if (Input.GetKeyDown (KeyCode.A)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocidadMovimiento, GetComponent<Rigidbody2D> ().velocity.y);
			
		}*/
		if ((enSuelo || !dobleSalto) && Input.GetMouseButtonDown(0)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocidadMovimiento, GetComponent<Rigidbody2D> ().velocity.y);
			//rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
			if (!dobleSalto && !enSuelo) {
				dobleSalto = true;
			}
		
		if (Input.GetMouseButtonDown(0)){
			if(corriendo){
				// Hacemos que salte si puede saltar
				if(enSuelo || !dobleSalto){
     GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, alturaSalto);
					//rigidbody2D.AddForce(new Vector2(0, fuerzaSalto));
					if(!dobleSalto && !enSuelo){
						dobleSalto = true;
					}
				}
			}else{
				corriendo = true;
					NotificationCenter.DefaultCenter().PostNotification(this, "PersonajeEmpiezaACorrer");
			}
		}

	 
		}
	}
	void FixedUpdate(){
		if(corriendo){
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (velocidadMovimiento, GetComponent<Rigidbody2D> ().velocity.y);
		}

		animator.SetFloat("VelX", GetComponent<Rigidbody2D> ().velocity.y);
		enSuelo = Physics2D.OverlapCircle(comprobadorSuelo.position, comprobadorRadio, mascaraSuelo);
		animator.SetBool("isGrounded", enSuelo);
		if(enSuelo){
			dobleSalto = false;
		}
	}
}

