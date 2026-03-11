using Game.GlobalComponent;
using Game.Traffic;
using UnityEngine;

namespace Game.Enemy
{
	public class PedestrianHumanoidController : SimpleHumanoidController
	{
		private const float StayTimeout = 4f;

		private SlowUpdateProc slowUpdateProc;

		private RoadPoint currentFromPoint;

		private RoadPoint currentToPoint;

		private int currentLine;

		private float stayingTime;
		[HideInInspector]
		public bool isIK;

		public Transform leftHand;
		public Transform rightHand;
		public Transform leftFoot;
		public Transform rightFoot;
		public Transform footRotation;


		public override void Init(BaseNPC controlledNPC)
		{
			base.Init(controlledNPC);
			if (currentFromPoint == null)
			{
				currentFromPoint = TrafficManager.Instance.FindClosestPedestrianPoint(controlledNPC.transform.position);
				if (currentFromPoint != null)
				{
					currentLine = Random.Range(0, currentFromPoint.LineCount) + 1;
					currentToPoint = TrafficManager.BestDestinationPoint(currentFromPoint);
					RecalcMovePoint();
				}
			}
			if (behaiviour == HumanoidBehaiviour.SkateBoard)
			{
				if (GetComponentInParent<HumanoidNPC>())
				{
					GetComponentInParent<HumanoidNPC>().RootModel.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.67f, 0);
					GetComponentInParent<HumanoidNPC>().RootModel.transform.localEulerAngles = new Vector3(0, 90, 0);
					behvObject.SetActive(true);
					isIK = false;
				}
            }
            else if (behaiviour == HumanoidBehaiviour.HoverBoard)
            {
				if (GetComponentInParent<HumanoidNPC>())
				{
					GetComponentInParent<HumanoidNPC>().RootModel.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.7f, 0);
					behvObject.SetActive(true);
					isIK = false;
				}
			}
			else if (behaiviour == HumanoidBehaiviour.Gyro)
			{
				if (GetComponentInParent<HumanoidNPC>())
				{
					GetComponentInParent<HumanoidNPC>().RootModel.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.7f, 0);
					behvObject.SetActive(true);
					isIK = true;
				}
			}
			else if (behaiviour == HumanoidBehaiviour.SmallBicycle)
			{
				if (GetComponentInParent<HumanoidNPC>())
				{
					GetComponentInParent<HumanoidNPC>().RootModel.GetComponent<CapsuleCollider>().center = new Vector3(0, 0.7f, 0);
					behvObject.SetActive(true);
					GetComponentInParent<HumanoidNPC>().NPCAnimator.SetBool("BiCycle", true);
					isIK = true;
				}
			}
		}

		public override void DeInit()
		{
			currentFromPoint = null;
			currentToPoint = null;
			base.DeInit();
            if (dummyPropObject)
            {
				Instantiate(dummyPropObject, behvObject.transform.position, behvObject.transform.rotation);
            }
		}

		public void InitPedestrianPath(RoadPoint fromPoint, RoadPoint toPoint, int line)
		{
			currentFromPoint = fromPoint;
			currentToPoint = toPoint;
			currentLine = line;
			RecalcMovePoint();
		}

		private void Awake()
		{
			slowUpdateProc = new SlowUpdateProc(SlowUpdate, 0.5f);
		}

        private void OnEnable()
        {
			
		}

        private void FixedUpdate()
		{
            slowUpdateProc.ProceedOnFixedUpdate();
		}

		private void SlowUpdate()
		{
			if (currentFromPoint != null)
			{
				if (!base.IsMoving && ObstacleSensor.CanMove)
				{
					TrafficManager.Instance.GetNextRoute(ref currentFromPoint, ref currentToPoint, ref currentLine);
					RecalcMovePoint();
				}
				if (stayingTime > 4f)
				{
					RoadPoint roadPoint = currentToPoint;
					currentToPoint = currentFromPoint;
					currentFromPoint = roadPoint;
					RecalcMovePoint();
				}
				if (!base.IsMoving)
				{
					stayingTime += slowUpdateProc.DeltaTime;
				}
				else
				{
					stayingTime = 0f;
				}
			}
		}

		private void RecalcMovePoint()
		{
			TrafficManager.Instance.CalcTargetSidewalkPoint(currentFromPoint, currentToPoint, currentLine, out Vector3 _, out Vector3 endLine);
			SetMovePoint(endLine);
			stayingTime = 0f;
		}

		private void OnDrawGizmosSelected()
		{
			Gizmos.color = Color.red;
			Gizmos.DrawSphere(MovePoint, 0.5f);
		}
	}
}
