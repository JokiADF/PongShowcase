using TMPro;
using UnityEngine;

namespace _Project.CodeBase.UI.Elements
{
    public class ScoreOnResult : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI score;

        public void UpdateValueScore(int value) => 
            score.text = value.ToString();
    }
}
