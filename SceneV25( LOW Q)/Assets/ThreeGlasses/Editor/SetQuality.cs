using UnityEngine;
using UnityEditor;
using System.Collections;

[ExecuteInEditMode]
public class SetQuality : ScriptableWizard 
{
	// Update is called once per frame
    void OnWizardUpdate() 
    {
        QualitySettings.vSyncCount = 0;
	}
}
