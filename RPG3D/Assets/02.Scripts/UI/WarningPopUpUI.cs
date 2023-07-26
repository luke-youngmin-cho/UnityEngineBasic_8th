using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace RPG.UI
{
    public class WarningPopUpUI : UIMonoBehaviour
    {
        [SerializeField] private TMP_Text _title;
        [SerializeField] private TMP_Text _description;

        public void Show(string title, string description)
        {
            _title.text = title;
            _description.text = description;
            base.Show();
        }

        public void Show(string title, string description, float hideDelay)
        {
            Show(title, description);
            Invoke("Hide", hideDelay);
        }
    }
}