using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON; //########################댕겨와야행


//TODO :  작업중!!!!


public class DungeonMgr : MonoBehaviour
{
    public TextAsset txtFile; //Jsonfile
    public GameObject jsonObject; //Prefab (Json char 달린)

    public void InstSingleDungeon(int n, string dungeoncullum) 
    {

        string json = txtFile.text;
        var jsonData = JSON.Parse(json);
        int item = n; //n은 몆번째 던전인지 index Json파일 참고


        GameObject character = Instantiate(jsonObject); // 만들거야

        character.transform.name = jsonData[dungeoncullum][item]["Name"]; // 프리팹 이름

        character.GetComponent<JsonChar>().charname = (jsonData[dungeoncullum][item]["Name"]); // 던전명
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
