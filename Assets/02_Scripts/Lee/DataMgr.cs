using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

// �����ϴ� ���
// 1. ������ �����Ͱ� ����
// 2. �����͸� json���� ��ȯ
// 3. json�� �ܺο� ����

// �ҷ����� ���
// 1. �ܺο� ����� json�� ������
// 2. json�� ������ ���·� ��ȯ
// 3. �ҷ��� �����͸� ���

public enum Character
{
    Blue, Red, Yellow
}

//public class PlayerData
//{
//    // �����̸�, ����, ���ݷ�, ü��, ���, ������, ����ġ����
//    public string className;
//public int level;
//public int atkDmg;
//public int hp;
//public int haveGold;
//public int item;
//public int expPotion;
//}

public class DataMgr : MonoBehaviour
{
    // �̱���
    public static DataMgr instance;

    //PlayerData currentPlayer = new PlayerData();

    //string path;
    //string filename = "save";

    private void Awake()
    {
        #region �̱���
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Destroy(instance.gameObject);
        }
        DontDestroyOnLoad(gameObject);
        #endregion

        //path = Application.persistentDataPath + "/";
    }

    public Character currentCharacter;

    void Start()
    {
        //string jsondata = JsonUtility.ToJson(currentPlayer);
        // print(path);
        //File.WriteAllText(path + filename, data); //json�� �����Ҷ� ���� �Լ�

        //PlayerData loadPlayerData = JsonUtility.FromJson<PlayerData>(jsondata); // json���� �ҷ����� �Լ� <Ŭ������>(�����̸�)

        //print(loadPlayerData.className);
        //print(loadPlayerData.level);
    }
}
