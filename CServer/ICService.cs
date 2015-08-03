using System;
using System.Collections.Generic;
using System.ServiceModel;
using DataController.DTO_Model;

namespace CServer
{
    [ServiceContract]
    internal interface ICService
    {

        [OperationContract]
        List<ProjectDto> GetProjects();

        [OperationContract]
        void AddUser(UserDto t);

        [OperationContract]
        void DeleteUser(UserDto t);

        [OperationContract]
        void UpdateUser(UserDto t);

        [OperationContract]
        void AddProject(ProjectDto t);

        [OperationContract]
        void DeleteProject(ProjectDto t);

        [OperationContract]
        List<UserDto> GetUsers();

        [OperationContract]
        bool CheckPassword(string password, int id);

        [OperationContract]
        List<ProjectDto> GetByDateAndDeptProject(DateTime start, DateTime finish, int deptid);

        [OperationContract]
        void UpdateProject(ProjectDto t);
    }
}