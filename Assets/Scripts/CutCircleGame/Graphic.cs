using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Graphic : MaskableGraphic
{
    List<UIVertex> vertexList = new List<UIVertex>();

    [Range(0, 360)]
    public float fillRange;
    public Texture texture;

    public float radio;

    [Range(3, 7000)]
    public int segment;

    public float lineWidth = 10;

    public bool stat = false;

    private int beSeg = 3;
    private int nextSeg;
    private bool add = false;

    private float CD = 0;
    private float beCD = 0.5f;

    public override Texture mainTexture
    {
        get { return texture; }
    }


    protected override void Start()
    {
        if (stat == false)
        {
            CutCircleGameEvent.instance.onSpaceButtonDown += turn;
        }
    }

    protected override void OnPopulateMesh(VertexHelper vh)
    {
        //Debug.Log("run");
        vh.Clear();
        if (vertexList.Count > 2)
        {
            lineWidth = Mathf.Clamp(lineWidth, 0, radio);
            UIVertex uiVertex0;
            UIVertex uiVertex1;
            UIVertex uiVertex2;
            UIVertex uiVertex3;
            Vector3 pointToCenter;

            for (int i = 1; i < vertexList.Count; i++)
            {
                UIVertex[] uiVertexs = new UIVertex[4];

                uiVertex0 = new UIVertex();
                uiVertex0.position = vertexList[i].position;
                uiVertex0.color = color;
                if (texture != null)
                {
                    uiVertex0.uv0 = new Vector2(
                        uiVertex0.position.x / texture.width + 0.5f,
                        uiVertex0.position.y / texture.height + 0.5f
                    );
                }

                uiVertex1 = new UIVertex();
                pointToCenter = (vertexList[i].position - Vector3.zero).normalized;
                uiVertex1.position = vertexList[i].position - pointToCenter * lineWidth;
                uiVertex1.color = color;
                if (texture != null)
                {
                    uiVertex1.uv0 = new Vector2(
                        uiVertex1.position.x / texture.width + 0.5f,
                        uiVertex1.position.y / texture.height + 0.5f
                    );
                }

                uiVertex2 = new UIVertex();
                uiVertex2.position = vertexList[i - 1].position;
                uiVertex2.color = color;
                if (texture != null)
                {
                    uiVertex2.uv0 = new Vector2(
                        uiVertex2.position.x / texture.width + 0.5f,
                        uiVertex2.position.y / texture.height + 0.5f
                    );
                }

                uiVertex3 = new UIVertex();
                pointToCenter = (vertexList[i - 1].position - Vector3.zero).normalized;
                uiVertex3.position = vertexList[i - 1].position - pointToCenter * lineWidth;
                uiVertex3.color = color;
                if (texture != null)
                {
                    uiVertex3.uv0 = new Vector2(
                        uiVertex3.position.x / texture.width + 0.5f,
                        uiVertex3.position.y / texture.height + 0.5f
                    );
                }

                uiVertexs[3] = uiVertex0;
                uiVertexs[2] = uiVertex1;
                uiVertexs[1] = uiVertex2;
                uiVertexs[0] = uiVertex3;

                vh.AddUIVertexQuad(uiVertexs);
            }
        }
    }

    void Update()
    {
        if (Time.frameCount % 5 == 0)
        {
            vertexList.Clear();
            float spanAngle = 360 / (segment * 1.0f);

            for (int i = 0; i < segment + 1; i++)
            {
                float angle = Mathf.Clamp(i * spanAngle, 0, fillRange);

                float x = radio * Mathf.Cos(angle * Mathf.Deg2Rad);

                float y = radio * Mathf.Sin(angle * Mathf.Deg2Rad);

                UIVertex uiVertex = new UIVertex();
                uiVertex.color = color;
                uiVertex.position = new Vector3(x, y, 0);
                vertexList.Add(uiVertex);
            }
            SetVerticesDirty();
        }

        if (add == true)
        {
            if (CD > 0)
            {
                CD -= Time.deltaTime;
            }
            else
            {
                if (segment < nextSeg)
                {
                    if (nextSeg == 6)
                    {
                        beCD = 0.5f;
                        segment += 1;
                    }
                    if (nextSeg == 12)
                    {
                        beCD = 0.2f;
                        segment += 1;
                    }
                    if (nextSeg >= 24)
                    {
                        beCD = 0.2f;
                        segment += 2 * (nextSeg - beSeg) / 10;
                    }
                    CD = beCD;
                }
                else
                {
                    segment = nextSeg;
                    beSeg = segment;
                }
            }
        }
    }

    void turn(int dl)
    {
        add = true;
        nextSeg = Resourses.instance.serEdge(dl);
    }
}
