using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] private GameObject laserPrefab;
   
    void Update()
    {
        if(GameManager.Instance.IsGameOver) return;
        
        if (Input.GetButtonDown("Fire1"))
        {
            GenerateLaser();
        }
    }

    private void GenerateLaser()
    {
        GameObject gm = Instantiate(laserPrefab);
        gm.transform.position = transform.position;
        gm.transform.rotation = transform.rotation;
        gm.GetComponent<Rigidbody2D>().AddForce(transform.up * 700);
    }
    
}
