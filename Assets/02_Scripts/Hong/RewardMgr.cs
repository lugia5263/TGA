using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using SimpleJSON; //########################��ܿ;���

public class RewardMgr : MonoBehaviour
{
    public static RewardMgr reward;
    public InventoryManager inventoryMgr;
    public ImageList imagelist;


    public TextAsset txtFile; //Jsonfile
    public GameObject jsonObject; //Prefab (Json char �޸�)


    public GameObject rewardCanvas;
    public GameObject inventoryCanvas;

    public List<GameObject>  countList;


    public void QuestReward()
    {

    }



    public void MakeItem(int itemIdx, int count) // n��° �������� count�� ����
    {
        InstMaterial(itemIdx, count);
    }
    public void MakeItemOne(int itemIdx) // n��° �������� 1�� ����
    {
        InstMaterial(itemIdx, 1);
    }
    public void MakeItemRandomBtn()
    {
        int makeidx = Random.Range(1, 5);// 1���� 3���� ����
        InstMaterial(makeidx, 1);
    } // �������� ��� 1�� ��� ��ư




              // ����ȯ
    public void InstMaterial(int n, int itemcount)
    {

        string json = txtFile.text;
        var jsonData = JSON.Parse(json);


        int item = n-1; // �Ű�����


        GameObject character = Instantiate(jsonObject); // ����ž�

        character.transform.name = jsonData["Weapon"][item]["Name"]; // ������Ʈ�� ����

        character.GetComponent<JsonChar>().charname = (jsonData["Weapon"][item]["Name"]);
        character.GetComponent<JsonChar>().discription = (jsonData["Weapon"][item]["Discription"]);
        character.GetComponent<JsonChar>().atk = (int)(jsonData["Weapon"][item]["Str"]);
        character.GetComponent<JsonChar>().count += itemcount;
        Debug.Log(jsonData["Weapon"][item]["Name"]);
        character.GetComponent<Image>().sprite = imagelist.meterialsImage[n];

        character.tag = "Material";
        character.transform.SetParent(rewardCanvas.transform);

    } 


             //����ġ ���� ��ȯ
    public void InstExp(int n, int itemcount) 
    {

        string json = txtFile.text;
        var jsonData = JSON.Parse(json);


        int item = n-1; // �Ű�����


        GameObject character = Instantiate(jsonObject); // ����ž�

        character.transform.name = jsonData["Food"][item]["Name"]; // ������Ʈ�� ����

        character.GetComponent<JsonChar>().charname = (jsonData["Food"][item]["Name"]);
        character.GetComponent<JsonChar>().discription = (jsonData["Food"][item]["Discription"]);
        character.GetComponent<JsonChar>().exp = (int)(jsonData["Food"][item]["exp"]);
        character.GetComponent<JsonChar>().count += itemcount;
        Debug.Log(jsonData["Food"][item]["Name"]);
        character.GetComponent<Image>().sprite = imagelist.expPotionImage[n];

        character.tag = "Exp";
        character.transform.SetParent(rewardCanvas.transform);

    } 


             // ��� ��ȯ
    public void InstGOld(int itemcount)
    {
        GameObject character = Instantiate(jsonObject); // ����ž�

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