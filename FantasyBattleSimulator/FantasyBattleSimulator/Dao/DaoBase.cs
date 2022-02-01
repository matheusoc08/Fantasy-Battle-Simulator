using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FantasyBattleSimulator
{
    class DaoBase
    {
        SqlConnection conn = new SqlConnection(@"Data Source=localhost\SQLEXPRESS;Initial Catalog=FANTASY_BATTLE;Integrated Security=True;Connect Timeout=30");
        string query = //"select class_id, class_name from characters";
            $"SELECT CHAR_ID, CLASS_ID, CHAR_NAME, CHAR_LEVEL, CHAR_HP, CHAR_MP,CHAR_PHYSICAL_ATTACK, " +
                $"CHAR_MAGIC_ATTACK, CHAR_PHYSICAL_DEFENSE, CHAR_MAGIC_DEFENSE, CHAR_CRITICAL_RATE " +
                $"FROM CHARACTERS ";

        //public DaoBase()
        //{
        //    SqlConnection conn = new SqlConnection(@"Data Source = local\SQLEXPRESS; Initial Catalog = FANTASY_BATTLE; Integrated Security= True; Connect Timeout = 30;");
        //}

        public void Connect()
        {
            try
            {
                conn.Open();
                //Console.WriteLine("Conexão efetiva");

                //var dataAdapter = new SqlDataAdapter(query, conn);
                //var commandBuilder = new SqlCommandBuilder(dataAdapter);

                //var ds = new DataSet();
                //dataAdapter.Fill(ds);

                //Console.WriteLine(ds.Tables[0]);

                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();

                //command.Parameters.AddWithValue("@class_id",1);

                while (reader.Read())
                {

                    //Console.WriteLine("{0}", reader.GetInt32(0));
                    //int columNumber = 0;
                    //string test = (string)reader[columNumber];
                    Console.WriteLine($"{reader.GetValue(0)} {reader.GetValue(2)}");
                }

                conn.Close();
            }
            catch (Exception erro)
            {
                throw new ArgumentException("Conexao não sucedida " + erro);
            }
        }

        public void CharacterInformation(int charId)
        {
            string query = 
                $"SELECT CHAR_NAME, CHAR_HP, CHAR_MP,CHAR_PHYSICAL_ATTACK, " +
                $"CHAR_MAGIC_ATTACK, CHAR_PHYSICAL_DEFENSE, CHAR_MAGIC_DEFENSE, CHAR_CRITICAL_RATE " +
                $"FROM CHARACTERS " +
                $"WHERE CHAR_ID = {charId}";
            try
            {
                conn.Open();
                SqlCommand command = new SqlCommand(query, conn);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    string retorno = $"Nome: {reader.GetValue(0)}" + Environment.NewLine;
                    retorno += $"HP: {reader.GetValue(1)}" + Environment.NewLine;
                    retorno += $"MP: {reader.GetValue(2)}" + Environment.NewLine;
                    retorno += $"Ataque físico: {reader.GetValue(3)}" + Environment.NewLine;
                    retorno += $"Ataque mágico: {reader.GetValue(4)}" + Environment.NewLine;
                    retorno += $"Defesa física: {reader.GetValue(5)}" + Environment.NewLine;
                    retorno += $"Defesa mágica: {reader.GetValue(6)}" + Environment.NewLine;
                    retorno += $"Chance de crítico: {reader.GetValue(7)}%" + Environment.NewLine;

                    Console.WriteLine($"{retorno}");
                }

                conn.Close();
            }
            catch(Exception erro)
            {
                throw new Exception("Erro: " + erro);
            }
        }
    }
}
 