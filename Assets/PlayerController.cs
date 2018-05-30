using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    Rigidbody2D rb2d;

    Animator anim;

    SpriteRenderer sr;

    public int life = 3;
    bool isColi = false;
    bool isCrossLine = false;

    private Sprite currentSprite;

	public GameObject GOUI;
    float nextImmortalTime = 0f;

    // Use this for initialization
    void Start()
    {
        rb2d = gameObject.GetComponent<Rigidbody2D>();
        sr = gameObject.GetComponent<SpriteRenderer>();
        anim = GetComponent<Animator>();
        currentSprite = sr.sprite;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * 0.2f);
        // Jumping
        if (Input.GetKey(KeyCode.UpArrow) && isColi)
        {
            rb2d.velocity = new Vector2(0, 19);
        }

        if (Input.GetKey(KeyCode.DownArrow) && isColi){
            anim.SetBool("isSlide", true);
		}

        if (Input.GetKeyUp(KeyCode.DownArrow))
            anim.SetBool("isSlide", false);

        if (!currentSprite.Equals(sr.sprite))
        {
            Destroy(GetComponent<PolygonCollider2D>());
            gameObject.AddComponent<PolygonCollider2D>();
			currentSprite = sr.sprite;
        }

		if (life <= 0)
        {
            Die();
        }


    }


    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            isColi = true;
        }

        if (other.gameObject.CompareTag("wall"))
        {
            life -= 1;
	        
        }

        if (other.gameObject.CompareTag("ravine"))
        {
            Debug.Log("DEAD");
            Die();
        }

    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
            isColi = false;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!isImmortal())
        {
            if (other.gameObject.CompareTag("wall"))
            {
                life = life - 1;
                nextImmortalTime = 10;
                Debug.Log("Hit wall---life: " + life);
            }
        }
        if (other.gameObject.CompareTag("item"))
        {
            Debug.Log("INNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNNN");
            other.GetComponent<Item>().getItem(this);
            Destroy(other.gameObject);

        }
    }

  public void Die()
    {
        // if (gameObject.Equals(null))
        // {
            Destroy(gameObject);
        // }
        Time.timeScale = 0.0f;

		Instantiate(GOUI);

    }

    public void setLife(int life)
    {
        this.life += life;
    }
    public void setNextImmortalTime(float t)
    {
        nextImmortalTime = Time.time + t;
    }
    public bool isImmortal()
    {
        if (nextImmortalTime > Time.time)
            return true;
        return false;
    }
}
