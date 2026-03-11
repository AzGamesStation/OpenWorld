using Game.Weapons;
using UnityEngine;

namespace Game.Character
{
    [System.Serializable]
    public class ShootingAssistant : StateMachineBehaviour
    {
        private WeaponController weaponController;

        public bool shooted;

        public override void OnStateEnter(Animator animator, AnimatorStateInfo animatorStateInfo, int layerIndex)
        {
            //  Debug.Break();
            if (weaponController == null)
            {
                WeaponControllerInitialize(animator);
            }
            if (weaponController != null)
            {
                //Debug.Log(weaponController.CurrentWeapon.AttackDelay);
                animator.SetFloat("ShootSpeed", 1f / weaponController.CurrentWeapon.AttackDelay);
            }
            shooted = false;
        }

        public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
        {
            if (!shooted)
            {
                if (weaponController != null)
                {
                    weaponController.AttackWithWeapon();
                }
                shooted = true;
            }
            if (stateInfo.normalizedTime > 0.9f)
            {
                shooted = false;
            }
        }

        private void WeaponControllerInitialize(Animator animator)
        {
            weaponController = animator.GetComponent<WeaponController>();
            if (!weaponController)
            {
                UnityEngine.Debug.LogError("Can't find WeaponController");
            }
        }
    }
}
