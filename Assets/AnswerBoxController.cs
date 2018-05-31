using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AnswerBoxController : MonoBehaviour {

    public AnswerBox[] ab;

	public Sprite[] letter ;


	void put(int index){Debug.Log(index);
		ab[index].GetComponent<Image>().sprite = letter[ab[index].ans];
	}
	
	int count = 0;
    public void checkLetter(int value)
    {
		int c=0;
        for (int i = 0; i < ab.Length; i++)
        {
            if (ab[i].ans == value)
            {
				if(ab[i].isFill == false){	
				put(i);				
				count++;
				ab[i].isFill = true;
				}
				c = 1;
				if(count == ab.Length){
					
					new GameObject().AddComponent<GoPrePlayScene>();
					Debug.Log("WINNNNNNNN");
				}
            }

        }
		if(c==0){
			UIController.decreaseTime();
		}
    }
}
