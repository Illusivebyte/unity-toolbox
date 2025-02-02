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
			return value;
		}
		set
		{
			if (this.value != value)
            {
				this.value = value;
				ReportChange();
				if(debug)
					Debug.Log (name + ": " + this.value);
			}
		}
	}

    public override void SaveVariable()
    {
        DataSaver.SaveData<StringData>(fileName, new StringData(value));
    }

    public override void LoadVariable()
    {
        StringData data = DataSaver.LoadData<StringData>(fileName);
        if (data == null)
        {
            Value = "";
            return;
        } 
        Value = data.value;
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
