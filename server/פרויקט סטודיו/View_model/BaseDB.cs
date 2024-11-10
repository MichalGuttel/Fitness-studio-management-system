using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using model;
using ViewModel;


namespace View_model
{
   public  abstract class BaseDB
    {
       
     
        protected string connectionString;
        protected OleDbConnection connection;
        protected OleDbCommand command;
        protected OleDbDataReader reader;

        protected List<BaseEntity> list;

        protected List<BaseEntity> inserted = new List<BaseEntity>();
        protected List<BaseEntity> changed = new List<BaseEntity>();
        protected List<BaseEntity> deleted = new List<BaseEntity>();

        public BaseDB(string tableName)
        {
            connection = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + GetCurrentPath() + "data\\schedul_accec.accdb");
            command = new OleDbCommand();
            command.Connection = connection;
            command.CommandText = "select * from " + tableName;
            list = new List<BaseEntity>();
        }
        public string GetCurrentPath()
        {
            string path = System.IO.Directory.GetCurrentDirectory();
            string[] arr = path.Split('\\');
            path = "";
            for (int i = 0; i < arr.Length - 3; i++)
            {
                path += arr[i] + "\\";
            }
            return path;
        }
        protected abstract BaseEntity CreateModel();
        protected void Select()
        {
            List<BaseEntity> lst = new List<BaseEntity>();
            try
            {
                //פותחות את הקישור
                connection.Open();
                //יוצרות אוביקט שלתוכו נכנסים הנתונים מהמסד
                reader = command.ExecuteReader();
                //עוברות על מה שהגיע
                while (reader.Read())
                {
                    list.Add(CreateModel());
                }
            }
            catch (Exception ex)
            {
                //Console.WriteLine(ex);
            }
            finally
            {
                //סגירת החיבור כדי לשחרר משאבים מהזיכרון
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
        }
        public void Add(BaseEntity item)
        {
            if (item != null)
            {
                list.Add(item);
                inserted.Add(item);
            }
        }
        public void Update(BaseEntity item)
        {
            if (item != null)
                changed.Add(item);
        }
        public void Deleted(BaseEntity item)
        {
            if (item != null)
                deleted.Add(item);
        }
        public int SaveChanges()
        {
            int records = 0;
            try
            {
                command.Connection = connection;
                connection.Open();
                foreach (var item in inserted)
                {
                    try
                    {
                        command.CommandText = SQLBuilder.InsertSQL(item);
                        records += command.ExecuteNonQuery();
                    }
                    catch
                    {
                        //inserted.Remove(item);
                    }
                }
                inserted.Clear();
                foreach (var item in changed)
                {
                    try
                    {
                        command.CommandText = SQLBuilder.UpdateSQL(item);
                        records += command.ExecuteNonQuery();
                    }
                    catch
                    {
                        //changed.Remove(item);
                    }
                }
                changed.Clear();
                foreach (var item in deleted)
                {
                    try
                    {
                        command.CommandText = SQLBuilder.DeleteSQL(item);
                        records += command.ExecuteNonQuery();
                        list.Remove(item);
                    }
                    finally { }
                }
                deleted.Clear();
            }

            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message + "\nDataBase:" + command.CommandText);
            }
            finally
            {
                if (connection.State == System.Data.ConnectionState.Open)
                    connection.Close();
            }
            return records;
        }
        protected abstract string CreateInsertCommand(BaseEntity item);
        protected abstract string CreateUpdateCommand(BaseEntity item);
        protected abstract string CreatedeletedCommand(BaseEntity item);
    }
}
    



