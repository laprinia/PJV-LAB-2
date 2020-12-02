using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{
   public static int scoreValue = 0;
   private Text score;

   private void Start()
   {
      score = GetComponent<Text>();
   }

   private void Update()
   {
      score.text = "Score " + scoreValue;
   }
}
