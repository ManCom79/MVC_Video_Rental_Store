using DataAccess.Interfaces;
using DomainModels;
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
        public void Add(T entity)
        {
            var records = ReadRecords();

            var newId = 1;

            if (records.Count > 0)
            {
                newId = records.Max(x => x.Id) + 1;
            }

            entity.Id = newId;
            records.Add(entity);

            WriteRecords(records);

		}

        public void Delete(T entity)
        {
			var records = ReadRecords();
            records.Remove(entity);

			WriteRecords(records);
		}

        public void DeleteById(int id)
        {
            var records = ReadRecords();
            var record = records.FirstOrDefault(x => x.Id == id);

            records.Remove(record);

			WriteRecords(records);
		}

        public List<T> GetAll()
        {
            return ReadRecords();
        }

        public T GetById(int id)
        {
			var records = ReadRecords();
            var record = records.FirstOrDefault(x => x.Id == id);

            return record;
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

        public void Update(T entity)
        {
            var records = ReadRecords();
            var record = records.FirstOrDefault(x => x.Id == entity.Id);
            
            var IndexOfRecord = records.IndexOf(record);

            records[IndexOfRecord] = entity;

            WriteRecords(records);
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
