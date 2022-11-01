using UnityEngine.UI;

public class TextListener : VariableListener
{
	public Text text;
	public bool toUppercase;

	protected override void OnEnable()
	{
		base.OnEnable ();
		if (this.toUppercase)
		{
			this.text.text =  (this.trackingVariable as StringVariable).Value.ToUpper();
		}
		else
		{
			this.text.text = (this.trackingVariable as StringVariable).Value;
		}
	}

	public override void VariableUpdated()
	{
		if (this.toUppercase)
		{
			this.text.text =  (this.trackingVariable as StringVariable).Value.ToUpper();
		}
		else
		{
			this.text.text = (this.trackingVariable as StringVariable).Value;
		}
	}

}
