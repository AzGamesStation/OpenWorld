using UnityEngine;

namespace UnitySampleAssets.CrossPlatformInput
{
	public class ButtonHandler : MonoBehaviour
	{
		private string downedStateName = string.Empty;

		public void SetDownState(string name)
		{
			downedStateName = name;
			CrossPlatformInputManager.SetButtonDown(name);
			GlobalContants.IsRewadedAd = false;
		}

		public void SetUpState(string name)
		{
			downedStateName = string.Empty;
			CrossPlatformInputManager.SetButtonUp(name);
		}

		public void SetAxisPositiveState(string name)
		{
			CrossPlatformInputManager.SetAxisPositive(name);
		}

		public void SetAxisNeutralState(string name)
		{
			CrossPlatformInputManager.SetAxisZero(name);
		}

		public void SetAxisNegativeState(string name)
		{
			CrossPlatformInputManager.SetAxisNegative(name);
		}

		private void OnDisable()
		{
			if (downedStateName.Length > 0)
			{
				SetUpState(downedStateName);
			}
		}
	}
}