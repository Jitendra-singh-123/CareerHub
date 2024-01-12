using CarrerHubSytem.UtilClass;
using CarrerHubSytem.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarrerHubSytem
{
    class Program
    {
        static void Main(string[] args)
        {

            DatabaseManager db = new DatabaseManager();
            int choice;
            try
            {
                do
                {

                    Console.WriteLine("1.Apply for the job");
                    Console.WriteLine("2. Create Profile");
                    Console.WriteLine("3. Post Job");
                    Console.WriteLine("4. Get Job");
                    Console.WriteLine("5. Insert Job Application ");
                    Console.WriteLine("6. Get Applicants ");
                    Console.WriteLine("7.  press 0 for exit");
                    Console.WriteLine("Enter your choice ");
                    choice = int.Parse(Console.ReadLine());
                    Company c = new Company();
                    Applicant applicant = new Applicant();
                    JobListing job = new JobListing();
                    switch (choice)
                    {

                        case 1:
                            Console.WriteLine("Enter Job Id");
                            int jobid = int.Parse(Console.ReadLine());
                            Console.WriteLine("Enter Cover Letter");
                            string s = Console.ReadLine();
                            applicant.ApplyForJob(db, jobid, s);
                            break;

                        case 2:
                            Console.WriteLine("Enter Applicant id,email,first name,last name and phone number");
                            int applicantid = int.Parse(Console.ReadLine());
                            string em = Console.ReadLine();
                            string fn = Console.ReadLine();
                            string ln = Console.ReadLine();
                            string pn = Console.ReadLine();
                            applicant.CreateProfile(db, applicantid, em, fn, ln, pn);
                            break;

                        case 3:
                            Console.WriteLine("Enter jobid,title, descirption, job Location, salary and job type");
                            int jobID = int.Parse(Console.ReadLine());
                            string title = Console.ReadLine();
                            string desc = Console.ReadLine();
                            string loc = Console.ReadLine();
                            decimal salary = decimal.Parse(Console.ReadLine());
                            string type = Console.ReadLine();

                            c.PostJob(db, jobID, title, desc, loc, salary, type);
                            break;

                        case 4:
                            List<JobListing> jobListings = new List<JobListing>();
                            jobListings = c.GetJobs(db);
                            foreach (JobListing j in jobListings)
                            {
                                Console.WriteLine($"\nJobID : {j.JobID}\nCompanyID : {j.CompanyID}\nJob title : {j.JobTitle}\nDescription: {j.JobDescription}\nLocation: {j.JobLocation}\nSalary: {j.Salary}\nJob Type: {j.JobType}");
                            }
                            break;

                        case 5:
                            Console.WriteLine("Enter applicant id and cover letter");
                            int appid = int.Parse(Console.ReadLine());
                            string coverletter = Console.ReadLine();
                            job.Apply(db, appid, coverletter);
                            break;
                        case 6:
                            List<Applicant> applicants = new List<Applicant>();
                            applicants = job.GetApplicants(db);
                            foreach (Applicant ap in applicants)
                            {
                                Console.WriteLine($"\nApplicantId : {ap.ApplicantID}\nFirst Name: {ap.FirstName}\nLast Name: {ap.LastName}\nEmail: {ap.Email}\nResume: {ap.Resume}\nPhone Number: {ap.Phone}");
                            }
                            break;

                        case 0: Console.Write("Exiting the program");
                            break;
                        default:
                            Console.WriteLine("Invalid Option");
                            break;

                    }
                } while (choice != 0);
            }
            catch(Exception e)
            {
                Console.Write(e.Message);
            }
 
        }
    }
}
