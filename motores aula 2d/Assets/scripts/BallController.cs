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
        direcao = Random.insideUnitCircle.normalized;
        direcao = new Vector2(direcao.x, 1).normalized;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.CompareTag("Bloco"))
        {
            Destroy(collision.gameObject);
        }
        
        
        if (collision.gameObject.CompareTag("RefB"))
        {
           collision.gameObject.GetComponent<BlocoRefor>().TomouHit();
        }
        
        if (collision.gameObject.CompareTag("DangerZone"))
        {
            GameManager.instance.GameOver();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("Player"))
        {
            Vector2 direcaoJogador = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            direcao = direcao + direcaoJogador;
        }

        if (collision.contacts.Length == 1)
        {
            direcao = Vector2.Reflect(direcao, collision.contacts[0].normal);
        }
        else
        {
            Vector2 normalMedia = Vector2.zero;
            foreach (var ponto in collision.contacts)
            {
                direcao = (normalMedia + ponto.normal) / 2;
            }
        }
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rb.velocity = direcao.normalized * velocidade;
    }
}
