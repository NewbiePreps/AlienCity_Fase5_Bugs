using UnityEngine;
using System.Collections;

public class Esmaga : MonoBehaviour {
	public Animator Doors;

	void OnTriggerEnter(Collider hit)
	{
		if (hit.gameObject.tag == "Player") {

			Doors.SetBool ("Open", true);
		} 
	}
}
