using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class TopDownController : MonoBehaviour
{
    public Rigidbody2D body;
    public SpriteRenderer spriteRenderer;
    public List<Sprite> nSprites;
    public List<Sprite> nwSprites;
    public List<Sprite> neSprites;
    public List<Sprite> sSprites;
    public List<Sprite> swSprites;
    public List<Sprite> seSprites;
    public List<Sprite> wSprites;
    public List<Sprite> eSprites;

    public float walkspeed;
    public float frameRate;
    float idleTime;

    Vector2 direction;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        direction = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).normalized;
        body.velocity = direction * walkspeed;

        HandleSpriteFlip();

        List<Sprite> directionSprites = getSpriteDirection();
        if (directionSprites != null)
        {
            float playTime = Time.time - idleTime;
            int totalframes = (int)(playTime * frameRate);
            int frame = totalframes % directionSprites.Count;
            spriteRenderer.sprite = directionSprites[frame];
        } else
        {
            idleTime = Time.time;
        }
    }

    void HandleSpriteFlip()
    {
        if (!spriteRenderer.flipX && direction.x < 0)
        {
            spriteRenderer.flipX = true;
        }
        else if (spriteRenderer.flipX && direction.x > 0)
        {
            spriteRenderer.flipX = false;
        }
    }

    List<Sprite> getSpriteDirection()
    {
        List<Sprite> selectedSprites = null;

        if (direction.y > 0)
        {
            if (Mathf.Abs(direction.x) > 0)
            {
                selectedSprites = neSprites;
            } else {
                selectedSprites = nSprites;
            }

        } else if (direction.y < 0)
        {
            if (Mathf.Abs(direction.x) > 0)
            {
                selectedSprites = seSprites;
            } else
            {
                selectedSprites = sSprites;
            }
        }
        else
        {
            if(Mathf.Abs(direction.x) > 0)
            {
                selectedSprites = eSprites;
            }
        }
        return selectedSprites;
    }
}
