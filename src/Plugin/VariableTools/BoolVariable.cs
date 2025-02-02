using UnityEngine;

[CreateAssetMenu(menuName="Variable/New Bool")]
public class BoolVariable : Variable<bool>
{
	[SerializeField]
	private bool value;
    public override System.Type type{get{ return typeof(bool);}}
	public override bool Value
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
        DataSaver.SaveData<BoolData>(fileName, new BoolData(value));
    }

    public override void LoadVariable()
    {
        BoolData data = DataSaver.LoadData<BoolData>(fileName);
        if (data == null)
        {
            Value = false;
            return;
        }
        Value = data.value;
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
