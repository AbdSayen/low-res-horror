using UnityEngine;

public class PaperReader
{
    private ReadPanel readPanel;

    public PaperReader(ReadPanel readPanel)
    {
        this.readPanel = readPanel;
    }

    public void Read()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

            Debug.DrawRay(ray.origin, ray.direction * 5f, Color.red, 1f);

            if (Physics.Raycast(ray, out RaycastHit hit, 5f))
            {
                Paper paper = hit.transform.gameObject.GetComponent<Paper>();
                if (paper != null)
                {
                    readPanel.Open(paper.TextRu);
                }
            }
        }
    }
}
