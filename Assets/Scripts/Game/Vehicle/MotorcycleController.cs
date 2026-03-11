using Game.Character;
using Game.Character.CharacterController;
using Game.Character.Stats;
using Game.GlobalComponent;
using System;
using System.Collections;
using UnityEngine;

namespace Game.Vehicle
{
    public class MotorcycleController : CarController
    {
        private const string SteerAxeName = "Horizontal";

        private const string ThrottleAxeName = "Vertical";

        private const string LeanAxisName = "Lean";

        private const float BikeMass = 500f;

        private const float DropSpeed = 15f;

        private const float ForcePopRagdoll = 4000f;

        private const float DropFromTimeOut = 0.05f;

        private const float DropFromOffsetRate = 2f;

        private const float StaminaPerSecond = 1f;

        private const float LeanRate = 4f;

        private const float SteerSpeedRate = 0.25f;

        public WheelCollider FrontWheelCollider;

        public WheelCollider RearWheelCollider;

        public float EngineTorque = 1500f;

        public float MaxEngineRPM = 6000f;

        public float MinEngineRPM = 1000f;

        public float SteerAngle = 40f;

        public float maxSpeed = 180f;

        public float Brake = 2500f;

        [HideInInspector]
        public float MotorInput;

        [HideInInspector]
        public float steerInput;

        [HideInInspector]
        public bool crashed;

        [HideInInspector]
        public bool reversing;

        [HideInInspector]
        public DrivableVehicle mainDrivableVehicle;

        private float leanInput;

        private GameObject helm;

        private Vector3 helmStartRotation;

        private MotorcycleSpecific motorcycleSpecific;

        private float helmAngleMultiplier = 1f;

        private float leanAngle;

        private SimpleWheelController FrontWheelController;

        private SimpleWheelController RearWheelController;

        public override void Init(DrivableVehicle drivableVehicle)
        {
            base.Init(drivableVehicle);
            motorcycleSpecific = (MotorcycleSpecific)VehicleSpecific;
            leanAngle = motorcycleSpecific.MaxLeanAngle;
            StartCoroutine(SwithDriverModelDelay(isGetin: true, motorcycleSpecific.GetOutAnimationTime));
            helm = motorcycleSpecific.Helm;
            helmAngleMultiplier = motorcycleSpecific.HelmAngle / SteerAngle;
            helmStartRotation = helm.transform.localEulerAngles;
            MainRigidbody.constraints = RigidbodyConstraints.FreezeRotationZ;
            MainRigidbody.mass = 500f;
            MainRigidbody.maxAngularVelocity = 2f;
            mainDrivableVehicle = drivableVehicle;
            WheelCollider[] componentsInChildren = MainRigidbody.GetComponentsInChildren<WheelCollider>();
            for (int i = 0; i < componentsInChildren.Length; i++)
            {
                if (componentsInChildren[i].Equals(drivableVehicle.GetComponent<SteeringWheels>().Wheels[0]))
                {
                    FrontWheelCollider = componentsInChildren[i];
                }
                else
                {
                    RearWheelCollider = componentsInChildren[i];
                }
            }
            FrontWheelController = FrontWheelCollider.GetComponent<SimpleWheelController>();
            RearWheelController = RearWheelCollider.GetComponent<SimpleWheelController>();
            FrontWheelController.WheelPoint = ((MotorcycleSpecific)VehicleSpecific).FrontWheelPoint.transform;
            FrontWheelController.ResetWheelCollider();
            RearWheelController.ResetWheelCollider();
            if ((bool)motorcycleSpecific.BrakeSound && (bool)BrakeAudioSource)
            {
                BrakeAudioSource.loop = true;
                BrakeAudioSource.clip = motorcycleSpecific.BrakeSound;
            }
            maxSpeed = drivableVehicle.MaxSpeed * player.stats.GetPlayerStat(StatsList.DrivingMaxSpeed);
            IsInitialized = true;
        }

        private void Start()
        {
            if (FrontWheelController == null)
            {
                FrontWheelController = FrontWheelCollider.GetComponent<SimpleWheelController>();
            }
            if (RearWheelController == null)
            {
                RearWheelController = RearWheelCollider.GetComponent<SimpleWheelController>();
            }
        }

