using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour
{
    public int sizeX, sizeY;
    public GameObject hexObject;
    Dictionary<Vector2, GameObject> map = new Dictionary<Vector2,GameObject>();

    private float inneradius = 0.85f;
    private float outerradius = 1;

    // Start is called before the first frame update
    void Start()
    {
        CreateMap();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void CreateMap(){
        for(int i = 0; i < sizeX; i++){
            for (int j = 0; j < sizeY; j++)
            {
                GameObject hex = Instantiate(hexObject, transform);
                hex.transform.position = new Vector3(j%2 != 0 ? i * inneradius * 2 * 1.05f: i * inneradius * 2 * 1.05f + (inneradius + inneradius * 0.05f) , 0, j * outerradius * 1.55f);
                map.Add(new Vector2(i,j), hex);
            }
        }
    }
}
