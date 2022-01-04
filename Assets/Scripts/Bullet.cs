using UnityEngine;

public class Bullet : MonoBehaviour
{
    private void Update()
    {
        Vector3 fillingArea = Camera.main.ViewportToWorldPoint(Camera.main.transform.position);

        Vector3 pos = transform.position;
        
        if (pos.x > Mathf.Abs(fillingArea.x) ||(pos.x < -Mathf.Abs(fillingArea.x)) ||  (pos.y > Mathf.Abs(fillingArea.y)) ||  (pos.y < -Mathf.Abs(fillingArea.y))) Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.tag.Equals("Meteor"))
        {
            other.gameObject.GetComponent<Meteor>().TakeDamage();
            Destroy(gameObject);
        }
    }
}
