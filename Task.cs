namespace MathMaster;

public class Task
{
    private static maxPoints = 100;
    public Task(int tasknr, string taskname, )
    {
        tasknr = taskNr;
        taskname = taskName;

    }   


    private int _tasknr;
    public int taskNr
    {
        get
        {
            return _tasknr;
        }
        set
        {
            _tasknr = value;
        }
    }

    private string _taskname;
    public string taskName
    {
        get
        {
            return _taskname;
        }
        set
        {
            _taskname = value;
        }
    }

    private string _tasksector;
    public string taskSector
    {
        get
        {
            return _tasksector;
        }
        set
        {
            _tasksector = value;
        }
    }

    private int _difficulty;
    public int difficulty
    {
        get
        {
            return _difficulty;
        }
        set
        {
            _difficulty = value;
        }
    }

    private int _points;
    public uint points
    {
        get
        {
            return _points;
        }
        set
        {
            if(value >= 0 && value < )
            _points = value;
        }
    }

    private bool _drawing;
    public bool drawing
    {
        get
        {
            return _drawing;
        }
        set
        {
            _drawing = value;
        }
    }

    private string _question;
    public string uestion
    {
        get
        {
            return _question;
        }
        set 
        {
            _question = value; 
        }
    }

    private string _answer;
    public string answer
    {
        get
        {
            return _answer;
        }
        set 
        {
            _answer = value; 
        }
    }

    private string _source;
    public string source
    {
        get
        {
            return _source;
        }
        
        set 
        {
            _source = value; 
        }
    }

    private string _group;
    public string group
    {
        get
        {
            return _group;
        }
        set
        {
            _group = value;
            if (value != -2)
            {
                _group = value;
            }
        }
    }

    private string _image;
    public string image
    {
        get
        {
            return _image;
        }
        set
        {
            _image = value;
        }
    }
}