using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Globalization;

public class LoadingSystem : MonoBehaviour
{
    public GameObject Hip_Center;
    public GameObject Spine;
    public GameObject Shoulder_Center;
    public GameObject Head;
    public GameObject Shoulder_Left;
    public GameObject Elbow_Left;
    public GameObject Wrist_Left;
    public GameObject Hand_Left;
    public GameObject Shoulder_Right;
    public GameObject Elbow_Right;
    public GameObject Wrist_Right;
    public GameObject Hand_Right;
    public GameObject Hip_Left;
    public GameObject Knee_Left;
    public GameObject Ankle_Left;
    public GameObject Foot_Left;
    public GameObject Hip_Right;
    public GameObject Knee_Right;
    public GameObject Ankle_Right;
    public GameObject Foot_Right;

    public GameObject cubeParent;

    // if it is loading data from a csv file or not
    public bool isLoading = false;

    // path to the csv file
    public string movementToLoad;
    public string fileToLoadFrom;

    //arrays for the data from the .csv
    public string[] fields;
    public string[] contents;

    public int numberOfLines;

    public int frameNo = 1;

    private JointProgression jointProgression;


    private void Start()
    {
        // check if path to the csv file exists
        // read the file and separate by line
        if (File.Exists(Application.dataPath + "/MovementDataBase/" + "ExpertMovement/" + fileToLoadFrom + "/" + movementToLoad + ".csv"))
        {
            contents = File.ReadAllLines(Application.dataPath + "/MovementDataBase/" + "ExpertMovement/" + fileToLoadFrom + "/" + movementToLoad + ".csv");
            numberOfLines = contents.Length;
        }

        jointProgression = new JointProgression();
    }

    public void Update()
    {
        if (isLoading)
        {
            // separate the lines into fields
            fields = contents[frameNo].Split(';');

            // define gameobjects transform using the apropriate fields
            Hip_Center.transform.position = new Vector3(float.Parse(fields[3]), float.Parse(fields[4]), float.Parse(fields[5]));
            Spine.transform.position = new Vector3(float.Parse(fields[7]), float.Parse(fields[8]), float.Parse(fields[9]));
            Shoulder_Center.transform.position = new Vector3(float.Parse(fields[11]), float.Parse(fields[12]), float.Parse(fields[13]));
            Head.transform.position = new Vector3(float.Parse(fields[15]), float.Parse(fields[16]), float.Parse(fields[17]));
            Shoulder_Left.transform.position = new Vector3(float.Parse(fields[19]), float.Parse(fields[20]), float.Parse(fields[21]));
            Elbow_Left.transform.position = new Vector3(float.Parse(fields[23]), float.Parse(fields[24]), float.Parse(fields[25]));
            Wrist_Left.transform.position = new Vector3(float.Parse(fields[27]), float.Parse(fields[28]), float.Parse(fields[29]));
            Hand_Left.transform.position = new Vector3(float.Parse(fields[31]), float.Parse(fields[32]), float.Parse(fields[33]));
            Shoulder_Right.transform.position = new Vector3(float.Parse(fields[35]), float.Parse(fields[36]), float.Parse(fields[37]));
            Elbow_Right.transform.position = new Vector3(float.Parse(fields[39]), float.Parse(fields[40]), float.Parse(fields[41]));
            Wrist_Right.transform.position = new Vector3(float.Parse(fields[43]), float.Parse(fields[44]), float.Parse(fields[45]));
            Hand_Right.transform.position = new Vector3(float.Parse(fields[47]), float.Parse(fields[48]), float.Parse(fields[49]));
            Hip_Left.transform.position = new Vector3(float.Parse(fields[51]), float.Parse(fields[52]), float.Parse(fields[53]));
            Knee_Left.transform.position = new Vector3(float.Parse(fields[55]), float.Parse(fields[56]), float.Parse(fields[57]));
            Ankle_Left.transform.position = new Vector3(float.Parse(fields[59]), float.Parse(fields[60]), float.Parse(fields[61]));
            Foot_Left.transform.position = new Vector3(float.Parse(fields[63]), float.Parse(fields[64]), float.Parse(fields[65]));
            Hip_Right.transform.position = new Vector3(float.Parse(fields[67]), float.Parse(fields[68]), float.Parse(fields[69]));
            Knee_Right.transform.position = new Vector3(float.Parse(fields[71]), float.Parse(fields[72]), float.Parse(fields[73]));
            Ankle_Right.transform.position = new Vector3(float.Parse(fields[75]), float.Parse(fields[76]), float.Parse(fields[77]));
            Foot_Right.transform.position = new Vector3(float.Parse(fields[79]), float.Parse(fields[80]), float.Parse(fields[81]));

            frameNo++;

            // play the movement from the beginning
            if (frameNo >= numberOfLines)
            {
                frameNo = 1;
            }
        }

        if (!isLoading)
        {
            cubeParent.SetActive(false);
        }
        else
        {
            cubeParent.SetActive(true);
        }
    }
}
