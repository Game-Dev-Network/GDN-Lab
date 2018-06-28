using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
///   This ScriptableObject is used to store the data
///   of the player's score.
///   It also stores a method to jump to the ScoreScene
///   that should be updated if the scene name is changed.
/// </summary>
[CreateAssetMenu]
public class Score : ScriptableObject {
  // Variables
  [SerializeField] private HighscoreRowData m_highscoreRowData;
  
  // Properties
  public HighscoreRowData ScoreData { get { return m_highscoreRowData; } }

  // Build Pattern
  public Score SetValue(int value) { m_highscoreRowData.Score = value; return this; }
  public Score SetName(string name) { m_highscoreRowData.Name = name; return this; }

  // Methods
  public void Launch() { SceneManager.LoadScene("ScoreScene"); }
}