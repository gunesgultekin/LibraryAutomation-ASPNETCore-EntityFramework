

using Library.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application.Interfaces
{
    public interface IUsersRepository //: IRepository<Users>
    {
        public void Add(Users entity);
        public void Delete(Users entity);
        public void Update(Users entity);
        public Users GetUserInfo(String userName);
        public bool LoginAuth(string username,string password);
        public int Register(string username,string password,string name,string surname);
    }
}
