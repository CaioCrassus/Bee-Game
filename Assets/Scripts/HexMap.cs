using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HexMap : MonoBehaviour
{

    public static HexMap instance;

    public int sizeX, sizeY;
    public GameObject hexEmpty;
    public GameObject hexFull;
    public GameObject hexRoyal;
    public GameObject hexClosed;
    public GameObject hexSelectble;
    public GameObject blank;

    private float inneradius = 0.85f;
    private float outerradius = 1;

    Dictionary<Vector2, Hex> map = new Dictionary<Vector2,Hex>();

    public int emptyCount{get; private set;}
    public int fullCount{get; private set;}
    public int selectableCount{get; private set;}
    public int blankCount{get; private set;}
    public int selectedCount{get; private set;}

    // Start is called before the first frame update
    void Start()
    {
        if(instance == null) instance = this;
        CreateMap();
    }

    void CreateMap(){
        for(int i = -sizeX/2; i < sizeX/2; i++){
            for (int j = -sizeY/2; j < sizeY/2; j++)
            {
                Hex hex = new Hex();
                if (i==0&&j==0){
                    hex.unit = Instantiate(hexRoyal, transform);
                    hex.state = state.empty;
                    emptyCount++;
                }
                else {
                    hex.unit = Instantiate(blank, transform);
                    hex.state = state.nothing;
                    blankCount++;
                }
                hex.unit.transform.position = new Vector3(j%2 != 0 ? i * inneradius * 2 * 1.05f: i * inneradius * 2 * 1.05f + (inneradius + inneradius * 0.05f) , 0, j * outerradius * 1.55f);
                map.Add(new Vector2(i,j), hex);

                hex.unit.GetComponent<HexUnit>().gridPos = new Vector2(i,j);
                hex.unit.GetComponent<HexUnit>().mapRef = this;
                hex.unit.name = (i, j).ToString();
            }
        }
        updateMap();
    }

    public void ChangeHexState(Vector2 unitPos, state s){
        Hex hexUnit = map[unitPos];

        //remove from count
        if(hexUnit.state!=s){
            switch (hexUnit.state)
            {
                case state.nothing:
                blankCount--;
                break;
                case state.empty:
                emptyCount--;
                break;
                case state.full:
                fullCount--;
                break;
                case state.royal:
                selectedCount--;
                break;
                case state.selectble:
                selectableCount--;
                break;
            }

            //change state
            //Debug.Log("chaging:" + hexUnit.unit.name + "From" + hexUnit.state  + "TO" + s);
            Vector3 aux = hexUnit.unit.transform.localPosition;
            //hexUnit.unit.SetActive(false);
            Destroy(map[unitPos].unit);
            hexUnit.state = s;
            //Debug.Log(map[unitPos].state);
            switch(s){
                case state.nothing:
                hexUnit.unit = Instantiate(blank, transform);
                blankCount++;
                return;
                case state.empty:
                int rand = Random.Range(1,101);
                if(rand <= 50){
                    hexUnit.unit = Instantiate(hexEmpty, transform);
                } else if (rand <=  85)
                {
                    hexUnit.unit = Instantiate(hexFull, transform);
                } else
                {
                    hexUnit.unit = Instantiate(hexClosed, transform);
                }
                emptyCount++;
                break;
                case state.full:
                hexUnit.unit = Instantiate(hexFull, transform);
                fullCount++;
                break;
                case state.royal:
                hexUnit.unit = Instantiate(hexRoyal, transform);
                selectedCount++;
                break;
                case state.selectble:
                hexUnit.unit = Instantiate(hexSelectble, transform);
                selectableCount++;
                break;
            }
                hexUnit.unit.GetComponent<HexUnit>().gridPos = unitPos;
                hexUnit.unit.GetComponent<HexUnit>().mapRef = this;
                hexUnit.unit.transform.position = aux;
                hexUnit.unit.name = (unitPos.x,unitPos.y).ToString();
                map[unitPos] = hexUnit;
        }
    }

    public void updateMap(){
        foreach (KeyValuePair<Vector2, Hex> h in map)
        {
            Vector2 pos = h.Key;
            Vector2 offset;
            if (h.Value.state != state.nothing && h.Value.state != state.selectble){
                    offset = new Vector2(1,0);
                    if (map.ContainsKey(pos + offset) && map[pos + offset].state == state.nothing)
                        ChangeHexState(pos + offset, state.selectble);

                    offset = new Vector2(-1,0);
                    if (map.ContainsKey(pos + offset) && map[pos + offset].state == state.nothing)
                        ChangeHexState(pos + offset, state.selectble);
                    
                    offset = new Vector2(0,1);
                    if (map.ContainsKey(pos + offset) && map[pos + offset].state == state.nothing)
                        ChangeHexState(pos + offset, state.selectble);
                    
                    offset = new Vector2(0,-1);
                    if (map.ContainsKey(pos + offset) && map[pos + offset].state == state.nothing)
                        ChangeHexState(pos + offset, state.selectble);
                    
                    offset = new Vector2(1,1);
                    if (map.ContainsKey(pos + offset) && map[pos + offset].state == state.nothing)
                        ChangeHexState(pos + offset, state.selectble);
                    
                    offset = new Vector2(1,-1);
                    if (map.ContainsKey(pos + offset) && map[pos + offset].state == state.nothing)
                        ChangeHexState(pos + offset, state.selectble);
            }
                switch(h.Value.state){
                    case state.nothing:
                    break;
                    case state.empty:
                    break;
                    case state.full:
                    break;
                    case state.royal:
                    break;
                    case state.selectble:
                    break;
                }
        //Debug.Log((blankCount,emptyCount,fullCount,selectedCount,selectableCount).ToString());
        }
    }

    Vector2 GetRandomHexOfState(state s){
        List<Vector2> pos = new List<Vector2>();
        foreach (KeyValuePair<Vector2, Hex> h in map)
        {
            if(h.Value.state == s)
                pos.Add(h.Key);
        }
        if (pos.Count == 0) return new Vector2(-100000,-10000);
        return pos[Random.Range(0, pos.Count)];
    }

    state GetHexUnitState(Vector2 pos){
        return map[pos].state;
    }
}

public enum state{nothing, empty, full, royal, selectble}
struct Hex{
    public state state;
    public GameObject unit;
}