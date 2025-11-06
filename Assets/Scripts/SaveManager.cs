using UnityEngine;

public static class SaveManager
{
    // 이름 저장
    public static void SavePlayerName(string name)
    {
        PlayerPrefs.SetString("PlayerName", name);
        PlayerPrefs.Save();
    }

    // 이름 불러오기
    public static string LoadPlayerName()
    {
        return PlayerPrefs.GetString("PlayerName", "");
    }

    // 이름 저장
    public static void SaveHighScorePlayerName(string name)
    {
        PlayerPrefs.SetString("HighPlayerName", name);
        PlayerPrefs.Save();
    }

    // 이름 불러오기
    public static string LoadHighScorePlayerName()
    {
        return PlayerPrefs.GetString("HighPlayerName", "");
    }


    // 최고점 저장
    public static void SaveHighScore(int score)
    {
        PlayerPrefs.SetInt("HighScore", score);
        PlayerPrefs.Save();
    }

    // 최고점 불러오기
    public static int LoadHighScore()
    {
        return PlayerPrefs.GetInt("HighScore", 0);
    }

    // 초기화(테스트용)
    public static void ResetAll()
    {
        PlayerPrefs.DeleteAll();
    }
}
