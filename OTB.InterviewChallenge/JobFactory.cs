using System;
using System.Collections.Generic;
using System.Text;

namespace OTB.InterviewChallenge
{ 

    public class JobFactory
    {
        private List<Job> _jobs;
        private const string _SPLIT_CHARS = "=>";

        public JobFactory(string[] jobs)
        {
            const string _PROC_NAME = "JobFactory";

            try
            {
                _jobs = new List<Job>();
                ValidateInput(jobs);
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
        private void ValidateInput(string[] jobs)
        {
            const string _PROC_NAME = "ValidateInput";

            try
            {
                if ((jobs.Length == 0) || (jobs == null))
                    throw new Exception("Input string arguments can not be empty");

                foreach (var job in jobs)
                {
                    string[] splitValues = job.Split(_SPLIT_CHARS);

                    if (job.ToLower().Contains(_SPLIT_CHARS) && splitValues.Length == 2)
                    {
                        if (splitValues[0] == splitValues[1])
                        {
                            throw new Exception("jobs can’t depend on themselves");
                        }
                        else
                        {
                            _jobs.Add(new Job(splitValues[0], splitValues[1]));
                        }
                    }
                    else
                    {
                        throw new Exception("Input is not in the correct format. Split chars => must exist with a mandatory value on the left of => and an optional value on the right. e.g. a=>b or a=>");
                    }
                }
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

        public string GetSortedJobs()
        {
            const string _PROC_NAME = "GetSortedJobs";

            try
            {
                string sortedJobs = "";

                sortedJobs = "abcxx";

                return sortedJobs;
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
