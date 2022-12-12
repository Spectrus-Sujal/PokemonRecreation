using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThisMonster : MonoBehaviour
{
    public MonsterDatabase.Monsters thisOne;
    public Monster me;
    
    public Transform CM;
    
    // Start is called before the first frame update
    void Start()
    {
        Debug.Log(thisOne);
        me = CM.GetComponent<MonsterDatabase>().MonstersList[(int)thisOne];
    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
