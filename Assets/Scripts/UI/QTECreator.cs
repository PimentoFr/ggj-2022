using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QTEItem
{
    public string action_label { get; set; }
    public List<string> keys_type { get; set; }

    public QTEItem(string _action_label, List<string> _keys_type)
    {
        action_label = _action_label;
        keys_type = _keys_type;
    }
}

public class QTECreator : MonoBehaviour
{
    public GameObject prefabQteItem;
    List<QteItemUI> qteItemUiList = new List<QteItemUI>();

    void Start()
    {
        CreateItems(new List<QTEItem>
        {
            new QTEItem("Remplir du papier", new List<string>{"UP", "DOWN", "LEFT"}),
            new QTEItem("Lancer photocopie", new List<string>{"RIGHT", "DOWN", "LEFT"}),
            new QTEItem("Recuperer impression", new List<string>{"UP", "UP", "LEFT"}),
        });
    }

    public void CreateItems(List<QTEItem> qteitems)
    {
        int i = 0;
        foreach(QTEItem qteitem in qteitems) {
            Vector3 positionItemUi = new Vector3(0, 100 -i * 40, 0);
            QteItemUI qteItemUi = Instantiate(prefabQteItem, new Vector3(0, 0, 0), Quaternion.identity).GetComponent<QteItemUI>();
            qteItemUi.transform.parent = transform;
            qteItemUi.transform.localPosition = positionItemUi;
            qteItemUi.SetActionLabel(qteitem.action_label);
            qteItemUi.GenerateKeys(qteitem.keys_type);
            qteItemUiList.Add(qteItemUi);
            i++;
        }
    }

    void Leave()
    {
        Destroy(gameObject);
    }
}
