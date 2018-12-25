using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class ProximaCena : MonoBehaviour {
	public string nivel;

	// Use this for initialization
	void Start () {
		StartCoroutine (Espera());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Espera()
	{
		yield return new WaitForSeconds (6);
		SceneManager.LoadScene(nivel);
	}


}
