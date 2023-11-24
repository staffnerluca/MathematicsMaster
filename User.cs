namespace MathMaster
{
    public class User
    {
        public User(int userid, string username, string useremail, string userpw, int points, bool isteacher, DateTime lastlogin, DateTime lastlogout, bool darkmode, DateTime birthdate)
        {
            this.userId = userid;
            this.userName = username;
            this.userEmail = useremail;
            this.userPw = userpw;
            this.points = points;
            this.isTeacher = isteacher;
            this.lastLogin = lastlogin;
            this.lastLogout = lastlogout;
            this.darkMode = darkmode;
            this.birthDate = birthdate;
        }

        private int _userId;
        public int userId
        {
            get
            {
                return _userId;
            }
            set
            {
                _userId = value;
            }
        }

        private string _userName;
        public string userName
        {
            get
            {
                return _userName;
            }
            set
            {
                _userName = value;
            }
        }

        private string _userEmail;
        public string userEmail
        {
            get
            {
                return _userEmail;
            }
            set
            {
                _userEmail = value;
            }
        }

        private string _userPw;
        public string userPw
        {
            get
            {
                return _userPw;
            }
            set
            {
                _userPw = value;
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
                if (value >= 0 && value < 100)
                    _points = value;
            }
        }

        private bool _isTeacher;
        public bool isTeacher
        {
            get
            {
                return _isTeacher;
            }
            set
            {
                _isTeacher = value;
            }
        }

        private DateTime _lastLogin;
        public DateTime lastLogin
        {
            get
            {
                return _lastLogin;
            }
            set
            {
                _lastLogin = value;
            }
        }

        private DateTime _lastLogout;
        public DateTime lastLogout
        {
            get
            {
                return _lastLogout;
            }
            set
            {
                _lastLogout = value;
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

        private bool _darkMode;
        public bool darkMode
        {
            get
            {
                return _darkMode;
            }
            set
            {
                _darkMode = value;
            }
        }

        private DateTime _birthDate;
        public DateTime birthDate
        {
            get
            {
                return _birthDate;
            }
            set
            {
                _birthDate = value;
            }
        }
    }
}
