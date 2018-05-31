using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoxControl : MonoBehaviour {

	Random _random = new Random();

	public GameObject[] boxs;

	public int[] boxValue;

	public int rand;

	public int[] randomLetter = new int[correctLetter.Length + 3];

	public char[] ansW ;

	public Sprite[] letter ;

	SpriteRenderer sr;

	const int ADDEDRANDOMLETTER = 3;
    public static int[] correctLetter = new int[] { 'c', 'a', 't' };

	public Sprite[] boxArray;
	// Use this for initialization
	void Start () {
		sr = gameObject.GetComponent<SpriteRenderer>();
		randomizeLetter();
	
		int size = boxs.Length;

		int a = randomLetter.Length;
		randomLetter = Shuffle(randomLetter);
		boxValue = new int[boxs.Length];
		int i = 0;
		while(i != size){
			for(int j = 0 ; j < a && i < size; j++){
				put(i,randomLetter[j]);
				boxValue[i]=randomLetter[j];
				boxs[i].GetComponent<AnswerBox>().ans = randomLetter[j];
				i++;
			}
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public T[] Shuffle<T>(T[] array)
	{
		for (int i = array.Length; i > 1; i--)
		{
			// Pick random element to swap.
			int j = Random.Range(0,array.Length-1); // 0 <= j <= i-1

			// Swap.
			T tmp = array[j];
			array[j] = array[i - 1];
			array[i - 1] = tmp;
		}
		return array;
	}


	void put(int index,int value){
		boxs[index].GetComponent<SpriteRenderer>().sprite = letter[value];
	}

	void randomizeLetter(){
        for (int i = 0; i < randomLetter.Length - 1 ;i++)
        {
            if (i < ansW.Length){
                randomLetter[i] = ansW[i] - 'a';
            }
            else{
                int ran = Random.Range(0, 25);
                randomLetter[i] = ran;
            }
        }
    }
}
