using UnityEngine;
using System.Collections;

public class Collectable : MonoBehaviour {
    

    void Show()
    {
        this.GetComponent<SpriteRenderer>().enabled = true;
        this.GetComponent<CircleCollider2D>().enabled = true;
    }

    void Hide()
    {
        this.GetComponent<SpriteRenderer>().enabled = false;
        this.GetComponent<CircleCollider2D>().enabled = false;
    }

    void Collect()
    {
        Hide();
        GameManager.instance.CollectedCoin();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
            Collect();
    }
}
