using Microsoft.VisualBasic;
using System.Data.SqlClient;

public static class Database
{

    public static SqlConnection Connetti()
    {
        string stringaDiConnessione = "Data Source=localhost;Initial Catalog=db-biblioteca;Integrated Security=True";

        SqlConnection connessione = new SqlConnection(stringaDiConnessione);

        try
        {
            connessione.Open();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }
        return connessione;
    }

    public static void Disconnetti(SqlConnection connessione)
    {
        connessione.Close();
    }

    public static void AggiungiDocumento(string codice, string titolo, DateTime anno, string settore, int stato, string scaffale, string autore, SqlConnection connessione)
    {
        string query = "INSERT INTO documenti (codice, titolo, anno, settore, stato, scaffale, autore) VALUES (@codice, @titolo, @anno, @settore, @stato, @scaffale, @autore)";

        SqlCommand cmd = new SqlCommand(query, connessione);
        cmd.Parameters.Add(new SqlParameter("@codice", codice));
        cmd.Parameters.Add(new SqlParameter("@titolo", titolo));
        cmd.Parameters.Add(new SqlParameter("@anno", anno));
        cmd.Parameters.Add(new SqlParameter("@settore", settore));
        cmd.Parameters.Add(new SqlParameter("@stato", stato));
        cmd.Parameters.Add(new SqlParameter("@scaffale", scaffale));
        cmd.Parameters.Add(new SqlParameter("@autore", autore));

        int righeAggiungte = cmd.ExecuteNonQuery();

    }

    public static int RicercaDocumento(string codice, SqlConnection connessione)
    {
        string query = "SELECT Id FROM documenti WHERE codice=@Codice";

        SqlCommand cmd = new SqlCommand(query, connessione);
        cmd.Parameters.Add(new SqlParameter("@Codice", codice));

        int id = 0;
        using (SqlDataReader reader = cmd.ExecuteReader())
        {
            while (reader.Read())
            {
                id = reader.GetInt32(0);
            }
        }
        return id;
    }

    public static void ModificaDocumento( string codice, SqlConnection connessione, string codice2, string titolo, DateTime anno, string settore, int stato, string scaffale, string autore)
    {
        int id = RicercaDocumento(codice, connessione);

        string query = "UPDATE documenti SET codice=@Codice, titolo=@Titolo, anno=@Anno, settore=@Settore, stato=@Stato, scaffale=@Scaffale, autore=@Autore  WHERE id = " + id;
        SqlCommand cmd = new SqlCommand(query, connessione);
        cmd.Parameters.Add(new SqlParameter("@Codice", codice2));
        cmd.Parameters.Add(new SqlParameter("@Titolo", titolo));
        cmd.Parameters.Add(new SqlParameter("@Anno", anno));
        cmd.Parameters.Add(new SqlParameter("@Settore", settore));
        cmd.Parameters.Add(new SqlParameter("@Stato", stato));
        cmd.Parameters.Add(new SqlParameter("@Scaffale", scaffale));
        cmd.Parameters.Add(new SqlParameter("@Autore", autore));

        int righeModificate = cmd.ExecuteNonQuery();

    }

    public static void EliminaDocumento(string codice, SqlConnection connessione)
    {
        int id = RicercaDocumento(codice, connessione);

        string query = "DELETE FROM documenti WHERE id=@Id ";
        SqlCommand cmd = new SqlCommand(query, connessione);
        cmd.Parameters.Add(new SqlParameter("@id", id));

        int righeEliminate = cmd.ExecuteNonQuery();
    }


    public static void AggiungiPrestito(string nome, string cognome, DateTime data_inizio, DateTime data_fine, string tipo, int documento_id , SqlConnection connessione)
    {
        string query = "INSERT INTO prestiti (nome, cognome, data_inizio, data_fine, tipo, documento_id) VALUES (@nome, @cognome, @data_inizio, @data_fine, @tipo, @documento_id)";

        SqlCommand cmd = new SqlCommand(query, connessione);
        cmd.Parameters.Add(new SqlParameter("@nome", nome));
        cmd.Parameters.Add(new SqlParameter("@cognome", cognome));
        cmd.Parameters.Add(new SqlParameter("@data_inizio", data_inizio));
        cmd.Parameters.Add(new SqlParameter("@data_fine", data_fine));
        cmd.Parameters.Add(new SqlParameter("@tipo", tipo));
        cmd.Parameters.Add(new SqlParameter("@documento_id", documento_id));

        int righeAggiungte = cmd.ExecuteNonQuery();
    }


}