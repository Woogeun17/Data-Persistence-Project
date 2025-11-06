using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;

public class SceneLoader : MonoBehaviour
{
    [Header("UI References")]
    public TMP_InputField nameInputField;
    public Button startButton;
    public Text NameScore;

    private string playerName = "";

    void Start()
    {
        // 시작 시 버튼 비활성화
        startButton.interactable = false;

        // 저장된 이름이 있으면 자동 복원
        if (PlayerPrefs.HasKey("HighPlayerName"))
        {
            playerName = PlayerPrefs.GetString("HighPlayerName");
            NameScore.text = $"Best Score : {playerName} : {SaveManager.LoadHighScore()}";
        }
        else
        {
            NameScore.text = $"Best Score : No Name : 0";
        }

        // InputField가 변경될 때마다 OnNameChanged() 실행
        nameInputField.onValueChanged.AddListener(OnNameChanged);
    }

    // 이름 입력 시마다 호출
    void OnNameChanged(string value)
    {
        playerName = value.Trim(); // 공백 제거
        startButton.interactable = playerName.Length > 0;
    }


    public void LoadGameScene()
    {
        if (string.IsNullOrEmpty(playerName))
        {
            Debug.Log("이름이 비어 있습니다!");
            return;
        }

        // 이름 저장 (PlayerPrefs를 이용해 세션 유지 가능)
        SaveManager.SavePlayerName(playerName);


        SceneManager.LoadScene(1);
    }

    public void QuitGame()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false; // 에디터에서는 Play 모드 종료
#else
        Application.Quit(); // 빌드된 게임에서는 완전 종료
#endif
    }

    public void ResetGame()
    {
        SaveManager.ResetAll();
        NameScore.text = $"Best Score : No Name : 0";
    }
}
