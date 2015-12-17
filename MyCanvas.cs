using System.Collections.Generic;
using UnityEngine;

namespace GuiTest
{
    class MyCanvas : MonoBehaviour
    {
        //public UIVertex[] verts;
        private List<UIVertex> verts = new List<UIVertex>();

        void Start() {
            Debug.Log("Starting MyCanvas");
            //Canvas canvas = gameObject.GetComponent<Canvas>();
            //canvas.renderMode = RenderMode.ScreenSpaceOverlay;
            //verts = new UIVertex[4];
            //GenerateVerts();
        }

        void GenerateVerts() {
            GenerateSquare();
            CanvasRenderer uiRenderer = gameObject.GetComponent<CanvasRenderer>();
            uiRenderer.SetVertices(verts);
            Material mat = new Material(Shader.Find("Sprites/Default"));
            uiRenderer.SetMaterial(mat, null);
        }

        void GenerateSquare() {
            UIVertex vert = new UIVertex();
            vert.color = new Color32(255, 0, 0, 255);
            vert.uv0 = new Vector2(0, 0);
            vert.position = new Vector3(0, 0);
            verts[0] = vert;
            vert.position = new Vector3(0, 300);
            verts[1] = vert;
            vert.position = new Vector3(300, 300);
            verts[2] = vert;
            vert.position = new Vector3(300, 0);
            verts[3] = vert;
        }
    }
}
