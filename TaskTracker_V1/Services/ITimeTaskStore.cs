using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace TaskTracker_V1.Models
{
    public interface ITimeTaskStore
    {
        Task<IEnumerable<TimeTask>> GetTimeTasksAsync();
        Task<TimeTask> GetTimeTask(int id);
        Task AddTimeTask(TimeTask TimeTask);
        Task UpdateTimeTask(TimeTask TimeTask);
        Task DeleteTimeTask(TimeTask TimeTask);
    }

}