        protected override void FixedUpdate()
        {
            //Lean();
        }

        public void DropFromSpeed(float relativeSpeed)
        {
            if (Mathf.Abs(relativeSpeed) >= 15f || (!RearWheelCollider.isGrounded && !FrontWheelCollider.isGrounded))
            {
                DropFrom();
            }
        }

        public override void DropFrom()
        {
            if (PlayerInteractionsManager.Instance.IsPossibleGetOut() && base.gameObject.activeInHierarchy)
            {
                StartCoroutine(DropFromDelay());
            }
        }

        public IEnumerator DropFromDelay()
        {
            if (IsInitialized)
            {
                Transform transform = PlayerInteractionsManager.Instance.Player.transform;
                MainRigidbody.constraints = RigidbodyConstraints.None;
                transform.position += Vector3.up;
                transform.parent = null;
                PlayerInteractionsManager.Instance.ResetCharacterHipsPlace();
                player.ReplaceOnRagdoll(canWakeUp: true, MainRigidbody.linearVelocity);
                MainRigidbody.constraints = RigidbodyConstraints.None;
                PlayerInteractionsManager.Instance.GetOutFromVehicle(isRaggdol: true);
            }
            yield return new WaitForSeconds(0.05f);
        }

        public override void DeInit(Action callbackAfterDeInit)
        {
            SwithDriverModel(isGetin: false);
            helm.transform.localEulerAngles = helmStartRotation;
            FrontWheelCollider.GetComponent<SimpleWheelController>().WheelPoint = null;
            MainRigidbody.centerOfMass = primordialCenterOfMass;
            MainRigidbody.ResetInertiaTensor();
            MotorInput = 0f;
            RearWheelCollider.motorTorque = 0f;
            FrontWheelCollider.brakeTorque = Brake;
            RearWheelCollider.brakeTorque = Brake;
            FrontWheelCollider = null;
            RearWheelCollider = null;
            base.DeInit(callbackAfterDeInit);
        }

        private void Braking()
        {
            if (Mathf.Abs(MotorInput) <= 0.05f)
            {
                isBraking = false;
                FrontWheelCollider.brakeTorque = Brake / 25f;
                RearWheelCollider.brakeTorque = Brake / 25f;
            }
            else if (MotorInput < 0f && !reversing)
            {
                isBraking = true;
                FrontWheelCollider.brakeTorque = Brake * (Mathf.Abs(MotorInput) / 5f);
                RearWheelCollider.brakeTorque = Brake * Mathf.Abs(MotorInput);
                if (FrontWheelCollider.isGrounded || RearWheelCollider.isGrounded)
                {
                    MainRigidbody.AddForce(MotorInput * MainRigidbody.transform.forward * Brake/10);
                }
            }
            else
            {
                isBraking = false;
                FrontWheelCollider.brakeTorque = 0f;
                RearWheelCollider.brakeTorque = 0f;
            }
        }

        private IEnumerator SwithDriverModelDelay(bool isGetin, float time = 0f)
        {
            yield return new WaitForSeconds(time);
            SwithDriverModel(isGetin);
        }

        private void SwithDriverModel(bool isGetin)
        {
            if (isGetin)
            {
                motorcycleSpecific.HandsController.RightArm.Upperarm.bone = PlayerManager.Instance.CurrentStuffHelper.RightUpperArm;
                motorcycleSpecific.HandsController.RightArm.Forearm.bone = PlayerManager.Instance.CurrentStuffHelper.RightForeArm;
                motorcycleSpecific.HandsController.LeftArm.Upperarm.bone = PlayerManager.Instance.CurrentStuffHelper.LeftUpperArm;
                motorcycleSpecific.HandsController.LeftArm.Forearm.bone = PlayerManager.Instance.CurrentStuffHelper.LeftForeArm;
                motorcycleSpecific.HandsController.spine.spineTransform = PlayerManager.Instance.CurrentStuffHelper.Spine;
                motorcycleSpecific.HandsController.spine.chestTransform = PlayerManager.Instance.CurrentStuffHelper.Chest;
            }
        }

        protected override VehicleType GetVehicleType()
        {
            return VehicleType.Motorbike;
        }

        private void Update()
        {
            Inputs();
            ProceedStamina();
            Drive();
            ShiftGears(MotorInput);
            ProceedEnginePitchSound(MotorInput);
            Braking();
            BrakeEffect();
        }

