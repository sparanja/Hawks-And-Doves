using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class DataSource
{
    private int numberOfDoves, numberOfHawks, numberOfFood;
    public static DataSource obj;
    private static readonly System.Random random = new System.Random();
    private static readonly object syncLock = new object();

    public int getNumberOfDoves()
    {
        return numberOfDoves;
    }

    public int getNumberOfHawks()
    {
        return numberOfHawks;
    }

    public int getNumberOfFood()
    {
        return numberOfFood;
    }

    public void setNumberOfDoves(int Value)
    {
        this.numberOfDoves = Value;
    }

    public void setNumberOfHawks(int Value)
    {
        this.numberOfHawks = Value;
    }
    public void setNumberOfFood(int Value)
    {
        this.numberOfFood = Value;
    }

    public int getHealth()
    {
        List<int> health = new List<int>() { 100, 80, 60, 40, 20 };
        /* lock (syncLock)
         {
             return health[random.Next(health.Count)];
         } */

        System.Random random = new System.Random(Guid.NewGuid().GetHashCode());
        return health[random.Next(0, health.Count)];
    }

    private DataSource()
    {

    }

    public static DataSource getSingletonInstance()
    {
        if (obj == null)
        {
            obj = new DataSource();
        }
        return obj;
    }


}
