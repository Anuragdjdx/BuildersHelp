using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using UnityEngine.UI;

public class Insert : MonoBehaviour {
    private const string V0 = "306";
    private const string V = "TestName";
    private const string V1 = "9987456321";
    private const string V2 = "pasword";
    public Button RegisterBtn;
    private string conn, sqlQuery;
    IDbConnection dbconn;
    IDbCommand dbcmd;

    public InputField Flatno_Ifield, FlatHolderName_Ifield, ContactNo_Ifield, Password_ifield;
    Text Flatno_txt;
    Text FlatHolderName_txt;
    Text ContactNo_txt;
    Text Password_txt;

    // Use this for initialization
    void Start()
    {
        conn = "URI=file:" + Application.dataPath + "/Plugins/UsersDatabase.s3db"; //Path to database.
     
        Button reg_btn = RegisterBtn.GetComponent<Button>();
        reg_btn.onClick.AddListener(OnRegisterButtonClick);

        Flatno_txt = GetComponent<Text>();
        FlatHolderName_txt = GetComponent<Text>();
        ContactNo_txt  = GetComponent<Text>();
        Password_txt = GetComponent<Text>();

    }


    void OnRegisterButtonClick()
    {


     




        insertvalue(int.Parse(V0), V, long.Parse(V1), V2);



    }

    private void insertvalue(int FlatNo, string FlatHolderName, long ContactNo, string Password)
    {
        using (dbconn = new SqliteConnection(conn))
        {
            dbconn.Open(); //Open connection to the database.
            dbcmd = dbconn.CreateCommand();
            sqlQuery = string.Format("insert into UsersInfo ( FlatNo, FlatHolderName,ContactNo,Password) values (\"{0}\",\"{1}\",\"{2}\",\"{3}\")", FlatNo, FlatHolderName, ContactNo, Password);// table name
            dbcmd.CommandText = sqlQuery;
            dbcmd.ExecuteScalar();
            dbconn.Close();
        }
    }


}
