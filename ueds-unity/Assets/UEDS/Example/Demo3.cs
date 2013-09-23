using UnityEngine;
using System.Collections;
using UEDS;

public class Demo3 : MonoBehaviour
{
	public ExampleClass mInstanceToInit;

	public string mFileName = Application.persistentDataPath + "/" + Settings.kDefaultFileName;

	void Start ()
	{
		StartCoroutine(Init());
	}

	IEnumerator Init()
	{
		UEDS.Settings.FileName = mFileName;

		//
		// to stay async we use coroutines and IEnumerators
		//
		IEnumerator ien = UEDS.Settings.Init();

		while(ien.MoveNext())
			yield return 0;

		//
		// Settings are now loaded. We now setup our instances. 
		//

		UEDS.Settings.InitInstanceWithGlobalSettings<ExampleClass>( mInstanceToInit );


	}
	
	// Update is called once per frame
	void Update ()
	{

	}
}

