using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Game.Factions;
using Game.Character.CharacterController;
using Game.Character.Extras;
using Game.GlobalComponent;

namespace Game.Weapons
{
    public class FlameController : Weapon
    {
        public float MaxLength;
        public LayerMask layer;
        public DamageType HitDamageType = DamageType.Energy;
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
        private void Awake()
        {
        }

        private void InflictDamageEvent(Weapon weapon, HitEntity owner, HitEntity victim, Vector3 hitPos, Vector3 hitVector, float defenceReduction = 0f)
        {
            victim.OnHit(DamageType.Energy, owner, weapon.Damage, hitPos, hitVector, defenceReduction);
        }
        // Update is called once per frame
        void Update()
        {
            Ray ray = new Ray(transform.position, transform.TransformDirection(Vector3.forward));
            RaycastHit hit;    
            if (Physics.Raycast(ray, out hit, MaxLength, layer))
            {
                HitEntity component = hit.collider.gameObject.GetComponent<HitEntity>();
                
                currentOwner = player;
                if (component != null)
                {
                    Debug.Log("component");
                    InflictDamageEvent(this, currentOwner, component, hit.point, Vector3.zero, DefenceIgnorance);
                    EntityManager.Instance.OverallAlarm(currentOwner, component, hit.point, 20);
                    PointSoundManager.Instance.Play3DSoundOnPoint(hit.point, SoundHit);
                    FactionsManager.Instance.PlayerAttackHuman(component);
                }
            }
        }
    }
}
