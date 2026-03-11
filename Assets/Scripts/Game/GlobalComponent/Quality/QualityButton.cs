using System;
using UnityEngine;

namespace Game.GlobalComponent.Quality
{
	public class QualityButton : MonoBehaviour
	{
		public bool ApplyNow;

		public QualityLvls QualityLvl;

		public GameObject OnStateObject;

		public GameObject OffStateObject;

		private void Awake()
		{
			QualityManager.updateQuality = (QualityManager.UpdateQuality)Delegate.Combine(QualityManager.updateQuality, new QualityManager.UpdateQuality(UpdateButtonState));
		}

		private void OnDestroy()
		{
			QualityManager.updateQuality = (QualityManager.UpdateQuality)Delegate.Remove(QualityManager.updateQuality, new QualityManager.UpdateQuality(UpdateButtonState));
		}

		private void OnEnable()
		{
			UpdateButtonState();
		}
        private void Start()
        {
			//QualityManager.ChangeQuality(QualityLvl, ApplyNow);
		}
        public void UpdateButtonState()
		{
			bool flag = QualityManager.QualityLvl == QualityLvl;
			OnStateObject.SetActive(flag);
			OffStateObject.SetActive(!flag);
		}

		public void SetQualityLvl()
		{
			QualityManager.ChangeQuality(QualityLvl, ApplyNow);
		}
	}
}
