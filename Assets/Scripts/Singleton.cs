using System.Linq;
using UnityEngine;

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
	private static T _instance;

	private static object _lock = new object();

	private static bool applicationIsQuitting = false;

	public static bool InstanceExists => (Object)Instance != (Object)null;

	public static T Instance
	{
		get
		{
			if (applicationIsQuitting)
			{
				return (T)null;
			}
			lock (_lock)
			{
				if ((Object)_instance == (Object)null)
				{
					_instance = (T)UnityEngine.Object.FindObjectOfType(typeof(T));
					if ((Object)_instance == (Object)null)
					{
						GameObject gameObject = null;
						GameObject gameObject2 = null;
						string text = typeof(T).ToString().Split('.').LastOrDefault();
						gameObject = (GameObject)Resources.Load(text, typeof(GameObject));
						if (gameObject != null)
						{
							gameObject2 = UnityEngine.Object.Instantiate(gameObject);
							_instance = gameObject2.GetComponent<T>();
						}
						else
						{
							gameObject2 = new GameObject();
							_instance = gameObject2.AddComponent<T>();
						}
						gameObject2.name = "(singleton) " + text;
					}
				}
				return _instance;
			}
		}
	}

	public virtual void Awake()
	{
		if ((Object)_instance == (Object)null)
		{
			_instance = (this as T);
			Object.DontDestroyOnLoad(base.gameObject);
		}
		else
		{
			UnityEngine.Object.Destroy(base.gameObject);
		}
	}

	protected virtual void OnDestroy()
	{
		StopAllCoroutines();
		applicationIsQuitting = true;
	}
}
