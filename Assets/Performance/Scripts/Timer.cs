using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;

namespace Performance
{
	public class Timer 
	{
		private static Stopwatch stopwatch = new Stopwatch();

		public static void Start()
		{
			stopwatch.Reset();
			stopwatch.Start();
		}

		public static void Stop(out System.TimeSpan elapsed)
		{
			stopwatch.Stop();
			elapsed = stopwatch.Elapsed;
		}

		public static void Stop(out long ms)
		{
			stopwatch.Stop();
			ms = stopwatch.ElapsedMilliseconds;
		}
	}
}
