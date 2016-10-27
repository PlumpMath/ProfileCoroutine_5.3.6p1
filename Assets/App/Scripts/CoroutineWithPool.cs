using UnityEngine;
using Performance;
using System.Collections;
using System.Collections.Generic;

public class CoroutineWithPool : MonoBehaviour 
{
	private List<bool> isExecutes = new List<bool>();
	private int counter = 0;
	private int TotalMilliSec = 0;

	private IEnumerator Start () 
	{
		for (int i = 0; i < 10000; ++i)
		{
			isExecutes.Add(false);
			StartCoroutine(Dummy(i));	
		}
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
				isExecutes[i] = true;
			}
			Profiler.EndSample();
			Timer.Stop(out ts);
			TotalMilliSec += ts.Milliseconds;

			++counter;
			yield return null;
		}

		Debug.LogError(TotalMilliSec + "ms");
	}

	private IEnumerator Dummy(int id)
	{
		while(true)
		{
			yield return new WaitUntil(() => isExecutes[id]);
			yield return null;	
			isExecutes[id] = false;			
		}
	}
}
