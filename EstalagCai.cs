using UnityEngine;
using System.Collections;

public class EstalagCai : MonoBehaviour {
	public Animator Estalag;

	void OnTriggerEnter(Collider hit)
	{
		if (hit.gameObject.tag == "Player") {

			Estalag.SetBool ("Cai", true);
		} 
	}
}
