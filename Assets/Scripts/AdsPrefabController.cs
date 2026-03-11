using UnityEngine;

public class AdsPrefabController : MonoBehaviour
{
	private static bool created;

	private void Awake()
	{
		if (!created)
		{
			Object.DontDestroyOnLoad(base.gameObject);
			created = true;
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}
}
