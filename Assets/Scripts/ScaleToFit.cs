using UnityEngine;
using System.Collections;

public class ScaleToFit : MonoBehaviour {

	public enum FitMode
	{
		Smallest,
		Largest
	}

	[SerializeField] private FitMode m_FitMode = FitMode.Smallest;

	[ContextMenu("Apply Scaling")]
	public void CalculateAndApplyScaling()
	{
		RectTransform parentRect = (this.transform.parent as RectTransform);
		RectTransform childRect = (this.transform as RectTransform);

		float XScalingFactor = parentRect.rect.width / childRect.rect.width;
		float YScalingFactor = parentRect.rect.height / childRect.rect.height;
		float scale = 1f;

		switch (this.m_FitMode)
		{
		case FitMode.Smallest:
			scale = (XScalingFactor > YScalingFactor) ? YScalingFactor : XScalingFactor;
			break;
		case FitMode.Largest:
			scale = (XScalingFactor < YScalingFactor) ? YScalingFactor : XScalingFactor;
			break;
		}

		childRect.localScale = new Vector3(scale, scale, 1f);
	}

	void Update(){
		CalculateAndApplyScaling ();
	}
}