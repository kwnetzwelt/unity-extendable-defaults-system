using UnityEngine;
using System.Collections;
using UEDS;

[EditorSettingsContainerAttribute(title="Example",description="This is an example Class to show the usage of the global editor settings feature. ")]
public class ExampleClass : MonoBehaviour {
	
	[EditorSetting(title="An integer value of concern",description="Some Property Description here")]
	public int mSomeValue;
	
	
	[EditorSetting(title="A Color")]
	public Color mSomeColor;

	[EditorSetting(title="Default Position",description="The default position for all instances of this type")]
	public Vector3 mDefaultPosition;


	public string mInstanceName = "";

}
