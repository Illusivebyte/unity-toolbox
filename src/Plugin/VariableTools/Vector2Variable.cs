using UnityEngine;

[CreateAssetMenu(menuName="Variable/New Vector2")]
public class Vector2Variable : Variable
{
	[SerializeField]
	private Vector2 value;
    public override StandardVariableType type
    {
        get
        { 
            return StandardVariableType.Vector2;
        }
    }
	public Vector2 Value{
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
        DataSaver.SaveData(this.fileName, (new Vector2Data(this.Value) as object));
    }

    public override void LoadVariable()
    {
        Vector2Data data = DataSaver.LoadData(this.fileName) as Vector2Data;
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
    protected class Vector2Data
    {
        public Vector2 value;

        public Vector2Data(Vector2 value)
        {
            this.value = value;
        }
    }
}
