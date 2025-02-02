using UnityEngine;
using UnityEngine.UIElements;

[CreateAssetMenu(menuName="Variable/New Int")]
public class IntVariable : Variable <int>
{
	[SerializeField]
	private int value;
    public override System.Type type
    { 
        get
        { 
            return typeof(int);
        }
    }
	public override int Value
    {
		get
		{
			return value;
		}
		set
		{
			if (this.value != value) {
				this.value = value;
				ReportChange();
				if(debug)
					Debug.Log (name + ": " + this.value);
			}
		}
	}

    public override void SaveVariable()
    {
        DataSaver.SaveData<IntData>(fileName, new IntData(value));
    }

    public override void LoadVariable()
    {
        IntData data = DataSaver.LoadData<IntData>(fileName);
        if (data == null)
        {
            Value = 0;
            return;
        }
        Value = data.value;
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
