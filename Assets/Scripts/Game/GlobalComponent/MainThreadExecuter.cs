using System.Collections.Generic;
using UnityEngine;

namespace Game.GlobalComponent
{
	public class MainThreadExecuter : MonoBehaviour
	{
		public delegate void Runnable();

		public int RunsPerFrame = 5;

		private static MainThreadExecuter instance;

		private Queue<Runnable> runnables;

		public static MainThreadExecuter Instance => instance;

		public void Run(Runnable runnable)
		{
			runnables.Enqueue(runnable);
		}

		private void Awake()
		{
			if (instance == null)
			{
				Object.DontDestroyOnLoad(this);
				instance = this;
				runnables = new Queue<Runnable>();
			}
			else
			{
				UnityEngine.Object.Destroy(base.gameObject);
			}
		}

		private void Update()
		{
			for (int i = 0; i < RunsPerFrame; i++)
			{
				if (runnables.Count <= 0)
				{
					break;
				}
				runnables.Dequeue()();
			}
		}
	}
}
