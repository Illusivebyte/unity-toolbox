using UnityEngine;

[CreateAssetMenu(menuName="Variable/New Vector3")]
public class Vector3Variable : Variable<Vector3>
{
	[SerializeField]
	private Vector3 value;
    public override System.Type type
    {
        get
        { 
            return typeof(Vector3);
        }
    }
	public override Vector3 Value{
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
        DataSaver.SaveData<Vector3Data>(fileName, new Vector3Data(Value));
    }

    public override void LoadVariable()
    {
        Vector3Data data = DataSaver.LoadData<Vector3Data>(fileName);
        if (data == null)
        {
            Value = new Vector3();
            return;
        }
        Value = data.value;

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
