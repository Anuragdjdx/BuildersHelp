using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;
using UnityEngine.UI;

public class db : MonoBehaviour {

    public Button RegisterBtn;

	// Use this for initialization
	void Start ()
    {   

        Button reg_btn = RegisterBtn.GetComponent<Button>();
        reg_btn.onClick.AddListener(OnRegisterButtonClick);

    }
	

    void OnRegisterButtonClick()
    {
        string conn = "URI=file:" + Application.dataPath + "/Plugins/UsersDatabase.s3db"; //Path to database.
        IDbConnection dbconn;
        dbconn = (IDbConnection)new SqliteConnection(conn);
        dbconn.Open(); //Open connection to the database.
        IDbCommand dbcmd = dbconn.CreateCommand();
        string sqlQuery = "SELECT * " + "FROM UsersInfo";// table name
        dbcmd.CommandText = sqlQuery;
        IDataReader reader = dbcmd.ExecuteReader();
        while (reader.Read())
        {
            int user_id = reader.GetInt32(0);
            int FlatNo = reader.GetInt32(1);
            string FlatHolderName = reader.GetString(2);
            Int64 ContactNo = reader.GetInt64(3);
            string Password = reader.GetString(4);

            Debug.Log("UserId= " + user_id + "  FlatNo. =" + FlatNo + "  HolderName =" + FlatHolderName + "Phone" + ContactNo + " Password " + Password);
        }
        reader.Close();
        reader = null;
        dbcmd.Dispose();
        dbcmd = null;
        dbconn.Close();
        dbconn = null;
    }


}
