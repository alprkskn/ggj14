using UnityEngine;
using System.Collections.Generic;


public class player : MonoBehaviour {
    SkeletonAnimation skeletonAnimation;
    public float speed = 3.0f;
    public float specialSpeedConst = 1.0f;
    public float jumpSpeed = 5.0f;
    public float specialJumpConst = 1.0f;
    public bool directionForward = true;
	public Dictionary<player.DrugEnums, int> inventory;
    
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
    
	void Awake()
	{
		inventory = new Dictionary<player.DrugEnums, int>();
	}
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
        //foreach(KeyValuePair<DrugEnums, int> pair in inventory) {
		//	Debug.Log ("zaaa: " + pair.Key + " - " + pair.Value);
		//}
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
        if (Input.GetKeyDown(KeyCode.E) || Input.GetKeyDown(KeyCode.RightControl))
        {
            //interactions
            // if you can take smt then take it
			interact();
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

	private void takeItemFrom(InteractObject obj) {
		foreach(player.DrugEnums drug in obj.getItems()) {
			if(!inventory.ContainsKey(drug))
				inventory.Add(drug, 0);

			inventory[drug]++;
		}
	}

	private bool useItem(player.DrugEnums drug) {
		if(inventory.ContainsKey(drug))
		{
			if(inventory[drug] > 0) {
				consumeMeth(drug);
				inventory[drug]--;
				return true;
			}
		}

		return false;
	}

	void OnTriggerEnter(Collider c) {
		Debug.Log(c.tag);
		if(c.tag == "Key")
		{
			SceneManager.Instance.currentKeys++;
			c.gameObject.SetActive(false);
			Destroy(c.gameObject);
		}
	}

	private void interact() {
		Collider[] objList = Physics.OverlapSphere(transform.position, 2f);
		foreach(Collider c in objList)
		{
			if(c.tag == "Interact")
			{
				if(c.name == "window")
				{
					if(toxicity > 50)
						toxicity = 50;
				}
				else if(c.name == "chest")
				{
					takeItemFrom(c.gameObject.GetComponent<InteractObject>());
					Debug.Log("took");
				}
				else if(c.name == "merdiven")
				{
					c.gameObject.GetComponent<InteractObject>().teleportPlayer(transform);
				}

			}	
		}
	}

    /* Check consumed drug and update toxicity level, add it into the drugList, and set the timer for that drug. */
    public void consumeMeth(DrugEnums drug)
    {

		if(drug == DrugEnums.LSD)
        {
            toxicity += Random.Range(35, 45);
            drugList.Add(DrugEnums.LSD);
            drugTime[(int)DrugEnums.LSD] += 7.0f - (float)(drugTime[(int)DrugEnums.LSD] * 0.5);
			SceneManager.Instance.revealObjects(player.DrugEnums.LSD);
        }

		else if(drug == DrugEnums.Smoke)
        {
            toxicity += Random.Range(20, 30);
            drugList.Add(DrugEnums.Smoke);
            drugTime[(int)DrugEnums.Smoke] += 5.0f - (float)(drugTime[(int)DrugEnums.Smoke]*0.5);
			SceneManager.Instance.revealObjects(player.DrugEnums.Smoke);
        }

		else if(drug == DrugEnums.Mushroom)
        {
            toxicity += Random.Range(30, 40);
            drugList.Add(DrugEnums.Mushroom);
            drugTime[(int)DrugEnums.Mushroom] += 6.0f - (float)(drugTime[(int)DrugEnums.Mushroom] * 0.5);
			SceneManager.Instance.revealObjects(player.DrugEnums.Mushroom);
        }

		else if(drug == DrugEnums.Vodka)
        {
            toxicity += Random.Range(10, 20);
            drugList.Add(DrugEnums.Vodka);
            drugTime[(int)DrugEnums.Vodka] += 5.0f - (float)(drugTime[(int)DrugEnums.Vodka] * 0.5);
			SceneManager.Instance.revealObjects(player.DrugEnums.Vodka);
        }
    }
}
