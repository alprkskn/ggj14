using UnityEngine;
using System.Collections;

public class inventory : MonoBehaviour {

    private int LSD;
    private int smoke;
    private int mushroom;
    private int vodka;

    public void addLSD()
    {
        LSD++;
        return;
    }
    public void removeLSD()
    {
        LSD--;
        return;
    }
    public int getLSD()
    {
        return LSD;
    }

    public void addSmoke()
    {
        smoke++;
        return;
    }
    public void removeSmoke()
    {
        smoke--;
        return;
    }
    public int getSmoke()
    {
        return smoke;
    }

    public void addMushroom()
    {
        mushroom++;
        return;
    }
    public void removeMushroom()
    {
        mushroom--;
        return;
    }
    public int getMushroom()
    {
        return mushroom;
    }

    public void addVodka()
    {
        vodka++;
        return;
    }
    public void removeVodka()
    {
        vodka--;
        return;
    }
    public int getVodka()
    {
        return vodka;
    }
}
