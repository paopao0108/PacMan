using System;

public class GameModel 
{
    private static GameModel _instance;
    private int _score; // ���ʤ���ķ���

    private GameModel() { }

    public int Score { get => _score; }

    public static GameModel GetInstance()
    {
        if (_instance == null) _instance = new GameModel();
        return _instance;
    }
}
