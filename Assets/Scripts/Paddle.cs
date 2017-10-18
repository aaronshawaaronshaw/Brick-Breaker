using UnityEngine;
using System.Collections;

public class Paddle : MonoBehaviour {
	
	public bool auto = false;
	public float paddleClampLow, paddleClampHigh;
	
	private Ball ball;
	
	void Start() {
		if (Application.loadedLevelName == "Tutorial") {auto = true;};
		ball = GameObject.FindObjectOfType<Ball>(); 
		
	}
	
	/*
	 * Update is called once per frame
	 */
	void Update () {
		if (!auto) {
			moveWithMouse();
		} else {
			autoPlay();
		}
	}
	
	/* 
	 * Forces the paddle to move to the current mouse x location
	 */
	void moveWithMouse() {
		
		float mousePosInBlocks = Input.mousePosition.x / Screen.width * 16;
		float x = Mathf.Clamp(mousePosInBlocks, paddleClampLow, paddleClampHigh);	
		Vector3 paddlePos = new Vector3(x, 0.5f, 0f);
		
		this.transform.position = paddlePos;
	}
	
	/* 
	 * Paddle automatically follows ball's x location if autoplay is activated
	 */
	void autoPlay() {
		
		Vector3 paddlePos = new Vector3(ball.transform.position.x, 0.5f, 0f);
		
		this.transform.position = paddlePos;
		
	}
}
