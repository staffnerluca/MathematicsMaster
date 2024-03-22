using System;

namespace MathMaster;

public class FinishedTasks
{
    public FinishedTasks(int taskID, int userID, float percent)
    {
        this.taskID = taskID;
        this.userID = userID;
        this.percent = percent;
    }

    private int _taskID;
    public int taskID
    {
        get
        { return _taskID; }
        set { _taskID = value; }
    }

    private int _userID;
    public int userID
    {
        get
        {
            return _userID;
        }
        set
        {
            _userID = value;
        }
    }

    private float _percent;
    public float percent
    {
        get
        {
            return _percent;
        }
        set
        {
            //specification of allowed values how well the user finished a task
            if (_percent == 0.0 || _percent == 0.25 || _percent == 0.5 || _percent == 0.75 || _percent == 1.0)
            {
                _percent = value;
            }
            else
            {
                Console.WriteLine("This isn't allowed!"); 
            }
        }
    }
}