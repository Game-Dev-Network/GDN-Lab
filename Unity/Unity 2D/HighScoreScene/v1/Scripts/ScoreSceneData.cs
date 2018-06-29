using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///   This ScriptableObject is used to store the data
///   related to:
///    + The name of the scene that it will trun when clicked the goback button.   
///    + Highlight color for new score.
///    + Default Highscores.
/// </summary>
[CreateAssetMenu]
public class ScoreSceneData : ScriptableObject{
  // Variables
  [SerializeField] private string m_sceneBack;
  [SerializeField] private Color m_newHighscoreColor;
  [SerializeField] private HighscoreRowData[] m_defaultHighScores;
  private int m_index;

  // Properties
  public Color NewHighscoreColor { get { return m_newHighscoreColor; } }

  // Methods
  public HighscoreRowData Peek() { return m_defaultHighScores[m_index]; }
  public HighscoreRowData Dequeue() { return m_defaultHighScores[m_index++]; }

  public void ResetIndex() { m_index = 0; }

  public void GoBack() { SceneManager.LoadScene(m_sceneBack); }
}