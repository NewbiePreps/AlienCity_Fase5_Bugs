using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour {

	public float MoveSpeed;
	public float RotationSpeed;
	CharacterController cc;
	private Animator anim;
	protected Vector3 gravidade = Vector3.zero;
	protected Vector3 move = Vector3.zero;
	private bool jump = false;
	public int vida=100;
	public int dano=0;
	public Image bVida;
	public GameObject tiro;
	public GameObject posTiro;
	public int numTiros = 10;




	
	void Start()
	{
		cc = GetComponent<CharacterController> ();
		anim = GetComponent<Animator>();
		anim.SetTrigger("Parado");
		bVida.fillAmount = vida / 100f;
		bVida.color = Color.Lerp (Color.red, Color.green, bVida.fillAmount);
	}

	void Update()
	{
		Vector3 move = Input.GetAxis ("Vertical") * transform.TransformDirection (Vector3.forward) * MoveSpeed;
		transform.Rotate (new Vector3 (0, Input.GetAxis ("Horizontal") * RotationSpeed * Time.deltaTime, 0));

		if (!cc.isGrounded) {
			gravidade += Physics.gravity * Time.deltaTime;
		} 
		else 
		{
			gravidade = Vector3.zero;
			if(jump)
			{
				gravidade.y = 6f;
				jump = false;
			}
		}
		if (vida <= 0) {
			TrocaCena ("GameOver");
		}
		move += gravidade;
		cc.Move (move* Time.deltaTime);
		Anima ();
	}
	 
	void Anima()
	{
		if (!Input.anyKey)
		{
			anim.SetTrigger("Parado");
		} 
		else 
		{
			if(Input.GetKeyDown("space"))
			{
				anim.SetTrigger("Pula");
				jump = true;
			}
			else
			{
				if (Input.GetKeyDown (KeyCode.LeftControl) && numTiros>0) {
					Fire (); 

				} else {
					anim.SetTrigger ("Corre");
				}
			}
		}
	}

	void OnTriggerEnter (Collider other)
	{
		if (other.gameObject.CompareTag ("armadilha")) {
			dano = 10;
			vida -= dano;

		}
		else 
		{
			if (other.gameObject.CompareTag ("esmaga")) {
				dano = 30;
				vida -= dano;
			} else {
				dano = 0;
			}
		}
		if(other.gameObject.CompareTag ("sucesso")) {
			TrocaCena ("Sucesso");
		}
		bVida.fillAmount = vida / 100f;
		bVida.color = Color.Lerp (Color.red, Color.green, bVida.fillAmount);
	}

	void TrocaCena(string fase)
	{
		SceneManager.LoadScene(fase);
	}

	void Fire()

	{
		var bullet = (GameObject)Instantiate(tiro,posTiro.transform.position,posTiro.transform.rotation);
		bullet.GetComponent<Rigidbody> ().velocity = bullet.transform.forward * 10;
		Destroy(bullet, 2.0f); 
		numTiros -= 1;
	}

	public void RecarregaArma(int municao)
	{
		numTiros += municao;
	}


}
