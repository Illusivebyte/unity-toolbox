using UnityEngine;

[CreateAssetMenu(menuName="Variable/New Int")]
public class IntVariable : Variable {
	[SerializeField]
	private int value;
    public override StandardVariableType type
    { 
        get
        { 
            return StandardVariableType.Int;
        }
    }
	public int Value
    {
		get
		{
			return this.value;
		}
		set
		{
			if (this.value != value) {
				this.value = value;
				this.ReportChange ();
				if(this.debug)
					Debug.Log (this.name + ": " + this.value);
			}
		}
	}

    public override void SaveVariable()
    {
        DataSaver.SaveData(this.fileName, (new IntData(this.Value)as object));
    }

    public override void LoadVariable()
    {
        IntData data = DataSaver.LoadData(this.fileName) as IntData;
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
    protected class IntData
    {
        public int value;

        public IntData(int value)
        {
            this.value = value;
        }
    }
}
