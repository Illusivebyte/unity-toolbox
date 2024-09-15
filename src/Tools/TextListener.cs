using System;
using UnityEngine;
using UnityEngine.UI;

public class TextListener : MonoBehaviour
{
	StringVariable trackingVariable;
	public Text text;
	public bool toUppercase;

	protected void OnEnable()
	{
		VariableUpdated();
	}

	protected void VariableUpdated()
	{
        string value = toUppercase ? trackingVariable.Value.ToUpper() : trackingVariable.Value;
		this.text.text =  value.ToUpper();
	}
}
