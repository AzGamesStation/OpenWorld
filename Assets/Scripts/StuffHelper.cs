using Game.Items;
using UnityEngine;

public class StuffHelper : MonoBehaviour
{
	public Transform HatPlaceholder;

	public Transform GlassPlaceholder;

	public Transform MaskPlaceholder;

	[Space(5f)]
	public Transform LeftBraceletPlaceholder;

	public Transform RightBraceletPlaceholder;

	[Space(5f)]
	public Transform LeftHucklePlaceholder;

	public Transform RightHucklePlaceholder;

	[Space(5f)]
	public Transform LeftPalmPlaceholder;

	public Transform RightPalmPlaceholder;

	[Space(5f)]
	public Transform LeftToePlaceholder;

	public Transform RightToePlaceholder;

	[Space(10f)]
	public SlotRenderer SlotRenderers;

	[Space(10f)]
	public GameItemClothes[] DefaultClotheses;

	[Separator("For moto specific")]
	public Transform LeftUpperArm;

	public Transform LeftForeArm;

	public Transform RightUpperArm;

	public Transform RightForeArm;

	public Transform Spine;

	public Transform Chest;

	public Transform GetPlaceholder(SkinSlot slot)
	{
		Transform result = null;
		switch (slot)
		{
		case SkinSlot.Glass:
			result = GlassPlaceholder;
			break;
		case SkinSlot.Hat:
			result = HatPlaceholder;
			break;
		case SkinSlot.Mask:
			result = MaskPlaceholder;
			break;
		case SkinSlot.LeftBracelet:
			result = LeftBraceletPlaceholder;
			break;
		case SkinSlot.RightBracelet:
			result = RightBraceletPlaceholder;
			break;
		case SkinSlot.LeftHuckle:
			result = LeftHucklePlaceholder;
			break;
		case SkinSlot.RightHuckle:
			result = RightHucklePlaceholder;
			break;
		case SkinSlot.LeftPalm:
			result = LeftPalmPlaceholder;
			break;
		case SkinSlot.RightPalm:
			result = RightPalmPlaceholder;
			break;
		case SkinSlot.LeftToe:
			result = LeftToePlaceholder;
			break;
		case SkinSlot.RightToe:
			result = RightToePlaceholder;
			break;
		}
		return result;
	}
}
