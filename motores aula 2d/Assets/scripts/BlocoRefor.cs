using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlocoRefor : MonoBehaviour
{
    public int hp = 3;

    private SpriteRenderer renderer;
    // Start is called before the first frame update
    void Start()
    {
        TryGetComponent(out renderer);
    }

    public void TomouHit()
    {
        hp--;
        renderer.color *= 1.5f;
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }

    
}
