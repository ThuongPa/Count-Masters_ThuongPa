using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossManager : MonoBehaviour
{
    [Header("Boss Settings")]
    [SerializeField] private float bossHealth=35;
    [SerializeField] public float currenthealth;
    [SerializeField] private Image sliderimage;
    [SerializeField] private float fillamount;
    public static BossManager bossManagerInstance;
    public Animator animator;
    public bool isbossdead;

   
    
    
    void Start()
    {
        currenthealth=bossHealth;
        sliderimage = transform.parent.GetChild(1).GetChild(0).GetChild(0).GetComponent<Image>();
        bossManagerInstance=this;
       
    }

    
    void Update()
    {
        fillamount=(currenthealth / bossHealth);
        sliderimage.fillAmount = fillamount;

        if (fillamount < 0.01f)
        {
            
        }

        StartCoroutine(BossRun());

        if (currenthealth < 1)
        {
            isbossdead = true;

            PlayerManager.PlayerManagerInstance.roadSpeed=0;

           
            GetComponent<BoxCollider>().enabled=false;
            transform.parent.GetChild(2).GetChild(1).transform.gameObject.SetActive(false);
            animator.SetTrigger("BossDead");

        }else
        {
            isbossdead=false;
        }

        
        
    }

    public void BossGetDamage()
    {
        currenthealth = currenthealth -1;
       
    }

   IEnumerator BossRun()
   {
        if(PlayerManager.PlayerManagerInstance.bosszone && PlayerManager.PlayerManagerInstance.numberofstickman > 0)
        {
            animator.SetBool("StartRun",true);
            yield return new WaitForSeconds(1f);
            animator.SetBool("IsBossAttacking",true);
        }
        else
        {
            animator.SetBool("StartRun", false);
            animator.SetBool("IsBossAttacking",false);
            
            
            
        
        }
   }

    
}
