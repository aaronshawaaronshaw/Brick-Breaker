using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class Lives : MonoBehaviour {
	public Text lives;
	private static int livesCount;
	
	private Brick brick;
	// Use this for initialization
	void Start () {
		livesCount = 3;
		lives.text = "lives " + livesCount.ToString();
	
	}
	
	public void decrement(){
		livesCount--;
		lives.text = "lives " + livesCount.ToString();
	}
}
