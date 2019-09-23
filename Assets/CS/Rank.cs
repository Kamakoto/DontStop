using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;

public class Rank : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Refresh();
	}
	    
	// Update is called once per frame
	void Update () {


	}


    public void SendScore(string name)
    {
    //    GameObject.Find("Rankstate").GetComponent<UILabel>().text = "正在尝试连接树状图设计者";
        if (Instation.Online)
        {
            string conurl = "server=*;port=*;user=*;password=*;database=UserMDF;Character Set=utf8;Connect TimeOut=3;";
            MySqlConnection con = new MySqlConnection(conurl);

            try
            {
                con.Open();
                int a = Instation.NowScore;
                string username = name;
                MySqlCommand Send = new MySqlCommand("insert into DontStop(UserName,Score) values ('" + username + "','" + a + "')", con);
                Send.ExecuteNonQuery();
                GameObject.Find("Rankstate").GetComponent<UILabel>().text = "S2:已成功向树状图设计者递送信息";
                con.Close();
                Refresh();
            }

            catch(MySqlException E)
            {
                GameObject.Find("Rankstate").GetComponent<UILabel>().text = "E13:无法送出信息\n" + E.Message;
            }
        }
        


    }


    public void Refresh()
    {
        if (Instation.Online)
        {
            string conurl = "server=*;port=*;user=*;password=*;database=UserMDF;Character Set=utf8;Connect TimeOut=3;";
            MySqlConnection con = new MySqlConnection(conurl);
            try
            {
                con.Open();
                string[] Rank_Name = new string[9] { null, null, null, null, null, null, null, null, null, };
                int[] Rank_Score = new int[9] { 0, 0, 0, 0, 0, 0, 0, 0, 0 };

                MySqlCommand Max = new MySqlCommand("SELECT * FROM DontStop ORDER BY Score DESC LIMIT 9", con);
                MySqlDataReader READER = Max.ExecuteReader();
                int i = 0;
                while (READER.Read())
                {
                    Rank_Name[i] = READER.GetString(READER.GetOrdinal("UserName"));
                    Rank_Score[i] = READER.GetInt32(READER.GetOrdinal("Score"));
                    GameObject.Find("Rank" + (i + 1)).GetComponent<UILabel>().text = "#" + (i + 1) + ":" + Rank_Name[i] + " / " + Rank_Score[i];
                    i += 1;
                }
                con.Close();
                GameObject.Find("Rankstate").GetComponent<UILabel>().text = "S1:已成功连接到树状图设计者";
            }
            catch (MySqlException E)
            {
                GameObject.Find("Rankstate").GetComponent<UILabel>().text = "E12:无法连接到排行榜\n"+E.Message;
            }
        }
        else
        {
            GameObject.Find("Rankstate").GetComponent<UILabel>().text = "E94:网络组件已关闭";
        }
        

    }





}
