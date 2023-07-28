using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TabGroup : MonoBehaviour
{
    [Serializable]
    public struct GroupPair
    {
        public Button button;
        public List<GameObject> children;
    }
    [SerializeField] private List<GroupPair> pairs;
    public int currentGroupdID;

    private void Awake()
    {
        for (int j = 0; j < pairs.Count; j++)
        {
            foreach (var item in pairs[j].children)
                item.SetActive(j == currentGroupdID);
        }

        for (int i = 0; i < pairs.Count; i++)
        {
            int index = i;
            pairs[i].button.onClick.AddListener(() =>
            {
                currentGroupdID = index;
                for (int j = 0; j < pairs.Count; j++)
                {
                    foreach (var item in pairs[j].children)
                        item.SetActive(j == index);
                }
            });
        }
    }
}
