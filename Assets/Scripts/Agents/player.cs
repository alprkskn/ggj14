using UnityEngine;
using System.Collections.Generic;


public class player : MonoBehaviour {
    SkeletonAnimation skeletonAnimation;
    public float speed = 3.0f;
    public float specialSpeedConst = 1.0f;
    public float jumpSpeed = 5.0f;
    public float specialJumpConst = 1.0f;
    public bool directionForward = true;
    public inventory inventory;
    
	public enum DrugEnums
    {
        LSD,
        Smoke,
        Mushroom,
        Vodka
    };
    public List<DrugEnums> drugList;
    public List<float> drugTime;
    public double toxicity = 0.00;
    
    void Start()
    {
        drugList = new List<DrugEnums>();
        drugTime = new List<float>();
        drugTime.Add(0);
        drugTime.Add(0);
        drugTime.Add(0);
        drugTime.Add(0);
        skeletonAnimation = GetComponent<SkeletonAnimation>();
    }

    void Update()
    {
        
        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            rigidbody.velocity = new Vector3(speed * specialSpeedConst, rigidbody.velocity.y, (int)rigidbody.velocity.z);
            //skeletonAnimation.animationName = "walk";
            directionForward = true;
        }
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            rigidbody.velocity = new Vector3(-speed * specialSpeedConst, rigidbody.velocity.y, (int)rigidbody.velocity.z);
            //skeletonAnimation.animationName = "sex bomb";
            directionForward = false;
        }
        if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
        {
            rigidbody.velocity = new Vector3((int)rigidbody.velocity.x, rigidbody.velocity.y, speed * specialSpeedConst);
            //if (directionForward)
                //skeletonAnimation.animationName = "walk";
            //else
                //skeletonAnimation.animationName = "sex bomb";
        }
        if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
        {
            rigidbody.velocity = new Vector3((int)rigidbody.velocity.x, rigidbody.velocity.y, -speed * specialSpeedConst);
            //if (directionForward)
                //skeletonAnimation.animationName = "walk";
            //else
                //skeletonAnimation.animationName = "sex bomb";
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if ((int)rigidbody.velocity.y == 0)
            {
                rigidbody.velocity = new Vector3((int)rigidbody.velocity.x, jumpSpeed * specialJumpConst, (int)rigidbody.velocity.z);
                //skeletonAnimation.animationName = "jump";
            }
        }
        if (Input.GetKeyUp(KeyCode.Q) || Input.GetKeyUp(KeyCode.RightShift))
        {
            //interactions
            // if sandik or kapi or window then open it
        }
        if (Input.GetKeyUp(KeyCode.E) || Input.GetKeyUp(KeyCode.RightControl))
        {
            //interactions
            // if you can take smt then take it
        }

        /* Timer for drugs effect time */
        for (int i = 0; i < 3; i++)
        {
            if (drugTime[i] > Time.deltaTime)
            {
                drugTime[i] -= Time.deltaTime;
            }
            else
            {
                drugTime[i] = 0.0f;
            }
        }

        /*Toxicity level control*/
        if (toxicity >= 100)
        {
            print("Bad Trick");
        }
    }

    /* Check consumed drug and update toxicity level, add it into the drugList, and set the timer for that drug. */
    public void consumeMeth(object meth)
    {

        if(meth.GetType().ToString().CompareTo("LSD") == 0)
        {
            LSD consumedLSD = (LSD)meth;
            toxicity += Random.Range(consumedLSD.minToxicityLevel, consumedLSD.maxToxicityLevel);
            drugList.Add(DrugEnums.LSD);
            drugTime[(int)DrugEnums.LSD] += 7.0f - (float)(drugTime[(int)DrugEnums.LSD] * 0.5);
			SceneManager.Instance.revealObjects(player.DrugEnums.LSD);
        }

        else if (meth.GetType().ToString().CompareTo("smoke") == 0)
        {
            smoke consumedSmoke = (smoke)meth;
            toxicity += Random.Range(consumedSmoke.minToxicityLevel, consumedSmoke.maxToxicityLevel);
            drugList.Add(DrugEnums.Smoke);
            drugTime[(int)DrugEnums.Smoke] += 5.0f - (float)(drugTime[(int)DrugEnums.Smoke]*0.5);
			SceneManager.Instance.revealObjects(player.DrugEnums.Smoke);
        }

        else if (meth.GetType().ToString().CompareTo("mushroom") == 0)
        {
            mushroom consumedMushroom = (mushroom)meth;
            toxicity += Random.Range(consumedMushroom.minToxicityLevel, consumedMushroom.maxToxicityLevel);
            drugList.Add(DrugEnums.Mushroom);
            drugTime[(int)DrugEnums.Mushroom] += 6.0f - (float)(drugTime[(int)DrugEnums.Mushroom] * 0.5);
			SceneManager.Instance.revealObjects(player.DrugEnums.Mushroom);
        }

        else if (meth.GetType().ToString().CompareTo("vodka") == 0)
        {
            vodka consumedVodka = (vodka)meth;
            toxicity += Random.Range(consumedVodka.minToxicityLevel, consumedVodka.maxToxicityLevel);
            drugList.Add(DrugEnums.Vodka);
            drugTime[(int)DrugEnums.Vodka] += 5.0f - (float)(drugTime[(int)DrugEnums.Vodka] * 0.5);
			SceneManager.Instance.revealObjects(player.DrugEnums.Vodka);
        }
    }
}
