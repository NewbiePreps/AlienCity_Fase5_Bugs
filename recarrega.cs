using UnityEngine;
using System.Collections;

public class recarrega : MonoBehaviour {

	private PlayerController PC;

	void Start()
	{
		GameObject PlayerObjeto = GameObject.FindWithTag ("Player");
		if (PlayerObjeto != null) {
			PC = PlayerObjeto.GetComponent<PlayerController>();
		}
	}

	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("Player")||(other.gameObject.CompareTag("tiro")))
		{
			PC.RecarregaArma (10);
			Destroy(gameObject);

		}
	}
}
