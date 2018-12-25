using UnityEngine;
using System.Collections;

public class RotacionaPedra : MonoBehaviour {
	
	void Update () {
		transform.Rotate(new Vector3(0, 0, 1), 30 * Time.deltaTime);
	}

}
