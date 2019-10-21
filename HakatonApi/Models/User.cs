using System;
using System.Collections.Generic;

namespace HakatonApi.Models
{
    public partial class User
    {
        public User()
        {
            WaitingTask = new HashSet<WaitingTask>();
        }

        public int IdUser { get; set; }
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        public string UserType { get; set; }

        public virtual ICollection<WaitingTask> WaitingTask { get; set; }
    }
}
