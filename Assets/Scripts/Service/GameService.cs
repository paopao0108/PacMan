using System;

public class GameService
{
    private static GameService _instance;

    private GameService() { }
    public static GameService GetInstance()
    {
        if (_instance == null) _instance = new GameService();
        return _instance;
    }

    public bool IsSuccess()
    {
        // 失败
        // 1. 碰到敌人
        // 2. 走出迷宫

        // 胜利
        // 3. 吃完豆子，并且在迷宫中
        //Console.WriteLine("当前分数：" + ScoreModel.GetInstance().CurScore);
        //Console.WriteLine("目标分数：" + GameModel.GetInstance().Score);
        if (ScoreModel.GetInstance().CurScore >= GameModel.GetInstance().Score)
        {
            return true;
        }
        return false;
    }

    public void Fail()
    {
        // 处理失败逻辑
    }

    public void Success()
    {
        // 处理成功逻辑
    }
}
