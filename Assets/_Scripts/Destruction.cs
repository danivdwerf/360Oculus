using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Destruction : MonoBehaviour {

    [SerializeField]
    private List<GameObject> Not_DestroyedWalls;

    [SerializeField]
    private List<GameObject> DestroyedWalls;

    public Action ExplosionEvent;

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < Not_DestroyedWalls.Count; i++)
            {
                Not_DestroyedWalls[i].SetActive(false);
            }
            if (this.ExplosionEvent != null)
                ExplosionEvent();
        }
    }
}
