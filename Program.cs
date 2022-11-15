/*Richiesta:
    Si vuole progettare un sistema per la gestione di una biblioteca dove il bibliotecario può verificare i dati dei clienti registrati

    cognome,
    nome,
    email,
    recapito telefonico,

    Il bibliotecario può effettuare dei prestiti ai suoi clienti registrati, attraverso il sistema, sui documenti che sono di vario tipo (libri, DVD). I documenti sono caratterizzati da:

    un codice identificativo di tipo stringa (ISBN per i libri, numero seriale per i DVD),
    titolo,
    anno,
    settore (storia, matematica, economia, …),
    stato (In Prestito, Disponibile),
    uno scaffale in cui è posizionato,
    un autore (Nome, Cognome).
    Per i libri si ha in aggiunta il numero di pagine, mentre per i dvd la durata.

    Il bibliotecario deve poter eseguire delle ricerche per codice o per titolo e, eventualmente, effettuare dei prestiti registrando il periodo (Dal/Al) del prestito e il documento.
    Deve essere possibile effettuare la ricerca dei prestiti dato nome e cognome di un cliente.
    Mi raccomando, prima di buttarvi sul codice fate qualche schema per capire le entità principali e le loro relazioni / eredità.
    Buon lavoro! (modificato) 
*/


using System.Data.SqlClient;

Biblioteca biblioteca = new Biblioteca();



bool continua = true;
while (continua)
{
    //Benvenuto 
    Console.WriteLine("Benvenuto");
    Console.WriteLine("Scrivi una delle opzionis: ");
    //funzioni possibili: crea prestito, cerca un libro o un dvd
    Console.WriteLine("     1. Cerca un libro");
    Console.WriteLine("     2. Cerca un dvd");
    Console.WriteLine("     3. Crea un prestito per un libro");
    Console.WriteLine("     4. Crea un prestito per un Dvd");
    Console.WriteLine("     5. Lista prestiti");
    Console.WriteLine("     6. Stampa lista documenti");
    Console.WriteLine("     7. Aggiungi un libro al database");
    Console.WriteLine("     8. Modifica un libro al database");
    Console.WriteLine("     9. Aggiungi un prestito al database");

    Console.WriteLine("     19. Esci");

    int inputUtente = Convert.ToInt32(Console.ReadLine());

    switch (inputUtente)
    {
        case 1:
            Console.WriteLine("Quale libro vuoi cercare?");
            string libro = Console.ReadLine().ToLower();
            Console.WriteLine(biblioteca.CercaLibro(libro).ToString());
            libro = null;
            break;

        case 2:
            Console.WriteLine("Quale dvd vuoi cercare?");
            string dvd = Console.ReadLine().ToLower();
            Console.WriteLine(biblioteca.CercaDvd(dvd).ToString());
            break;

        case 3:
            //chiede il nome utente
            Console.WriteLine("inserisci nome utente registrato");
            string libroInputNomeUtente = Console.ReadLine();
            //chiede il cognome utente
            Console.WriteLine("inserisci cognome utente registrato");
            string libroInputCognomeUtente = Console.ReadLine();
            //chiede il libro per creare il prestito
            Console.WriteLine("Quale libro vuoi prendere in prestito?");
            string inputLibro = Console.ReadLine().ToLower();
            bool prestitoLibro = biblioteca.CreaPrestitoLibro(libroInputNomeUtente, libroInputCognomeUtente, inputLibro);
            if (prestitoLibro)
            {
                Console.WriteLine("Prestito avvenuto con successo");
            }
            else
                Console.WriteLine("il libro è gia stato preso in prestito");
            break;

        case 4:
            //chiede il nome utente
            Console.WriteLine("inserisci nome utente registrato");
            string dvdInputNomeUtente = Console.ReadLine();
            //chiede il cognome utente
            Console.WriteLine("inserisci cognome utente registrato");
            string dvdInputCognomeUtente = Console.ReadLine();
            //chiedere il dvd per creare il prestito
            Console.WriteLine("Quale Dvd vuoi prendere in prestito?");
            string inputDvd = Console.ReadLine().ToLower();
            bool prestitoDvd = biblioteca.CreaPrestitoDvd(dvdInputNomeUtente, dvdInputCognomeUtente, inputDvd);
            if (prestitoDvd)
                Console.WriteLine("Prestito avvenuto con successo");
            else
                Console.WriteLine("il Dvd è gia stato preso in prestito");
            break;

        case 5:
            Console.WriteLine("Ecco la lista dei prestiti attivi");
            biblioteca.StampaPrestiti();
            break;

        case 6:
            Console.WriteLine("sezione Lista documenti");
            Console.WriteLine(biblioteca.ListaDocumenti());
            break;

        case 7:
            Console.WriteLine("Sezione: aggiungi un libro al database");
            SqlConnection connessione = Database.Connetti();

            CreaLibroDb(connessione);

            //Database.AggiungiDocumento()

            Database.Disconnetti(connessione);

            break;

        case 8:
            //modifica del documento
            Console.WriteLine("Sezione: Modifica un libro");

            SqlConnection connessione3 = Database.Connetti();
            Console.Write("Inserisci il codice del libro da modificare: ");
            string codice2 = Console.ReadLine();

            Console.Write("Inserisci il codice: ");
            string codice = Console.ReadLine();

            Console.Write("Inserisci il titolo del documento: ");
            string titolo = Console.ReadLine();

            Console.Write("Inserisci la data di pubblicazione: ");
            DateTime data = DateTime.Parse(Console.ReadLine());

            Console.Write("Inserisci il settore: ");
            string settore = Console.ReadLine();

            Console.Write("Inserisci [si/no] se è in prestito: ");
            string statoStringa = Console.ReadLine();
            int stato = 0;
            if (statoStringa.ToLower() == "si")
                stato = 1;

            Console.Write("Inserisci lo scaffale: ");
            string scaffale = Console.ReadLine();

            Console.Write("Inserisci l'autore del libro: ");
            string autore = Console.ReadLine();

            Database.ModificaDocumento(codice2, connessione3, codice, titolo, data, settore, stato, scaffale, autore);


            Database.Disconnetti(connessione3);

            break;

        case 9:
            Console.WriteLine("Sezione: aggiungi un prestito al database");
            SqlConnection connessione2 = Database.Connetti();

            Console.Write("Inserisci il codice del libro da prendere in prestito: ");
            string codice4 = Console.ReadLine();

            int idDocumento = Database.RicercaDocumento(codice4, connessione2);

            Console.Write("Inserisci il nome dell'intesatario del prestito: ");
            string nome = Console.ReadLine();
            
            Console.Write("Inserisci il cognome dell'intesatario del prestito: ");
            string congome = Console.ReadLine();

            Console.Write("Inserisci la data di inizio prestito: ");
            DateTime data_inizio = DateTime.Parse(Console.ReadLine());
            
            Console.Write("Inserisci la data di fine prestito: ");
            DateTime data_fine = DateTime.Parse(Console.ReadLine());
            
            Console.Write("Inserisci il tipo del documento: ");
            string tipo = Console.ReadLine();


            Database.AggiungiPrestito(nome, congome, data_inizio, data_fine, tipo, idDocumento, connessione2);

            Database.Disconnetti(connessione2);

            break;

        case 10:
            continua = false;
            break;

        default:
            Console.WriteLine("opzione non disponibile");
            break;
    }
}


