using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
using Photon.Realtime;
using UnityEngine.UI;

public class PlayerScript : MonoBehaviourPunCallbacks, IPunObservable
{
    public float speed = 10.0f;
    private Transform tr;
    public PhotonView pv;
    public Text nickNameTxt;

    private void Awake()
    {
        if (pv.IsMine)
        {
            nickNameTxt.text = PhotonNetwork.NickName+("나");
            nickNameTxt.color = Color.white;
        }
        else
        {
            nickNameTxt.text = pv.Owner.NickName;
            nickNameTxt.color = Color.red;
        }
    }

    void Start()
    {
        tr = GetComponent<Transform>();
        pv = GetComponent<PhotonView>();
    }

    void Update()
    {
        if (pv.IsMine)
        {
            nickNameTxt.text = PhotonNetwork.NickName;
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);
            tr.Translate(movement * Time.deltaTime * speed);
        }
        else
        {
            //끊어진 시간이 너무 길 경우(텔레포트)
            if ((tr.position - currPos).sqrMagnitude >= 10.0f * 10.0f)
            {
                tr.position = currPos;
                tr.rotation = currRot;
            }
            //끊어진 시간이 짧을 경우(자연스럽게 연결 - 데드레커닝)
            else
            {
                tr.position = Vector3.Lerp(tr.position, currPos, Time.deltaTime * 10.0f);
                tr.rotation = Quaternion.Slerp(tr.rotation, currRot, Time.deltaTime * 10.0f);
            }
        }
    }

    //클론이 통신을 받는 변수 설정
    private Vector3 currPos;
    private Quaternion currRot;

    public void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
    {
        //통신을 보내는 
        if (stream.IsWriting)
        {
            stream.SendNext(tr.position);
            stream.SendNext(tr.rotation);
        }

        //클론이 통신을 받는 
        else
        {
            currPos = (Vector3)stream.ReceiveNext();
            currRot = (Quaternion)stream.ReceiveNext();
        }
    }
}   