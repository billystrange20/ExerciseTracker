using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker2
{
    public class ExDatabase
    {
        private readonly SQLiteAsyncConnection _exDatabase;

        public ExDatabase(string dbPath)
        {
            _exDatabase = new SQLiteAsyncConnection(dbPath);
            _exDatabase.CreateTableAsync<Exercise>().Wait();
        }

        public Task<List<Exercise>> GetExerciseAsync()
        {
            return _exDatabase.Table<Exercise>().ToListAsync(); 
        }

        public Task<List<Exercise>> GetAllExerciseTypeAsync(string type)
        {
            return _exDatabase.QueryAsync<Exercise>("SELECT * FROM Exercise WHERE ExType = '" + type + "'");
        }

        public Task<int> SaveExerciseAsync(Exercise exercise)
        {
            return _exDatabase.InsertAsync(exercise);
        }

        public Task<int> UpdateExerciseAsync(Exercise exercise)
        {
            return _exDatabase.UpdateAsync(exercise);
        }

        public Task<int> DeleteExerciseAsync(Exercise exercise)
        {
            return _exDatabase.DeleteAsync(exercise);
        }
    }
}
