using System;
using System.Collections.Generic;
using System.Linq;

namespace CServer
{
    public class CService:ICService
    {
        public List<Project> GetProjects()
        {
            using (var context = new CamozziEntities())
            {
                IQueryable<Project> query = context.Projects;
                return query.ToList();
            }
        }

        public void AddReclamation(Reclamation t)
        {
            using (var context = new CamozziEntities())
            {
                context.Reclamations.Add(t);
                context.SaveChanges();
            }
        }

        public void DeleteReclamation(Reclamation t)
        {
            using (var context = new CamozziEntities())
            {
                context.Reclamations.Remove(t);
                context.SaveChanges();
            }
        }

        public void UpdateReclamation(Reclamation t)
        {
            using (var context = new CamozziEntities())
            {
                context.Reclamations.Attach(t);
                var entry = context.Entry(t);
                entry.Property(e => e.Act).IsModified = true;
                entry.Property(e => e.Count).IsModified = true;
                entry.Property(e => e.Nomenclature).IsModified = true;
                entry.Property(e => e.ReclamationAct).IsModified = true;
                entry.Property(e => e.Send).IsModified = true;
                entry.Property(e => e.Start).IsModified = true;
                entry.Property(e => e.Finish).IsModified = true;
                entry.Property(e => e.Solution).IsModified = true;
                entry.Property(e => e.UserId).IsModified = true;
                entry.Property(e => e.ManagerId).IsModified = true;
                entry.Property(e => e.Comment).IsModified = true;
                entry.Property(e => e.Production).IsModified = true;
                entry.Property(e => e.State).IsModified = true;
                context.SaveChanges();
            }
        }

        public List<Reclamation> GetByDateReclamation(DateTime start, DateTime finish)
        {
            using (var context = new CamozziEntities())
            {
                var proj = (from rec in context.Reclamations
                            where rec.Start > start
                            where rec.Finish < finish
                            select rec).ToList();
                return proj;
            }
        }

        public void AddUser(User t)
        {
            using (var context = new CamozziEntities())
            {
                context.Users.Add(t);
                context.SaveChanges();
            }
        }

        public void DeleteUser(User t)
        {
            using (var context = new CamozziEntities())
            {
                context.Users.Remove(t);
                context.SaveChanges();
            };
        }

        public void UpdateUser(User t)
        {
            using (var context = new CamozziEntities())
            {
                context.Users.Attach(t);
                var entry = context.Entry(t);
                entry.Property(e => e.Name).IsModified = true;
                entry.Property(e => e.Password).IsModified = true;
                entry.Property(e => e.Phone).IsModified = true;
                entry.Property(e => e.Mail).IsModified = true;
                entry.Property(e => e.Comment).IsModified = true;
                context.SaveChanges();
            }
        }

        public void AddProject(Project t)
        {
            using (var context = new CamozziEntities())
            {
                context.Projects.Add(t);
                context.SaveChanges();
            }
        }

        public void DeleteProject(Project t)
        {
            using (var context = new CamozziEntities())
            {
                context.Projects.Remove(t);
                context.SaveChanges();
            }
        }

        public List<User> GetUsers()
        {
            using (var context = new CamozziEntities())
            {
                IQueryable<User> query = context.Users;
                return query.ToList();
            }
        }

        public List<Reclamation> GetReclamations()
        {
            using (var context = new CamozziEntities())
            {
                IQueryable<Reclamation> query = context.Reclamations;
                return query.ToList();
            }
        }

        public List<Project> GetByDateAndDeptProject(DateTime start, DateTime finish, int deptid)
        {
            using (var context = new CamozziEntities())
            {

                //TODO correct LinQ Query
                var proj = (from pr in context.Projects
                            //where pr.Start>Start 
                            where pr.Finish < finish
                            where pr.DeptId == deptid
                            select pr).ToList();
                return proj;
            }

        }

        public void UpdateProject(Project t)
        {
            using (var context = new CamozziEntities())
            {
                context.Projects.Attach(t);
                var entry = context.Entry(t);
                entry.Property(e => e.Name).IsModified = true;
                entry.Property(e => e.Start).IsModified = true;
                entry.Property(e => e.Finish).IsModified = true;
                entry.Property(e => e.UserId).IsModified = true;
                entry.Property(e => e.ManagerId).IsModified = true;
                entry.Property(e => e.Comment).IsModified = true;
                entry.Property(e => e.Priority).IsModified = true;
                entry.Property(e => e.State).IsModified = true;
                context.SaveChanges();
            }
        }
    }
}
