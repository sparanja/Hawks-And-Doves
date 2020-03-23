using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class input : MonoBehaviour
{
    // Start is called before the first frame update

    public TextMeshProUGUI Hawks;
    public TextMeshProUGUI Doves;
    public TextMeshProUGUI Food;

    private Vector3 Min;
    private Vector3 Max;
    private float x_Axis;
    private float y_Axis;
    private float z_Axis;
    private Vector3 random_position;
    public bool can_Instantiate;

    public GameObject hawkContain, DoveGameObeject, FoodGameObject;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void SetRange()
    {
        Min = new Vector3(-4.2f, -2.7f, 0);
        Max = new Vector3(4.2f, 2.7f, 0);
    }

    private void GenerateRandom()
    {
        x_Axis = UnityEngine.Random.Range(Min.x, Max.x);
        y_Axis = UnityEngine.Random.Range(Min.y, Max.y);
        z_Axis = UnityEngine.Random.Range(Min.z, Max.z);
        random_position = new Vector3(x_Axis, y_Axis, z_Axis);
    }

    public void check()
    {
        DataSource obj = DataSource.getSingletonInstance();
        obj.setNumberOfHawks(Int32.Parse(Hawks.text.Replace("\u200B", "").ToString()));
        obj.setNumberOfDoves(Int32.Parse(Doves.text.Replace("\u200B", "").ToString()));
        obj.setNumberOfFood(Int32.Parse(Food.text.Replace("\u200B", "").ToString()));
        UpdateStartCharacters();
    }

    public void UpdateStartCharacters()
    {

        DataSource obj = DataSource.getSingletonInstance();
        // if (Input.GetKeyDown(KeyCode.D))
        Debug.Log(obj.getNumberOfDoves());
        Debug.Log("Hello World");
        Debug.Log(obj.getNumberOfHawks());
        for (int i = 0; i < obj.getNumberOfDoves(); i++)
        {

            GenerateRandom();
            Instantiate(DoveGameObeject, random_position, Quaternion.identity);

        }
        obj.setNumberOfDoves(obj.getNumberOfDoves() + 100);
        // if (Input.GetKeyDown(KeyCode.H))
        for (int i = 0; i < obj.getNumberOfHawks(); i++)
        {

            GenerateRandom();
            Instantiate(hawkContain, random_position, Quaternion.identity);

        }
        obj.setNumberOfHawks(obj.getNumberOfHawks() + 100);
        // if (Input.GetKeyDown(KeyCode.F))
        for (int i = 0; i < obj.getNumberOfFood(); i++)
        {

            GenerateRandom();
            Instantiate(FoodGameObject, random_position, Quaternion.identity);
        }
        obj.setNumberOfFood(obj.getNumberOfFood() + 100);

        if (can_Instantiate)
        {
            //Instantiate(gameObject, random_position, Quaternion.identity);
        }


    }
}
