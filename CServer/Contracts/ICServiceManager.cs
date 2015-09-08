using System;
using System.Collections.Generic;
using System.ServiceModel;
using DataController.DTO_Model;

namespace CServer.Contracts
{
    [ServiceContract(CallbackContract = typeof (ICService))]
    internal interface ICServiceManager
    {
        [OperationContract(IsOneWay = true)]
        void RegisterClient(string name);

        [OperationContract(IsOneWay = true)]
        void RemoveClient(string name);

        [OperationContract]
        List<ProjectDto> GetProjects();

        [OperationContract(IsOneWay = true)]
        void AddUser(UserDto t);

        [OperationContract(IsOneWay = true)]
        void DeleteUser(UserDto t);

        [OperationContract(IsOneWay = true)]
        void UpdateUser(UserDto t);

        [OperationContract(IsOneWay = true)]
        void AddProject(ProjectDto t);

        [OperationContract(IsOneWay = true)]
        void DeleteProject(ProjectDto t);

        [OperationContract]
        List<UserDto> GetUsers();

        [OperationContract]
        bool CheckPassword(string password, int id);

        [OperationContract]
        List<ProjectDto> GetByDateAndDeptProject(DateTime start, DateTime finish, int deptid);

        [OperationContract(IsOneWay = true)]
        void UpdateProject(ProjectDto t);
    }

    [ServiceContract]
    internal interface ICService
    {
        [OperationContract(IsOneWay = true)]
        void SendUpdates(List<ProjectDto> projectlist, List<UserDto> userlist);
    }
}