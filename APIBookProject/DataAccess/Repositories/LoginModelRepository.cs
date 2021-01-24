using DataAccess;
using DataStructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DataAccess.Repositories
{
    public class LoginModelRepository
    {
        private AppDbContext appDbContext;
        public LoginModelRepository(AppDbContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public LoginModel CreateUser(LoginModel loginModel)
        {
            appDbContext.LoginModels.Add(loginModel);
            appDbContext.SaveChanges();
            return loginModel;
        }

        public LoginModel GetByName(string name)
        {
            LoginModel loginModel = new LoginModel();
            loginModel = appDbContext.LoginModels.Where(x=>x.UserName==name).FirstOrDefault();
            return loginModel;
        }
    }
}
