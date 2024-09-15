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
			return this.value;
		}
		set
		{
			if (this.value != value) 
            {
				this.value = value;
				this.ReportChange();
				if(this.debug)
					Debug.Log (this.name + ": " + this.value);
			}
		}
	}

    public override void SaveVariable()
    {
        DataSaver.SaveData(this.fileName, (new QuaternionData(this.Value)as object));
    }

    public override void LoadVariable()
    {
        QuaternionData data = DataSaver.LoadData(this.fileName) as QuaternionData;
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
    protected class QuaternionData
    {
        public Quaternion value;

        public QuaternionData(Quaternion value)
        {
            this.value = value;
        }
    }
}
