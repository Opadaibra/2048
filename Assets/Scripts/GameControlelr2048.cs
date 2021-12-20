using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System;

public class GameControlelr2048 : MonoBehaviour
{
    public static GameControlelr2048 instance;
    public static int ticker;
    [SerializeField] GameObject fillPrefab;
    [SerializeField] Cells2048[] allCells;
    public static Action<string> slide;

    public int Score;
    [SerializeField] Text ScoreDisplay;
    public int gameover;
    [SerializeField] GameObject Gameovepanel;
    [SerializeField] int winning;
    [SerializeField] GameObject winningpanel;
    bool haswon;
    public Color[] fillcolors;

    /// <summary>
    Vector2 Touchstartpos;
    Vector2 Touchcurrentpos;
    Vector2 Touchendpos;
    bool stoptoch = false;
    public float sliderange;
    float taprange;
    /// </summary>
    private void OnEnable()
    {
        if (instance == null)
            instance = this;
    }
    void Start()
    {
        StartSpawnFill(); StartSpawnFill();
    }
    IEnumerator HoldTouch()
    {
        stoptoch = true;
        yield return new WaitForSeconds(.25f);
        stoptoch = false;
    }

   
    // Update is called once per frame
    void Update()
    {
       
        if (Input.touchCount > 0 && Input.GetTouch(0).deltaTime > 0.05f)
        {
            if (Input.touchCount == 1
                && Mathf.Abs(Input.GetTouch(0).deltaPosition.x) > Mathf.Abs(Input.GetTouch(0).deltaPosition.y)
                && Input.GetTouch(0).deltaPosition.x > 0.5f)
            {
                slide("d");
                ticker = 0;
                gameover = 0;
                StartCoroutine(HoldTouch());
            }
            if (Input.touchCount == 1
                 && Mathf.Abs(Input.GetTouch(0).deltaPosition.x) > Mathf.Abs(Input.GetTouch(0).deltaPosition.y)
                 && Input.GetTouch(0).deltaPosition.x < -0.5f)
            {

                slide("a");
                ticker = 0;
                gameover = 0;
                StartCoroutine(HoldTouch());


            }
            if (Input.touchCount == 1 && Mathf.Abs(Input.GetTouch(0).deltaPosition.x) < Mathf.Abs(Input.GetTouch(0).deltaPosition.y)
             && Input.GetTouch(0).deltaPosition.y < -0.5f)
            {
                slide("s");
                ticker = 0;
                gameover = 0;
                StartCoroutine(HoldTouch());


            }
            if (Input.touchCount == 1 && Mathf.Abs(Input.GetTouch(0).deltaPosition.x) < Mathf.Abs(Input.GetTouch(0).deltaPosition.y)
            && Input.GetTouch(0).deltaPosition.y > 0.5f)
            {
                slide("w");
                gameover = 0;
                ticker = 0;
                StartCoroutine(HoldTouch());
            }
        }
        if (stoptoch)
        {
            return;
        }
      
    }
    public void SpawnFill()
    {
        //Check if is full  
        bool isFull = true;
        for (int i = 0; i < allCells.Length; i++)
        {
            if (allCells[i].fill == null)
            {
                isFull = false;
            }
        }
        if (isFull == true)
            return;
        //////////////////////////
        int WhichSpawn = UnityEngine.Random.Range(0, allCells.Length);
        if (allCells[WhichSpawn].transform.childCount != 0)
        {
            Debug.Log(allCells[WhichSpawn].name + "Is already fill");
            SpawnFill();
            return;
        }
        float chance = UnityEngine.Random.Range(0f, 1f);
        Debug.Log(chance);
        if (chance < .2f)
        {
            return;
        }
        else if (chance < .8f)
        {

            GameObject Tempfill = Instantiate(fillPrefab, allCells[WhichSpawn].transform);
            Debug.Log(2);
            fill2048 Tempcomponent = Tempfill.GetComponent<fill2048>();
            allCells[WhichSpawn].GetComponent<Cells2048>().fill = Tempcomponent;
            Tempcomponent.fillvalueupdate(2);
        }
        else
        {
            GameObject Tempfill = Instantiate(fillPrefab, allCells[WhichSpawn].transform);
            Debug.Log(4);
            fill2048 Tempcomponent = Tempfill.GetComponent<fill2048>();
            allCells[WhichSpawn].GetComponent<Cells2048>().fill = Tempcomponent;
            Tempcomponent.fillvalueupdate(4);
        }
    }
    public void StartSpawnFill()
    {

        int WhichSpawn = UnityEngine.Random.Range(0, allCells.Length);
        if (allCells[WhichSpawn].transform.childCount != 0)
        {
            Debug.Log(allCells[WhichSpawn].name + "Is already fill");
            SpawnFill();
            return;
        }

        GameObject Tempfill = Instantiate(fillPrefab, allCells[WhichSpawn].transform);
        Debug.Log(2);
        fill2048 Tempcomponent = Tempfill.GetComponent<fill2048>();
        allCells[WhichSpawn].GetComponent<Cells2048>().fill = Tempcomponent;
        Tempcomponent.fillvalueupdate(2);

    }
    public void updatescore(int ScoreIn)
    {
        Score += ScoreIn;
        ScoreDisplay.text = Score.ToString();
    }
    public void Checkgameover()
    {
        gameover++;
        if (gameover >= 16)  
        {
            Gameovepanel.SetActive(true);
        }
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    public void wincheck(int highesfill)
    {
        if (haswon)
            return;
        if(highesfill == winning)
        {
            winningpanel.SetActive(true);
            haswon = true;
        }
    }
    public void KeepPlaying()
    {
        winningpanel.SetActive(false);
    }
}
