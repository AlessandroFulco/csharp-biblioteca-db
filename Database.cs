using System.Data.SqlClient;

public static class Database
{

    public static void Connetti(SqlConnection connessione)
    {

        try
        {
            connessione.Open();
        }
        catch(Exception e)
        {
            Console.WriteLine(e.Message);
        }

    }

    public static void Disconnetti(SqlConnection connessione)
    {
        connessione.Close();
    }

    public static void AggiungiDocumento(string codice, string titolo, DateTime anno, string settore, bool stato, string scaffale, string autore, SqlConnection connessione)
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

    public static void AggiungiPrestito(string nome, string cognome, DateOnly data_inizio, DateOnly data_fine, string tipo)
    {

    }


}