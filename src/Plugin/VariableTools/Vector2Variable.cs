using UnityEngine;

[CreateAssetMenu(menuName="Variable/New Vector2")]
public class Vector2Variable : Variable<Vector2>
{
	[SerializeField]
	private Vector2 value;
    public override System.Type type
    {
        get
        { 
            return typeof(Vector2);
        }
    }
	public override Vector2 Value{
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
        DataSaver.SaveData<Vector2Data>(fileName, new Vector2Data(this.Value));
    }

    public override void LoadVariable()
    {
        Vector2Data data = DataSaver.LoadData<Vector2Data>(fileName);
        if (data == null)
        {
            Value = new Vector2();
            return;
        }
        Value = data.value;
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
