using System.Text;
using TMPro;
using UnityEngine;

namespace _Project.CodeBase.UI.Elements
{
    public class ScoreItemText : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI text;

        public void SetText(int score, string data) => 
            text.text = new StringBuilder($"<color=#00ffff>{score}</color> - " + data).ToString();
    }
}