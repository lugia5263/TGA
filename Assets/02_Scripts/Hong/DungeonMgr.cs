using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON; //########################��ܿ;���


//TODO :  �۾���!!!!


public class DungeonMgr : MonoBehaviour
{
    public TextAsset txtFile; //Jsonfile
    public GameObject jsonObject; //Prefab (Json char �޸�)

    public void InstSingleDungeon(int n, string dungeoncullum) 
    {

        string json = txtFile.text;
        var jsonData = JSON.Parse(json);
        int item = n; //n�� �p��° �������� index Json���� ����


        GameObject character = Instantiate(jsonObject); // ����ž�

        character.transform.name = jsonData[dungeoncullum][item]["Name"]; // ������ �̸�

        character.GetComponent<JsonChar>().charname = (jsonData[dungeoncullum][item]["Name"]); // ������
        character.GetComponent<JsonChar>().discription = (jsonData[dungeoncullum][item]["Discription"]); // 
        character.GetComponent<JsonChar>().atk = (int)(jsonData[dungeoncullum][item]["Str"]);
        
        Debug.Log(jsonData[dungeoncullum][item]["Name"]);

        character.tag = "Dungeon";
        //character.transform.SetParent(rewardCanvas.transform);

    }

    public void weraewr()
    {
        
    }
}
