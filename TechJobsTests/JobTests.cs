using Microsoft.VisualStudio.TestTools.UnitTesting;
using TechJobsOO;

namespace TechJobsTests
{
    [TestClass]
    public class JobTests
    {
        [TestMethod]
        public void TestSettingJobId()
        {
            Job jorb1 = new Job();
            Job jorb2 = new Job();

            Assert.IsTrue(jorb2.Id - jorb1.Id == 1);
            Assert.IsTrue(jorb1.Id != jorb2.Id);
        }
        [TestMethod]
        public void TestJobConstructorSetsAllFields()
        {
            Employer employer = new Employer("ACME");
            Location location = new Location("Desert");
            PositionType jobtype = new PositionType("Quality Control");
            CoreCompetency jobCoreCompetency = new CoreCompetency("Persistance");
            Job jorb1 = new Job("Product tester", employer, location, jobtype, jobCoreCompetency);
            Assert.IsTrue(jorb1.Name == "Product tester");
            Assert.AreEqual(jorb1.EmployerName, employer);
            Assert.AreEqual(jorb1.EmployerLocation, location);
            Assert.AreEqual(jorb1.JobType, jobtype);
            Assert.AreEqual(jorb1.JobCoreCompetency, jobCoreCompetency);
        }

        [TestMethod]
        public void TestJobsForEquality()
        {
            Employer employer = new Employer("ACME");
            Location location = new Location("Desert");
            PositionType jobtype = new PositionType("Quality Control");
            CoreCompetency jobCoreCompetency = new CoreCompetency("Persistance");
            Job jorb1 = new Job("Product tester", employer, location, jobtype, jobCoreCompetency);
            Job jorb2 = new Job("Product tester", employer, location, jobtype, jobCoreCompetency);

            Assert.IsTrue(jorb1.Equals(jorb2) == false);
        }

        [TestMethod]
        public void TestToStringForSpaces()
        {
            Job jorb1 = new Job();
            string jobstring = jorb1.ToString();
            Assert.IsTrue(jobstring.StartsWith("\n"));
            Assert.IsTrue(jobstring.EndsWith("\n"));

        }

        [TestMethod]
        public void TestToStringForInfo()
        {
            Employer employer = new Employer("ACME");
            Location location = new Location("Desert");
            PositionType jobtype = new PositionType("Quality Control");
            CoreCompetency jobCoreCompetency = new CoreCompetency("Persistance");
            Job jorb1 = new Job("Product tester", employer, location, jobtype, jobCoreCompetency);

            string expectedJorb = "\n" +
                "ID: " + jorb1.Id + "\n" +
                "Name: " + jorb1.Name + "\n" +
                "Employer: " + jorb1.EmployerName + "\n" +
                "Location: " + jorb1.EmployerLocation + "\n" +
                "Position Type: " + jorb1.JobType + "\n" +
                "Core Competency: " + jorb1.JobCoreCompetency + "\n";


            Assert.AreEqual(expectedJorb, jorb1.ToString());

        }

        [TestMethod]
        public void TestToStringForEmptyFieldMessage()
        {
            Employer employer = new Employer("");
            Location location = new Location("Desert");
            PositionType jobtype = new PositionType("Quality Control");
            CoreCompetency jobCoreCompetency = new CoreCompetency("Persistance");
            Job jorb1 = new Job("Product tester", employer, location, jobtype, jobCoreCompetency);

            string expectedJorb = "\n" +
                "ID: " + jorb1.Id + "\n" +
                "Name: " + jorb1.Name + "\n" +
                "Employer: " + "Data not available" + "\n" +
                "Location: " + jorb1.EmployerLocation + "\n" +
                "Position Type: " + jorb1.JobType + "\n" +
                "Core Competency: " + jorb1.JobCoreCompetency + "\n";

            Assert.AreEqual(expectedJorb, jorb1.ToString());

        }

    }
}
