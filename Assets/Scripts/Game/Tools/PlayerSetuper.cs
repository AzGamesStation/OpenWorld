using Game.Character;
using Game.Character.CharacterController;
using Game.Character.Stats;
using Game.GlobalComponent;
using Game.MiniMap;
using Game.UI;
using Game.Weapons;
using System.Linq;
using UnityEngine;
using UnityEngine.Rendering;

namespace Game.Tools
{
	[ExecuteInEditMode]
	public class PlayerSetuper : MonoBehaviour
	{
		public const string MainPanel = "Canvas/Game/Main/";

		public const string CharacterControls = "Canvas/Game/Controls/Character/";

		private static ControlsType[] allControlsPanels = new ControlsType[6]
		{
			ControlsType.Moto,
			ControlsType.Car,
			ControlsType.Copter,
			ControlsType.Mech,
			ControlsType.Mech,
			ControlsType.Tank
		};

		public static void SetUpManagers(PlayerSetuperHelper playerSetupHelperInstance, GameObject UIGO = null)
		{
			Player playerScript = playerSetupHelperInstance.PlayerScript;
			Transform transform = playerScript.transform;
			if (UIGO == null)
			{
				UIGO = UnityEngine.Object.FindObjectOfType<UIGame>().gameObject;
			}
			Transform transform2 = UIGO.transform;
			CameraManager.Instance.SetCameraTarget(transform);
			Object.FindObjectOfType<Game.MiniMap.MiniMap>().Target = transform.gameObject;
			UISetUpHelper component = transform2.GetComponent<UISetUpHelper>();
			if ((bool)component)
			{
				Object.FindObjectOfType<UpgradeManager>().Panels = component.Panels;
			}
		}

		public static void SetUpUI(PlayerSetuperHelper playerSetupHelperInstance, PlayerSetuperHelper defaultHelper, GameObject UIGO = null)
		{
			Player playerScript = playerSetupHelperInstance.PlayerScript;
			Transform transform = playerScript.transform;
			WeaponController weaponController = playerSetupHelperInstance.WeaponController;
			AnimationController animationController = playerSetupHelperInstance.AnimationController;
			if (UIGO == null)
			{
				UIGO = UnityEngine.Object.FindObjectOfType<UIGame>().gameObject;
			}
			Transform transform2 = UIGO.transform;
			bool flag = playerSetupHelperInstance.TransformationControlsPanels.Count() > 0;
			weaponController.AmmoText = defaultHelper.WeaponController.AmmoText;
			weaponController.WeaponImage = defaultHelper.WeaponController.WeaponImage;
			transform.GetComponentInChildren<SuperKick>().SuperKickButton = defaultHelper.GetComponentInChildren<SuperKick>().SuperKickButton;
			animationController.SprintButton = defaultHelper.AnimationController.SprintButton;
			animationController.ShootRopeButtons = defaultHelper.AnimationController.ShootRopeButtons;
			GameObject[] shootRopeButtons = animationController.ShootRopeButtons;
			foreach (GameObject gameObject in shootRopeButtons)
			{
				gameObject.gameObject.SetActive(playerSetupHelperInstance.Rope);
			}
			playerScript.Health.StatDisplay = defaultHelper.PlayerScript.Health.StatDisplay;
			playerScript.stats.stamina.StatDisplay = defaultHelper.PlayerScript.stats.stamina.StatDisplay;
			animationController.FlyInputs = defaultHelper.AnimationController.FlyInputs;
			GameObject[] flyInputs = animationController.FlyInputs;
			foreach (GameObject gameObject2 in flyInputs)
			{
				gameObject2.gameObject.SetActive(playerSetupHelperInstance.SuperFly);
			}
			Transform transform3 = transform2.Find("Canvas/Game/Controls/Character/OnGroundControls/Transformation");
			transform3.gameObject.SetActive(flag);
			ControlsType[] array = allControlsPanels;
			foreach (ControlsType controlsType in array)
			{
				Transform controlPanel = ControlsPanelManager.Instance.GetControlPanel(controlsType);
				Transform transform4 = controlPanel.Find("Transformation");
				transform4.gameObject.SetActive(flag && playerSetupHelperInstance.TransformationControlsPanels.Contains(controlsType));
				controlPanel.Find("GetOutButton").gameObject.SetActive(!flag);
				transform3 = transform2.Find("Canvas/Game/Controls/Character/OnGroundControls/Transformation");
				transform3.gameObject.SetActive(flag);
				transform3 = transform2.Find("Canvas/Game/Controls/Character/OnGroundControls/GetInButton");
				transform3.gameObject.SetActive(!flag);
			}
		}

