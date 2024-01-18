using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON; //########################댕겨와야행

public class RewardMgr : MonoBehaviour
{
    public static RewardMgr reward;
    public InventoryManager inventoryMgr;
    public ImageList imagelist;


    public TextAsset txtFile; //Jsonfile
    public GameObject jsonObject; //Prefab (Json char 달린)


    public GameObject rewardCanvas;
    public GameObject inventoryCanvas;

    public List<GameObject>  countList;


    public void QuestReward()
    {

    }



    public void MakeItem(int itemIdx, int count) // n번째 아이템을 count개 얻음
    {
        InstMaterial(itemIdx, count);
    }
    public void MakeItemOne(int itemIdx) // n번째 아이템을 1개 얻음
    {
        InstMaterial(itemIdx, 1);
    }
    public void MakeItemRandomBtn()
    {
        int makeidx = Random.Range(1, 5);// 1에서 3까지 나옴
        InstMaterial(makeidx, 1);
    } // 랜덤으로 재료 1개 얻는 버튼




              // 재료소환
    public void InstMaterial(int n, int itemcount)
    {

        string json = txtFile.text;
        var jsonData = JSON.Parse(json);


        int item = n-1; // 매개변수


        GameObject character = Instantiate(jsonObject); // 만들거야

        character.transform.name = jsonData["Weapon"][item]["Name"]; // 오브젝트명 정의

        character.GetComponent<JsonChar>().charname = (jsonData["Weapon"][item]["Name"]);
        character.GetComponent<JsonChar>().discription = (jsonData["Weapon"][item]["Discription"]);
        character.GetComponent<JsonChar>().atk = (int)(jsonData["Weapon"][item]["Str"]);
        character.GetComponent<JsonChar>().count += itemcount;
        Debug.Log(jsonData["Weapon"][item]["Name"]);
        character.GetComponent<Image>().sprite = imagelist.meterialsImage[n];

        character.tag = "Material";
        character.transform.SetParent(rewardCanvas.transform);

    } 


             //경험치 물약 소환
    public void InstExp(int n, int itemcount) 
    {

        string json = txtFile.text;
        var jsonData = JSON.Parse(json);


        int item = n-1; // 매개변수


        GameObject character = Instantiate(jsonObject); // 만들거야

        character.transform.name = jsonData["Food"][item]["Name"]; // 오브젝트명 정의

        character.GetComponent<JsonChar>().charname = (jsonData["Food"][item]["Name"]);
        character.GetComponent<JsonChar>().discription = (jsonData["Food"][item]["Discription"]);
        character.GetComponent<JsonChar>().exp = (int)(jsonData["Food"][item]["exp"]);
        character.GetComponent<JsonChar>().count += itemcount;
        Debug.Log(jsonData["Food"][item]["Name"]);
        character.GetComponent<Image>().sprite = imagelist.expPotionImage[n];

        character.tag = "Exp";
        character.transform.SetParent(rewardCanvas.transform);

    } 


             // 골드 소환
    public void InstGOld(int itemcount)
    {
        GameObject character = Instantiate(jsonObject); // 만들거야

        string json = txtFile.text;
        var jsonData = JSON.Parse(json);
        character.GetComponent<JsonChar>().count += itemcount;
        character.GetComponent<Image>().sprite = imagelist.goldImage[1];
        character.tag = "Gold";
        character.transform.SetParent(rewardCanvas.transform);
    }


    public void Reward100exp3EABtn()
    {
        InstExp(3, 100);
    }

}