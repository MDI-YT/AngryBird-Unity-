using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[SelectionBase]
public class Monster : MonoBehaviour
{
    
    public Sprite _deadSprite;

    public ParticleSystem _particleSystem;

    bool _hasDied;

    // Start is called before the first frame update

    // IEnumerator ResetAfterDelay(int delay)
    // {
    //     yield return new WaitForSeconds(delay);
    //     Dead();
    // }
    // void Dead()
    // {
        
    //     gameObject.SetActive(false);
        
    // }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if(ShouldIDie(collision))
        {
            StartCoroutine(Die());
        }
    }
  

    bool ShouldIDie(Collision2D collision)
    {
        if(_hasDied)
        return false;

        Bird bird = collision.gameObject.GetComponent<Bird>();
        if (bird != null)
        {
            return true;

        }
        if(collision.contacts[0].normal.y < -0.5)
        {
            return true;
        }
            
        return false;
    }

    IEnumerator Die()
    {
        _hasDied = true;
        GetComponent<SpriteRenderer>().sprite = _deadSprite;
        _particleSystem.Play();
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }
}
