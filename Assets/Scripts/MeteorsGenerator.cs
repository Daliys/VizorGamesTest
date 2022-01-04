using UnityEngine;

public class MeteorsGenerator : MonoBehaviour
{
    [SerializeField] private GameObject[] meteorPrefabs;
    
    void Start()
    {
        for (int i = 0; i < 12; i++)
        {
         GenerateNewMeteor();  
        }
    }

    public void GenerateNewMeteor()
    {
        Vector3 fillingArea = Camera.main.ViewportToWorldPoint(Camera.main.transform.position);
        fillingArea.x = Mathf.Abs(fillingArea.x);
        fillingArea.y = Mathf.Abs(fillingArea.y);
        
        GameObject gm = Instantiate(meteorPrefabs[Random.Range(0, meteorPrefabs.Length)], transform, true);
        gm.transform.position = GetRandomPosition(fillingArea);
        gm.GetComponent<Rigidbody2D>().AddForce(new Vector2(Random.Range(-1f,1), Random.Range(-1f,1f)) * 100);
        gm.GetComponent<Meteor>().Initialization(this);
    }

    private Vector3 GetRandomPosition(Vector3 fillingArea)
    {
       Vector3 pos = new Vector3(Random.Range(-fillingArea.x, fillingArea.x), Random.Range(-fillingArea.y, fillingArea.y));
       if (Vector2.Distance(GameManager.Instance.Player.transform.position, pos) < 3) GetRandomPosition(fillingArea);
       return pos;
    }
    
}
