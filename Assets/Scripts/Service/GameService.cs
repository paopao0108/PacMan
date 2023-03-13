using System;

public class GameService
{
    private static GameService _instance;

    private GameService() { }
    public static GameService GetInstanvce()
    {
        if (_instance == null) _instance = new GameService();
        return _instance;
    }

    public void GameOver()
    {
        // 失败
        // 1. 碰到敌人
        // 2. 走出迷宫

        // 胜利
        // 3. 吃完豆子，并且在迷宫中
        if (ScoreModel.GetInstance().CurScore >= GameModel.GetInstance().Score)
        {
            Console.WriteLine("游戏胜利！！");
        }
         
    }
}
