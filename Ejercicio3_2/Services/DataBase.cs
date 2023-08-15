using Ejercicio3_2.Models;
using SQLite;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace Ejercicio3_2.Services
{
    public class DataBase : IDisposable
    {
        readonly SQLiteAsyncConnection con;
        private string dbFullPath { get; set;}
        private string dbPath { get; set; }
        private string dbName { get; set; }

        public DataBase() {
            /*dbName = "tarea.db3";
            dbPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
            dbFullPath = Path.Combine(dbPath, dbName);
            con = new SQLiteAsyncConnection(dbFullPath);
            con.CreateTableAsync<Alumnos>().Wait();*/
        }

        public DataBase(string dbPath){
            con = new SQLiteAsyncConnection(dbPath);
            try
            {
                con.CreateTableAsync<Alumnos>().Wait();
            }
            catch(Exception ex) { Debug.WriteLine(ex.ToString()); }
        }

        public void Dispose()
        {
            con.CloseAsync();
        }

        public Task<int> addStudent(Alumnos alumno){
            if(alumno.Id == 0) return con.InsertAsync(alumno);
            else return con.UpdateAsync(alumno);
        }

        public Task<List<Alumnos>> getAllAlumnos(){
            return con.Table<Alumnos>().ToListAsync();
        }

        public Task<Alumnos> getById(int id){
            return con.Table<Alumnos>().Where(i => i.Id == id).FirstOrDefaultAsync();
        }

        public Task<int> delStudent(Alumnos alumno){
            return con.DeleteAsync(alumno);
        }

        public Task<int> UpdtStudent(Alumnos alumno){
            return con.UpdateAsync(alumno);
        }
    }
}
