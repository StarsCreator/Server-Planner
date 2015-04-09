using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace CServer
{
    [ServiceContract]
    internal interface ICService
    {
        [OperationContract]
        List<Project> GetProjects();

        [OperationContract]
        void AddReclamation(Reclamation t);

        [OperationContract]
        void DeleteReclamation(Reclamation t);

        [OperationContract]
        void UpdateReclamation(Reclamation t);

        [OperationContract]
        List<Reclamation> GetByDateReclamation(DateTime start, DateTime finish);

        [OperationContract]
        void AddUser(User t);

        [OperationContract]
        void DeleteUser(User t);

        [OperationContract]
        void UpdateUser(User t);

        [OperationContract]
        void AddProject(Project t);

        [OperationContract]
        void DeleteProject(Project t);

        [OperationContract]
        List<User> GetUsers();

        [OperationContract]
        List<Reclamation> GetReclamations();

        [OperationContract]
        List<Project> GetByDateAndDeptProject(DateTime start, DateTime finish, int deptid);

        [OperationContract]
        void UpdateProject(Project t);
    }
}