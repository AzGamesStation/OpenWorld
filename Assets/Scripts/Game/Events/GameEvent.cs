using System.Collections.Generic;
using UnityEngine;

namespace Game.Events
{
	[CreateAssetMenu]
	public class GameEvent : ScriptableObject
	{
		private readonly List<GameEventListener> eventListeners = new List<GameEventListener>();

		public void Raise()
		{
			for (int num = eventListeners.Count - 1; num >= 0; num--)
			{
				eventListeners[num].OnEventRaised();
			}
		}

		public void RegisterListener(GameEventListener listener)
		{
			if (!eventListeners.Contains(listener))
			{
				eventListeners.Add(listener);
			}
		}

		public void UnregisterListener(GameEventListener listener)
		{
			if (eventListeners.Contains(listener))
			{
				eventListeners.Remove(listener);
			}
		}
	}
}
