using UnityEngine;

[CreateAssetMenu(menuName="Variable/New Float")]
public class FloatVariable : Variable<float>
{
	[SerializeField]
	private float value;
    public override System.Type type{ get{ return typeof(float);}}
	public override float Value{
		get
		{
			return value;
		}
		set
		{
			if (this.value != value)
            {
				this.value = value;
				ReportChange();
				if(this.debug)
					Debug.Log (name + ": " + this.value);
			}
		}
	}

    public override void SaveVariable()
    {
        DataSaver.SaveData<FloatData>(fileName, new FloatData(Value));
    }

    public override void LoadVariable()
    {
        FloatData data = DataSaver.LoadData<FloatData>(fileName);
        if (data == null)
        {
           Value = 0f;
           return;
        }
        Value = data.value;
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
