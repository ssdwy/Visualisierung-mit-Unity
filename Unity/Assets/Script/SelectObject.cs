using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SelectObject : MonoBehaviour
{
    [SerializeField] private string selectableTag1 = "Selectable";
    [SerializeField] private string selectableTag2 = "SelectableFlur";
    [SerializeField] private string selectableTag3 = "SelectableStair";
    [SerializeField] private string selectableTag4 = "SelectablePlattform";

    [SerializeField] private Material highlightMaterial;
    [SerializeField] private Material wrongMaterial;

    //private Canvas cv;
    [SerializeField] private Text parameter;

    private Material defaultmaterial;

    private Transform _selection;

    // Start is called before the first frame update
    void Start()
    {
        parameter.text = null;
    }

    // Update is called once per frame
    void Update()
    {
        if(_selection != null)
        {
            var selectionRenderer = _selection.GetComponent<Renderer>();
            selectionRenderer.material = defaultmaterial;
            _selection = null;
            parameter.text = null;
        }
        var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;
        if(Physics.Raycast(ray, out hit))
        {
            var selection = hit.transform;

            // Kennzeichnung von Türen
            if (selection.CompareTag(selectableTag1))
            {
                var selectionSize = selection.GetComponent<BoxCollider>();
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    defaultmaterial = selectionRenderer.material;
                    if (selectionSize.size.x >= 0.8)
                    {
                        
                        selectionRenderer.material = highlightMaterial;
                    }
                    else
                    {
                        selectionRenderer.material = wrongMaterial;
                    }
                   
                }
                if(selectionSize != null)
                {
                    float laenge = selectionSize.size.z;
                    float bereite = selectionSize.size.x;
                    string dispalyInfo = string.Format("{0}\n{1}\n", "Länge: " + laenge + "m", "Bereite: " + bereite + "m");
                    parameter.text = dispalyInfo;
                }
                _selection = selection;
            }
            // Markierung von Korridoren
            if (selection.CompareTag(selectableTag2))
            {
                var selectionSize = selection.GetComponent<BoxCollider>();
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    defaultmaterial = selectionRenderer.material;
                    float bereite = (float)(selectionSize.size.z * 0.17);
                    if (bereite >= 0.8)
                    {

                        selectionRenderer.material = highlightMaterial;
                    }
                    else
                    {
                        selectionRenderer.material = wrongMaterial;
                    }
                }
                if (selectionSize != null)
                {
                    if (selectionSize.size.z < 10)
                    {
                        float bereite = (float)(selectionSize.size.z * 0.17);
                        float laenge = (float)(selectionSize.size.x * 3.28);
                        string dispalyInfo = string.Format("{0}\n{1}\n", "Länge: " + laenge + "m", "Bereite: " + bereite + "m");
                        parameter.text = dispalyInfo;
                    }
                    else
                    {
                        float bereite = (float)(selectionSize.size.z * 0.326);
                        float laenge = (float)(selectionSize.size.x * 0.213);
                        string dispalyInfo = string.Format("{0}\n{1}\n", "Länge: " + laenge + "m", "Bereite: " + bereite + "m");
                        parameter.text = dispalyInfo;
                    }
                }
                _selection = selection;
            }
            // Markierung von Treppen
            if (selection.CompareTag(selectableTag3))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    defaultmaterial = selectionRenderer.material;
                    selectionRenderer.material = highlightMaterial;
                }

                float laenge = 3f;
                float bereite = 1f;
                string dispalyInfo = string.Format("{0}\n{1}\n", "Länge: " + laenge + "m", "Bereite: " + bereite + "m");
                parameter.text = dispalyInfo;

                
                _selection = selection;
            }
            // Markierungsplattform
            if (selection.CompareTag(selectableTag4))
            {
                var selectionRenderer = selection.GetComponent<Renderer>();
                if (selectionRenderer != null)
                {
                    defaultmaterial = selectionRenderer.material;
                    selectionRenderer.material = highlightMaterial;
                }

                float laenge = 2.13f;
                float bereite = 1.03f;
                string dispalyInfo = string.Format("{0}\n{1}\n", "Länge: " + laenge + "m", "Bereite: " + bereite + "m");
                parameter.text = dispalyInfo;

                _selection = selection;
            }
        }

    }
}
