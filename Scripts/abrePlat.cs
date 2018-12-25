using UnityEngine;
using System.Collections;

public class abrePlat : MonoBehaviour {

	public Animator Doors;
	void OnTriggerEnter(Collider hit)
	{
		if (hit.gameObject.tag == "Player") {

			Doors.SetBool ("Open", true);
		} 
	}
	void OnTriggerExit(Collider hit)
	{
		if (hit.gameObject.tag == "Player") {
			Doors.SetBool ("Open", false);
		}
	}
}
