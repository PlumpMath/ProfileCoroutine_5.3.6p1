using UnityEngine;
using Performance;
using System.Collections;
using System.Collections.Generic;

public class CoroutineTest : MonoBehaviour 
{
	private Coroutine cPool;
	private bool isExecute = false;

	private IEnumerator Start () 
	{
		cPool = StartCoroutine(Dummy());	
		StartCoroutine(MyUpdate());
		yield break;
	}

	private IEnumerator MyUpdate()
	{
		while(true)
		{
			isExecute = true;
			yield return new WaitWhile(() => isExecute);
			// 取り敢えず待つ
			Debug.LogError("待ってます");
			yield return new WaitForSeconds(1);
		}
	}

	private IEnumerator Dummy()
	{
		while(true)
		{
			yield return new WaitUntil(() => isExecute);
			Debug.LogError("始まり");
			yield return new WaitForSeconds(3);	
			Debug.LogError("終わり");
			isExecute = false;			
		}
	}
}
