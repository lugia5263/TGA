using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [Header("Move")]
    public float speed;
    public float moveSpeed = 8f;
    public float turn;
    public bool desh;
    float deshCool;
    float curDeshCool = 8f;
    public bool isDeshInvincible;

    float hAxis;
    float vAxis;
    Vector3 moveVec;

    [Header("Component")]
    public CharacterController characterController;
    public Rigidbody rigid;
    public GameObject rigids;
    public Transform cameraArm;
    Animator animator;
    public TrailRenderer trailRenderer;
    public Weapons weapons;
    private PlayableDirector pd;
    public TimelineAsset[] Ta;
    Boss boss;
    TPScontroller tps;
    StateManager stateManager;
    MeshRenderTail meshRenderTail;
   

    [Header("CamBat")]
    public bool isAttack;
    public bool isAttack1;
    public bool isAttack2;
    public bool isAttack3;
    float fireDelay;
    public bool isFireReady;
    public bool isDeath;
    public bool downing;

    public GameObject skillOneEffect;
    public GameObject skillQ;
    public GameObject skillE;
    public GameObject skillR;
    public GameObject skillLoding;
    
    public Transform targetPlayer;

    bool qisReady;
    bool eisReady;
    bool risReady;

    public float qskillcool;
    public float eskillcool;
    public float rskillcool;

    public float curQskillcool = 12f;
    public float curEskillcool = 8f;
    public float curRskillcool = 15f;

    [SerializeField] private float rotCamXAxisSpeed = 500f;
    [SerializeField] private float rotCamYAxisSpeed = 3f;
    void Start()
    {
        weapons = GetComponentInChildren<Weapons>();
        rigid = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
        characterController = GetComponent<CharacterController>();
        pd = GetComponent<PlayableDirector>();
        boss = GameObject.FindGameObjectWithTag("Boss").GetComponent<Boss>();
        tps = GetComponentInParent<TPScontroller>();
        stateManager = GetComponent<StateManager>();
       
    }

    // Update is called once per frame
    void Update()
    {
        if(isDeath != true)
        {
            GetinPut();
            Attack();
            SkillOn();
            Death();
            Deshs();
        }
        
    }

    void GetinPut()
    {
        hAxis = Input.GetAxisRaw("Horizontal");
        vAxis = Input.GetAxisRaw("Vertical");
        turn = Input.GetAxisRaw("Mouse X");
        isAttack = Input.GetButtonDown("Fire");
    }
    void Deshs()
    {
        deshCool += Time.deltaTime;
        if(deshCool >= curDeshCool)
        {
            desh = true;
            deshCool = curDeshCool;
        }
        if (desh)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                animator.SetTrigger("isDesh");
                //DeshCool = 0;
                isDeshInvincible = true;
            }
        }
    }
    void Attack()
    {
        fireDelay += Time.deltaTime;
        isFireReady = weapons.rate < fireDelay;

        if (isAttack && isFireReady)
        {
            weapons.WeaponUse();
            animator.SetTrigger("Attack");
            fireDelay = 0;
        }
        if(isAttack1)
        {
            isAttack3 = false;
            if(Input.GetMouseButtonDown(1))
            {
                animator.SetTrigger("Smash1");
                isAttack1 = false;
            }
        }
        if(isAttack2)
        {
            isAttack1 = false;
            if(Input.GetMouseButtonDown(1))
            {
                animator.SetTrigger("Smash2");
                isAttack2 = false;
            }
        }
        if(isAttack3)
        {
            isAttack2 = false;
            if(Input.GetMouseButtonDown(1))
            {
                animator.SetTrigger("Smash3");
                isAttack3 = false;
            }
        }
    }


    public void Death()
    {

        if (stateManager.hp <= 0)
        {
            isDeath = true;
            characterController.enabled = false;
            StartCoroutine(DeathDelay());
        }

    }

    IEnumerator DeathDelay()
    {
        animator.SetTrigger("isDeath");
        yield return null;
    }
    void SkillOn()
    {
        qskillcool += Time.deltaTime; 

        if (qskillcool >= curQskillcool)
        {
            qskillcool = curQskillcool;
            qisReady = true;
        }
            
        eskillcool += Time.deltaTime;

        if (eskillcool >= curEskillcool)
        {
            eskillcool = curEskillcool;
            eisReady = true;
        }
        rskillcool += Time.deltaTime;

        if (rskillcool >= curRskillcool)
        {
            rskillcool = curRskillcool;
            risReady = true;
        }

        if(qisReady)
        {
            if (Input.GetKeyDown(KeyCode.Q))
            {
                animator.SetTrigger("SkillQ");
                qskillcool = 0;
                qisReady = false;
            }
        }

        if(eisReady)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetTrigger("SkillE");
                eskillcool = 0;
                eisReady = false;
            }
        }
        
        if(risReady)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                animator.SetTrigger("SkillR");
                rskillcool = 0;
                risReady = false;
            }
        }
    }
   

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("DownPattern"))
        {
            if (isDeshInvincible == true)
                return;

            animator.SetTrigger("Down");
        }

        if (other.CompareTag("SaveZone"))
        {
            isDeshInvincible = true;
        }
    }

    void Die()
    {
        isDeath = true;
    }
    void Downing()
    {
        downing = true;
    }

    void StandUp()
    {
        downing = false;
    }
    void SkillOneAttack()
    {
        GameObject obj;

        obj = Instantiate(skillOneEffect, targetPlayer.position, targetPlayer.rotation);

        Destroy(obj, 2f);
    }
    void Skill_Q()
    {
        GameObject obj;

        obj = Instantiate(skillQ, targetPlayer.position, targetPlayer.rotation);
        obj.GetComponent<WeaponsAttribute>().sm = transform.GetComponent<StateManager>();
        Destroy(obj, 2f);
    }
    void Skill_E()
    {
        GameObject obj;

        obj = Instantiate(skillE, targetPlayer.position, targetPlayer.rotation);
        obj.GetComponent<WeaponsAttribute>().sm = transform.GetComponent<StateManager>();
        Destroy(obj, 2f);
    }

    void Skill_R()
    {
        GameObject obj;

        obj = Instantiate(skillR, targetPlayer.position, targetPlayer.rotation);
        obj.GetComponent<WeaponsAttribute>().sm = transform.GetComponent<StateManager>();
        Destroy(obj, 2f);

    }

    void Skill_QLoding()
    {
        GameObject obj;

        obj = Instantiate(skillLoding, targetPlayer.position, targetPlayer.rotation);

        Destroy(obj, 2f);
    }

    public void SlidingUse()
    {
        characterController.enabled = false;
    }

    public void SlidingEnd()
    {
        characterController.enabled = true;
    }
}
