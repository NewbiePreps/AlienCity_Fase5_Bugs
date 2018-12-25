using UnityEngine;
using System.Collections;

public class ChaveEncontrada : MonoBehaviour {

	// Use this for initialization
	public OpenTheDoors porta;
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		
	
	}
	void OnTriggerEnter(Collider other) 
	{
		if (other.gameObject.CompareTag("Player"))
		{
			porta.PegouChave();
			Debug.Log ("Chave Encontrada");
		}
	}
	void OnTriggerExit(Collider other) 
	{
		if (other.gameObject.CompareTag("Player"))
		{
			Destroy (gameObject);
		}
	}
}
