using UnityEngine;

namespace Game.Enemy
{
	public class HumanoidNPC : BaseNPC
	{
		public override void Init()
		{
			base.Init();
		}

		public override void DeInit()
		{
			base.DeInit();
		}

		public void Smash()
		{
			SmartHumanoidController smartHumanoidController = (SmartHumanoidController)base.CurrentController;
			if (smartHumanoidController != null)
			{
				smartHumanoidController.AnimationController.Smash(StatusNpc, new GameObject[1]
				{
					base.gameObject
				});
			}
		}

		private void OnAnimatorIK()
		{
			if (GetComponentInChildren<PedestrianHumanoidController>())
			{
				if (GetComponentInChildren<PedestrianHumanoidController>().isIK)
				{
                    if (GetComponentInChildren<PedestrianHumanoidController>().leftHand)
                    {
						NPCAnimator.SetIKPositionWeight(AvatarIKGoal.LeftHand, 1);
						NPCAnimator.SetIKRotationWeight(AvatarIKGoal.LeftHand, 1);
						NPCAnimator.SetIKPosition(AvatarIKGoal.LeftHand, GetComponentInChildren<PedestrianHumanoidController>().leftHand.position);
						NPCAnimator.SetIKRotation(AvatarIKGoal.LeftHand, GetComponentInChildren<PedestrianHumanoidController>().leftHand.rotation);


						NPCAnimator.SetIKPositionWeight(AvatarIKGoal.RightHand, 1);
						NPCAnimator.SetIKRotationWeight(AvatarIKGoal.RightHand, 1);
						NPCAnimator.SetIKPosition(AvatarIKGoal.RightHand, GetComponentInChildren<PedestrianHumanoidController>().rightHand.position);
						NPCAnimator.SetIKRotation(AvatarIKGoal.RightHand, GetComponentInChildren<PedestrianHumanoidController>().rightHand.rotation);
					}
				
                    if (GetComponentInChildren<PedestrianHumanoidController>().leftFoot)
                    {
						NPCAnimator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 1);
                        NPCAnimator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 1);
                        NPCAnimator.SetIKPosition(AvatarIKGoal.LeftFoot, GetComponentInChildren<PedestrianHumanoidController>().leftFoot.position);
                        NPCAnimator.SetIKRotation(AvatarIKGoal.LeftFoot, GetComponentInChildren<PedestrianHumanoidController>().footRotation.rotation);


                        NPCAnimator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 1);
                        NPCAnimator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 1);
                        NPCAnimator.SetIKPosition(AvatarIKGoal.RightFoot, GetComponentInChildren<PedestrianHumanoidController>().rightFoot.position);
                        NPCAnimator.SetIKRotation(AvatarIKGoal.RightFoot, GetComponentInChildren<PedestrianHumanoidController>().footRotation.rotation);
                    }


				}
                else
                {
					NPCAnimator.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
					NPCAnimator.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0);
					NPCAnimator.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
					NPCAnimator.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0);
				}
			}
		}
	}
}
