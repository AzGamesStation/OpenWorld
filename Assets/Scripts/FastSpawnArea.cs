using UnityEngine;

public class FastSpawnArea : MonoBehaviour
{
	public bool DebugLog;

	private const float dt = 1f;

	private static float lastTimeTriggerStay;

	public static bool PlayerInArea => lastTimeTriggerStay != 0f && Time.time - lastTimeTriggerStay < 1f;

	private void OnTriggerStay(Collider other)
	{
		if (DebugLog)
		{
			UnityEngine.Debug.Log(other.name);
		}
		if (other.tag == "Player")
		{
			if (DebugLog)
			{
				UnityEngine.Debug.Log("Игрок в зоне.");
			}
			lastTimeTriggerStay = Time.time;
		}
	}
}
