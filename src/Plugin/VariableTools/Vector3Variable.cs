using UnityEngine;

[CreateAssetMenu(menuName="Variable/New Vector3")]
public class Vector3Variable : Variable
{
	[SerializeField]
	private Vector3 value;
    public override StandardVariableType type
    {
        get
        { 
            return StandardVariableType.Vector3;
        }
    }
	public Vector3 Value{
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
        DataSaver.SaveData(this.fileName, (new Vector3Data(this.Value) as object));
    }

    public override void LoadVariable()
    {
        Vector3Data data = DataSaver.LoadData(this.fileName) as Vector3Data;
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
    protected class Vector3Data
    {
        public Vector3 value;

        public Vector3Data(Vector3 value)
        {
            this.value = value;
        }
    }
}
