using System;
using System.Collections.Generic;
using System.Text;

namespace OTB.InterviewChallenge
{
    public class Job
    {
        private string _name;
        private string _dependency;


        public string Name
        {
            get { return _name; }
            set { _name = value; }
        }
        public string Dependency
        {
            get { return _dependency; }
            set { _dependency = value; }
        }

        public Job(string name, string dependency)
        {
            const string _PROC_NAME = "Job";

            try
            {
                _dependency = dependency;
                _name = name;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in '{_PROC_NAME}': {ex.Message}");
                throw ex;
            }
            finally
            {

            }
        }


    }
}
