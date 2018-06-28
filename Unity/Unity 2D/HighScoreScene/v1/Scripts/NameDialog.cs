using UnityEngine;
using UnityEngine.UI;

/// <summary>
///   This component controls the dialog that appears
///   when the score value doesn't contains information
///   about the player's Name. 
///   When Score already has a Name acts like it was entered
///   in "Insert Name" dialog and it just redirect directly
///   to the HighscoreList.
/// </summary>
public class NameDialog : MonoBehaviour {
  // Variables
  [SerializeField] private Score m_score;
  [SerializeField] private HighscoreList m_scoreList;
  [SerializeField] private Text m_playerName;
  [SerializeField] private Text m_defaultPlayerName;

  // Methods
  private void Start() { if (m_score.ScoreData.Name != "") { CallHighscoreList(); } }

  public void OnOK() {
    m_score.SetName((m_playerName.text == "") ? m_defaultPlayerName.text : m_playerName.text);
    CallHighscoreList();
  }

  private void CallHighscoreList() {
    m_scoreList.gameObject.SetActive(true);
    m_score.SetName("");
    gameObject.SetActive(false);
  }
}
