using UnityEngine;
using System.Collections;
using Performance;

public class CoroutineWithoutPool : MonoBehaviour 
{
	private int counter = 0;
	private int TotalMilliSec = 0;

	private IEnumerator Start () 
	{
		yield return StartCoroutine(MyUpdate());
	}

	private IEnumerator MyUpdate()
	{
		System.TimeSpan ts;
		TotalMilliSec = 0;

		while(counter < 100)
		{
			Timer.Start();
			Profiler.BeginSample("Coroutine --------------------------------");
			for (int i = 0; i < 10000; ++i)
			{
				StartCoroutine(Dummy());	
			}
			Profiler.EndSample();
			Timer.Stop(out ts);
			TotalMilliSec += ts.Milliseconds;

			++counter;
			yield return null;
		}

		Debug.LogError(TotalMilliSec + "ms");
	}

	private IEnumerator Dummy()
	{
		yield return null;	
	}
}
