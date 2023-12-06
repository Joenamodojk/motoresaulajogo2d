using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallController : MonoBehaviour
{
    private Rigidbody2D rb;

    public Vector2 direcao;

    public int velocidade;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out rb);
        direcao = Random.insideUnitCircle;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Bloco"))
        {
            Destroy(collision.gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 direcaoJogador = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            direcao = direcao + direcaoJogador;
        }
        direcao = Vector2.Reflect(direcao, collision.contacts[0].normal);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = direcao.normalized * velocidade;
    }
}
