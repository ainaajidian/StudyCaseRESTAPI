using EnrollmentService.Models;
using Microsoft.EntityFrameworkCore;
using EnrollmentService.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EnrollmentService.Data
{
    public class EnrollmentDAL : IEnrollment
    {
        private ApplicationDbContext _db;
        public EnrollmentDAL(ApplicationDbContext db)
        {
            _db = db;
        }

        public async Task Delete(string id)
        {
            try
            {
                var result = await GetById(id);
                if (result == null) throw new Exception($"data course {id} tidak ditemukan");
                _db.Enrollments.Remove(result);
                await _db.SaveChangesAsync();
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"error: {dbEx.Message}");
            }
        }

        public async Task<IEnumerable<Enrollment>> GetAll()
        {
            var results = await (from e in _db.Enrollments
                                 orderby e.EnrollmentID ascending
                                 select e).AsNoTracking().ToListAsync();
            return results;
        }

        public async Task<Enrollment> GetById(string id)
        {
            var result = await (from e in _db.Enrollments
                                where e.EnrollmentID == Convert.ToInt32(id)
                                select e).SingleOrDefaultAsync();
            if (result == null) throw new Exception($"data id {id} tidak ditemukan");

            return result;
        }

        public async Task<Enrollment> Insert(Enrollment obj)
        {
            try
            {
                _db.Enrollments.Add(obj);
                await _db.SaveChangesAsync();
                return obj;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error: {dbEx.Message}");
            }
        }

        public async Task<Enrollment> Update(string id, Enrollment obj)
        {
            try
            {
                var result = await GetById(id);
                result.CourseID = obj.CourseID;
                result.StudentID = obj.StudentID;
                result.Grade = obj.Grade;
                await _db.SaveChangesAsync();
                obj.EnrollmentID = Convert.ToInt32(id);
                return obj;
            }
            catch (DbUpdateException dbEx)
            {
                throw new Exception($"Error: {dbEx.Message}");
            }
        }
    }
}
