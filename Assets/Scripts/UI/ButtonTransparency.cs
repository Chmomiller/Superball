using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonTransparency : MonoBehaviour 
{
	public float AlphaThreshold = 0.5f;

	void Start()
	{
		this.GetComponent<Image>().alphaHitTestMinimumThreshold = AlphaThreshold;
	}
}
