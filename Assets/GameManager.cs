using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject Enemy;
    public int wave_size=3;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        for(int i = 0;i<wave_size;i++){
            Instantiate(Enemy);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
