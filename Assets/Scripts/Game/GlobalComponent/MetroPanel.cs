using Game.Character;
using Game.Character.CharacterController;
using Game.MiniMap;
using Game.UI;
using System;
using UnityEngine;

namespace Game.GlobalComponent
{
	public class MetroPanel : MonoBehaviour
	{
		[Serializable]
		public class AnimationSetup
		{
			public float Scale = 2f;

			public Color StartColor;

			public Color EndColor;

			public float timePerFrame = 2f;
		}

		public static MetroPanel Instance;

		public Sprite MenuMapSprite;

		public Sprite MetroMapSprite;

		public float NormalScale;

		public Animator MetroPaneleAnimator;

		public MenuPanelManager MenuManager;

		public AnimationSetup AnimationSettings;

		private MetroManager manager;

		private Metro animatedMetro;

		private float timer;

		private Player player;

		private MetroManager metroManager
		{
			get
			{
				if ((bool)manager)
				{
					return manager;
				}
				manager = MetroManager.Instance;
				return manager;
			}
		}

		private void Awake()
		{
			Instance = this;
		}

		private void Start()
		{
			player = PlayerInteractionsManager.Instance.Player;
		}

		public void Open()
		{
			if (!player)
			{
				player = PlayerInteractionsManager.Instance.Player;
			}
			if (!player.IsDead)
			{
				MenuManager.OpenPanel(MetroPaneleAnimator);
			}
		}

		private void OnEnable()
		{
			UIGame.Instance.Pause();
			foreach (Metro metro in metroManager.Metros)
			{
				if ((bool)metro.MetroMark)
				{
					metro.MetroMark.SetMetroSprite(MetroMapSprite);
				}
			}
			CheckSelected();
		}

		private void OnDisable()
		{
			if ((bool)manager)
			{
				UIGame.Instance.Resume();
				foreach (Metro metro in metroManager.Metros)
				{
					if ((bool)metro.MetroMark)
					{
						metro.MetroMark.SetNormalSprite(MenuMapSprite);
					}
				}
				Game.MiniMap.MiniMap.Instance.ChangeMapSize(fullScreen: false);
			}
		}

		private void Update()
		{
			AnimateMetro();
		}

		private void AnimateMetro()
		{
			if (!base.gameObject.activeSelf || !metroManager.TerminusMetro)
			{
				return;
			}
			if (!animatedMetro)
			{
				animatedMetro = metroManager.TerminusMetro;
			}
			if (animatedMetro.Equals(metroManager.TerminusMetro))
			{
				timer += Time.fixedDeltaTime;
				if (AnimationSettings.timePerFrame / 2f > timer)
				{
					animatedMetro.MetroMark.drawedIconSprite.color = Color.Lerp(animatedMetro.MetroMark.drawedIconSprite.color, AnimationSettings.StartColor, Time.fixedDeltaTime * 8f);
					animatedMetro.MetroMark.IconScale = Mathf.Lerp(animatedMetro.MetroMark.IconScale, NormalScale * AnimationSettings.Scale, Time.fixedDeltaTime * 2f);
				}
				else
				{
					animatedMetro.MetroMark.drawedIconSprite.color = Color.Lerp(animatedMetro.MetroMark.drawedIconSprite.color, AnimationSettings.EndColor, Time.fixedDeltaTime * 8f);
					animatedMetro.MetroMark.IconScale = Mathf.Lerp(animatedMetro.MetroMark.IconScale, NormalScale, Time.fixedDeltaTime * 2f);
				}
				if (AnimationSettings.timePerFrame < timer)
				{
					timer = 0f;
				}
			}
			else
			{
				animatedMetro.MetroMark.IconScale = NormalScale;
				animatedMetro = null;
			}
		}

		public void CheckSelected()
		{
			if (base.gameObject.activeSelf)
			{
				foreach (Metro metro in MetroManager.Instance.Metros)
				{
					if (metro.Equals(metroManager.CurrentMetro))
					{
						metro.MetroMark.SetCurrent();
					}
					else if (metro.Equals(metroManager.TerminusMetro))
					{
						metro.MetroMark.Select();
					}
					else
					{
						metro.MetroMark.DisableSelected();
					}
				}
			}
		}
	}
}
