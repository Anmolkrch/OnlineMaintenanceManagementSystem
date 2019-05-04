using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceMaintanance.Model.Master;
using ServiceMaintanance.ViewModel;

namespace ServiceMaintanance.Service.UserService
{
    public interface IUserService
    {
        /// <summary>
        /// User authentication on login
        /// </summary>
        /// <param name="loginViewModel"></param>
        /// <returns></returns>
        UserViewModel LoginAuthentication(LoginViewModel loginViewModel);


        /// <summary>
        /// Update user status on logout
        /// </summary>
        /// <param name="userId"></param>
        void UserLogOff(string userId);


        /// <summary>
        /// Save Users
        /// </summary>
        /// <param name="user"></param>
        /// <param name="logId"></param>
        /// <param name="validateOnSaveEnabled"></param>
        /// <param name="mailBodyTemplate"></param>
        /// <returns></returns>
        bool SaveUsers(UserViewModel userViewModel, long logId = 0, bool validateOnSaveEnabled = true, string mailBodyTemplate = "");

        /// <summary>
        /// Update User information
        /// </summary>
        /// <param name="user"></param>        
        /// <returns></returns>
        bool UpdateUsers(UserViewModel userViewModel);


        /// <summary>
        /// Delete user
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        //int Delete(long UserId);

        /// <summary>
        /// Get all Users
        /// </summary>
        /// <param name="searchingParams"></param>
        /// <returns></returns>
        //List<UserViewModel> GetAllUsers(SearchingParams searchingParams);

        /// <summary>
        /// Get all users for drop down (get only Id and Name)
        /// </summary>
        /// <param name="searchingParams"></param>
        /// <returns></returns>
       
        /// <summary>
        /// Get user detail by Id
        /// </summary>
        /// <param name="UserId"></param>
        /// <returns></returns>
        UserViewModel GetUsersDetailsById(long UserId);

        /// <summary>
        /// Get user detail by email
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        UserViewModel GetUsersDetailsByEmail(string email);
       

        /// <summary>
        /// Check for User email exists
        /// </summary>
        /// <param name="emailAddress"></param>
        /// <param name="id"></param>
        /// <returns></returns>
        bool IsUserExists(string emailAddress, string id);


        /// <summary>
        /// Change password after logged in
        /// </summary>
        /// <param name="userId"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        //bool ChangePassword(string userId, string password);


        /// <summary>
        /// Change password on account activation
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        //UserViewModel ChangePassword(ChangePasswordViewModel model);


        /// <summary>
        /// Change Account status of user
        /// </summary>
        /// <param name="id"></param>
        /// <param name="accountStatus"></param>
        /// <returns></returns>
        //MyJsonResult ChangeAccountStatus(long id, int accountStatus);

        /// <summary>
        /// Get all user Types
        /// </summary>
        /// <returns></returns>
        List<UserTypeViewModel> GetUserTypes();

        List<UserViewModel> GetAllUsers(SearchingParams searchingParams);
    }
}
