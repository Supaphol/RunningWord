using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ArrayIntToBox : MonoBehaviour {


	public Sprite[] letter ;
	SpriteRenderer sr;

	public int[] array ;

	public GameObject ans;

	public PlayerController pc;

	public int rand;

	public int[] randomLetter = new int[correctLetter.Length + ADDEDRANDOMLETTER];
	// Use this for initialization
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer>();
		pc = FindObjectOfType<PlayerController>();
		randomizeLetter();
		array = randomLetter;
		int size = array.Length ;
		rand = Random.Range(0,size-1);
		put(array[rand]);
	}
	// Update is called once per frame
	
	int[] DoRandom(int amount){
		int[] temp = new int[amount];
		for(int i =0 ;i<amount;i++){
			temp[i] = Random.Range(1,26);
		}
		return temp;
	}


    public int ansValue;
    bool isFill = false;

	public bool isAnswer(int num)
    {
		for(int i = 0 ; i < correctLetter.Length;i++){
			if(num == (int)(correctLetter[i] -'a')){

				return true;
			}
		}
		return false;

        // if (num == ansValue && !isFill)
        // {
        //     isFill = true;
        //     // change sprite
        //     return true;
        // }
        // return false;
    }

    const int ADDEDRANDOMLETTER = 3;
    public static int[] correctLetter = new int[] { 'c', 'a', 't' };
    
    void randomizeLetter()
    {
        for (int i = 0; i < randomLetter.Length - 1; i++)
        {
            // initialize correct letter to random letter Array
            if (i < correctLetter.Length)
            {
                randomLetter[i] = correctLetter[i] - 'a';
            }
            else
            {
                int ran = Random.Range(97, 122);
                randomLetter[i] = ran - 'a';

        //         Debug.Log(randomLetter[i]);
            }
        }

        // Debug.Log("=========================================================================================");
        // for(int i = 0; i < randomLetter.Length - 1; i++){
        //     Debug.Log(randomLetter[i]);
        // }
    }
	void put(int value){
		ans.GetComponent<SpriteRenderer>().sprite = letter[value];
	}

}
