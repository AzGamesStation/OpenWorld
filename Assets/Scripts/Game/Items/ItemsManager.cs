using Game.Character.Stats;
using System.Collections.Generic;
using UnityEngine;

namespace Game.Items
{
	public class ItemsManager : MonoBehaviour
	{
		private static ItemsManager instance;

		public bool ShowDebug;

		public Sprite[] ssss;

		public GameItem[] items;

		[SerializeField]
		private UpgradeList playerUpgrades;

		private bool inited;

		public static ItemsManager Instance => instance ?? (instance = UnityEngine.Object.FindObjectOfType<ItemsManager>());

		public Dictionary<int, GameItem> Items
		{
			get;
			private set;
		}

		private void Awake()
		{
			instance = this;
		}

		public void Init()
		{
			if (!inited)
			{
				instance = this;
				AssembleGameitems();
				inited = true;
			}
		}

		public bool AddItem(GameItem item)
		{
			if (Items.ContainsKey(item.ID))
			{
				if (ShowDebug)
				{
					UnityEngine.Debug.LogWarning(item.ShopVariables.Name + " - предмет с таким ID уже сеществует. Пытаюсь переполучить ID.");
				}
				item.ID = GenerateID(item);
			}
			if (!Items.ContainsKey(item.ID))
			{
				Items.Add(item.ID, item);
				if (ShowDebug)
				{
					UnityEngine.Debug.LogFormat(item.gameObject, "{0} Added item name : {1}", item.ID, item.gameObject.name);
				}
				return true;
			}
			if (ShowDebug)
			{
				UnityEngine.Debug.LogError(item.ShopVariables.Name + " не добавлен. Предмет с таким ID уже сеществует.");
			}
			return false;
		}

		public GameItem GetItem(int id)
		{
			GameItem value = null;
			bool flag = Items.TryGetValue(id, out value);
			if (ShowDebug)
			{
				foreach (KeyValuePair<int, GameItem> item in Items)
				{
					UnityEngine.Debug.Log(item.Key + " " + item.Value.ShopVariables.Name + " " + (item.Value == null));
				}
				return value;
			}
			return value;
		}

		public int GenerateID(GameItem item)
		{
			return item.ID = item.gameObject.GetInstanceID();
		}

		public Dictionary<int, GameItem> AssembleGameitems()
		{
			Items = new Dictionary<int, GameItem>();
			GameItem[] componentsInChildren = GetComponentsInChildren<GameItem>();
			GameItem[] array = componentsInChildren;
			foreach (GameItem gameItem in array)
			{
				Instance.AddItem(gameItem);
				gameItem.Init();
			}
			return Items;
		}
	}
}
