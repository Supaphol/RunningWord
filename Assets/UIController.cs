using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIController : MonoBehaviour
{
    public float baseTime = 10.5f;
    public Text timer;
	public Text lifeRemaining;

    public GameObject lifeItemCanvas;
    public GameObject timeItemCanvas;
    public GameObject immortalItemCanvas;

    public float remainingTime;

    static public float startTime;
    public PlayerController player;
    private float pickupItemTime  = 0;

    private bool isPickUpItem = false;
    public int[] correctLetter ;

    void Start()
    {
        player = FindObjectOfType<PlayerController>();
        startTime = Time.time;
    }

    void Update()
    {
		if(player == null) return;

        remainingTime = (int)(baseTime - Time.time + startTime);

		lifeRemaining.text = "X " + player.life ;

        if (remainingTime >= 1 )
        {
            timer.text = "" + remainingTime;
        }
        else
        {
            remainingTime = (int)(baseTime - Time.time + startTime);
            timer.text = "" + remainingTime;
            player.Die();
			
        }
    }
    public void setRemainingTime(int time)
    {
        startTime = startTime + time;
    }

    public void showItemIcon(int itemNum){
        if(itemNum ==1){
            GameObject item = (GameObject)Instantiate(lifeItemCanvas);
            Destroy(item,1);
        }
        if(itemNum ==2){
            GameObject item = (GameObject)Instantiate(immortalItemCanvas);
            Destroy(item,9f);
        }
        if(itemNum ==3){
            GameObject item = (GameObject)Instantiate(timeItemCanvas);
            Destroy(item,1);
        }
    }

    static public void decreaseTime(){
       startTime -=10;
    }

}
