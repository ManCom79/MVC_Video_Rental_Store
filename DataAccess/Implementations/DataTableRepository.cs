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
            throw new NotImplementedException();
        }

        public void Delete(T entity)
        {
            throw new NotImplementedException();
        }

        public void DeleteById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<T> GetAll()
        {
            throw new NotImplementedException();
        }

        public T GetById(int Id)
        {
            throw new NotImplementedException();
        }

        public List<T> ReadRecords()
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
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
