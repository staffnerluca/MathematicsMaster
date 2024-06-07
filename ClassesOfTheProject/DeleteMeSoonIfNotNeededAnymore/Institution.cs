using System;

namespace MathMaster.ClassesOfTheProject.DeleteMeSoonIfNotNeededAnymore;

public class Institution
{
    public Institution(int institutionID, string address, string country, char type, string phonenumber, string email, char postalcode)
    {
        this.institutiionID = institutionID;
        this.address = address;
        this.country = country;
        this.type = type;
        this.phoneNumber = phonenumber;
        this.email = email;
        this.postalcode = postalcode;
    }

    private int _institutionID;
    public int institutiionID
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

    //? makes a variable nullable
    private string? _address;
    public string? address
    {
        get
        {
            return _address;
        }
        set
        {
            _address = value;
        }
    }

    private string? _country;
    public string? country
    {
        get
        {
            return _country;
        }
        set
        {
            _country = value;
        }
    }

    private char _type;
    public char type
    {
        get
        {
            return _type;
        }
        set
        {
            _type = value;
        }
    }

    private int _points;
    public int points
    {
        get
        {
            return _points;
        }
        set
        {
            if(value >= 0 && value < 100)
                _points = value;
        }
    }

    private string _phoneNumber;
    public string phoneNumber
    {
        get
        {
            return _phoneNumber;
        }
        set
        {
            _phoneNumber = value; 
        }
    }

    private string? _email;
    public string? email
    {
        get
        {
            return _email;
        }
        
        set 
        {
            _email = value; 
        }
    }

    private int _group;
    public int group
    {
        get
        {
            return _group;
        }
        set
        {
            _group = value;
            if (value != (-2))
            {
                _group = value;
            }
        }
    }

    private char _postalcode;
    public char postalcode
    {
        get
        {
            return _postalcode;
        }
        set
        {
            _postalcode = value;
        }
    }
}