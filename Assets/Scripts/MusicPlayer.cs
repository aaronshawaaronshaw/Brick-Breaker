using UnityEngine;
using System.Collections;

public class MusicPlayer : MonoBehaviour {

	 static MusicPlayer music = null;
	 void Awake() {
	 
		if (music != null) {
			Destroy(gameObject);
			Debug.Log ("Duplicate music player self-descructing");
		} else {
			music = this;
			GameObject.DontDestroyOnLoad(gameObject);
		}
		
	 }
}
