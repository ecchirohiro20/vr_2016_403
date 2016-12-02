﻿using UnityEngine;
using System.Collections;

public class DeleteCount : MonoBehaviour {

    public TextMesh mesh;
    public TextMesh[] UI;
    int deleteCount;
	// Use this for initialization
	void Start () {
        deleteCount = 0;
        GetComponent<TextMesh>().text = "倒した数:" + deleteCount.ToString();
        foreach(TextMesh obj in UI)
            obj.text = "倒した数:" + deleteCount.ToString();
    }

    // Update is called once per frame
    void Update(){

    }
    public void CountPlus()
    {
        deleteCount++;
        GetComponent<TextMesh>().text = "倒した数:" + deleteCount.ToString();
        mesh.text = "倒した数:" + deleteCount.ToString();
        foreach (TextMesh obj in UI)
            obj.text = "倒した数:" + deleteCount.ToString();
    }
}
