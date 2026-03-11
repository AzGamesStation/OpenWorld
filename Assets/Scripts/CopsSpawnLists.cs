using System;
using UnityEngine;

namespace Game.Traffic
{
	[Serializable]
	public struct CopsSpawnLists
	{
		public SpawnVehicleList[] m_Details;

		public SpawnVehicleList GetListByStar(int starCount)
		{
			int num = Mathf.Clamp(starCount - 1, 0, m_Details.Length - 1);
			return m_Details[num];
		}
	}
}
