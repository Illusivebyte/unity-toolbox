using UnityEngine;

[CreateAssetMenu(menuName="Variable/New Float")]
public class FloatVariable : Variable
{
	[SerializeField]
	private float value;
    public override StandardVariableType type{ get{ return StandardVariableType.Float;}}
	public float Value{
		get
		{
			return this.value;
		}
		set
		{
			if (this.value != value)
            {
				this.value = value;
				this.ReportChange ();
				if(this.debug)
					Debug.Log (this.name + ": " + this.value);
			}
		}
	}

    public override void SaveVariable()
    {
        DataSaver.SaveData(this.fileName, (new FloatData(this.Value)as object));
    }

    public override void LoadVariable()
    {
        FloatData data = DataSaver.LoadData(this.fileName) as FloatData;
        if (data != null)
        {
            this.Value = data.value;
        }
        else
        {
            Debug.Log(this.name +": No file found to load");
        }

    }
    
    [System.Serializable]
    protected class FloatData
    {
        public float value;

        public FloatData(float value)
        {
            this.value = value;
        }
    }
}