        public void ProceedStamina()
        {
            player.stats.stamina.DoFixedUpdate();
        }

        private void Inputs()
        {
            if (mainDrivableVehicle.DeepInWater && mainDrivableVehicle.WaterSensor.InWater)
            {
                MotorInput = 0f;
                EngineAudioSource.Stop();
                return;
            }
            leanInput = Controls.GetAxis("Lean");
            if (!crashed)
            {
                MotorInput = Controls.GetAxis("Vertical");
                float num = Time.deltaTime * 4f * (1f - Mathf.Abs(speed) / maxSpeed * 0.25f);
                if (Controls.GetAxis("Horizontal") == 0f)
                {
                    num *= 5f;
                }
                steerInput = Mathf.Lerp(steerInput, Controls.GetAxis("Horizontal"), num);
            }
            else
            {
                MotorInput = 0f;
                steerInput = 0f;
            }
            if (MotorInput < 0f)
            {
                Vector3 vector = base.transform.InverseTransformDirection(MainRigidbody.linearVelocity);
                if (vector.z < 0.1f)
                {
                    reversing = true;
                    return;
                }
            }
            reversing = false;
        }

        private void Drive()
        {
            FrontWheelController.ResetWheelCollider();
            RearWheelController.ResetWheelCollider();
            speed = CalcSpeedKmh();
            float num = SteerAngle * steerInput * (1f - Mathf.Abs(speed) / maxSpeed * 0.25f);
            FrontWheelCollider.steerAngle = num;
            helm.transform.localEulerAngles = helmStartRotation + new Vector3(0f, 0f, num * helmAngleMultiplier);
            if (speed > maxSpeed)
            {
                RearWheelCollider.motorTorque = 0f;
            }
            else if (!reversing)
            {
                float num2 = DrivableVehicle.Acceleration * player.stats.GetPlayerStat(StatsList.CarAcceleration);
                num2 = ((!(Controls.GetAxis("Vertical") > 0f) || (!FrontWheelCollider.isGrounded && !RearWheelCollider.isGrounded)) ? 0f : (num2 * Controls.GetAxis("Vertical")));
                RearWheelCollider.motorTorque = EngineTorque * Mathf.Clamp(MotorInput, 0f, 1f) * Mathf.Clamp(gearEffect, 0.1f, 2f);
                MainRigidbody.AddForce(MainRigidbody.transform.forward * 100f * num2);
            }
            if (reversing)
            {
                if (speed < 10f)
                {
                    RearWheelCollider.motorTorque = EngineTorque * MotorInput / 4f;
                }
                else
                {
                    RearWheelCollider.motorTorque = 0f;
                }
            }
        }

        private void LateUpdate()
        {
            if (FrontWheelCollider.isGrounded || RearWheelCollider.isGrounded)
            {
                Vector3 up = MainRigidbody.transform.up;
                if (up.y > 0f)
                {
                    Vector3 eulerAngles = MainRigidbody.transform.eulerAngles;
                    float z = eulerAngles.z;
                    float b = (!(speed > speedToNextGear)) ? ((0f - leanAngle) * steerInput * speed / maxSpeed) : ((0f - leanAngle) * steerInput);
                    z = Mathf.LerpAngle(z, b, Time.deltaTime * 4f);
                    Transform transform = MainRigidbody.transform;
                    Vector3 eulerAngles2 = base.transform.eulerAngles;
                    float x = eulerAngles2.x;
                    Vector3 eulerAngles3 = base.transform.eulerAngles;
                    transform.eulerAngles = new Vector3(x, eulerAngles3.y, z);
                }
            }
        }

        private void Lean()
        {
            if (Mathf.Abs(leanInput) > 0.5f)
            {
                float num = (!FrontWheelCollider.isGrounded && !RearWheelCollider.isGrounded) ? 5000f : 2000f;
                MainRigidbody.AddRelativeTorque(new Vector3(num * leanInput, 0f, 0f), ForceMode.Force);
            }
        }

        private float CalcSpeedKmh()
        {
            return Vector3.Dot(MainRigidbody.linearVelocity, MainRigidbody.transform.forward) * 3.6f;
        }
    }
}