		public static GameObject SwitchModel(PlayerSetuperHelper playerSetupHelperInstance, GameObject newModelPrefab, Transform oldModelInstance)
		{
			SkinnedMeshRenderer[] array = null;
			Player playerScript = playerSetupHelperInstance.PlayerScript;
			AnimationController animationController = playerSetupHelperInstance.AnimationController;
			Transform transform = playerScript.transform;
			bool flag = playerSetupHelperInstance.TransformationControlsPanels.Count() > 0;
			Transform transform2 = oldModelInstance.Find("metarig/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand");
			Transform transform3 = oldModelInstance.Find("metarig/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:LeftShoulder/mixamorig:LeftArm/mixamorig:LeftForeArm/mixamorig:LeftHand");
			Transform transform4 = transform2.Find("WeaponsPlaceholder");
			Transform transform5 = transform2.Find("HookPlaceholder");
			Transform transform6 = transform3.Find("LeftWeaponsPlaceholder");
			Transform transform7 = UnityEngine.Object.Instantiate(newModelPrefab, oldModelInstance.position, oldModelInstance.rotation, oldModelInstance.parent).transform;
			Transform parent = transform7.Find("metarig/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:RightShoulder/mixamorig:RightArm/mixamorig:RightForeArm/mixamorig:RightHand");
			Transform parent2 = transform7.Find("metarig/mixamorig:Hips/mixamorig:Spine/mixamorig:Spine1/mixamorig:Spine2/mixamorig:LeftShoulder/mixamorig:LeftArm/mixamorig:LeftForeArm/mixamorig:LeftHand");
			Vector3 localPosition = transform4.localPosition;
			Quaternion localRotation = transform4.localRotation;
			transform4.SetParent(parent);
			transform4.localPosition = localPosition;
			transform4.localRotation = localRotation;
			localPosition = transform5.localPosition;
			localRotation = transform5.localRotation;
			transform5.SetParent(parent);
			transform5.localPosition = localPosition;
			transform5.localRotation = localRotation;
			localPosition = transform6.localPosition;
			localRotation = transform6.localRotation;
			transform6.SetParent(parent2);
			transform6.localPosition = localPosition;
			transform6.localRotation = localRotation;
			array = transform7.GetComponentsInChildren<SkinnedMeshRenderer>();
			SkinnedMeshRenderer[] array2 = array;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array2)
			{
				skinnedMeshRenderer.shadowCastingMode = ShadowCastingMode.On;
				skinnedMeshRenderer.receiveShadows = false;
				skinnedMeshRenderer.motionVectors = false;
				skinnedMeshRenderer.skinnedMotionVectors = false;
				skinnedMeshRenderer.lightProbeUsage = LightProbeUsage.Off;
				skinnedMeshRenderer.reflectionProbeUsage = ReflectionProbeUsage.Off;
			}
			animationController.CharacterModel = transform7.gameObject;
			animationController.GetComponent<Animator>().avatar = transform7.GetComponent<Animator>().avatar;
			if (flag)
			{
				transform.GetComponent<Transformer>().robotModel = transform7.gameObject;
			}
			return transform7.gameObject;
		}

		public static void SwitchTransformationModel(PlayerSetuperHelper playerSetupHelperInstance, GameObject NewTransformationModel, Transform OldTransformationModel)
		{
			SkinnedMeshRenderer[] array = null;
			Player playerScript = playerSetupHelperInstance.PlayerScript;
			Transform transform = playerScript.transform;
			Transformer component = transform.GetComponent<Transformer>();
			GameObject gameObject = UnityEngine.Object.Instantiate(NewTransformationModel, OldTransformationModel.position, OldTransformationModel.rotation, OldTransformationModel.parent);
			array = gameObject.GetComponentsInChildren<SkinnedMeshRenderer>();
			SkinnedMeshRenderer[] array2 = array;
			foreach (SkinnedMeshRenderer skinnedMeshRenderer in array2)
			{
				skinnedMeshRenderer.shadowCastingMode = ShadowCastingMode.On;
				skinnedMeshRenderer.receiveShadows = false;
				skinnedMeshRenderer.motionVectors = false;
				skinnedMeshRenderer.skinnedMotionVectors = false;
				skinnedMeshRenderer.lightProbeUsage = LightProbeUsage.Off;
				skinnedMeshRenderer.reflectionProbeUsage = ReflectionProbeUsage.Off;
			}
			gameObject.SetActive(value: false);
			component.transformationModel = gameObject;
			UnityEngine.Object.Destroy(OldTransformationModel.gameObject);
		}
	}
}
