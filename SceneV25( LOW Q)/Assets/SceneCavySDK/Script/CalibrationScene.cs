using UnityEngine;
using System.Collections;

public class CalibrationScene : MonoBehaviour
{
	public string nextScene="GameScene";
	public CalibrationUI caliUI;
	
	void Start()
	{
		caliUI.doCalibration=true;
		
		caliUI.OnCalibratedEvent-=StartGame;
		caliUI.OnCalibratedEvent+=StartGame;
		caliUI.Connect();		
	}
	
	void GotoNextScene(PlayBandData data)
	{
		if (CalibrationUI.isCorrectStep())
		{
			StartGame();
		}
	}
	
	void StartGame()
	{
		caliUI.OnCalibratedEvent-=StartGame;
		
		Application.LoadLevel(nextScene);
		PlayBand.FixedNorth();
	}
}
