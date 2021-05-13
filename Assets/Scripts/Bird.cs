using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    [SerializeField] float _launchForce = 500;
    public float maxdragforce = 5;
    Vector2 _startPosition;
    Rigidbody2D  _rigidbody2D;
    SpriteRenderer _spriteRenderer;

    // Start is called before the first frame update
    void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Start()
    {
        _startPosition = _rigidbody2D.position;
        _rigidbody2D.isKinematic = true;
        
    }

    void OnMouseDown(){
        _spriteRenderer.color= Color.red;
    }

    void OnMouseUp(){
        Vector2 currentPosition =_rigidbody2D.position;
        Vector2 direction = _startPosition - currentPosition;
        direction.Normalize();
       _rigidbody2D.isKinematic = false;
       _rigidbody2D.AddForce(direction * _launchForce);
       _spriteRenderer.color= Color.white;
    }

    void OnMouseDrag(){
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            Vector2 desiredPosition = mousePosition;

            float distance = Vector2.Distance(desiredPosition, _startPosition);

            if(distance > maxdragforce )
            {
                Vector2 dist = desiredPosition - _startPosition;
                dist.Normalize();

                desiredPosition = _startPosition + (dist * maxdragforce);
            }
            if(desiredPosition.x > mousePosition.x){
                desiredPosition.x = mousePosition.x;

            }
            _rigidbody2D.position = desiredPosition;
    }


        
            



    // Update is called once per frame
    void Update()
    {
        
    }


    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("hit");
        StartCoroutine(ResetAfterDelay(3));
        // yield return new WaitForSeconds(3);
        // _rigidbody2D.position = _startPosition;
        // _rigidbody2D.isKinematic = true;
        // _rigidbody2D.velocity = Vector2.zero;
    }

    IEnumerator ResetAfterDelay(int delay)
    {
        yield return new WaitForSeconds(delay);
        _rigidbody2D.position = _startPosition;
        _rigidbody2D.isKinematic = true;
        _rigidbody2D.velocity = Vector2.zero;
    }

    
}
