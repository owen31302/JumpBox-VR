using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FPSDisplay : MonoBehaviour {


	float deltaTime = 0.0f;
	public Text FPSText;

	void Awake(){
		//QualitySettings.vSyncCount = 0;  // VSync must be disabled
		//Application.targetFrameRate = 300;
	}

	void Update () {

		deltaTime += (Time.deltaTime - deltaTime) * 0.1f;
		float fps = 1.0f / deltaTime;
		FPSText.text = "FPS:" + fps;
	}
}
