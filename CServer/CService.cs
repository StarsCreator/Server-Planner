using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using DataController;
using DataController.DTO_Model;

namespace CServer
{
    public class CService : ICService
    {
        public CService()
        {
            Mapper.CreateMap<ProjectDb, Project>();
            Mapper.CreateMap<AccountDb, Account>();
            Mapper.CreateMap<DeptDb, Dept>();
            Mapper.CreateMap<ReclamationDb, Reclamation>();
            Mapper.CreateMap<UserDb, User>();
            Mapper.CreateMap<Project, ProjectDb>();
        }

        public List<Project> GetProjects()
        {
            var list = new List<Project>();

            using (var context = new CamozziEntities())
            {
                foreach (var userDb in context.ProjectDbs.Where(x=>x.Start<=new DateTime(2015,3,1)))
                {
                    var user = Mapper.Map<Project>(userDb);
                    list.Add(user);
                }
            }
            return list;
        }

        public void AddReclamation(Reclamation t)
        {
            var reclamation = new ReclamationDb()
            {
                Act = t.Act,
                Client = t.Client,
                Comment = t.Comment,
                Finish = t.Finish,
                ReclamationAct = t.ReclamationAct,
                Start = t.Start,
                State = t.State,
                Solution = t.Solution,
                Production = t.Production,
                Send = t.Send,
                Nomenclature = t.Nomenclature,
                Count = t.Count,
                ManagerId = t.ManagerId,
                UserId = t.UserId,
                CreatorId = t.CreatorId
            };
            using (var context = new CamozziEntities())
            {
                context.ReclamationDbs.Add(reclamation);
                context.SaveChanges();
            }
            Console.WriteLine("Reclamation Add");
        }

        public void DeleteReclamation(Reclamation t)
        {
            using (var context = new CamozziEntities())
            {
                context.ReclamationDbs.Remove(context.ReclamationDbs.Find(t.Id));
                context.SaveChanges();
            }
        }

        public void UpdateReclamation(Reclamation t)
        {
            using (var context = new CamozziEntities())
            {
                var reclamation = context.ReclamationDbs.Find(t.Id);
                reclamation.Act = t.Act;
                reclamation.Client = t.Client;
                reclamation.Comment = t.Comment;
                reclamation.Finish = t.Finish;
                reclamation.ReclamationAct = t.ReclamationAct;
                reclamation.Start = t.Start;
                reclamation.State = t.State;
                reclamation.Solution = t.Solution;
                reclamation.Production = t.Production;
                reclamation.Send = t.Send;
                reclamation.Nomenclature = t.Nomenclature;
                reclamation.Count = t.Count;
                reclamation.ManagerId = t.ManagerId;
                reclamation.UserId = t.UserId;
                reclamation.CreatorId = t.CreatorId;
                //context.ReclamationDbs.Add(reclamation);
                context.SaveChanges();
            }
        }

        public List<Reclamation> GetByDateReclamation(DateTime start, DateTime finish)
        {
            var list = new List<Reclamation>();
            using (var context = new CamozziEntities())
            {
                var proj = (from rec in context.ReclamationDbs
                    where rec.Start > start
                    where rec.Finish < finish
                    select rec).ToList();

                list.AddRange(proj.Select(Mapper.Map<Reclamation>));
            }

            return list;
        }

        public void AddUser(User t)
        {
            var user = new UserDb()
            {
                AccountId = t.AccountId,
                Comment = t.Comment,
                DeptId = t.DeptId,
                Mail = t.Mail,
                Name = t.Name,
                Password = "123",
                Phone = t.Phone
            };

            using (var context = new CamozziEntities())
            {
                context.UserDbs.Add(user);
                context.SaveChanges();
            }
        }

        public void DeleteUser(User t)
        {
            using (var context = new CamozziEntities())
            {
                context.UserDbs.Remove(context.UserDbs.Find(t.Id));
                context.SaveChanges();
            }
        }

        public void UpdateUser(User t)
        {
            using (var context = new CamozziEntities())
            {
                var user = context.UserDbs.Find(t.Id);
                //context.UserDbs.Attach(Mapper.Map<UserDb>(t));
                //var entry = context.Entry(t);
                user.Mail = t.Mail;
                user.Comment = t.Comment;
                //user.Name = t.Name;
                user.Phone = t.Phone;               
                context.SaveChanges();
            }
        }

        public void AddProject(Project t)
        {
            var project = new ProjectDb()
            {
                CreationDate = t.CreationDate,
                Comment = t.Comment,
                CreatorId = t.CreatorId,
                DeptId = t.DeptId,
                Finish = t.Finish,
                ManagerId = t.ManagerId,
                Name = t.Name,
                Priority = t.Priority,
                Start = t.Start,
                State = t.State,
                UserId = t.UserId
            };
            using (var context = new CamozziEntities())
            {
                context.ProjectDbs.Add(project);
                context.SaveChanges();
            }
            Console.WriteLine("Project Add");
        }

        public void DeleteProject(Project t)
        {
            using (var context = new CamozziEntities())
            {
                context.ProjectDbs.Remove(context.ProjectDbs.Find(t.Id));
                context.SaveChanges();
            }
        }

        public List<User> GetUsers()
        {
            var list = new List<User>();

            using (var context = new CamozziEntities())
            {
                foreach (var userDb in context.UserDbs)
                {
                    var user = Mapper.Map<User>(userDb);
                    list.Add(user);
                }
            }
            return list;
        }

        public List<Reclamation> GetReclamations()
        {
            var list = new List<Reclamation>();

            using (var context = new CamozziEntities())
            {
                foreach (var userDb in context.ReclamationDbs)
                {
                    var user = Mapper.Map<Reclamation>(userDb);
                    list.Add(user);
                }
            }
            return list;
        }

        public List<Project> GetByDateAndDeptProject(DateTime start, DateTime finish, int deptid)
        {
            List<Project> list = null;
            using (var context = new CamozziEntities())
            {//TODO
                var proj = (from rec in context.ProjectDbs
                    //where rec.Start > start
                    where rec.Finish < finish
                    select rec).ToList();

                list.AddRange(proj.Select(Mapper.Map<Project>));
            }

            return list;
        }

        public void UpdateProject(Project t)
        {
            using (var context = new CamozziEntities())
            {
                var project = context.ProjectDbs.First(x => x.Id == t.Id);
                project.CreationDate = t.CreationDate;
                project.Comment = t.Comment;
                project.CreatorId = t.CreatorId;
                project.DeptId = t.DeptId;
                project.Finish = t.Finish;
                project.ManagerId = t.ManagerId;
                project.Name = t.Name;
                project.Priority = t.Priority;
                project.Start = t.Start;
                project.State = t.State;
                project.UserId = t.UserId;
                context.SaveChanges();
            }
        }

        public bool CheckPassword(string password,int id)
        {
            string psw;
            using (var db = new CamozziEntities())
            {
                psw = db.UserDbs.First(x => x.Id == id).Password;
            }
            return psw == password;
        }
    }
}