using DataAccess.Interfaces;
using DomainModels;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO.Pipes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Implementations
{
    public class DataTableRepository<T> : IDataTableRepository<T> where T : Base
    {
        protected VideoRentalDbContext _dbContext;
        public DataTableRepository(VideoRentalDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(T entity)
        {
            _dbContext.Add(entity);
            _dbContext.SaveChanges();
            //Uncomment to use local files as DB
            //var records = ReadRecords();

            //var newId = 1;

            //if (records.Count > 0)
            //{
            //    newId = records.Max(x => x.Id) + 1;
            //}

            //entity.Id = newId;
            //records.Add(entity);

            //WriteRecords(records);
        }

        public void Delete(T entity)
        {
            _dbContext.Remove(entity);
            _dbContext.SaveChanges();
            //Uncomment to use local files as DB
            //var records = ReadRecords();
            //         records.Remove(entity);

            //WriteRecords(records);
        }

        public void DeleteById(int id)
        {
            var record = GetById(id);
            Delete(record);
            //Uncomment to use local files as DB
            //         var records = ReadRecords();
            //         var record = records.FirstOrDefault(x => x.Id == id);

            //         records.Remove(record);

            //WriteRecords(records);
        }

        public List<T> GetAll()
        {
            return _dbContext.Set<T>().AsNoTracking().ToList();
            //Uncomment to use local files as DB
            //return ReadRecords();
        }

        public T GetById(int id)
        {
            var record = _dbContext.Set<T>().AsNoTracking().Where(x => x.Id == id).FirstOrDefault();
            if (record == null)
            {
                throw new Exception($"There is no record with id: {id}");
            }
            return record;
            //Uncomment to use local files as DB
            //var records = ReadRecords();
            //         var record = records.FirstOrDefault(x => x.Id == id);

            //         return record;
        }
        public void Update(T entity)
        {
            _dbContext.Update(entity);
            _dbContext.SaveChanges();
            //Uncomment to use local files as DB
            //var records = ReadRecords();
            //var record = records.FirstOrDefault(x => x.Id == entity.Id);

            //var IndexOfRecord = records.IndexOf(record);

            //records[IndexOfRecord] = entity;

            //WriteRecords(records);
        }
        public List<T> ReadRecords()
        {
			var folderPath = @"Database";
			var filepath = @$"{folderPath}/{typeof(T).Name}s.json";
			var result = new List<T>();

			if (!Directory.Exists(folderPath))
			{
				return result;
			}

			if (!File.Exists(filepath))
			{
				return result;
			}

			try
			{
				using (var stremReader = new StreamReader(filepath))
				{
					string content = stremReader.ReadToEnd();
					JsonSerializerSettings settings = new JsonSerializerSettings { TypeNameHandling = TypeNameHandling.All };
					result = JsonConvert.DeserializeObject<List<T>>(content, settings) ?? new List<T>();
				}
			}
			catch (Exception ex)
			{
				return result;
			}
			return result;
		}



        public void WriteRecords(List<T> record)
        {
            var folderPath = @"Database";
            var filepath = @$"{folderPath}/{typeof(T).Name}s.json";

            if(!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            if(!File.Exists(filepath)) { 
                File.Create(filepath).Close();
            }

            
            string json = JsonConvert.SerializeObject(record);

            using(StreamWriter sw = new StreamWriter(filepath))
            {
                sw.WriteLine(json);
            }
        }
    }
}
