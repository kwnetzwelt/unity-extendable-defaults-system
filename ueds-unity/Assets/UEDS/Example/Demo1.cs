using UnityEngine;
using System.Collections;
using UEDS;
public class Demo1 : MonoBehaviour
{
	public ExampleClass classToInit;

	// Use this for initialization
	void Start ()
	{
		StartCoroutine( Init () );
	}

	IEnumerator Init()
	{
		IEnumerator ien = Settings.Init();
		while(ien.MoveNext())
			yield return 0;

		//
		// Init is Done. Now Setup our instance. 
		//
		Settings.InitInstanceWithGlobalSettings<ExampleClass>( classToInit );
	}
}

