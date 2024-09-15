using UnityEngine;

[CreateAssetMenu(menuName="Variable/New Bool")]
public class BoolVariable : Variable<bool>
{
	[SerializeField]
	private bool value;
    public override System.Type type{ get{ return typeof(bool);}}
	public override bool Value
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
        DataSaver.SaveData(this.fileName, (new BoolData(this.Value)as object));
    }

    public override void LoadVariable()
    {
        BoolData data = DataSaver.LoadData(this.fileName) as BoolData;
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
    protected class BoolData
    {
        public bool value;

        public BoolData(bool value)
        {
            this.value = value;
        }
    }
}
