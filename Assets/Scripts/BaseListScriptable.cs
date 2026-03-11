using System.Collections.Generic;
using UnityEngine;

public abstract class BaseListScriptable<T> : ScriptableObject
{
	[SerializeField]
	protected List<T> m_Details;

	public T this[int index] => m_Details[index];

	public int Count => m_Details.Count;

	protected virtual void Awake()
	{
	}

	protected virtual void OnEnable()
	{
	}

	protected virtual void OnDisable()
	{
	}

	protected virtual void OnDestroy()
	{
	}

	public void Clear()
	{
		m_Details.Clear();
	}

	public void Add(T obj)
	{
		if (m_Details != null)
		{
			m_Details.Add(obj);
		}
	}
}
