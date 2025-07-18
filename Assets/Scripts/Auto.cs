using UnityEngine;

public class Auto : MonoBehaviour
{
    public ParametrAuto parametr;

    private Rigidbody2D rb;
    private SpriteRenderer sr;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponentInChildren<SpriteRenderer>();

        sr.color = parametr.color;
    }
}
