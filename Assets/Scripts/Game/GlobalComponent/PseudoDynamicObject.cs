using System.Collections;
using UnityEngine;

namespace Game.GlobalComponent
{
	public class PseudoDynamicObject : MonoBehaviour
	{
		private const float RigidbodyClampSpeedPeriod = 5f;

		public int BodyMass = 100;

		public float StayImpulse = 1000f;

		public float MaxVelocity = 75f;

		public bool isAnimated;

		public Animation animation;

		public bool IsDebug;

		private Vector3 initialPosition;

		private Quaternion initialRotation;

		private Rigidbody ownRigidbody;

		private bool alreadyDynamic;

		private void Awake()
		{
			initialPosition = base.transform.position;
			initialRotation = base.transform.rotation;
			MeshCollider component = GetComponent<MeshCollider>();
			if (component != null)
			{
				component.convex = true;
			}
		}

		private void OnDisable()
		{
			if (!base.gameObject.activeInHierarchy && ownRigidbody != null)
			{
				UnityEngine.Object.Destroy(ownRigidbody);
				ownRigidbody = null;
				alreadyDynamic = false;
				base.transform.position = initialPosition;
				base.transform.rotation = initialRotation;
				if (isAnimated)
				{
					GetComponent<Animation>().enabled = true;
				}
				StopAllCoroutines();
			}
		}

		public void ReplaceOnDynamic(Vector3 force = default(Vector3), Vector3 direction = default(Vector3))
		{
			if (isAnimated)
			{
				GetComponent<Animation>().enabled = false;
			}
			if (!alreadyDynamic)
			{
				alreadyDynamic = true;
				ownRigidbody = base.gameObject.AddComponent<Rigidbody>();
				if (!ownRigidbody)
				{
					return;
				}
				ownRigidbody.mass = BodyMass;
				StartCoroutine(ClampRigidbodySpeed(5f));
			}
			ownRigidbody.AddForce(force, ForceMode.Impulse);
			ownRigidbody.AddTorque(direction, ForceMode.Impulse);
		}

		private void OnCollisionEnter(Collision col)
		{
			if (alreadyDynamic)
			{
				return;
			}
			Rigidbody rigidbody = col.rigidbody;
			if (rigidbody == null)
			{
				return;
			}
			if (IsDebug)
			{
				UnityEngine.Debug.LogFormat("PDO collision impule = {0}", col.impulse.magnitude);
			}
			if (!(col.impulse.magnitude < StayImpulse))
			{
				if (isAnimated)
				{
					GetComponent<Animation>().enabled = false;
				}
				rigidbody.linearVelocity = col.relativeVelocity;
				ReplaceOnDynamic();
			}
		}

		private IEnumerator ClampRigidbodySpeed(float time)
		{
			WaitForEndOfFrame waitForEndOfFrame = new WaitForEndOfFrame();
			while (time > 0f)
			{
				yield return waitForEndOfFrame;
				time -= Time.deltaTime;
				if (alreadyDynamic && ownRigidbody.linearVelocity.magnitude > MaxVelocity)
				{
					ownRigidbody.linearVelocity = ownRigidbody.linearVelocity.normalized * MaxVelocity;
				}
			}
		}
	}
}
