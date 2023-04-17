using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ExerciseTracker2
{
    public class WgtDatabase
    {
        private readonly SQLiteAsyncConnection _wgtDatabase;

        public WgtDatabase(string dbPath)
        {
            _wgtDatabase = new SQLiteAsyncConnection(dbPath);
            _wgtDatabase.CreateTableAsync<Weight>().Wait();
        }

        public Task<List<Weight>> GetWeightAsync()
        {
            return _wgtDatabase.Table<Weight>().ToListAsync();
        }

        public Task<List<Weight>> GetAllWeightDateOrderedAsync()
        {
            return _wgtDatabase.QueryAsync<Weight>("SELECT * FROM Weight ORDER BY DateWeight DESC");
            //SELECT * FROM Weight ORDER BY DateWeight DESC
            //date(DateWeight), UserWeight
        }

        public Task<List<Weight>> GetAllWeightDateOrderedChartAsync()
        {
            return _wgtDatabase.QueryAsync<Weight>("SELECT * FROM Weight ORDER BY DateWeight");
        }

        public Task<int> SaveWeightAsync(Weight weight)
        {
            return _wgtDatabase.InsertAsync(weight);
        }

        public Task<int> UpdateWeightAsync(Weight weight)
        {
            return _wgtDatabase.UpdateAsync(weight);
        }

        public Task<int> DeleteWeightAsync(Weight weight)
        {
            return _wgtDatabase.DeleteAsync(weight);
        }
    }
}
