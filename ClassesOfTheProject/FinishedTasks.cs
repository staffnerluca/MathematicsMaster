using System;

namespace MathMaster;

public class Group
{
    public Group(int groupID, string owner, int institutionID)
    {
        this.groupID = groupID;
        this.owner = owner;
        this.institutionID = institutionID;
    }

    private int _groupID;
    public int groupID
    {
        get
        {
            return _groupID;
        }
        set
        {
            _groupID = value;
        }
    }


    private string _owner;
    public int owner
    {
        get
        {
            return _owner;
        }
        set
        {
            _owner = value;
        }
    }

    private int _institutionID;
    public int institutionID
    {
        get
        {
            return _institutionID;
        }
        set
        {
            _institutionID = value;
        }
    }
}