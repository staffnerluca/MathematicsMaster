using System;

namespace MathMaster.ClassesOfTheProject.DeleteMeSoonIfNotNeededAnymore
{
    public class UserAndGroups
    {
        public UserAndGroups(int UID, int GID)
        {
            this.UID = UID;
            this.GID = GID;
        }

        private int _UID;
        public int UID
        {
            get
            {
                return _UID;
            }
            set
            {
                _UID = value;
            }
        }

        private int _GID;
        public int GID
        {
            get
            {
                return _GID;
            }
            set
            {
                _GID = value;
            }
        }
    }
}