using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cells2048 : MonoBehaviour
{
    public Cells2048 Up;
    public Cells2048 Down;
    public Cells2048 left;
    public Cells2048 right;

    public fill2048 fill;
    // Start is called before the first frame update
    private void OnEnable()
    {
        GameControlelr2048.slide += Onslide;
    }

    private void OnDisable()
    {
        GameControlelr2048.slide -= Onslide;

    }

    private void Onslide(string Whatwasissend)
    {
        cellchick();
        Debug.Log(Whatwasissend); 
        if(Whatwasissend =="w")
        {
            if (Up != null)
                return;
            Cells2048 currrentcell = this;
            SlidUp(currrentcell);
        }
        if (Whatwasissend == "s")
        {
            if (Down != null)
                return;
            Cells2048 currrentcell = this;
            SlidDown(currrentcell);
        }
        if (Whatwasissend == "a")
        {
            if (left != null)
                return;
            Cells2048 currrentcell = this;
            SlidLeft(currrentcell);
        }
        if (Whatwasissend == "d")
        {
            if (right != null)
                return;
            Cells2048 currrentcell = this;
            SlidRight(currrentcell);
        }
        GameControlelr2048.ticker++;
        if(GameControlelr2048.ticker==4)
        {
            GameControlelr2048.instance.SpawnFill();
        }
    }
    void SlidUp(Cells2048 currentcell)
    {
        if(currentcell.Down==null)
        {
            return;
        }
        if(currentcell.fill !=null)
        {
            Cells2048 nextcells = currentcell.Down;
            while(nextcells.Down!= null && nextcells.fill ==null)
            {
                nextcells = nextcells.Down;
            }
            if(nextcells.fill !=null)
            {
                if(currentcell.fill.value==nextcells.fill.value)
                {
                    nextcells.fill.Double();

                    nextcells.fill.transform.parent = currentcell.transform;
                    currentcell.fill = nextcells.fill;
                    nextcells.fill = null;
                }
                 else if (currentcell.Down.fill != nextcells.fill)
                {
                    Debug.Log("!Doubled");
                    nextcells.fill.transform.parent = currentcell.Down.transform;
                    currentcell.Down.fill = nextcells.fill;
                    nextcells.fill = null;
                }
            }
        }
        else
        {
            Cells2048 nextcells = currentcell.Down;
            if (nextcells.Down != null&& nextcells.fill == null)
            {
                nextcells = nextcells.Down; 
            }
            if (nextcells.fill != null)
            {
                nextcells.fill.transform.parent = currentcell.transform;
                currentcell.fill = nextcells.fill;
                nextcells.fill = null;
                SlidUp(currentcell);
                Debug.Log("slid to empty");

            }
        }
        if(currentcell.Down ==null)
        {
            return;
        }
        SlidUp(currentcell.Down);
                
    }
    void SlidDown(Cells2048 currentcell)
    {
        if (currentcell.Up == null)
        {
            return;
        }
        Debug.Log(currentcell.gameObject);
        if (currentcell.fill != null)
        {
            Cells2048 nextcells = currentcell.Up;
            while (nextcells.Up != null && nextcells.fill == null)
            {
                nextcells = nextcells.Up;
            }
            if (nextcells.fill != null)
            {
                if (currentcell.fill.value == nextcells.fill.value)
                {
                    nextcells.fill.Double();

                    nextcells.fill.transform.parent = currentcell.transform;
                    currentcell.fill = nextcells.fill;
                    nextcells.fill = null;
                }
                   else if (currentcell.Up.fill != nextcells.fill)
                {
                    Debug.Log("!Doubled");
                    nextcells.fill.transform.parent = currentcell.Up.transform;
                    currentcell.Up.fill = nextcells.fill;
                    nextcells.fill = null;
                }
            }
        }
        else
        {
            Cells2048 nextcells = currentcell.Up;
            if (nextcells.Up != null && nextcells.fill == null)
            {
                nextcells = nextcells.Up;
            }
            if (nextcells.fill != null)
            {
                nextcells.fill.transform.parent = currentcell.transform;
                currentcell.fill = nextcells.fill;
                nextcells.fill = null;
                SlidDown(currentcell);
                Debug.Log("slid to empty");

            }
        }
        if (currentcell.Up == null)
        {
            return;
        }
        SlidDown(currentcell.Up);

    }
    void SlidLeft(Cells2048 currentcell)
    {
        if (currentcell.right == null)
        {
            return;
        }
        Debug.Log(currentcell.gameObject);
        if (currentcell.fill != null)
        {
            Cells2048 nextcells = currentcell.right;
            while (nextcells.right != null && nextcells.fill == null)
            {
                nextcells = nextcells.right;
            }
            if (nextcells.fill != null)
            {
                if (currentcell.fill.value == nextcells.fill.value)
                {
                    nextcells.fill.Double();

                    nextcells.fill.transform.parent = currentcell.transform;
                    currentcell.fill = nextcells.fill;
                    nextcells.fill = null;
                }
                else if (currentcell.right.fill != nextcells.fill)
                {
                   
                    nextcells.fill.transform.parent = currentcell.right.transform;
                    currentcell.right.fill = nextcells.fill;
                    nextcells.fill = null;
                }
            }
        }
        else
        {
            Cells2048 nextcells = currentcell.right;
            if (nextcells.right != null && nextcells.fill == null)
            {
                nextcells = nextcells.right;
            }
            if (nextcells.fill != null)
            {
                nextcells.fill.transform.parent = currentcell.transform;
                currentcell.fill = nextcells.fill;
                nextcells.fill = null;
                SlidLeft(currentcell);
                Debug.Log("slid to empty");

            }
        }
        if (currentcell.right == null)
        {
            return;
        }
        SlidLeft(currentcell.right);

    }
    void SlidRight(Cells2048 currentcell)
    {
        if (currentcell.left == null)
        {
            return;
        }
        Debug.Log(currentcell.gameObject);
        if (currentcell.fill != null)
        {
            Cells2048 nextcells = currentcell.left;
            while (nextcells.left != null && nextcells.fill == null)
            {
                nextcells = nextcells.left;
            }
            if (nextcells.fill != null)
            {
                if (currentcell.fill.value == nextcells.fill.value)
                {
                    nextcells.fill.Double();
                    nextcells.fill.transform.parent = currentcell.transform;
                    currentcell.fill = nextcells.fill;
                    nextcells.fill = null;
                }
                else if(currentcell.left.fill !=nextcells.fill)
                {
                    Debug.Log("!Doubled");
                    nextcells.fill.transform.parent = currentcell.left.transform;
                    currentcell.left.fill = nextcells.fill;
                    nextcells.fill = null;
                }
            }
        }
        else
        {
            Cells2048 nextcells = currentcell.left;
            if (nextcells.left != null && nextcells.fill == null)
            {
                nextcells = nextcells.left;
            }
            if (nextcells.fill != null)
            {
                nextcells.fill.transform.parent = currentcell.transform;
                currentcell.fill = nextcells.fill;
                nextcells.fill = null;
                SlidRight(currentcell);
                Debug.Log("slid to empty");

            }
        }
        if (currentcell.left == null)
        {
            return;
        }
        SlidRight(currentcell.left);

    }
    void cellchick()
    {
        if (fill == null)
            return;
        if(Up!=null)
        {
            if (Up.fill == null)
                return;
            if (Up.fill.value == fill.value)
                return;
        }
        if (Down != null)
        {
            if (Down.fill == null)
                return;
            if (Down.fill.value == fill.value)
                return;
        }
        if (right != null)
        {
            if (right.fill == null)
                return;
            if (right.fill.value == fill.value)
                return;
        }
        if (left != null)
        {
            if (left.fill == null)
                return;
            if (left.fill.value == fill.value)
                return;
        }
        GameControlelr2048.instance.Checkgameover();
    }
}
