using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;

public class CsvParse : MonoBehaviour {

	private static CsvParse _instance = null;
	public static CsvParse instance { get { return _instance; } }

	[SerializeField]
	private string[] indexColumns = null;

	public CsvFileWrite csvFile = new CsvFileWrite();

	public List<string> colList = new List<string>();

    private void Awake()
    {
		_instance = this;
    }

    private void Start ()
	{
		DontDestroyOnLoad(this);

		// 첫 인덱스
		csvFile.rowData.Add(indexColumns);

		// 기존에 있는 csv의 열 불러오기
		csvFile.ReadCsv();
	}

	public void Write(string[] col)
    {
		csvFile.WriteCsv(col);
	}

	public void Write(List<string> col)
	{
		string[] coll = new string[col.Count];
		for (int i =0; i< col.Count; i++)
        {
			coll[i] = col[i];
        }

		csvFile.WriteCsv(coll);
	}
}
