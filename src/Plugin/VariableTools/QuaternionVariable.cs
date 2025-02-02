using UnityEngine;

[CreateAssetMenu(menuName="Variable/New Quaternion")]
public class QuaternionVariable : Variable<Quaternion> 
{
	[SerializeField]
	private Quaternion value;
    public override System.Type type{ get{ return typeof(Quaternion);}}
	public override Quaternion Value
    {
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
        DataSaver.SaveData<QuaternionData>(fileName, new QuaternionData(Value));
    }

    public override void LoadVariable()
    {
        QuaternionData data = DataSaver.LoadData<QuaternionData>(fileName);
        if (data == null)
        {
            Value = new Quaternion();
            return;
        }
        Value = data.value;
    }
    
    [System.Serializable]
    protected class QuaternionData
    {
        public Quaternion value;

        public QuaternionData(Quaternion value)
        {
            this.value = value;
        }
    }
}
