using System;
using UnityEngine;

[Serializable]
public class BaseBuff : MonoBehaviour
{
	[Separator("BaseBuff")]
	public bool DebugLog;

	[Space(10f)]
	[Tooltip("If not oneshot. How many time it's effect can be stacked?")]
	public int MaxStacks = 1;

	[Space(10f)]
	[Tooltip("Set 0 for manual control")]
	public float EffectDuration = 5f;

	[Tooltip("Is duration stack or just renew?")]
	public bool StackableDuration;

	[Space(10f)]
	public BaseFX VFX;

	protected float activationTime;

	protected bool effectIsActive;

	protected float timeToStop;

	protected int currStacks;

	public bool IsActive => effectIsActive;

	protected virtual void Start()
	{
		if (VFX != null)
		{
			VFX.EffectDuration = EffectDuration;
			VFX.StackableDuration = StackableDuration;
		}
	}

	protected virtual void FixedUpdate()
	{
		if (effectIsActive)
		{
			CheckAutoStop();
		}
	}

	protected void CheckAutoStop()
	{
		if (EffectDuration != 0f && timeToStop != 0f && Time.time >= timeToStop)
		{
			StopEffect();
		}
	}

	public virtual void StartEffect()
	{
		if (currStacks < MaxStacks)
		{
			currStacks++;
			AddStackEffect();
		}
		effectIsActive = true;
		if (timeToStop == 0f)
		{
			timeToStop = Time.time;
		}
		timeToStop = ((!StackableDuration) ? (Time.time + EffectDuration) : (timeToStop + EffectDuration));
		if (VFX != null)
		{
			VFX.StartEffect();
		}
	}

	public virtual void StopEffect()
	{
		currStacks = 0;
		ClearStacksEffects();
		effectIsActive = false;
		timeToStop = 0f;
		if (VFX != null)
		{
			VFX.StopEffect();
		}
	}

	public virtual void AddStackEffect()
	{
	}

	public virtual void ClearStacksEffects()
	{
	}
}
