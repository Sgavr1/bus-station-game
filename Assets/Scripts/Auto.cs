using UnityEngine;
using UnityEngineInternal;

public class Auto : MonoBehaviour
{
    public ParametrAuto parametr;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.bodyType = RigidbodyType2D.Static;
        sr = GetComponentInChildren<SpriteRenderer>();

        sr.color = parametr.color;
    }

    public bool Run()
    {
        RaycastHit2D[] hit = Physics2D.RaycastAll(transform.position, parametr.direction);

        if(hit.Length > 1)
        {
            return false;
        }

        rb.bodyType = RigidbodyType2D.Dynamic;

        rb.linearVelocity = parametr.direction * 4;

        hit[0].collider.enabled = false;

        Destroy(gameObject, 10);

        return true;
    }
}
