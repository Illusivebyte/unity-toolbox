using UnityEngine;

[CreateAssetMenu(menuName="Variable/New String")]
public class StringVariable : Variable<string>
{
	[SerializeField]
	private string value;
    public override System.Type type{ get{ return typeof(string);}}
	public override string Value
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
        DataSaver.SaveData(this.fileName, (new StringData(this.Value)as object));
    }

    public override void LoadVariable()
    {
        StringData data = DataSaver.LoadData(this.fileName) as StringData;
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
    protected class StringData
    {
        public string value;

        public StringData(string value)
        {
            this.value = value;
        }
    }
}
