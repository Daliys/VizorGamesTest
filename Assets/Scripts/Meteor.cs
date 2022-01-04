using UnityEngine;

public class Meteor : MonoBehaviour
{
    private MeteorsGenerator _meteorsGenerator;

    public void Initialization(MeteorsGenerator meteorsGenerator)
    {
        _meteorsGenerator = meteorsGenerator;
    }

    void Update()
    {
        BorderCheck();
    }

    public void TakeDamage()
    {
        GameManager.Instance.AddGameScore(25);
        Destroy();
    }
    
    private void BorderCheck()
    {
        Vector3 fillingArea = Camera.main.ViewportToWorldPoint(Camera.main.transform.position);

        Vector3 pos = transform.position;
        if (pos.x > Mathf.Abs(fillingArea.x)) pos.x = -Mathf.Abs(fillingArea.x);
        if (pos.x < -Mathf.Abs(fillingArea.x)) pos.x = Mathf.Abs(fillingArea.x);
        if (pos.y > Mathf.Abs(fillingArea.y)) pos.y = -Mathf.Abs(fillingArea.y);
        if (pos.y < -Mathf.Abs(fillingArea.y)) pos.y = Mathf.Abs(fillingArea.y);

        transform.position = pos;
    }

    public void Destroy()
    {
        _meteorsGenerator.GenerateNewMeteor();
        Destroy(gameObject);
    }
   
}
