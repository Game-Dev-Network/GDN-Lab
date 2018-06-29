using UnityEngine;
using UnityEngine.UI;

/// <summary>
///   Component used to update visually each Row.
/// </summary>
public class HighscoreRow : MonoBehaviour {
  // Constants
  private const int INDEX_POSITION = 0,
                    INDEX_NAME = 1,
                    INDEX_SCORE = 2;

  // Variables
  private Text[] m_contents;
  private Image m_image;
  private int m_position, m_score;

  // Properties
  private int Position {
    get { return m_position; }
    set {
      m_position = value;
      m_contents[INDEX_POSITION].text = m_position.ToString() + ".";
    }
  }

  private string PlayerName {
    get { return m_contents[INDEX_NAME].text; }
    set { m_contents[INDEX_NAME].text = value; }
  }

  private int Score {
    get { return m_score; }
    set {
      m_score = value;
      m_contents[INDEX_SCORE].text = m_score.ToString();
    }
  }

  // Builder Pattern
  public HighscoreRow SetPosition(int position) { Position = position; return this; }
  public HighscoreRow SetColor(Color color) { m_image.color = color; return this; }
  public HighscoreRow SetData(HighscoreRowData hsrData) {
    PlayerName = hsrData.Name;
    Score = hsrData.Score;
    return this;
  }
  
  // Methods
  private void Awake() {
    m_contents = GetComponentsInChildren<Text>();
    m_image = GetComponent<Image>();
  }
}