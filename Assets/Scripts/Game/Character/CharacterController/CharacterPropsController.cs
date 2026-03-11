using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using Game.Enemy;
using Game.Vehicle;
using Game.Character;
using Game.Character.CharacterController;

public class CharacterPropsController : MonoBehaviour
{
    [System.Serializable]
    public class Prop
    {
        public string name;
        public HumanoidBehaiviour behaviour;
        public GameObject propObject;
        public GameObject mainModel;
        public float speed;
        public Vector3 RootPlayerPosition;
        public Vector3 rootPlayerRotation;
        public bool hasIK;
        public Transform leftHand, rightHand;
        public Transform leftLeg, rightLeg;
        public GameObject[] BtnOnOff;
    }

    [HideInInspector] public bool isSkating;
    [HideInInspector] public float speed;
    public GameObject flyBtn;
    public Player player;
    public static CharacterPropsController instance;
    public HumanoidBehaiviour behaviour;
    public Animator anim;
    public Prop[] props = new Prop [1];
    [SerializeField] GameObject GetOffBtn;

    private VehicleType type;
    private bool IsIk;
    private Transform leftHand, rightHand;
    private Transform leftLeg, rightLeg;
    private Vector3 TempPos, tempRot;
    private Vector3 CurrentPos, currentRot;
    private GameObject propObject;
    private GameObject mainModel;
    private GameObject dummyProp;
    private GameObject currentProp;


    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        
    }

    public void GetProp(HumanoidBehaiviour type, bool value)
    {
        if (value)
        {
            for (int i = 0; i < props.Length; i++)
            {
                if (props[i].behaviour == type)
                {
                    
                    TempPos = props[i].mainModel.transform.localPosition;
                    tempRot = props[i].mainModel.transform.localEulerAngles;
                    mainModel = props[i].mainModel;
                    CurrentPos = props[i].RootPlayerPosition;
                    currentRot = props[i].rootPlayerRotation;
                    propObject = props[i].propObject;
                    speed = props[i].speed;
                    leftHand = props[i].leftHand;
                    rightHand = props[i].rightHand;
                    leftLeg = props[i].leftLeg;
                    rightLeg = props[i].rightLeg;
                    if (type == HumanoidBehaiviour.SkateBoard || type == HumanoidBehaiviour.HoverBoard || type == HumanoidBehaiviour.Gyro)
                    {
                        anim.SetBool("IsSkateBoard", true);
                        StopCoroutine("Delay");
                        StartCoroutine(Delay (1));
                    }
                    else if (type == HumanoidBehaiviour.SmallBicycle)
                    {

                        anim.SetBool("IsCycling", true);
                        StopCoroutine("Delay");
                        StartCoroutine(Delay(1));
                    }

                    for (int j = 0; j < props[i].BtnOnOff.Length; j++)
                    {
                        props[i].BtnOnOff[j].SetActive(false);
                    }
                    GetOffBtn.SetActive(true);
                }
            }
        }
        else
        {
            for (int i = 0; i < props.Length; i++)
            {
                if (props[i].behaviour == type && isSkating)
                {
                    propObject.SetActive(false);
                    props[i].mainModel.transform.localPosition = TempPos;
                    props[i].mainModel.transform.localEulerAngles = tempRot;
                    currentProp.transform.localPosition = new Vector3 (propObject.transform.localPosition.x, propObject.transform.localPosition.y, propObject.transform.localPosition.z-1);
                    currentProp.transform.localEulerAngles = propObject.transform.localEulerAngles;
                    currentProp.transform.parent = null;
                    currentProp.SetActive(true);
                    currentProp = null;
                    IsIk = false;
                    if (type == HumanoidBehaiviour.SkateBoard || type == HumanoidBehaiviour.HoverBoard || type == HumanoidBehaiviour.Gyro || type == HumanoidBehaiviour.SmallBicycle)
                    {
                        anim.SetBool("IsSkateBoard", false);
                        isSkating = false;
                    }
                    for (int j = 0; j < props[i].BtnOnOff.Length; j++)
                    {
                        props[i].BtnOnOff[j].SetActive(true);
                    }
                    GetOffBtn.SetActive(false);
                }
            }
        }
 
    }

    bool isDelayWorking;
    IEnumerator Delay(float delay)
    {
        yield return new WaitForSeconds(delay);
        currentProp.SetActive(false);
        currentProp.transform.parent = this.transform;
        propObject.SetActive(true);
        isDelayWorking = true;
        yield return new WaitForSeconds(1);
        isDelayWorking = false;
        isSkating = true;
        dummyProp = null;
        IsIk = true;
        mainModel.transform.localPosition = CurrentPos;
        mainModel.transform.localEulerAngles = currentRot;
    }
    public void WatchVideoProps()
    {
        if (CheckInternetConnection.Instance.IsInternetConnected)
        {
            if (RewardedAdsController.Instance)
            {
                GlobalContants.PropsWatched = true;
                RewardedAdsController.Instance.ShowRewarded("GetProp");
            }
            else
            {
                PropHandles(true);
            }
        }
        else
        {
            Invoke("ActivateFlyBtn", 2f);
            CheckInternetConnection.Instance.ToastMsg();
        }
    }

    void ActivateFlyBtn()
    {
        flyBtn.SetActive(true);
    }

    public void PropHandles(bool value)
    {
        GetProp(behaviour, value);
        if(player)
            player.isPropsOn = value;
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (dummyProp || isDelayWorking)
        {
            return;
        }
        if (isSkating)
        {
            return;
        }

        if (other.gameObject.GetComponent <PropPickUpDummy>())
        {
            dummyProp = other.gameObject;
            behaviour = dummyProp.GetComponent<PropPickUpDummy>().type;
            PlayerInteractionsManager.Instance.GetInPropsButton.gameObject.SetActive(true);
            currentProp = dummyProp;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        PlayerInteractionsManager.Instance.GetInPropsButton.gameObject.SetActive(false);
        dummyProp = null;
    }
    float TempWeight;
    private void OnAnimatorIK()
    {
        if (IsIk)
        {
            TempWeight += Time.deltaTime;
            if (TempWeight >= 1)
            {
                TempWeight = 1;
            }
            if (leftHand)
            {
                anim.SetIKPositionWeight(AvatarIKGoal.LeftHand, TempWeight);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftHand, TempWeight);
                anim.SetIKPosition(AvatarIKGoal.LeftHand, leftHand.position);
                anim.SetIKRotation(AvatarIKGoal.LeftHand, leftHand.rotation);


                anim.SetIKPositionWeight(AvatarIKGoal.RightHand, TempWeight);
                anim.SetIKRotationWeight(AvatarIKGoal.RightHand, TempWeight);
                anim.SetIKPosition(AvatarIKGoal.RightHand, rightHand.position);
                anim.SetIKRotation(AvatarIKGoal.RightHand, rightHand.rotation);
            }

            if (leftLeg)
            {
                anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, TempWeight);
                anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, TempWeight);
                anim.SetIKPosition(AvatarIKGoal.LeftFoot, leftLeg.position);
                anim.SetIKRotation(AvatarIKGoal.LeftFoot, leftLeg.rotation);


                anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, TempWeight);
                anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, TempWeight);
                anim.SetIKPosition(AvatarIKGoal.RightFoot, rightLeg.position);
                anim.SetIKRotation(AvatarIKGoal.RightFoot, rightLeg.rotation);
            }


        }
        else
        {
            TempWeight = 0;
            anim.SetIKPositionWeight(AvatarIKGoal.LeftFoot, 0);
            anim.SetIKRotationWeight(AvatarIKGoal.LeftFoot, 0);
            anim.SetIKPositionWeight(AvatarIKGoal.RightFoot, 0);
            anim.SetIKRotationWeight(AvatarIKGoal.RightFoot, 0);
        }
    }
}
