using Dapper;
using Modelo.Hero;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistencia.DAO
{
    public static class HeroDM
    {
        //Trae el ConnexionString desde el archivo de configuración: Web.config
        private static string Cadena_ = ConfigurationManager.AppSettings["ConexionString"];
        



        public static IEnumerable<Hero> getHeroes()
        {
            try
            {
                //SQL SERVER
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    var consulta = @"SELECT *
                    FROM [heroes]";

                    // Se ejecuta la consulta y se mapean los resultados:
                    var heroes = db.Query<Hero>(consulta);
                    
                    
                    return heroes;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
            

        }
        public static Hero getHero(int id)
        {
            Hero hero;
            try
            {
                //SQL SERVER
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    var consulta = @"SELECT *
                    FROM [heroes] WHERE id="+id;

                    // Se ejecuta la consulta y se mapean los resultados:
                    
                    var listHero = (List<Hero>)db.Query<Hero>(consulta);
                    hero = listHero.FirstOrDefault();

                    return hero;
                }

            }
            catch (Exception ex)
            {
                return null;
            }

        }
        public static Boolean addHero(Hero hero)
        {
            try
            {
                
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    var consulta = @"INSERT INTO 
                    [heroes] (name) VALUES ('"+hero.name+"') ";
                    // Se ejecuta la consulta y se mapean los resultados:
                    var resultado = db.ExecuteScalar<int>(consulta);
                    return true;
                }
            }
            catch (Exception ex) {
                return false;
            }
        }
        public static Boolean updateHero(Hero hero)
        {
            try
            {
                //SQL SERVER
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    var consulta = @"UPDATE 
                    [heroes] SET name = '" + hero.name + "' WHERE id='" + hero.id +"'";
                    // Se ejecuta la consulta.
                    var resultado = db.ExecuteScalar<int>(consulta);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
        public static Boolean deleteHero(Hero hero)
        {
            try
            {
                //SQL SERVER
                using (IDbConnection db = new SqlConnection(Cadena_))
                {
                    var consulta = @"DELETE 
                    [heroes] WHERE id='" + hero.id + "'";
                    // Se ejecuta la consulta.
                    var resultado = db.ExecuteScalar<int>(consulta);
                    return true;
                }
            }
            catch (Exception ex)
            {
                return false;
            }
        }
    }
}
