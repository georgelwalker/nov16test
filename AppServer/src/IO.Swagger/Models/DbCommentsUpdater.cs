using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

using Npgsql;
using Npgsql.EntityFrameworkCore.PostgreSQL;
using System.Reflection;
using Microsoft.EntityFrameworkCore.Storage;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

/// <summary>
/// 
/// </summary>
namespace IO.Swagger.Models
{
    public class DbCommentsUpdater<TContext>
        where TContext : DbTestContext
    {
        public DbCommentsUpdater(TContext context)
        {
            this.context = context;
        }

        Type contextType;
        TContext context;
        IDbContextTransaction transaction;
        
        public void UpdateDatabaseDescriptions()
        {
            contextType = typeof(TContext);
            this.context = context;
            var props = contextType.GetProperties(System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.Public);
            DbConnection con = context.Database.GetDbConnection();
            try
            {
                con.Open();
                transaction = context.Database.BeginTransaction();
                foreach (var prop in props)
                {
                    if (prop.PropertyType.InheritsOrImplements((typeof(DbSet<>))))
                    {
                        var tableType = prop.PropertyType.GetGenericArguments()[0];
                        SetTableDescriptions(tableType);
                    }
                }
                transaction.Commit();                
            }
            catch
            {
                if (transaction != null)
                    transaction.Rollback();
                throw;
            }
            finally
            {
                
                if (con.State == System.Data.ConnectionState.Open)
                {
                    con.Close();
                }
                
            }
        }

        private void SetTableDescriptions(Type tableType)
        {
            string fullTableName = context.Model.FindEntityType(tableType).Relational().TableName;  // context.GetTableName(tableType);
            Regex regex = new Regex(@"(\[\w+\]\.)?\[(?<table>.*)\]");
            Match match = regex.Match(fullTableName);
            string tableName;
            if (match.Success)
                tableName = match.Groups["table"].Value;
            else
                tableName = fullTableName;

            var tableAttrs = tableType.GetTypeInfo().GetCustomAttributes(typeof(TableAttribute), false);
            var tableAttrsArray = tableAttrs.ToArray<Attribute>();
            if (tableAttrsArray.Length > 0)
            {
                tableName = ((TableAttribute)tableAttrsArray[0]).Name;
            }
                
            foreach (var prop in tableType.GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance))
            {
                if (prop.PropertyType.GetTypeInfo().IsClass && prop.PropertyType != typeof(string))
                    continue;
                var attrs = prop.GetCustomAttributes(typeof(MetaDataExtension), false);
                var attrsArray = attrs.ToArray<Attribute>();
                if (attrsArray.Length > 0)
                    SetColumnDescription(tableName, prop.Name, ((MetaDataExtension)attrsArray[0]).Description);
            }
        }

        private void SetColumnDescription(string tableName, string columnName, string description)
        {
            // Postgres has the COMMENT command to update a description.
            string query = "COMMENT ON COLUMN \"" + tableName + "\".\"" + columnName + "\" IS {0}";

            //context.Database.ExecuteSqlCommand(query, parameters: description);            
            query = "COMMENT ON COLUMN \"" + tableName + "\".\"" + columnName + "\" IS '" + description.Replace("'","\'") + "'";
            context.Database.ExecuteSqlCommand(query);
        }


    }
    public static class ReflectionUtil
    {

        public static bool InheritsOrImplements(this Type child, Type parent)
        {
            parent = ResolveGenericTypeDefinition(parent);

            var currentChild = child.GetTypeInfo().IsGenericType
                                    ? child.GetGenericTypeDefinition()
                                    : child;

            while (currentChild != typeof(object))
            {
                if (parent == currentChild || HasAnyInterfaces(parent, currentChild))
                    return true;

                currentChild = currentChild.GetTypeInfo().BaseType != null
                                && currentChild.GetTypeInfo().BaseType.GetTypeInfo().IsGenericType
                                    ? currentChild.GetTypeInfo().BaseType.GetGenericTypeDefinition()
                                    : currentChild.GetTypeInfo().BaseType;

                if (currentChild == null)
                    return false;
            }
            return false;
        }

        private static bool HasAnyInterfaces(Type parent, Type child)
        {
            return child.GetInterfaces()
                .Any(childInterface =>
                {
                    var currentInterface = childInterface.GetTypeInfo().IsGenericType
                        ? childInterface.GetGenericTypeDefinition()
                        : childInterface;

                    return currentInterface == parent;
                });
        }

        private static Type ResolveGenericTypeDefinition(Type parent)
        {
            var shouldUseGenericType = true;
            if (parent.GetTypeInfo().IsGenericType && parent.GetGenericTypeDefinition() != parent)
                shouldUseGenericType = false;

            if (parent.GetTypeInfo().IsGenericType && shouldUseGenericType)
                parent = parent.GetGenericTypeDefinition();
            return parent;
        }
    }

    /*
    public static class ContextExtensions
    {
        public static string GetTableName(this DbContext context, Type tableType)
        {
            string table = context.Model.FindEntityType(tableType).Relational().TableName;
            
            return table;
        }
        // this is probably not required

    */
        /*
        public static string GetTableName<T>(this DbContext context) where T : class
        {

            ObjectContext objectContext = ((IObjectContextAdapter)context).ObjectContext;

            return objectContext.GetTableName<T>();
        }

        public static string GetTableName<T>(this ObjectContext context) where T : class
        {
            string sql = context.CreateObjectSet<T>().ToTraceString();
            Regex regex = new Regex("FROM (?<table>.*) AS");
            Match match = regex.Match(sql);

            string table = match.Groups["table"].Value;
            return table;
        }
        */
    //}
}
