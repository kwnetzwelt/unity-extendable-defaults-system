using UnityEngine;
using System.Collections;
using UEDS;

[EditorSettingsContainerAttribute(gizmo="duck.png")]
public class ExampleClass2 : MonoBehaviour {
	
	[EditorSetting]
	public int mSomeValue;
	
	
	[EditorSetting]
	public Color mSomeColor;

	[EditorSetting]
	public Vector3 MyVector
	{ get; set;}

	public string mInstanceName = "";

}
