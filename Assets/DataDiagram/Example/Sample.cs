using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sample : MonoBehaviour {

    List<GameObject> lineList = new List<GameObject>();

    private DD_DataDiagram dataDiagram;
    //private RectTransform DDrect;

    private bool m_IsContinueInput = false;
    private float m_Input = 0f;
    private float h = 0;

    void AddALine() {

        if (null == dataDiagram)
            return;

        Color color = Color.HSVToRGB((h += 0.1f) > 1 ? (h - 1) : h, 0.8f, 0.8f);
        GameObject line = dataDiagram.AddLine(color.ToString(), color);
        if (null != line)
            lineList.Add(line);
    }

    // Use this for initialization
    void Start () {

        GameObject dd = GameObject.Find("DataDiagram");
        if(null == dd) {
            Debug.LogWarning("can not find a gameobject of DataDiagram");
            return;
        }
        dataDiagram = dd.GetComponent<DD_DataDiagram>();

        dataDiagram.PreDestroyLineEvent += (s, e) => { lineList.Remove(e.line); };

        for(int i=0; i<3; i++){
            AddALine();
        }
    }

    // Update is called once per frame
    void Update () {

    }

    private void FixedUpdate() {

        m_Input += Time.deltaTime;
        ContinueInput(m_Input);
    }

    private void ContinueInput(float f) {

        if (null == dataDiagram)
            return;

        if (false == m_IsContinueInput)
            return;

        DataSource data = DataSource.getSingletonInstance();
        int [] graphsPoints = new int[3]  {data.getNumberOfDoves(), data.getNumberOfHawks(), data.getNumberOfFood()};
        int index = 0;
        float pointVal = 0f;
        foreach (GameObject l in lineList) {
            pointVal += (float) ((graphsPoints[index]/10)%5);
            Debug.Log("Graph Points:"+pointVal); 
            dataDiagram.InputPoint(l, new Vector2(0.1f,
                (Mathf.Sin(f + pointVal) + 1f) * 2f)); 
            index += 1;
        }
    }

    public void onButton() {

        if (null == dataDiagram)
            return;

        foreach (GameObject l in lineList) {
            dataDiagram.InputPoint(l, new Vector2(1, Random.value * 4f));
        }
    }

    public void OnAddLine() {
        AddALine();
    }

    public void OnRectChange() {

        if (null == dataDiagram)
            return;

        Rect rect = new Rect(Random.value * Screen.width, Random.value * Screen.height,
            Random.value * Screen.width / 2, Random.value * Screen.height / 2);

        dataDiagram.rect = rect;
    }

    public void OnContinueInput() {

        m_IsContinueInput = !m_IsContinueInput;

    }

}
