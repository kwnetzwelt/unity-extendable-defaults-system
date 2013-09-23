using UnityEngine;
using System.Collections;

public class Demo2 : MonoBehaviour
{

	void Start ()
	{
		StartCoroutine(Init());
	}

	IEnumerator Init()
	{
		//
		// to stay async we use coroutines and IEnumerators
		//
		IEnumerator ien = UEDS.Settings.Init ();

		while(ien.MoveNext())
			yield return 0;

		//
		// Settings are now loaded. We now setup our instances. 
		//

		var instances = GameObject.FindObjectsOfType(typeof(ExampleClass2)) as ExampleClass2[];
		foreach(var c in instances)
		{
			Debug.Log("Setting up Component on: " + c.name);
			//
			// Loads Settings
			//
			if(c.mInstanceName == null || c.mInstanceName == "")
				UEDS.Settings.InitInstanceWithGlobalSettings<ExampleClass2>( c );
			else
				UEDS.Settings.InitInstanceWithGlobalSettings<ExampleClass2>( c , c.mInstanceName );

		}

		//
		// one more class ... you should use this using an interface :)
		//
		
		var instances2 = GameObject.FindObjectsOfType(typeof(ExampleClass)) as ExampleClass[];
		foreach(var c in instances2)
		{
			Debug.Log("Setting up Component on: " + c.name);
			//
			// Loads Settings
			//
			if(c.mInstanceName == null || c.mInstanceName == "")
				UEDS.Settings.InitInstanceWithGlobalSettings<ExampleClass>( c );
			else
				UEDS.Settings.InitInstanceWithGlobalSettings<ExampleClass>( c , c.mInstanceName );
			
		}

	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}