void CreaLibroDb(SqlConnection connessione)
{
    Console.Write("Inserisci il codice: ");
    string codice = Console.ReadLine();

    Console.Write("Inserisci il titolo del documento: ");
    string titolo = Console.ReadLine();

    Console.Write("Inserisci la data di pubblicazione: ");
    DateTime data = DateTime.Parse(Console.ReadLine());

    Console.Write("Inserisci il settore: ");
    string settore = Console.ReadLine();

    Console.Write("Inserisci [si/no] se è in prestito: ");
    string statoStringa = Console.ReadLine();
    int stato = 0;
    if (statoStringa.ToLower() == "si")
        stato = 1;

    Console.Write("Inserisci lo scaffale: ");
    string scaffale = Console.ReadLine();

    Console.Write("Inserisci l'autore del libro: ");
    string autore = Console.ReadLine();

    Database.AggiungiDocumento(codice, titolo, data, settore, stato, scaffale, autore, connessione);

}




//string stringaDiConnessione = "Data Source=localhost;Initial Catalog=db-biblioteca;Integrated Security=True";


//SqlConnection connessione = new SqlConnection(stringaDiConnessione);

//connessione.Open();

////Database.AggiungiDocumento("3412", "prova", new DateTime(2022, 05, 06), "2A", true, "matematica", "alessandro", connessione);

////Database.AggiungiPrestito("alessandro", "Fulco", new DateTime(2022, 11, 11), new DateTime(2023, 11, 11), "libro", 1, connessione);

////Console.WriteLine(Database.RicercaDocumento("12345", connessione));




//connessione.Close();