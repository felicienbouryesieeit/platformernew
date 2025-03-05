using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class basescript : MonoBehaviour
{
    protected gamemanagerscr gamemanagervar;
    // Start is called before the first frame update

    void Awake()
    {
        Awake2();
    }

    protected virtual void Awake2() {

    }
    void Start()
    {
        
        gamemanagervar = gamemanagerscr.gamemanagervar2;
        Debug.Log("soucoupe soucoupe"+(gamemanagervar==null));
        Start2();
        
    }

    // Update is called once per frame
    void Update()
    {
        Update2();
    }

    protected virtual void Start2() {

    }

    protected virtual void Update2() {
        
    }
}
