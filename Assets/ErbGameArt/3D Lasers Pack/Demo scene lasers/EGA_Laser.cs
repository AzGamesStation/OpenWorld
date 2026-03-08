using System.Collections;
using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using System;
using UnityEngine;
using Game.Factions;
using Game.Character.CharacterController;
using Game.Weapons;
using Game.Character.Extras;
using Game.GlobalComponent;
namespace Game.Weapons
{
    public class EGA_Laser : Weapon
    {
        public new GameObject HitEffect;
        public float HitOffset = 0;

        public float MaxLength;
        private LineRenderer Laser;

        public float MainTextureLength = 1f;
        public float NoiseTextureLength = 1f;
        private Vector4 Length = new Vector4(1, 1, 1, 1);
        //private Vector4 LaserSpeed = new Vector4(0, 0, 0, 0); {DISABLED AFTER UPDATE}
        //private Vector4 LaserStartSpeed; {DISABLED AFTER UPDATE}
        //One activation per shoot
        private bool LaserSaver = false;
        private bool UpdateSaver = false;
        public LayerMask layer;

        private ParticleSystem[] Effects;
        private ParticleSystem[] Hit;
        public DamageType HitDamageType = DamageType.Energy;
        protected HitEntity currentOwner;
        public float ProjectileDamage;
        public float DefenceIgnorance;
        public Player player;

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
        void Start()
        {
            //Get LineRender and ParticleSystem components from current prefab;  
            Laser = GetComponent<LineRenderer>();
            Effects = GetComponentsInChildren<ParticleSystem>();
            Hit = HitEffect.GetComponentsInChildren<ParticleSystem>();
            //if (Laser.material.HasProperty("_SpeedMainTexUVNoiseZW")) LaserStartSpeed = Laser.material.GetVector("_SpeedMainTexUVNoiseZW");
            //Save [1] and [3] textures speed
            //{ DISABLED AFTER UPDATE}
            //LaserSpeed = LaserStartSpeed;
        }

        private void InflictDamageEvent(Weapon weapon, HitEntity owner, HitEntity victim, Vector3 hitPos, Vector3 hitVector, float defenceReduction = 0f)
        {
            victim.OnHit(DamageType.Energy, owner, weapon.Damage, hitPos, hitVector, defenceReduction);
        }

        private void Update()
        {
            //if (Laser.material.HasProperty("_SpeedMainTexUVNoiseZW")) Laser.material.SetVector("_SpeedMainTexUVNoiseZW", LaserSpeed);
            //SetVector("_TilingMainTexUVNoiseZW", Length); - old code, _TilingMainTexUVNoiseZW no more exist
            Laser.material.SetTextureScale("_MainTex", new Vector2(Length[0], Length[1]));
            Laser.material.SetTextureScale("_Noise", new Vector2(Length[2], Length[3]));
            //To set LineRender position
            if (Laser != null && UpdateSaver == false)
            {
                Laser.SetPosition(0, transform.position);
                Ray ray = new Ray ( transform.position, transform.TransformDirection(Vector3.forward));
                RaycastHit hit; //DELATE THIS IF YOU WANT USE LASERS IN 2D
                                //ADD THIS IF YOU WANNT TO USE LASERS IN 2D: RaycastHit2D hit = Physics2D.Raycast(transform.position, transform.forward, MaxLength);       
                if (Physics.Raycast(ray, out hit, MaxLength, layer))//CHANGE THIS IF YOU WANT TO USE LASERRS IN 2D: if (hit.collider != null)
                {
                    //End laser position if collides with object
                    Laser.SetPosition(1, hit.point);
                    HitEffect.transform.position = hit.point + hit.normal * HitOffset;
                    //Hit effect zero rotation
                    HitEffect.transform.rotation = Quaternion.identity;
                    foreach (var AllPs in Effects)
                    {
                        if (!AllPs.isPlaying) AllPs.Play();
                    }
                    //Texture tiling
                    Length[0] = MainTextureLength * (Vector3.Distance(transform.position, hit.point));
                    Length[2] = NoiseTextureLength * (Vector3.Distance(transform.position, hit.point));
                    //Texture speed balancer {DISABLED AFTER UPDATE}
                    //LaserSpeed[0] = (LaserStartSpeed[0] * 4) / (Vector3.Distance(transform.position, hit.point));
                    //LaserSpeed[2] = (LaserStartSpeed[2] * 4) / (Vector3.Distance(transform.position, hit.point));

                    HitEntity component = hit.collider.gameObject.GetComponent<HitEntity>();
                    currentOwner = player;
                    if (component != null)
                    {
                        //component.OnHit(HitDamageType, currentOwner, ProjectileDamage, hit.point, hit.point, DefenceIgnorance);
                      
                        InflictDamageEvent(this, currentOwner, component, hit.point, Vector3.zero, DefenceIgnorance);
                        EntityManager.Instance.OverallAlarm(currentOwner, component, hit.point, 20);
                        PointSoundManager.Instance.Play3DSoundOnPoint(hit.point, SoundHit);
                        FactionsManager.Instance.PlayerAttackHuman(component);
                    }
                    //FactionsManager.Instance.ChangePlayerRelations(Faction.Player, 2f);

                }
                else
                {
                    //End laser position if doesn't collide with object
                    var EndPos = transform.position + transform.forward * MaxLength;
                    Laser.SetPosition(1, EndPos);
                    HitEffect.transform.position = EndPos;
                    foreach (var AllPs in Hit)
                    {
                        if (AllPs.isPlaying) AllPs.Stop();
                    }
                    //Texture tiling
                    Length[0] = MainTextureLength * (Vector3.Distance(transform.position, EndPos));
                    Length[2] = NoiseTextureLength * (Vector3.Distance(transform.position, EndPos));
                    //LaserSpeed[0] = (LaserStartSpeed[0] * 4) / (Vector3.Distance(transform.position, EndPos)); {DISABLED AFTER UPDATE}
                    //LaserSpeed[2] = (LaserStartSpeed[2] * 4) / (Vector3.Distance(transform.position, EndPos)); {DISABLED AFTER UPDATE}
                }
                //Insurance against the appearance of a laser in the center of coordinates!
                if (Laser.enabled == false && LaserSaver == false)
                {
                    LaserSaver = true;
                    Laser.enabled = true;
                }
            }
        }

        public void DisablePrepare()
        {
            if (Laser != null)
            {
                Laser.enabled = false;
            }
            UpdateSaver = true;
            //Effects can = null in multiply shooting
            if (Effects != null)
            {
                foreach (var AllPs in Effects)
                {
                    if (AllPs.isPlaying) AllPs.Stop();
                }
            }
        }
    }

}