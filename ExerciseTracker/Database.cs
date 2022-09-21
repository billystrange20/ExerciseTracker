using System;
using SQLite;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker
{
    public class Database
    {
        private readonly SQLiteAsyncConnection _database;

        public Database(string dbPath)
        {
            _database = new SQLiteAsyncConnection(dbPath);
            _database.CreateTableAsync<Exercise>();
        }

        public Task<List<Exercise>> GetExerciseAsync()
        {
            return _database.Table<Exercise>().ToListAsync(); 
        }

        public Task<List<Exercise>> GetAllExerciseTypeAsync(string type)
        {
            return _database.QueryAsync<Exercise>("SELECT * FROM Exercise WHERE ExType = '" + type + "'");
        }

        public Task<int> SaveExerciseAsync(Exercise exercise)
        {
            return _database.InsertAsync(exercise);
        }

        public Task<int> UpdateExerciseAsync(Exercise exercise)
        {
            return _database.UpdateAsync(exercise);
        }

        public Task<int> DeleteExerciseAsync(Exercise exercise)
        {
            return _database.DeleteAsync(exercise);
        }
    }
}
