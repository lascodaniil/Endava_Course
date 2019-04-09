using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using LibrarieOnline.Model;


namespace LibrarieOnline
{
    public class MyRoleProvider : RoleProvider
    {

        public override string[] GetRolesForUser(string username)
        {
            LibrarieEntities dbContext = new LibrarieEntities();

            User user = dbContext.User.FirstOrDefault(x => x.UserName == username);
            var role = dbContext.UserRole.FirstOrDefault(x => x.RoleId == user.RoleId);
            string result = role.Role;

            string[] raspuns = { result };

            return  raspuns;
        }


        public override string ApplicationName { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

        public override void AddUsersToRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override void CreateRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool DeleteRole(string roleName, bool throwOnPopulatedRole)
        {
            throw new NotImplementedException();
        }

        public override string[] FindUsersInRole(string roleName, string usernameToMatch)
        {
            throw new NotImplementedException();
        }

        public override string[] GetAllRoles()
        {
            throw new NotImplementedException();
        }

        
        public override string[] GetUsersInRole(string roleName)
        {
            throw new NotImplementedException();
        }

        public override bool IsUserInRole(string username, string roleName)
        {
            throw new NotImplementedException();
        }

        public override void RemoveUsersFromRoles(string[] usernames, string[] roleNames)
        {
            throw new NotImplementedException();
        }

        public override bool RoleExists(string roleName)
        {
            throw new NotImplementedException();
        }
    }
}