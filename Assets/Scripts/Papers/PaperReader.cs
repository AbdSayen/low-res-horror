using UnityEngine;

public class PaperReader : MonoBehaviour
{
    [SerializeField] private GameObject handIcon;
    [SerializeField] private ReadPanel readPanel;

    private void Update()
    {
        Read();
    }

    public void Read()
    {
        Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);

        if (Physics.Raycast(ray, out RaycastHit hit, 5f))
        {
            Paper paper = hit.transform.gameObject.GetComponent<Paper>();
            if (paper != null)
            {
                if (!paper.isReaded)
                {
                    handIcon.SetActive(true);
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    readPanel.Open(paper.TextRu);
                    paper.Read();
                    handIcon.SetActive(false);
                }
            }
            else
            {
                handIcon.SetActive(false);
            }
        }
    }
}
