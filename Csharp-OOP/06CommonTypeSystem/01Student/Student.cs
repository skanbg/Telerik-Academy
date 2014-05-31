using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01Student
{
    public class Student : ICloneable, IComparable<Student>
    {
        public string FirstName { get; set; }
        public string MiddleName { get; set; }
        public string LastName { get; set; }
        public int SSN { get; set; }
        public string Address { get; set; }
        public int MobilePhone { get; set; }
        public string Email { get; set; }
        public int Course { get; set; }
        public Faculties Faculty { get; set; }
        public Specialties Specialty { get; set; }
        public Universities University { get; set; }

        public Student(string firstName, string middleName, string lastName, int ssn, string address, int mobilePhone, string email, int course, Faculties faculty, Specialties specialty, Universities university)
        {
            this.FirstName = firstName;
            this.MiddleName = middleName;
            this.LastName = lastName;
            this.SSN = ssn;
            this.Address = address;
            this.MobilePhone = mobilePhone;
            this.Email = email;
            this.University = university;
            this.Specialty = specialty;
            this.Course = course;
            this.Faculty = faculty;
        }

        public override bool Equals(object obj)
        {
            Student parsed = obj as Student;
            if (this.SSN == parsed.SSN)
            {
                return true;
            }
            return false;
        }

        public override string ToString()
        {
            return string.Format("SSN: {3} Student Name: {0} {1} {2}", this.FirstName, this.MiddleName, this.LastName, this.SSN);
        }

        public static bool operator ==(Student fStudent, Student sStudent)
        {
            return fStudent.SSN == sStudent.SSN;
        }

        public static bool operator !=(Student fStudent, Student sStudent)
        {
            return fStudent.SSN != sStudent.SSN;
        }

        public override int GetHashCode()
        {
            //SSN is unique for every student
            return this.SSN;
        }

        public object Clone()
        {
            return new Student(this.FirstName, this.MiddleName, this.LastName, this.SSN, this.Address, this.MobilePhone, this.Email, this.Course, this.Faculty, this.Specialty, this.University);
        }

        public int CompareTo(Student other)
        {
            if (this.FirstName.CompareTo(other.FirstName) != 0)
            {
                return this.FirstName.CompareTo(other.FirstName);
            }
            else if (this.MiddleName.CompareTo(other.MiddleName) != 0)
            {
                return this.MiddleName.CompareTo(other.MiddleName);
            }
            else if (this.LastName.CompareTo(other.LastName) != 0)
            {
                return this.LastName.CompareTo(other.LastName);
            }
            else if (this.SSN.CompareTo(other.SSN) != 0)
            {
                return this.SSN.CompareTo(other.SSN);
            }
            else
            {
                return 0;
            }
        }
    }
}
