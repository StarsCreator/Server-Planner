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
            Mapper.CreateMap<AccountDb, AccountDto>();
            Mapper.CreateMap<DeptDb, DeptDto>();
            Mapper.CreateMap<UserDb, UserDto>()
                .ForMember(x => x.AccountDto, opt => opt.MapFrom(a => Mapper.Map<AccountDb, AccountDto>(a.AccountDb)))
                .ForMember(x => x.DeptDto, opt => opt.MapFrom(a => Mapper.Map<DeptDb, DeptDto>(a.DeptDb)));
            Mapper.CreateMap<ProjectDb, ProjectDto>()
                .ForMember(x => x.Creator, opt => opt.MapFrom(a => Mapper.Map<UserDb, UserDto>(a.CreatorDb)))
                .ForMember(x => x.Manager, opt => opt.MapFrom(a => Mapper.Map<UserDb, UserDto>(a.ManagerDb)))
                .ForMember(x => x.Worker, opt => opt.MapFrom(a => Mapper.Map<UserDb, UserDto>(a.WorkerDb)));
        }

        public List<ProjectDto> GetProjects()
        {
            var list = new List<ProjectDto>();

            var thisTime = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            using (var context = new CamozziEntities())
            {
                foreach (var projectDb in context.ProjectDbs.Where(x => x.Finish >= thisTime))
                {
                    var user = Mapper.Map<ProjectDto>(projectDb);
                    list.Add(user);
                }
            }
            return list;
        }

        public void AddUser(UserDto t)
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
                user.QueryId = user.Id;
                context.SaveChanges();
            }
        }

        public void DeleteUser(UserDto t)
        {
            using (var context = new CamozziEntities())
            {
                context.UserDbs.Remove(context.UserDbs.Find(t.Id));
                context.SaveChanges();
            }
        }

        public void UpdateUser(UserDto t)
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

        public void AddProject(ProjectDto t)
        {
            var project = new ProjectDb
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
                Console.WriteLine("------------------------------------------------------------");
                Console.WriteLine(DateTime.Now+" Project Added by " + context.UserDbs.First(x=>x.Id==project.CreatorId).Name);
            }
        }

        public void DeleteProject(ProjectDto t)
        {
            using (var context = new CamozziEntities())
            {
                context.ProjectDbs.Remove(context.ProjectDbs.Find(t.Id));
                context.SaveChanges();
            }
        }

        public List<UserDto> GetUsers()
        {
            var list = new List<UserDto>();

            using (var context = new CamozziEntities())
            {
                foreach (var userDb in context.UserDbs)
                {
                    var user = Mapper.Map<UserDb, UserDto>(userDb);
                    list.Add(user);
                }
            }
            //Console.WriteLine("GetUsers");
            return list;
        }

        public List<ProjectDto> GetByDateAndDeptProject(DateTime start, DateTime finish, int deptid)
        {
            List<ProjectDto> list = null;
            using (var context = new CamozziEntities())
            {
//TODO
                var proj = (from rec in context.ProjectDbs
                    //where rec.Start > start
                    where rec.Finish < finish
                    select rec).ToList();

                list.AddRange(proj.Select(Mapper.Map<ProjectDto>));
            }

            return list;
        }

        public void UpdateProject(ProjectDto t)
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

        public bool CheckPassword(string password, int id)
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