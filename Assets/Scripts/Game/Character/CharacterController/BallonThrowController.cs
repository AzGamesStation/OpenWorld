using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Factions;
using Game.Character.CharacterController;
using Game.Weapons;
using Game.Character.Extras;
using Game.GlobalComponent;

namespace Game.Weapons
{
    public class BallonThrowController : Weapon
    {
        public LayerMask layer;
        protected HitEntity currentOwner;
        public Player player;
        public float DefenceIgnorance;
        public override void Attack(HitEntity owner)
        {
            Debug.Log("owner");
        }
        public override void Attack(HitEntity owner, HitEntity victim)
        {
            Debug.Log("victim");
        }

        public override void Attack(HitEntity owner, Vector3 direction)
        {
            Debug.Log("direction");
        }


        private void InflictDamageEvent(Weapon weapon, HitEntity owner, HitEntity victim, Vector3 hitPos, Vector3 hitVector, float defenceReduction = 0f)
        {
            victim.OnHit(DamageType.Ballon, owner, weapon.Damage, hitPos, hitVector, defenceReduction);
        }

        private void OnTriggerEnter(Collider other)
        {
            Debug.Log(other.gameObject.layer);
            if (other.gameObject.layer == 13 || other.gameObject.layer == 14 ||other.gameObject.layer == 15 || other.gameObject.layer == 8)
            {
                Debug.Log(other.gameObject.name);
                HitEntity component = other.gameObject.GetComponent<HitEntity>();
                currentOwner = player;
                if (component != null && other.gameObject.tag != "Player")
                {
                    Debug.Log("component");
                    //component.OnHit(HitDamageType, currentOwner, ProjectileDamage, hit.point, hit.point, DefenceIgnorance);

                    InflictDamageEvent(this, currentOwner, component, other.transform.position, Vector3.zero, DefenceIgnorance);
                    EntityManager.Instance.OverallAlarm(currentOwner, component, other.transform.position, 20);
                    PointSoundManager.Instance.Play3DSoundOnPoint(other.transform.position, SoundHit);
                    FactionsManager.Instance.PlayerAttackHuman(component);
                }
                Destroy(this.gameObject);
            }

        }
    }
}
