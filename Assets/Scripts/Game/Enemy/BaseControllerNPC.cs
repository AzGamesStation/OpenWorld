using UnityEngine;

namespace Game.Enemy
{
    public enum HumanoidBehaiviour
    {
        Walk,
        Idel,
        SkateBoard,
        HoverBoard,
        Gyro,
        SmallBicycle

    };
    public class BaseControllerNPC : MonoBehaviour
    {
        public Animator AnimatorWithController;
        public HumanoidBehaiviour behaiviour;
        public GameObject behvObject;
        public GameObject dummyPropObject;

        protected BaseNPC CurrentControlledNpc;

        public bool IsInited
        {
            get;
            protected set;
        }

        public virtual void Init(BaseNPC controlledNPC)
        {
            CurrentControlledNpc = controlledNPC;
            IsInited = true;
            if ((bool)AnimatorWithController)
            {
                controlledNPC.NPCAnimator.runtimeAnimatorController = AnimatorWithController.runtimeAnimatorController;
            }
        }

        public virtual void DeInit()
        {
            CurrentControlledNpc = null;
            IsInited = false;
        }

        protected virtual void Update()
        {
            if (IsInited)
            {
            }
        }
    }
}
