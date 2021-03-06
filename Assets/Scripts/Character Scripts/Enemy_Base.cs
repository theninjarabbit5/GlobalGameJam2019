﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy_Base : Character_Controller {

    private Stances myAttack;
    private float myTime;
    public float StartTime;
    public float attackFreq;
    public float attackTimeFrame;
    public float attackTimeStart;
    public Text text;
    public Stances[] attackPattern;
    private int curPatternPos;
    public GameObject[] defending;
    // Use this for initialization
    void Start () {
        currentHealth++;
        curPatternPos = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (isTurn)
        {
            defending[0].SetActive(false);
            defending[1].SetActive(false);
            defending[2].SetActive(false);
            Attack();
            text.text = " ";
        }
        else
        {
            Defend();
            //StartTime = Time.time;
            myTime = Time.time;
        }
	}
    private void Attack()
    {
        if(Time.time - myTime >= attackFreq)
        {
            attackTimeStart = Time.time;
            GetComponent<Animator>().Play("E_WeepBear_idle");
            //myAttack = (Stances)UnityEngine.Random.Range(0, 3);
            myAttack = attackPattern[curPatternPos];
            if (myAttack == Stances.Up) { GetComponent<Animator>().Play("E_WeepBear_Attack_High_Strike"); }
            else { GetComponent<Animator>().Play("E_WeepBear_Attack_High_Charge"); }
            curPatternPos++;
            if(curPatternPos > attackPattern.Length - 1) { curPatternPos = 0; }
            myTime = Time.time;
        }
        //if(Time.time - StartTime >= TurnTime) { isTurn = false; }
    }

    private void Defend()
    {
        text.text = "Defense: " + stance.ToString();
        GetComponent<Animator>().Play("E_WeepBear_idle");
        if(stance == Stances.Up)
        {
            defending[0].SetActive(true);
            defending[1].SetActive(false);
            defending[2].SetActive(false);
        }
        else if(stance == Stances.Middle)
        {
            defending[0].SetActive(false);
            defending[1].SetActive(true);
            defending[2].SetActive(false);
        }
        else if (stance == Stances.Down)
        {
            defending[0].SetActive(false);
            defending[1].SetActive(false);
            defending[2].SetActive(true);
        }
        else
        {
            defending[0].SetActive(false);
            defending[1].SetActive(false);
            defending[2].SetActive(false);
        }
    }

    public Stances MyAttack
    {
        get { return myAttack; }
        set { myAttack = value;}
    }
    
}
