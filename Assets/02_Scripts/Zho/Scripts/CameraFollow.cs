using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform playerTransform;
    Vector3 Offset; // ī�޶�� �÷��̾� ������ �Ÿ� ����
    public bool IsTransparent { get; private set; } = false;
    MeshRenderer[] renderers;
    WaitForSeconds delay = new WaitForSeconds(0.001f);
    WaitForSeconds resetDelay = new WaitForSeconds(0.005f);
    const float THRESHOLD_ALPHA = 0.25f;
    const float THRESHOLD_MAX_TIMER = 0.5f;
    
    bool isReseting = false;
    float timer = 0f;
    Coroutine timeCheckCoroutine;
    Coroutine resetCoroutine;
    Coroutine becomeTransparentCoroutine;
    public GameObject stage;

    private float xRotateMove, yRotateMove;

    public float rotateSpeed = 500.0f;

    public Vector3 roa;

    void Awake()
    {
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform;
        Offset = transform.position - playerTransform.position; //ī�޶� ��ġ - �÷��̾� ��ġ    
        renderers = GetComponentsInChildren<MeshRenderer>();
    }

    void LateUpdate()
    {
        transform.position = playerTransform.position + Offset; //ī�޶� ��ġ = �÷��̾� ��ġ + �Ÿ�
        Vector3 direction = (playerTransform.position - transform.position).normalized;
        RaycastHit[] hits = Physics.RaycastAll(transform.position, direction, Mathf.Infinity, 1 << LayerMask.NameToLayer("Filed"));
        for (int i = 0; i < hits.Length; i++)
        {
            TransparentObject[] obj = hits[i].transform.GetComponentsInChildren<TransparentObject>();

            for (int j = 0; j < obj.Length; j++)
            {
                obj[j]?.BecomeTransparent();
            }
        }
    }
    void Update()
    {

    }
}

   