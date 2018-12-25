using UnityEngine;
using System.Collections;
[RequireComponent(typeof(AudioSource))]
public class TocaSom : MonoBehaviour {


	//private float volume;
	private AudioSource audio;

	void Start() {
		audio = GetComponent<AudioSource>();
		audio.Play();
		//audio.Play(44100);
	}
	
	// Update is called once per frame
	void Update () {
		if(PlayerPrefs.GetInt("PPSom")==1)
		   {
			audio.mute = false;
		}
		else
		{
			audio.mute = true;
		}
		audio.volume = PlayerPrefs.GetFloat("PPVolume");
		//Debug.Log ("Volume:" + audio.volume);
	
	}
}
