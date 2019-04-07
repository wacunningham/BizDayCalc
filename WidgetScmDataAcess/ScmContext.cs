using System;
using System.Collections.Generic;
using System.Text;
using System.Data.Common;
using Microsoft.Data.Sqlite;

namespace WidgetScmDataAcess
{
   public class ScmContext
    {
        //private DbConnection connection;

        public IEnumerable<PartType> Parts { get; private set; }

        private SqliteConnection connection;

        public ScmContext(SqliteConnection conn)
        {
            connection = conn;
            ReadParts();
        }

        private void ReadParts()
        {
            using (var command = connection.CreateCommand())
            {   
                command.CommandText = @"SELECT Id, Name FROM PartType";
                using (var reader = command.ExecuteReader())
                {
                    var parts = new List<PartType>();
                    Parts = parts;
                    
                    while (reader.Read())
                    {                          
                            parts.Add(new PartType()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            });
                            
                        
                       
                    }
                    
                }
            }       

        }
    }
}
