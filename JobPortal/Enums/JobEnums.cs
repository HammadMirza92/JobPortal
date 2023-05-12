using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel;

namespace JobPortal.Enums
{
    public enum JobStatus
    {
       
        Open = 0,
        Close = 1
    }
    public enum JobType
    {
        FullTime = 0,
        Freelance = 1,
        Contract = 2,
        Internship = 3,
        Temporary = 4,
        PartTime = 5
    }
    public enum Location
    {
        Lahore = 0,
        Islamabad = 1,
        Karachi = 2,
        Multan = 3, 
        Hydarabad = 4,
        Gujranwala = 5,
        Faisalabad = 6,
        Sialkot = 7,
        Peshawar = 8
    }
    public enum Qualification
    {
        Bachelor = 0,
        Master = 1,
        PHD = 2
    }
    public enum SalaryType
    {
        Monthly = 0,
        Weekly = 1,
        Hourly = 2,
        Yearly = 3

    }
    public enum JobClasses
    {
        Feature = 0,
        Urgent = 1,
        Private = 2,
        
    }
    public enum JobSalary
    {
        Monthly =0,
        Weekly = 1,
        Hourly = 2,
        Yearly = 3
    }
    public enum JobExperience
    {
        Fresh = 0,
        Oneyear = 1,
        Twoyears = 2,
        Threeyears = 3,
        Fouryears = 4,
        Fiveyears = 5,
        AboveFive = 6,
    }
    public enum JobShift
    {
        Morning = 0,
        Evening = 1,
        Night = 2,
        Round = 3,
        
    }

}
