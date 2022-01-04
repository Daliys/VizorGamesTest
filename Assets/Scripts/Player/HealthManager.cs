using System.Collections;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    private int currentHealth;
    [SerializeField] private GameObject crushedShip;
    
    void Start()
    {
        currentHealth = 3;
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag.Equals("Meteor"))
        {
            other.gameObject.GetComponent<Meteor>().Destroy();
            currentHealth--;
            UI.Instance.UpdateHealth(currentHealth);
            StartCoroutine(TakeDamageShowVisible());
            if (currentHealth <= 0)
            {
                GameManager.Instance.GameOver();
            }
        }
    }

    IEnumerator TakeDamageShowVisible()
    {
        if (currentHealth <= 0)
        {
            GenerateShipShards();
            yield return null;
        }
        
        gameObject.GetComponent<SpriteRenderer>().color = Color.red;
        yield return new WaitForSecondsRealtime(0.25f); 
        gameObject.GetComponent<SpriteRenderer>().color = Color.white;
    }

    private void GenerateShipShards()
    {
        GameObject gm = Instantiate(crushedShip);
        gm.transform.position = transform.position;
        for (int i = 0; i < gm.transform.childCount; i++)
        {
            gm.transform.GetChild(i).gameObject.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f,1), Random.Range(-1f,1f)) * 40);
        }
        
        gameObject.SetActive(false);
    }
}
