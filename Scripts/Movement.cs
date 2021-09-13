using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class Movement : MonoBehaviour
{
    
    public static bool isAlive = true;
    
    [Header("CarLocation")]
    [SerializeField]
    float[] track = new float[3]  { 2, 0, 1 };

    [Header("Speeds")]
    public CinemachineDollyCart dolly;
    public float mini_Speed;
    public float maxBoost;
    public float Boost;
    public bool isBoosting = false;
    // public bool isBreak;
    public float h,v;


    void Start()
    {
        isAlive = true;
        // set starting location
        transform.localPosition = new Vector3(track[0], track[1], track[2]);
       
       
    }

    // Update is called once per frame
    void Update()
    {       
        if(isAlive)
        {

            h = Input.GetAxis("Horizontal");
            v = Input.GetAxis("Vertical");
            // update x axis
            //transform.localPosition = transform.right * track[0];
            transform.localPosition = new Vector3(track[0], track[1], 0);
            // StartCoroutine(delayPerSec());     // for delay
            inputPC();  
        }
              
    }


    

    public void SetBoostOn()
    {
        isBoosting = true;      
        
    }
    public void SetBoostOff()
    {
        isBoosting = false;        
    }   
/*
    public void FiringOn()
    {
        Debug.Log("firing on");
    }

    public void FiringOff()
    {
        Debug.LogFormat("off Firing");
    }
    */
    void inputPC()
    {
        
        //transform.localPosition = new Vector3(track[0], track[1], track[2]); // here I don't want to change value of (z Axis)track[2]
       if( h != 0)
        {

            if(Input.GetKeyDown(KeyCode.D) )
            {
                //moving right..
                moveRight();

            }
            else if(Input.GetKeyDown(KeyCode.A) )
            {
                //moving left..
                moveLeft();

            }
        }
        
/*
        // start and stop firing(INPUT)
            if(Input.GetKey(KeyCode.Space) )
            {               
                FiringOn();
            }
            else if(Input.GetKeyUp(KeyCode.Space) )
            {          
                FiringOff();
            } 
            
*/
        // start and stop boosting(INPUT)
            if(Input.GetKeyDown(KeyCode.W)  && isBoosting == false)
            {
               
                SetBoostOn();
            }
            else if(Input.GetKeyUp(KeyCode.W) && isBoosting == true)
            {          
                SetBoostOff();
            } 

        if(isBoosting)
        {
            if(dolly.m_Speed < maxBoost)
                dolly.m_Speed = dolly.m_Speed*Boost;
            else if(dolly.m_Speed > maxBoost)
                dolly.m_Speed = maxBoost;
            // Debug.Log("Boosting..... and curentSpeed : " + dolly.m_Speed);
        }
        else if(!isBoosting)
        {
            if(dolly.m_Speed <= mini_Speed)
                dolly.m_Speed = mini_Speed;                    
            else if(dolly.m_Speed > mini_Speed)
                dolly.m_Speed = dolly.m_Speed/Boost;   
            // Debug.Log("BOst STOP and CurrentSpeed :" + dolly.m_Speed); 
        }
    }

    public void moveRight()
    {
        track[0] += 1f;
    }

    public void moveLeft()
    {
        track[0] -= 1f;
    }
}
