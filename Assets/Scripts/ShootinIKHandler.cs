using Game.Character.CharacterController;
using UnityEngine;

public class ShootinIKHandler : MonoBehaviour
{
	private Animator anim;

	public float ikWeightHand = 1f;

	public float ikWeightElbow = 1f;

	public bool DoIKAnimation;

	public Transform leftIKHandTarget;

	public Transform leftIKHandHint;

	private AnimationController animationController;
	public bool isOnBike;
	public Transform lefthandIkPoint;
	public Transform righthandIkPoint;

	private void Start()
	{
		anim = GetComponent<Animator>();
		animationController = GetComponent<AnimationController>();
	}

	private void OnAnimatorIK()
	{
		//if (DoIKAnimation && animationController.IsAming())
		if (DoIKAnimation && animationController.IsAming())
            {
			anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, ikWeightHand);
			anim.SetIKPosition(AvatarIKGoal.LeftHand, leftIKHandTarget.position);
			anim.SetIKRotation(AvatarIKGoal.LeftHand, leftIKHandTarget.rotation);
			anim.SetIKHintPositionWeight(AvatarIKHint.LeftElbow, ikWeightElbow);
			anim.SetIKHintPosition(AvatarIKHint.LeftElbow, leftIKHandHint.position);
		}

		if (isOnBike)
		{
			anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, ikWeightHand);
			anim.SetIKPosition(AvatarIKGoal.LeftHand, lefthandIkPoint.position);
			anim.SetIKRotation(AvatarIKGoal.LeftHand, lefthandIkPoint.rotation);

			anim.SetIKPositionWeight(AvatarIKGoal.RightHand, ikWeightHand);
			anim.SetIKPosition(AvatarIKGoal.RightHand, righthandIkPoint.position);
			anim.SetIKRotation(AvatarIKGoal.RightHand, righthandIkPoint.rotation);
		}
	}
}
