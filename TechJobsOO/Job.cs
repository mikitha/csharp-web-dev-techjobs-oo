using System;
namespace TechJobsOO
{
    public class Job
    {
        public int Id { get; }
        private static int nextId = 1;
       

        public string Name { get; set; }
        public Employer EmployerName { get; set; }
        public Location EmployerLocation { get; set; }
        public PositionType JobType { get; set; }
        public CoreCompetency JobCoreCompetency { get; set; }

        // TODO: Add the two necessary constructors.XX
        public Job() 
        {
            Id = nextId;
            nextId++;
        }

        public Job(string name, Employer employer, Location location, PositionType jobtype, CoreCompetency jobCoreCompetency) :this()
        {
            Name = name;
            EmployerName = employer;
            EmployerLocation = location;
            JobType = jobtype;
            JobCoreCompetency = jobCoreCompetency;
        }


        public override bool Equals(object obj)
        {
            return obj is Job job &&
                   Id == job.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }

        public override string ToString()

        //My idea: deal with the Null Exceptions on the empty Job() consructor by making a dummy object in this ToString method that assigns "Data not available" to all fields.
        //Refined more efficient idea: Reverse the if statements 
        //Reverse if statements: currently (10/23 2:42PM) the if statements in the ToString method assign "Data not available" to null or empty string fields on each object(employerName, jobType, etc.), which causes null errors
        //if the empty Job() constuctor is used (resulting in a failed test for the TestToStringForSpaces() test), since the ToString method is expecting all the objects to exist (employerName, etc). By automatically assigning "Data
        //not available" to the job object fields at the start of ToString(), and then assigning their actual values in the if statements (IF they aren't null or empty), those null exception errors will stop.
        //The "My Idea" path, while it might work, results in a bunch of dummy objects being made which is probably not great for performance.
        {
            string jobName = "Data not available";
            string employerName = "Data not available";
            string employerLocation = "Data not available";
            string jobType = "Data not available";
            string jobCoreCompetency = "Data not available";
            bool hasInfo = false;


            if (Name != null && !Name.Equals(""))
            {
                hasInfo = true;
                jobName = Name;
         
            }
            if (EmployerName != null && EmployerName.Value != null && !EmployerName.Value.Equals(""))
            {
                hasInfo = true;
                employerName = EmployerName.Value;

            }
            if (EmployerLocation != null && EmployerName.Value != null && !EmployerLocation.Value.Equals(""))
            {
                hasInfo = true;
                employerLocation = EmployerLocation.Value; 
            }
            if (JobType != null && EmployerName.Value != null && !JobType.Value.Equals(""))
            {
                hasInfo = true;
                jobType = JobType.Value;
            }
            if (JobCoreCompetency != null && EmployerName.Value != null && !JobCoreCompetency.Value.Equals(""))
            {
                hasInfo = true;
                jobCoreCompetency = JobCoreCompetency.Value;
            }

            if (hasInfo == false)
            {
                return "\n" + "OOPS! This job does not seem to exist." + "\n";
            }
            else
            {

                return "\n" +
                    "ID: " + Id + "\n" +
                    "Name: " + jobName + "\n" +
                    "Employer: " + employerName + "\n" +
                    "Location: " + employerLocation + "\n" +
                    "Position Type: " + jobType + "\n" +
                    "Core Competency: " + jobCoreCompetency + "\n";
            }
        
        }



        // TODO: Generate Equals() and GetHashCode() methods.XX
    }
}
